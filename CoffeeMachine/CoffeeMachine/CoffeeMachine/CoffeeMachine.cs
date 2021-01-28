using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class CoffeeMachine : PetriNetwork
    {
        public int smallCoffeePrice = 5;
        public int mediumCoffeePrice = 10;
        public int largeCoffeePrice = 15;

        public CoffeeMachine(int s, int m, int l)
        {
            smallCoffeePrice = s;
            mediumCoffeePrice = m;
            mediumCoffeePrice = l;

            type = "Single Execution (user input)";

            Location location0 = new Location("0", 1);;
            Location location5 = new Location(smallCoffeePrice.ToString(), 0);
            Location location10 = new Location(mediumCoffeePrice.ToString(), 0);
            Location location15 = new Location(largeCoffeePrice.ToString(), 0);

            Transition transition1 = new Transition(smallCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location5),
                new Arc(1, "LT", location0)
            });

            transitionList.Add(transition1);

            Transition transition2 = new Transition(smallCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location10),
                new Arc(1, "LT", location5)
            });

            transitionList.Add(transition2);

            Transition transition3 = new Transition(mediumCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location15),
                new Arc(1, "LT", location10)
            });

            transitionList.Add(transition3);

            Transition transition4 = new Transition(mediumCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location10),
                new Arc(1, "LT", location0)
            });

            transitionList.Add(transition4);

            Transition transition5 = new Transition(mediumCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location15),
                new Arc(1, "LT", location5)
            });

            transitionList.Add(transition5);

            Transition transition6 = new Transition("-" + smallCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location0),
                new Arc(1, "LT", location5)
            });

            transitionList.Add(transition6);

            Transition transition7 = new Transition("-" + smallCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location5),
                new Arc(1, "LT", location10)
            });

            transitionList.Add(transition7);

            Transition transition8 = new Transition("-" + smallCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location10),
                new Arc(1, "LT", location15)
            });

            transitionList.Add(transition8);

            Transition transition9 = new Transition("-" + mediumCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location0),
                new Arc(1, "LT", location10)
            });

            transitionList.Add(transition9);

            Transition transition10 = new Transition("-" + mediumCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location5),
                new Arc(1, "LT", location15)
            });

            transitionList.Add(transition10);

            Transition transition11 = new Transition("-" + largeCoffeePrice.ToString(), new List<Arc>() {
                new Arc(1, "TL", location0),
                new Arc(1, "LT", location15)
            });

            transitionList.Add(transition11);
        }

        public override bool Execute(string tag)
        {
            var result = base.Execute(tag);

            Console.WriteLine("Current State: " + GetCurrentState());

            return result;
        }

        public override void Run()
        {
            base.Run();

            var input = "";
            int currentCredit = 0;
            var transitionTag = "";

            while (true)
            {
                string tagCopy = "";

                Console.WriteLine($"What do you wish to do? \n 1. Enter {smallCoffeePrice.ToString()} lei \n 2. Enter {mediumCoffeePrice.ToString()} leu \n 3. Buy small coffee \n 4. Buy medium coffee \n 5. Buy large coffee");
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        transitionTag = smallCoffeePrice.ToString();
                        break;
                    case "2":
                        transitionTag = mediumCoffeePrice.ToString();
                        break;
                    case "3":
                        transitionTag = "-" + smallCoffeePrice.ToString();
                        break;
                    case "4":
                        transitionTag = "-" + mediumCoffeePrice.ToString();
                        break;
                    case "5":
                        transitionTag = "-" + largeCoffeePrice.ToString();
                        break;
                    default:
                        Console.WriteLine("Invalid input option.");
                        break;
                }

                var result = Execute(transitionTag);

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

        public String GetCurrentState()
        {
            if (transitionList.Count == 0)
            {
                Console.WriteLine("Transition List is empty");
            }
            foreach (Transition transition in transitionList)
            {
                List<Location> locationList = new List<Location>();
                locationList = transition.GetArcsLocation();
                if (locationList.Count == 0)
                {
                    Console.WriteLine("Location List is empty");
                }
                foreach (Location location in locationList)
                {
                    if (location.tokens == 1)
                    {
                        return location._tag;
                    }
                }
            }

            return "404";
        }
    }
}
