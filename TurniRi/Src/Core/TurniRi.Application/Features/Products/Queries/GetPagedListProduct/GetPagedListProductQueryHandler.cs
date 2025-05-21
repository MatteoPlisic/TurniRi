using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TurniRi.Application.Interfaces.Repositories;
using TurniRi.Application.Wrappers;
using TurniRi.Domain.Products.DTOs;

namespace TurniRi.Application.Features.Products.Queries.GetPagedListProduct
{
    public class GetPagedListProductQueryHandler(IProductRepository productRepository) : IRequestHandler<GetPagedListProductQuery, PagedResponse<ProductDto>>
    {
        public async Task<PagedResponse<ProductDto>> Handle(GetPagedListProductQuery request, CancellationToken cancellationToken)
        {
            return await productRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);
        }
    }
}
