namespace Infrastructure.Database.Connection
{
    public static class TestMongoConnection 
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
    }
}