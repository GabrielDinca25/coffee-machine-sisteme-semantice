using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Transition
    {
        public String _tag;
        public List<Arc> arcList = new List<Arc>();

        public Transition(String tag, List<Arc> arcList)
        {
            this._tag = tag;
            this.arcList = arcList;
        }

        public bool IsValid()
        {
            foreach (Arc arc in arcList)
            {
                if (arc.IsValid() == false)
                {
                    return false;
                }
            }
            return true;
        }

        public List<Location> GetArcsLocation()
        {
            List<Location> locationList = new List<Location>();
            foreach (Arc arc in arcList)
            {
                locationList.Add(arc.location);
            }
            return locationList;
        }

        public void UpdateTransition()
        {
            foreach (Arc arc in arcList)
            {
                arc.UpdateArc();
            }
        }
    }
}
