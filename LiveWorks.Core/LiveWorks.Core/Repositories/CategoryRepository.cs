using LiveWorks.Core.Context;
using LiveWorks.Core.Models;

namespace LiveWorks.Core.Repositories
{
    public class CategoryRepository : InventoryRepository<Category>
    {
        public CategoryRepository(InventoryContext context) : base(context)
        {
        }
    }
}
