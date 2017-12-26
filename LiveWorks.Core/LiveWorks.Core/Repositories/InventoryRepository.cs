using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LiveWorks.Core.Context;

namespace LiveWorks.Core.Repositories
{
    public class InventoryRepository<TEntity> : Repository<TEntity> where TEntity : class
    {
        public InventoryRepository(DbContext context) : base(context)
        {
        }

        public InventoryContext InventoryContext
        {
            get
            {
                return Context as InventoryContext;
            }
        }
    }
}
