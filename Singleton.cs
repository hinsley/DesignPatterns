using System;

namespace DesignPatterns.Singleton
{
    class MainApp
    {
        static void Main()
        {
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            if (s1 == s2)
            {
                Console.WriteLine("s1 == s2");
            }
            else
            {
                Console.WriteLine("s1 != s2");
            }
        }
    }

    class Singleton
    {
        private static Singleton _instance;

        // Constructor is protected to prevent using `new` externally.
        protected Singleton()
        {}

        public static Singleton Instance()  
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }
    }
}