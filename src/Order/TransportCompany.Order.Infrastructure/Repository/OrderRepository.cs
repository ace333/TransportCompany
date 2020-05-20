﻿using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TransportCompany.Order.Domain.Enums;
using TransportCompany.Order.Infrastructure.Persistence;
using TransportCompany.Shared.Infrastructure.Persistence;

namespace TransportCompany.Order.Infrastructure.Repository
{
    public class OrderRepository: Repository<Domain.Entities.Order>, IOrderRepository
    {
        private readonly OrderDbContext _orderDbContext;

        public OrderRepository(OrderDbContext orderDbContext) 
            : base(orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<Domain.Entities.Order> GetCurrentOrderByCustomerId(int customerId)
        {
            return await _orderDbContext.Orders.Where(x => x.CustomerId == customerId && x.Status == OrderStatus.Started)
                .SingleOrDefaultAsync();
        }

        public async Task<Domain.Entities.Order> GetCurrentOrderByDriverId(int driverId)
        {
            return await _orderDbContext.Orders.Where(x => x.DriverId == driverId && x.Status == OrderStatus.Started)
                .SingleOrDefaultAsync();
        }
    }
}
