using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Arc
    {
        public int capacity;
        public String direction;
        public Location location;

        public Arc(int capacity, String direction, Location location)
        {
            this.capacity = capacity;
            this.direction = direction;
            this.location = location;
        }

        public bool IsValid()
        {
            if (direction.Equals("TL"))
            {
                return true;
            }
            else
            {
                return (capacity <= location.tokens);
            }
        }

        public void UpdateArc()
        {
            if (direction.Equals("LT"))
            {
                location.tokens -= capacity;
            }
            else
            {
                location.tokens += capacity;
            }
        }
    }
}
