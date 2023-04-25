using LiteDB;
using Microsoft.Extensions.Options;
using System;

namespace CartingService.Infraestructure
{
    public class LiteDbContext : ILiteDbContext
    {
        public LiteDatabase Database { get; set; }

        public LiteDbContext(IOptions<LiteDbOptions> options)
        {
            Database = new LiteDatabase(options.Value.DatabaseLocation);

        }
    }
}
