using System.Collections.Generic;
using CartingService.Domain;
using LiteDB;
namespace CartingService.Application
{
    public interface ICartingService
    {
        bool Delete(int cart);
        IEnumerable<Cart> FindAll();
        ObjectId Insert(Cart cart);
    }
}
