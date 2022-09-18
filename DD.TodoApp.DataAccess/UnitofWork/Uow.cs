using DD.TodoApp.DataAccess.Contexts;
using DD.TodoApp.DataAccess.Interfaces;
using DD.TodoApp.DataAccess.Repositories;
using DD.TodoApp.Entities.Concrete;
using System.Threading.Tasks;

namespace DD.TodoApp.DataAccess.UnitofWork
{
    public class Uow : IUow
    {
        private readonly TodoContext _context;

        public Uow(TodoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
