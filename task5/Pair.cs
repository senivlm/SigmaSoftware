using System;
namespace task5
{
    public class Pair
    {
        public int freq;
        public int value;


        public Pair()
        {

        }


        public Pair(int freq, int value)
        {
            this.freq = freq;
            this.value = value;
        }

        public override bool Equals(Object obj)
        {
            try
            {
                Pair pair = (Pair)obj;
                return pair.freq * pair.value == this.freq * this.value;
            }
            catch
            {
                return false;
            }
        }

        public override string ToString()
        {
            return value + " - " + freq;
        }

    }
}
