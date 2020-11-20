using System;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffeeMachine = new CoffeeMachine();
            var input  = "";
            int currentCredit = 0;
            var transitionTag = "";

            while(true)
            {
                string tagCopy = "";

                Console.WriteLine("What do you wish to do? \n 1. Enter 0.5 lei \n 2. Enter 1 leu \n 3. Buy small coffee \n 4. Buy medium coffee \n 5. Buy large coffee");
                input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        transitionTag = "5";
                        break;
                    case "2":
                        transitionTag = "10";
                        break;
                    case "3":
                        transitionTag = "-5";
                        break;
                    case "4":
                        transitionTag = "-10";
                        break;
                    case "5":
                        transitionTag = "-15";
                        break;
                    default:
                        Console.WriteLine("Invalid input option.");
                        break;
                }

                var result = coffeeMachine.Execute(transitionTag);

                bool isReversedTransition = IsReveresedTransition(transitionTag);

                if (result && isReversedTransition)
                {
                    tagCopy = transitionTag;
                    currentCredit -= Int32.Parse(tagCopy.Remove(0, 1));
                    Console.WriteLine(currentCredit);
                    Console.WriteLine("Credit: " + currentCredit / 10 + "." + currentCredit % 10);
                    Console.WriteLine("Bought coffee");
                }
                else if (result && !isReversedTransition)
                {
                    currentCredit += Int32.Parse(transitionTag);
                    Console.WriteLine("Credit: " + currentCredit / 10 + "." + currentCredit % 10);
                }
                else if (!result && isReversedTransition)
                {
                    Console.WriteLine("Not enough credit");
                }
                else if (!result && !isReversedTransition)
                {
                    Console.WriteLine("Invalid Operation");
                }

            }
        }

        static bool IsReveresedTransition(string tag)
        {
            if (tag.StartsWith("-"))
            {
                return true;
            }

            return false;
        }

    }
}
