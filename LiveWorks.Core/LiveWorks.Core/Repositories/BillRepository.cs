using LiveWorks.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LiveWorks.Core.Context;

namespace LiveWorks.Core.Repositories
{
    public class BillRepository : InventoryRepository<Bill>
    {
        public BillRepository(InventoryContext context) : base(context)
        {
        }
    }
}
