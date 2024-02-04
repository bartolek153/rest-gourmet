namespace AugustaGourmet.Api.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    void BeginTransactionAsync();
    Task<int> CommitAsync();
}