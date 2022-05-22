using System;
namespace task3
{
    public class Vector
    {
        int[] array;


        public Vector(int n)
        {
            array = new int[n];
        }

        public void InitRandom(int a, int b)
        {
            Random generator = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = generator.Next(a, b);
            }
        }

        public void InitShufle()
        {
            int r;
            Random generator = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                while (array[i] == 0)
                {
                    r = generator.Next(1, array.Length + 1);
                    for (int j = 0; j < array.Length; j++)
                    {
                        if (array[j] == r)
                        {
                            r = 0;
                            break;
                        }
                    }
                    array[i] = 0;
                }
            }
        }

        public void InitShufle2()
        {
            int r;
            Random generator = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    r = generator.Next(1, array.Length + 1);
                    if (Array.IndexOf(array, r) >= 0)
                    {
                        array[i] = r;
                        break;
                    }

                }
            }
        }

        public Pair[] CalculateFreq()
        {
            Pair[] pairs = new Pair[0];
            for (int i = 0; i < array.Length; i++)
            {
                bool noPair = true;

                for (int j = 0; j < pairs.Length; i++)
                    if (pairs[j].value == array[i])
                    {
                        noPair = false;
                        pairs[j].freq++;
                        break;
                    }

                if (noPair)
                {
                    Array.Resize(ref pairs, pairs.Length + 1);
                    pairs[pairs.Length - 1] = new Pair(1, array[i]);
                }
            }
            return pairs;

        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < array.Length; i++)
            {
                result = result + array[i] + ',';
            }
            return result;

        }

        public int this[int index]
        {
            set
            {
                array[index] = value;

            }
            get
            {
                return array[index];
            }
        }


    }
}
