using LiteDB;

namespace CartingService.Infraestructure
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; set; }
    }
}
