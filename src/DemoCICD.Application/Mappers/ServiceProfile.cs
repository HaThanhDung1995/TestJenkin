using AutoMapper;
using DemoCICD.Contract.Abstractions.Shared;
using DemoCICD.Contract.Services.V1.Products;
using DemoCICD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCICD.Application.Mappers
{
    public class ServiceProfile :Profile
    {
        public ServiceProfile()
        {
            CreateMap<Product,Response.ProductResponse>().ReverseMap();
            CreateMap<PagedResult<Product>, PagedResult<Response.ProductResponse>>().ReverseMap();
            CreateMap<Product, Contract.Services.V2.Products.Response.ProductResponse>().ReverseMap();
        }
    }
}
