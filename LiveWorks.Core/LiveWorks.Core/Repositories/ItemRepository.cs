using LiveWorks.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LiveWorks.Core.Context;
using System.Linq;

namespace LiveWorks.Core.Repositories
{
    public class ItemRepository : InventoryRepository<Item>
    {
        public ItemRepository(InventoryContext context)
            : base(context)
        {
        }

        public IEnumerable<Item> GetAllItems()
        {
            return GetAll();
        }

        public IEnumerable<Item> GetItemsByItemTypes(string type)
        {
            return InventoryContext.Items.Where(item => item.Type.Contains(type));
        }
    }
}
