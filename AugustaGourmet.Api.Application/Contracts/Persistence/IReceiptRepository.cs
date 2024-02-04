using AugustaGourmet.Api.Application.Features.Receipts;
using AugustaGourmet.Api.Domain.Entities.Fiscal.Receiptment;

namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IReceiptRepository : IGenericRepository<Receipt>
{
    Task<IReadOnlyList<ReceiptLine>> GetReceiptLinesAsync(int receiptId);
    Task<IReadOnlyList<ReceiptProductMappingDto>> GetMappedReceiptProductsAsync(int receiptId);
    Task<int[]> GetUnmappedReceipts();
    Task<bool> HasUnmappedProductsAsync(int receiptId);
}