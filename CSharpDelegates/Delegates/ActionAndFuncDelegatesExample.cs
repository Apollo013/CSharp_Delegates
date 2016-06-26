using CSharpDelegates.Utilities;
using System;

namespace CSharpDelegates.Delegates
{
    public class ActionAndFuncDelegatesExample
    {
        public static void Run()
        {

            PrintUtility.PrintTitle($"ACTION & FUNC");

            /****************************************************************************************************************/
            /* Action<> */
            /****************************************************************************************************************/
            // Use the Action<> delegate to point to DisplayMessage.
            // The Action<> delegate can point only to methods that take a void return value (can take up to 16 arguments)
            Action<string, ConsoleColor, int> actionTarget = new Action<string, ConsoleColor, int>(DisplayMessage);
            actionTarget("Action Message!", ConsoleColor.Yellow, 5);


            /****************************************************************************************************************/
            /* Func<> */
            /****************************************************************************************************************/
            // the final type parameter of Func<> is always the return value of the method

            Func<int, int, int> funcTarget = new Func<int, int, int>(Sum);
            int result = funcTarget.Invoke(40, 40);
            Console.WriteLine("40 + 40 = {0}", result);

            Func<int, int, string> funcTarget2 = new Func<int, int, string>(SumToString);
            string sum = funcTarget2.Invoke(90, 300);
            Console.WriteLine(sum);
        }

        // This is the target for the Action<> delegate.
        private static void DisplayMessage(string msg, ConsoleColor txtColor, int printCount)
        {
            // Set color of console text.
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = txtColor;
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }

            // Restore color.
            Console.ForegroundColor = previous;
        }

        // This is the target for the Func<> delegate.
        private static int Sum(int x, int y)
        {
            return x + y;
        }

        static string SumToString(int x, int y)
        {
            return (x + y).ToString();
        }
    }
}
