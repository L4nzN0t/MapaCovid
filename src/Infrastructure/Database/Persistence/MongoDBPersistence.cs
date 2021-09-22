using Infrastructure.Database.Connection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database.Persistence
{
    public static class MongoDBPersistence
    {
        public static void Configure(IConfiguration configuration)
        {
            TestMongoConnection.Connect(configuration);
            MappingMongoDb.Configure();
        }
    }
}