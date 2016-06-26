using System;

namespace CSharpDelegates.Models
{
    public class Car
    {
        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool carIsDead;

        // Class constructors.
        public Car() { MaxSpeed = 100; }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        /// <summary>
        /// (1) Define a delegate type.
        /// </summary>
        /// <param name="msgForCaller"></param>
        public delegate void CarEngineHandler(string msgForCaller);

        /// <summary>
        /// (2) Define a member variable of this delegate.
        /// </summary>
        private CarEngineHandler listOfHandlers;

        /// <summary>
        /// (3) Add registration function for the caller.
        /// </summary>
        /// <param name="methodToCall"></param>
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;

            /*
                Rather than using the += operator, we could call 'Delegate.Combine'
                if (listOfHandlers == null)
                    listOfHandlers = methodToCall;
                else
                    Delegate.Combine(listOfHandlers, methodToCall);
            */
        }

        /// <summary>
        /// remove a method from the invocation list:
        /// </summary>
        /// <param name="methodToCall"></param>
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }

        // 4) Implement the Accelerate() method to invoke the delegate's
        // invocation list under the correct circumstances.
        public void Accelerate(int delta)
        {
            // If this car is "dead," send dead message.
            if (carIsDead)
            {
                if (listOfHandlers != null)
                {
                    listOfHandlers("Sorry, this car is dead...");
                }
            }
            else
            {
                // Is this car "almost dead"?
                CurrentSpeed += delta;
                if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
                {
                    listOfHandlers("Careful buddy! Gonna blow!");
                }
            }

            if (CurrentSpeed >= MaxSpeed)
            {
                carIsDead = true;
            }
            else
            {
                Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }

        }
    }

}
