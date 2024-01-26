using AutoMapper;
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

namespace DemoCICD.Application.UseCases.V2.Queries.Products
{
    public sealed class GetProductByIdQueryHandler : IQueryHandler<Query.GetProductByIdQuery, Response.ProductResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Response.ProductResponse>> Handle(Query.GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id)
                ?? throw new ProductException.ProductNotFoundException(request.Id);

            var result = _mapper.Map<Response.ProductResponse>(product);

            return Result.Success(result);
        }
    }
}
