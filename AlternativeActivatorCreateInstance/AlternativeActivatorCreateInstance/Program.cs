using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AlternativeActivatorCreateInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = Factory<Config>.CreateInstance();
            config.Display();
            Console.ReadKey();
        }
    }

    public static class Factory<T>
       where T : new()
    {
        public static T CreateInstance() {
            var exp = Expression.New(typeof(T));
            var expLambda = Expression.Lambda<Func<T>>(exp);
            var expLambdaExecutableCode = expLambda.Compile();
            return expLambdaExecutableCode();
            //return Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile()();
        }

    }

    public class Config
    {
        public Config()
        {
            Console.WriteLine("Constructor Invoked");
        }
        public void Display()
        {
            Console.WriteLine("Called Display() of " + nameof(Config));
        }
    }
}
