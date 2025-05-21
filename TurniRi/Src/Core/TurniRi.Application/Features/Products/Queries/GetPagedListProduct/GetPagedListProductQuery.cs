using MediatR;
using TurniRi.Application.Parameters;
using TurniRi.Application.Wrappers;
using TurniRi.Domain.Products.DTOs;

namespace TurniRi.Application.Features.Products.Queries.GetPagedListProduct
{
    public class GetPagedListProductQuery : PaginationRequestParameter, IRequest<PagedResponse<ProductDto>>
    {
        public string Name { get; set; }
    }
}
