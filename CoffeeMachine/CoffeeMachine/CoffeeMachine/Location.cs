using System;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeMachine
{
    public class Location
    {
        public String _tag;
        public int tokens;

        public Location(String tag, int tokens)
        {
            this._tag = tag;
            this.tokens = tokens;
        }
    }
}
