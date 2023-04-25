using System.Collections.Generic;
using CartingService.Domain;
using LiteDB;

namespace CartingService.Application
{
    public interface ICartingRepository
    {
        bool Delete(int cart);
        List<Cart> FindAll();
        ObjectId Insert(Cart cart);
    }
}
