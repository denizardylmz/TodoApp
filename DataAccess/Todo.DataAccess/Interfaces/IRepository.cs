using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Todo.Entities.Domains;
using Todo.Entities.Domains.BaseEntities;

namespace Todo.DataAccess.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
    IQueryable<T> GetAll(bool asNoTracking = false);
    T? GetById(string id, bool asNoTracking = false);
    T? GetByFilter(Expression<Func<T, bool>> method, bool asNoTracking = false);
    bool Create(T model);
    void Update(T model, T entityToUpdate);
    bool Remove(T model);
}