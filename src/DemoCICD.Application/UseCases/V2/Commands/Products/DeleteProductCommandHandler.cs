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
    public sealed class DeleteProductCommandHandler : ICommandHandler<Command.DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork; // SQL-SERVER-STRATEGY-2

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(Command.DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id)
                ?? throw new ProductException.ProductNotFoundException(request.Id);

            var result = await _unitOfWork.Products.DeleteAsync(product.Id);

            return Result.Success(result);
        }
    }
}
