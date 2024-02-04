using System.Data.Entity;

using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.Features.Receipts;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;
using AugustaGourmet.Api.Persistence.Context;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class ReceiptRepository : GenericRepository<Receipt>, IReceiptRepository
{
    public ReceiptRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<ReceiptProductMappingDto>> GetMappedReceiptProductsAsync(int receiptId)
    {
        string query = string.Format(@"
        select 
	        b.[Id],
            b.[CodigoProduto] as PartnerProductId,
            b.[DescricaoProduto] as PartnerProductDescription,
            c.[Product_Id] as InventoryProductId
        from TCAD_NOTA_FISCAL_CAPA a
        join TCAD_NOTA_FISCAL_LINHA b on a.Id = b.Capa_Id
        left join PartnerProducts c 
          on c.Supplier_Id = a.Fornecedor_Id and c.SupplierProductId = b.CodigoProduto
        where a.Id = {0}", receiptId);

        var result = await _context.Database
            .SqlQuery<ReceiptProductMappingDto>(query)
            .ToListAsync();

        return result;
    }

    public async Task<IReadOnlyList<ReceiptLine>> GetReceiptLinesAsync(int receiptId)
    {
        return await _context.ReceiptLines
            .Where(x => x.ReceiptId == receiptId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int[]> GetUnmappedReceipts()
    {
        string query = @"
        
        SELECT DISTINCT capas.id
        FROM 
            TCAD_NOTA_FISCAL_CAPA capas
        JOIN 
            TCAD_NOTA_FISCAL_LINHA linhas ON capas.id = linhas.Capa_Id
        LEFT JOIN 
            PartnerProducts pp ON pp.SupplierProductId = linhas.CodigoProduto
                            AND pp.Supplier_Id = capas.Fornecedor_Id
        WHERE 
            pp.Id IS NULL";

        var result = await _context.Database
            .SqlQuery<int>(query)
            .ToArrayAsync();

        return result;
    }

    public async Task<bool> HasUnmappedProductsAsync(int receiptId)
    {
        string query = string.Format(@"
        SELECT 
            COUNT(*) 
        FROM 
            TCAD_NOTA_FISCAL_CAPA capas
        JOIN 
            TCAD_NOTA_FISCAL_LINHA linhas ON capas.id = linhas.Capa_Id
        LEFT JOIN 
            PartnerProducts pp ON pp.SupplierProductId = linhas.CodigoProduto
                            AND pp.Supplier_Id = capas.Fornecedor_Id
        WHERE 
            capas.id = {0}
            AND pp.Id IS NULL", receiptId);

        var result = await _context.Database
            .SqlQuery<int>(query)
            .SingleAsync();

        return result > 0;
    }
}