using System.Threading.Tasks;
using TurniRi.Application.DTOs;
using TurniRi.Domain.Products.DTOs;
using TurniRi.Domain.Products.Entities;

namespace TurniRi.Application.Interfaces.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PaginationResponseDto<ProductDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
    }
}
