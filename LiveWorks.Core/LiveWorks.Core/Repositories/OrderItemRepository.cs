using LiveWorks.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LiveWorks.Core.Context;
using System.Linq;

namespace LiveWorks.Core.Repositories
{
    public class OrderItemRepository : InventoryRepository<OrderItem>
    {
        public OrderItemRepository(InventoryContext context) 
            : base(context)
        {
        }

        private double GetTotalPriceOfOrderItem(OrderItem orderItem)
        {
            return orderItem.PricePerItem * orderItem.Quantity;
        }

        private IEnumerable<OrderItem> GetAllOrderItemsByOrderId(int orderId)
        {
            return InventoryContext.OrderItems.Where(item => item.Order.Id == orderId).ToList();
        }
    }
}
