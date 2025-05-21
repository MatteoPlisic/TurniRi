using MediatR;
using TurniRi.Application.Wrappers;
using TurniRi.Domain.Products.DTOs;

namespace TurniRi.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<BaseResult<ProductDto>>
    {
        public long Id { get; set; }
    }
}
