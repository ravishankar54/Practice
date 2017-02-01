namespace SingiletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public sealed class SingletonClass
    {
        private static volatile SingletonClass instance;
        private static object syncRoot = new object();
        public static SingletonClass Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        instance = new SingletonClass();
                    }
                }
                return instance;
            }
        }
    }
}
