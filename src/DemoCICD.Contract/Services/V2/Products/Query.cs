using DemoCICD.Contract.Abstractions.Messages;
using DemoCICD.Contract.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DemoCICD.Contract.Services.V2.Products.Response;

namespace DemoCICD.Contract.Services.V2.Products
{
    public static class Query
    {
        public record GetProductsQuery() : IQuery<List<ProductResponse>>;
        public record GetProductByIdQuery(Guid Id) : IQuery<ProductResponse>;
    }
}
