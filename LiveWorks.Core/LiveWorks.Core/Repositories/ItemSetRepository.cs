using LiveWorks.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LiveWorks.Core.Context;

namespace LiveWorks.Core.Repositories
{
    public class ItemSetRepository : InventoryRepository<ItemSet>
    {
        public ItemSetRepository(InventoryContext context) : base(context)
        {
        }
    }
}
