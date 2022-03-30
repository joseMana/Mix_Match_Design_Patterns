namespace Factory_and_Singleton
{
    public class Factory
    {
        private static Factory _instance;

        private Factory()
        {
        }

        public static Factory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Factory();
            }
            return _instance;
        }
    }
}
