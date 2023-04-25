using NUnit.Framework;
using CartingService.Domain;
using CartingService.Infraestructure;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TestCartingService
{
    [TestFixture]
    public class Tests
    {
        private readonly IConfiguration _configuration;
        

        LiteDbCartingRepository _dbCartingRepository;
        Cart _cart;
        List<Item> _items;

        public Tests()
        {
            _configuration = new ConfigurationBuilder()
               .SetBasePath(Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "CartingService"))
               .AddJsonFile(@"appsettings.json", false, false)
               .AddEnvironmentVariables()
               .Build();
        }

        [SetUp]
        public void Setup()
        {
            
            _items = new List<Item>();
            _dbCartingRepository = new LiteDbCartingRepository(_configuration);
        }


        [Test]
        public void Insert()
        {

            Item it = new Item
            {
                IdItem = 1,
                Image = "image1.jpg",
                Name = "Notebook",
                Price = 5,
                Quantity = 2
            };

            _items.Add(it);

            _cart = new Cart
            {
                Items = _items
            };

            var id = _dbCartingRepository.Insert(_cart);
        }

        [Test]
        public void GetAll()
        {

            var FindAll = _dbCartingRepository.FindAll();
        }

        [Test]
        public void Delete()
        {
            int id = 1;
            var _delete = _dbCartingRepository.Delete(id);
        }
    }
}