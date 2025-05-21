using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TurniRi.Application.Interfaces;
using TurniRi.Application.Interfaces.Repositories;
using TurniRi.Application.Wrappers;
using TurniRi.Domain.Products.Entities;

namespace TurniRi.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, BaseResult<long>>
    {
        public async Task<BaseResult<long>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Price, request.BarCode);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return product.Id;
        }
    }
}
