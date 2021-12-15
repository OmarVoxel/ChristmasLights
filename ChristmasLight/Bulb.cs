using System;

namespace ChristmasLight
{
    public class Bulb
    {
        private int _bulb;
        
        public int Status() => _bulb;
        public void TurnOn() => _bulb = 1;
        public void TurnOff() => _bulb = 0;
        public void Toggle() => _bulb = _bulb == 1 ? 0 : 1;
    }
}