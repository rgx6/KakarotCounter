using System;

namespace Kakarot
{
    public class Lap
    {
        public DateTime TimeStamp { get; set; }
        public int Rot { get; set; }

        public Lap(int rot)
        {
            TimeStamp = DateTime.Now;
            Rot = rot;
        }
    }
}
