using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierController 
{
    public class x2Multiplier : IMultiplierStrategy
    {
        public float ApplyMultiplier(float amount)
        {
            return amount * 2;
        }
    }
    public class x3Multiplier : IMultiplierStrategy
    {
        public float ApplyMultiplier(float amount)
        {
            return amount * 3;
        }
    }
    public class x5Multiplier : IMultiplierStrategy
    {
        public float ApplyMultiplier(float amount)
        {
            return amount * 5;
        }
    }
}
