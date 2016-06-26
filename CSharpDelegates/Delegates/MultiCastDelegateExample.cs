using CSharpDelegates.Models;
using System;

namespace CSharpDelegates.Delegates
{
    public class MultiCastDelegateExample
    {
        public static void Run()
        {
            // First, make a Car object.
            Car c1 = new Car("Jessie", 100, 10);

            // Now, tell the car which methods to call when it wants to send us messages.
            c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent)); // see below for 'OnCarEngineEvent' declaration
            Car.CarEngineHandler handler2 = new Car.CarEngineHandler(OnCarEngineEvent2);
            c1.RegisterWithCarEngine(handler2);

            // Speed up (this will trigger the events).
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            // Unregister the second handler.
            c1.UnRegisterWithCarEngine(handler2);

            // We won't see the "uppercase" message anymore!
            Console.WriteLine("***** Speeding up *****");
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }
        }

        // This is a target for incoming events (see: DELEGATES above).
        private static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n***** Message From Car Object *****");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("***********************************\n");
        }

        // This is another target for incoming events (see: DELEGATES above).
        private static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("=> {0}", msg.ToUpper());
        }
    }
}
