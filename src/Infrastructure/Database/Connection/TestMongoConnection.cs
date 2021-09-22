using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Database.Connection
{
    public class TestMongoConnection 
    {
        private static bool _IsConnected;
        public static bool IsConnected 
        {
            get
            {
                return _IsConnected;
            }
            set
            {
                _IsConnected = value;
            }
        }

        public static void Connect(IConfiguration configuration)
        {
            try
            {
                IMongoConnect mongoDB = new MongoDatabase(configuration);
                var t  = mongoDB.db.RunCommand((Command<BsonDocument>)"{ping:1}");
                if (t.GetElement("ok").Value == 1)
                {
                    _IsConnected = true;
                }
            }
            catch (System.TimeoutException)
            {
                _IsConnected = false;
            }
            
        }
    }
}