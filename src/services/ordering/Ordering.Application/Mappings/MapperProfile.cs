using AutoMapper;
using Ordering.Application.Features.Orders.Queries;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mappings
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
        }
    }
}