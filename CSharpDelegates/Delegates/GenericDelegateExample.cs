using CSharpDelegates.Utilities;
using System;

namespace CSharpDelegates.Delegates
{
    public class GenericDelegateExample
    {
        // This generic delegate can call any method
        // returning void and taking a single type parameter.
        public delegate void MyGenericDelegate<T>(T arg);

        public static void Run()
        {
            PrintUtility.PrintTitle("Generic Delegates");

            // Register targets.
            MyGenericDelegate<string> strTarget = new MyGenericDelegate<string>(StringTarget);
            MyGenericDelegate<int> intTarget = new MyGenericDelegate<int>(IntTarget);

            strTarget("Some string data");
            intTarget(9);
        }

        private static void StringTarget(string arg)
        {
            Console.WriteLine($"arg in uppercase is: {arg.ToUpper()}");
        }

        private static void IntTarget(int arg)
        {
            Console.WriteLine($"++arg is: {++arg}");
        }

    }
}
