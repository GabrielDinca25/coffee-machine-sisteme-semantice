using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class CoffeeMachine : PetriNetwork
    {
        public CoffeeMachine()
        {
            Location location0 = new Location("0", 1);
            Location location5 = new Location("5", 0);
            Location location10 = new Location("10", 0);
            Location location15 = new Location("15", 0);

            Transition transition1 = new Transition("5", new List<Arc>() {
            new Arc(1, "TL", location5),
            new Arc(1, "LT", location0)
        });
            transitionList.Add(transition1);

            Transition transition2 = new Transition("5", new List<Arc>() {
            new Arc(1, "TL", location10),
            new Arc(1, "LT", location5)
        });
            transitionList.Add(transition2);

            Transition transition3 = new Transition("5", new List<Arc>() {
            new Arc(1, "TL", location15),
            new Arc(1, "LT", location10)
        });
            transitionList.Add(transition3);

            Transition transition4 = new Transition("10", new List<Arc>() {
            new Arc(1, "TL", location10),
            new Arc(1, "LT", location0)
        });
            transitionList.Add(transition4);

            Transition transition5 = new Transition("10", new List<Arc>() {
            new Arc(1, "TL", location15),
            new Arc(1, "LT", location5)
        });
            transitionList.Add(transition5);

            Transition transition6 = new Transition("-5", new List<Arc>() {
            new Arc(1, "TL", location0),
            new Arc(1, "LT", location5)
        });
            transitionList.Add(transition6);

            Transition transition7 = new Transition("-5", new List<Arc>() {
            new Arc(1, "TL", location5),
            new Arc(1, "LT", location10)
        });
            transitionList.Add(transition7);

            Transition transition8 = new Transition("-5", new List<Arc>() {
            new Arc(1, "TL", location10),
            new Arc(1, "LT", location15)
        });
            transitionList.Add(transition8);

            Transition transition9 = new Transition("-10", new List<Arc>() {
            new Arc(1, "TL", location0),
            new Arc(1, "LT", location10)
        });
            transitionList.Add(transition9);

            Transition transition10 = new Transition("-10", new List<Arc>() {
            new Arc(1, "TL", location5),
            new Arc(1, "LT", location15)
        });
            transitionList.Add(transition10);

            Transition transition11 = new Transition("-15", new List<Arc>() {
            new Arc(1, "TL", location0),
            new Arc(1, "LT", location15)
        });
            transitionList.Add(transition11);
        }
    }
}
