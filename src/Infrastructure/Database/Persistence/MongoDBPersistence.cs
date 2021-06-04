namespace Infrastructure.Database.Persistence
{
    public static class MongoDBPersistence
    {
        public static void Configure()
        {
            MappingMongoDb.Configure();
        }
    }
}