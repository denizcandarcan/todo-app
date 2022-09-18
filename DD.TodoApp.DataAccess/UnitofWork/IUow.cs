using DD.TodoApp.DataAccess.Interfaces;
using DD.TodoApp.Entities.Concrete;
using System.Threading.Tasks;

namespace DD.TodoApp.DataAccess.UnitofWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChanges();
    }
}
