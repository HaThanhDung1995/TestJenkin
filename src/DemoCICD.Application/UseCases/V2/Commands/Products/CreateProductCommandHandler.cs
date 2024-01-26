using DemoCICD.Contract.Abstractions.Messages;
using DemoCICD.Contract.Services.V2.Products;
using DemoCICD.Contract.Shared;
using DemoCICD.Domain.Abstractions.Dappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCICD.Application.UseCases.V2.Commands.Products
{
    public sealed class CreateProductCommandHandler : ICommandHandler<Command.CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(Command.CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Domain.Entities.Product.CreateProduct(Guid.NewGuid(), request.Name, request.Price, request.Description);

            var result = await _unitOfWork.Products.AddAsync(product);

            return Result.Success(result);
        }
    }
}
