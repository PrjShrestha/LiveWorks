using LiveWorks.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LiveWorks.Core.Context;
using System.Linq;

namespace LiveWorks.Core.Repositories
{
    public class OrderRepository : InventoryRepository<Order>
    {
        public OrderRepository(InventoryContext context) 
            : base(context)
        {
        }

        public double GetTotalOfOrder(Order order)
        {
            var orderItems = InventoryContext.OrderItems.Where(item => item.Order.Id == order.Id);
            return CalculateTotal(orderItems);
        }

        private double CalculateTotal(IQueryable<OrderItem> orderItems)
        {
            return orderItems.Sum(x => x.PricePerItem * x.Quantity);
        }
    }
}
