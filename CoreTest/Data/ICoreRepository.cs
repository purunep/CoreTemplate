using System.Collections.Generic;
using CoreTest.Data.Entities;

namespace CoreTest.Data
{
    public interface ICoreRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders(bool includeItems);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
        Order GetOrderById(string username, int id);
        void AddEntity(object order);
        void AddOrder(Order newOrder);
    }
}