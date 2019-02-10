using CoreTest.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.Data
{
    public class CoreSeeder
    {
        private readonly CoreContext _context;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<CoreUser> _userManager;

        public CoreSeeder(CoreContext context, IHostingEnvironment hosting, 
            UserManager<CoreUser> userManager)
        {
           _context = context;
           _hosting = hosting;
           _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();

            CoreUser user = await _userManager.FindByEmailAsync("purunep@gmail.com");

            if(user == null)
            {
                user = new CoreUser()
                {
                    FirstName = "Puru",
                    LastName = "Dangol",
                    Email = "purunep@gmail.com",
                    UserName = "purunep@gmail.com"
                };
                var result = await _userManager.CreateAsync(user, "P@ssw0rd!");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder.");
                }
            }

            if(!_context.Products.Any())
            {
                var filePath = Path.Combine(_hosting.ContentRootPath,"Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _context.Products.AddRange(products);

                var order = _context.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product= products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }

                    };

                }

                _context.SaveChanges();

            }
        }

    }
}
