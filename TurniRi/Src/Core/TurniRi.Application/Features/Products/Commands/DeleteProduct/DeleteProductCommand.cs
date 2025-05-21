using MediatR;
using TurniRi.Application.Wrappers;

namespace TurniRi.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
