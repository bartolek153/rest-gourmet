using AugustaGourmet.Api.Application.Contracts.Persistence;
using AugustaGourmet.Api.Application.DTOs.Receipts;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;
using AugustaGourmet.Api.Persistence.Context;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AugustaGourmet.Api.Persistence.Repositories;

public class ReceiptRepository : GenericRepository<Receipt>, IReceiptRepository
{
    public ReceiptRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<ReceiptProductMappingDto>> GetMappedReceiptProductsAsync(int receiptId)
    {
        var receipt = new SqlParameter("@receiptId", receiptId);

        string query = @"
        select 
	        b.[Id],
            b.[CodigoProduto] as PartnerProductId,
            b.[DescricaoProduto] as PartnerProductDescription,
            c.[Product_Id] as InventoryProductId
        from TCAD_NOTA_FISCAL_CAPA a
        join TCAD_NOTA_FISCAL_LINHA b on a.Id = b.Capa_Id
        left join PartnerProducts c 
          on c.Supplier_Id = a.Fornecedor_Id and c.SupplierProductId = b.CodigoProduto
        where a.Id = @receiptId";

        var result = await _context.Database
            .SqlQueryRaw<ReceiptProductMappingDto>(query, receipt)
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
            .SqlQueryRaw<int>(query)
            .ToArrayAsync();

        return result;
    }

    public async Task<bool> AnyUnmappedProductsAsync(int receiptId)
    {
        var receipt = new SqlParameter("@receiptId", receiptId);

        //TODO: substitute count(1) for exists
        string query = @"
        SELECT COUNT(1) AS Value
        FROM 
            TCAD_NOTA_FISCAL_CAPA capas
        JOIN 
            TCAD_NOTA_FISCAL_LINHA linhas ON capas.id = linhas.Capa_Id
        LEFT JOIN 
            PartnerProducts pp ON pp.SupplierProductId = linhas.CodigoProduto
                            AND pp.Supplier_Id = capas.Fornecedor_Id
        WHERE 
            capas.id = @receiptId
            AND pp.Id IS NULL";

        var result = await _context.Database
            .SqlQueryRaw<int>(query, receipt)
            .SingleAsync();

        return result > 0;
    }

    public async Task<bool> ReceiptExistsAsync(string nfeId)
    {
        return await _context.Receipts
            .AnyAsync(x => x.NfeId == nfeId);
    }

    public async Task<string[]> ReceiptRangeExistsAsync(string[] nfeIds)
    {
        return await _context.Receipts
            .Where(x => nfeIds.Contains(x.NfeId))
            .Select(x => x.NfeId)
            .ToArrayAsync();
    }
}