using DemoCICD.Domain.Abstractions.Dappers.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCICD.Domain.Abstractions.Dappers
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}
