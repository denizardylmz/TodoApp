using Microsoft.EntityFrameworkCore.Storage;
using Todo.Entities.Domains;

namespace Todo.DataAccess.Interfaces;

public interface IUow : IDisposable
{

    IDbContextTransaction BeginTransaction();

    IRepository<T> GetRepository<T>() where T : Work;

    Task<int> SaveAsync();
}