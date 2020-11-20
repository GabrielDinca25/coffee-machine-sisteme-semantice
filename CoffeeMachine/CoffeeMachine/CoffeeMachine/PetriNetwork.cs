using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public abstract class PetriNetwork
    {
        protected List<Transition> transitionList = new List<Transition>();

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

        public bool Execute(String tag)
        {
            List<Transition> validTransitions = new List<Transition>();

            foreach (Transition transition in transitionList)
            {
                if (transition._tag.Equals(tag) && transition.IsValid())
                {
                    validTransitions.Add(transition);
                }
            }

            if (validTransitions.Count == 0)
            {
                return false;
            }

            foreach (Transition transition in validTransitions)
            {
                transition.UpdateTransition();
            }

            Console.WriteLine("Current State: " + GetCurrentState());

            return true;
        }
    }
}
