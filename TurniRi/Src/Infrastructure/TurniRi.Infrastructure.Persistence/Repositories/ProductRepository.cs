using System.Linq;
using System.Threading.Tasks;
using TurniRi.Application.DTOs;
using TurniRi.Application.Interfaces.Repositories;
using TurniRi.Domain.Products.DTOs;
using TurniRi.Domain.Products.Entities;
using TurniRi.Infrastructure.Persistence.Contexts;

namespace TurniRi.Infrastructure.Persistence.Repositories
{
    public class ProductRepository(ApplicationDbContext dbContext) : GenericRepository<Product>(dbContext), IProductRepository
    {
        public async Task<PaginationResponseDto<ProductDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = dbContext.Products.OrderBy(p => p.Created).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            return await Paged(
                query.Select(p => new ProductDto(p)),
                pageNumber,
                pageSize);

        }
    }
}
