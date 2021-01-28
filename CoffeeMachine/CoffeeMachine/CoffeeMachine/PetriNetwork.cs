using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public abstract class PetriNetwork
    {
        protected List<Transition> transitionList = new List<Transition>();

        protected string type;

        public virtual bool Execute(String tag)
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


            return true;
        }

        public virtual void Run()
        {
            Console.WriteLine($"Starting execution of {type} Petri Network");
        }

        public bool IsReveresedTransition(string tag)
        {
            if (tag.StartsWith("-"))
            {
                return true;
            }

            return false;
        }
    }
}
