namespace Bootcamp.Service;

public interface IUnitOfWork
{
    Task<int> CommitAsync();
}