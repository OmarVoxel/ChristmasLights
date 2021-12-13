using System;

namespace ChristmasLight
{
    public class Bulb
    {
        private int _bulb;
        
        public int Status() => _bulb;
        public void TurnOn() => _bulb = 1;
    }
}