using CoreTest.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.Data
{
    public class CoreRepository : ICoreRepository
    {
        private readonly CoreContext _ctx;

        public CoreRepository(CoreContext ctx)
        {
            _ctx = ctx;
        }

        public void AddEntity(object entity)
        {
            _ctx.Add(entity);
        }

        public void AddOrder(Order newOrder)
        {
            foreach(var item in newOrder.Items)
            {
                item.Product = _ctx.Products.Find(item.Product.Id);
            }
            AddEntity(newOrder);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders.Include(o => o.Items).
                    ThenInclude(p => p.Product).ToList();
            }
            else
            {
                return _ctx.Orders.ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders.Where(o => o.User.UserName == username)
                    .Include(o => o.Items).
                    ThenInclude(p => p.Product).ToList();
            }
            else
            {
                return _ctx.Orders.Where(o => o.User.UserName == username).ToList();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _ctx.Products.OrderBy(p => p.Title).ToList();
        }

        public Order GetOrderById(string username, int id)
        {
            return _ctx.Orders.Where(o => o.Id == id && o.User.UserName == username)
                .Include(o => o.Items)
                .ThenInclude(p => p.Product).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory( string category)
        {
            return _ctx.Products.Where(p => p.Category == category).ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
