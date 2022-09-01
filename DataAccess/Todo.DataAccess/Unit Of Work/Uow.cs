using Microsoft.EntityFrameworkCore.Storage;
using Todo.DataAccess.Contexts;
using Todo.DataAccess.Interfaces;
using Todo.DataAccess.Repository;
using Todo.Entities.Domains;

namespace Todo.DataAccess.Unit_Of_Work;

public class Uow : IUow
{
    private readonly TodoContext _context;

    public Uow(TodoContext context)
    {
        _context = context;
    }

    public IDbContextTransaction BeginTransaction()
    {
        return _context.Database.BeginTransaction();
    }

    public IRepository<T> GetRepository<T>() where T : Work
    {
        return new ConcreteRepository<T>(_context);
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
    
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}