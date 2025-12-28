namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.GetLogger();
            Logger logger2 = Logger.GetLogger();
            Console.WriteLine($"Logger1 HashCode: {logger1.GetHashCode()}, Logger2 HashCode: {logger2.GetHashCode()}");
        }
    }

    public sealed class Logger
    {
        private static Logger _instance;
        private Logger() { }

        private static readonly object _lockObj = new object();
        public static Logger GetLogger()
        {
            if (_instance == null)
            {
                lock (_lockObj)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }
    }
}
