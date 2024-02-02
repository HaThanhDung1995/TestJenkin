using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCICD.Domain.Abstractions.Dappers.Repositories.Product
{
    public interface IProductRepository : IGenericRepository<Domain.Entities.Product>
    {
    }
}
