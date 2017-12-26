using LiveWorks.Core.Context;
using LiveWorks.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveWorks.Core.UniOfWork
{
    public class InventoryUnitOfWork : IUnitOfWork
    {
        private readonly InventoryContext _context;

        public BillOrderRepository BillOrderRepository { get; private set; }
        public BillRepository BillRepository { get; private set; }
        public ClientRepository ClientRepository { get; private set; }
        public ItemRepository ItemRepository { get; private set; }
        public ItemSetItemRepository ItemSetItemRepository { get; private set; }
        public ItemSetRepository ItemSetRepository { get; private set; }
        public OrderItemRepository OrderItemRepository { get; private set; }
        public OrderRepository OrderRepository { get; private set; }
        //public CategoryRepository CategoryRepository { get; private set; }

        public InventoryUnitOfWork(InventoryContext context)
        {
            _context = context;
            BillOrderRepository = new BillOrderRepository(_context);
            BillRepository = new BillRepository(_context);
            ClientRepository = new ClientRepository(_context);
            ItemRepository = new ItemRepository(_context);
            ItemSetItemRepository = new ItemSetItemRepository(_context);
            ItemSetRepository = new ItemSetRepository(_context);
            OrderItemRepository = new OrderItemRepository(_context);
            OrderItemRepository = new OrderItemRepository(_context);
            //CategoryRepository = new CategoryRepository(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}


