using DemoCICD.Contract.Abstractions.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCICD.Contract.Services.V2.Products
{
    public static class Command
    {
        public record CreateProductCommandV2(string Name, decimal Price, string Description) : ICommand;

        public record UpdateProductCommandV2(Guid Id, string Name, decimal Price, string Description) : ICommand;

        public record DeleteProductCommandV2(Guid Id) : ICommand;
    }
}
