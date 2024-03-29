﻿using DemoCICD.Domain.Abstractions.Dappers;
using DemoCICD.Domain.Abstractions.Dappers.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCICD.Infrastructure.Dapper
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IProductRepository productRepository)
        {
            Products = productRepository;
        }

        public IProductRepository Products { get; }
    }
}
