using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Todo.DataAccess.Contexts;
using Todo.DataAccess.Interfaces;
using Todo.Entities.Domains;
using Todo.Entities.Domains.BaseEntities;

namespace Todo.DataAccess.Repository;

public class ConcreteRepository<T>: IRepository<T> where T : BaseEntity
{
    private readonly TodoContext _context;


    public ConcreteRepository(TodoContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    
    public IQueryable<T> GetAll(bool asNoTracking = false)
    {
        return asNoTracking ? Table.AsNoTracking().AsQueryable() : Table.AsQueryable();
    }

    public  T? GetById(string id, bool asNoTracking = false)
    {
        return asNoTracking ?  Table.AsNoTracking().FirstOrDefault(x => x.Id == Int32.Parse(id)) :  
             Table.FirstOrDefault(x => x.Id == Int32.Parse(id));
    }

    public T? GetByFilter(Expression<Func<T, bool>> method, bool asNoTracking = false)
    {
        return asNoTracking ?  Table.AsNoTracking().FirstOrDefault(method) : 
                 Table.FirstOrDefault(method);
    }

    public bool Create(T model)
    {
        return (Table.Add(model)).State == EntityState.Added;
    }

    public void Update(T model, T entityToUpdate)
    {
        _context.Entry(entityToUpdate).CurrentValues.SetValues(model);
    }

    public bool Remove(T model)
    {
        return (Table.Remove(model)).State == EntityState.Deleted;
    }
}