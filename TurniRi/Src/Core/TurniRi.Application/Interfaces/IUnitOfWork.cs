using System.Threading.Tasks;

namespace TurniRi.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
