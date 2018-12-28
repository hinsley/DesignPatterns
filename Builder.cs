using System;
using System.Collections.Generic;

namespace DesignPatterns.Builder
{
    class MainApp
    {
        public static void Main()
        {
            Director director = new Director();

            List<Builder> builders = new List<Builder>();
            builders.Add(new ConcreteBuilder1());
            builders.Add(new ConcreteBuilder2());

            foreach (Builder builder in builders)
            {
                director.Construct(builder);
                Product product = builder.GetResult();
                product.Show();
            }
        }
    }

    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }

    class ConcreteBuilder1 : Builder
    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("Foo (Part A)");
        }

        public override void BuildPartB()
        {
            _product.Add("Bar (Part B)");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    class ConcreteBuilder2 : Builder
    {
        private Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("Baz (Part A)");
        }

        public override void BuildPartB()
        {
            _product.Add("Bazinga (Part B)");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }

    class Product
    {
        private List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("Product Parts:");
            
            foreach (string part in _parts)
            {
                Console.WriteLine("\t" + part);
            }
        }
    }
}