using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    class CarRepairShop : PetriNetwork
    {
        public CarRepairShop()
        {
            type = "Multiple Execution";

            Location lobby = new Location("lobby", 7);
            Location paint = new Location("paint", 0);
            Location mechanical = new Location("mechanical", 0);
            Location electric = new Location("electric", 0);
            Location tyres = new Location("tyres", 0);

            Transition transition1 = new Transition("paint", new List<Arc>() {
                new Arc(2, "TL", paint),
                new Arc(2, "LT", lobby)
            });

            transitionList.Add(transition1);

            Transition transition2 = new Transition("mechanical", new List<Arc>() {
                new Arc(1, "TL", mechanical),
                new Arc(1, "LT", lobby)
            });

            transitionList.Add(transition2);

            Transition transition3 = new Transition("electric", new List<Arc>() {
                new Arc(3, "TL", electric),
                new Arc(3, "LT", lobby)
            });

            transitionList.Add(transition3);

            Transition transition4 = new Transition("tyres", new List<Arc>() {
                new Arc(2, "TL", tyres),
                new Arc(2, "LT", lobby)
            });

            transitionList.Add(transition4);
        }

        public override void Run()
        {
            base.Run();

            foreach (Transition transition in transitionList)
            {
                var result = Execute(transition._tag);

                foreach(Arc arc in transition.arcList)
                {
                    Console.WriteLine($"{arc.location._tag} has {arc.location.tokens} workers");
                }
            }
        }
    }
}

