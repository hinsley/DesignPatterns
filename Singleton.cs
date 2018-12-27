/// <summary>
/// Singleton design pattern.
/// 
/// Disallows more than one instance of a class inheriting the Singleton
/// behavior from being instantiated.
/// </summary>
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
                Console.WriteLine("s1 == s2. Singleton works!");
            }
            else
            {
                Console.WriteLine("s1 != s2. Singleton does not work.");
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