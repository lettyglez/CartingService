using LiteDB;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using CartingService.Domain;
using CartingService.Application;
using System;
using System.IO;

namespace CartingService.Infraestructure
{
    public class LiteDbCartingRepository : ICartingRepository
    {
        private readonly IConfiguration _configuration;
        private string _dataBaseLT;


        public LiteDbCartingRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
            _dataBaseLT = _configuration["LiteDbOptions:DatabaseLocation"];
        }

        public List<Cart> FindAll()
        {
            using (var _liteDb = new LiteDatabase(_dataBaseLT))
            {
                var result = _liteDb.GetCollection<Cart>("Cart")
                .FindAll().ToList();


                return result;
            }

        }

        public ObjectId Insert(Cart carting)
        {
            using (var _liteDb = new LiteDatabase(_dataBaseLT))
            {
                carting.IdCart = Guid.NewGuid();
                return _liteDb.GetCollection<Cart>("Cart")
                    .Insert(carting);
            }
        }

        public bool Delete(int id)
        {
            using (var _liteDb = new LiteDatabase(_dataBaseLT))
            {

                int del = 0;
                var collection = _liteDb.GetCollection<Cart>("Cart");
                
                var items = collection.FindAll().ToList();

                foreach (var item in items)
                {
                    foreach (var i in item.Items)
                    {
                        if (i.IdItem == id)
                        {
                            item.Items.Remove(i);
                            del = collection.DeleteAll();
                            _liteDb.GetCollection<Cart>("Cart")
                                .Insert(item);
                            break;
                        }
                    }

                }

                return (del > 0) ? true : false;
            }
        }
    }
}
