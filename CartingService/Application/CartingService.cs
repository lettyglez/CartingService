using LiteDB;
using System.Collections.Generic;
using CartingService.Domain;

namespace CartingService.Application
{
    public class CartingService : ICartingService
    {
        private readonly ICartingRepository _cartingRepository;
        public CartingService(ICartingRepository cartingRepository)
        {
            this._cartingRepository = cartingRepository;
        }

        public IEnumerable<Cart> FindAll()
        {
            var result = _cartingRepository.FindAll();
            return result;
        }

        public Cart FindOne(int id)
        {
            return new Cart();
        }

        public ObjectId Insert(Cart carting)
        {
            return _cartingRepository.Insert(carting);
        }

        public bool Delete(int id)
        {
            return _cartingRepository.Delete(id);
        }
    }
    
}
