using LiveWorks.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveWorks.Core.Context
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) :
            base(options)
        { }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ItemSet> ItemSets { get; set; }

        public DbSet<ItemSetItem> ItemSetItems { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<Item> BillOrders { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<StockIn> StockIn { get; set; }

        public DbSet<StockOut> StockOut { get; set; }

        //public DbSet<Category> Categories { get; set; }

    }
}
