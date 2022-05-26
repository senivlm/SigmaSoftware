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
                array[i] = generator.Next(a, b+1);
            }
        }

        public static bool IsPolindrom(int[] arr)
        {
            bool result = arr.Length>0;
            for (int i = 0; i < arr.Length/2; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1]) {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static int[] GetMaxSequence(int[] arr)
        {
            int j = 0;
            int maxvalue = 0;
            int curvalue = 0;

            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                curvalue = 1;
                for (j = i; j < arr.Length - 1; j++)
                {
                    if (arr[j] + 1 == arr[j + 1])
                    {
                        curvalue++;
                    }
                    else { break; }
                }
                if (maxvalue < curvalue)
                    {
                    index = i;
                    maxvalue = curvalue;
                    };
            }

            int[] result = new int[maxvalue];
            for (j = 0; j < maxvalue; j++)
            {
                result[j] = arr[index + j];
            }

            return result;
        }

        public void ReversMyImpl()
        {
            int buffer;
            for (int i = 0; i < array.Length / 2; i++)
            {
                buffer = array[array.Length - i - 1];
                array[array.Length - i - 1] = array[i];
                array[i] = buffer;

            }
        }

        public void ReversStandart()
        {
            Array.Reverse(array);
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

                for (int j = 0; j < pairs.Length; j++)
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
            return GetStringFromArray(array);

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

        public static String GetStringFromArray(int[] arr)
        {
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                result = result + arr[i];
                if (i < arr.Length - 1)
                {
                    result = result + ',';
                }
                
            }
            return result;

        }

        public void BubleSort()
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; i < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j - 1]) ;
                    {
                        int buf = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = buf;
                    }             
                }
            }
        }

        public void CountingSort()
        {
            int max = array[0];
           
            for (int i = 1; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                }
               
            }

            int[] newarray = new int[max+1];
            for (int i = 0; i < array.Length; i++)
            {
                newarray[array[i]]++;
            }

            int k = 0;
            for (int i = 0; i < max+1; i++)
            {
                for (int j = 0; j < newarray[i]; j++)
                {
                    array[k] = i;
                    k++;
                };
            }

        }

        public void RecSort()
        {
            int max = array[0];

        }

    }

}
