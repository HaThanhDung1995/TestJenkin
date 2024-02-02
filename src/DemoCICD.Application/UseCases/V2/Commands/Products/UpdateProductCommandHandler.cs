using DemoCICD.Contract.Abstractions.Messages;
using DemoCICD.Contract.Services.V2.Products;
using DemoCICD.Contract.Shared;
using DemoCICD.Domain.Abstractions.Dappers;
using DemoCICD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCICD.Application.UseCases.V2.Commands.Products
{
    public sealed class UpdateProductCommandHandler : ICommandHandler<Command.UpdateProductCommandV2>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(Command.UpdateProductCommandV2 request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id)
                ?? throw new ProductException.ProductNotFoundException(request.Id);

            product.Update(request.Name, request.Price, request.Description);

            var result = await _unitOfWork.Products.UpdateAsync(product);

            return Result.Success(result);
        }
    }
}
