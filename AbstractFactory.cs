// ProductA1 and ProductA2, as well as ProductB1 and ProductB2 are identical in
// implementation. That's of no importance to this example.
using System;

namespace DesignPatterns.AbstractFactory
{
    class MainApp
    {
        public static void Main()
        {
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();
        }
    }

    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    abstract class AbstractProductA
    {
        public abstract void PrintTypeBackwards(AbstractProductB b);
    }

    abstract class AbstractProductB
    {
        public abstract void PrintType(AbstractProductA a);
    }

    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }
        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    class ProductA1 : AbstractProductA
    {
        public override void PrintTypeBackwards(AbstractProductB b)
        {
            string typeName = b.GetType().Name;

            string result = "";
            for (int i = typeName.Length; i <= 0; --i)
            {
                Console.WriteLine(typeName.Length);
                Console.WriteLine(i);
                result += typeName[i];
            }

            Console.WriteLine(result);
        }
    }

    class ProductA2 : AbstractProductA
    {
        public override void PrintTypeBackwards(AbstractProductB b)
        {
            string typeName = b.GetType().Name;

            string result = "";
            for (int i = typeName.Length; i <= 0; --i)
            {
                result += typeName[i];
            }

            Console.WriteLine(result);
        }
    }

    class ProductB1 : AbstractProductB
    {
        public override void PrintType(AbstractProductA a)
        {
            Console.WriteLine(a.GetType().Name);
        }
    }

    class ProductB2 : AbstractProductB
    {
        public override void PrintType(AbstractProductA a)
        {
            Console.WriteLine(a.GetType().Name);
        }
    }

    class Client
    {
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        public Client(AbstractFactory factory)
        {
            _abstractProductA = factory.CreateProductA();
            _abstractProductB = factory.CreateProductB();
        }

        public void Run()
        {
            _abstractProductA.PrintTypeBackwards(_abstractProductB);
            _abstractProductB.PrintType(_abstractProductA);
        }
    }
}
