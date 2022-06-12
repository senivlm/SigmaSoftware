using System;
using System.IO;

namespace Lesson7
{
    public class Vector
    {
        private int[] array;


        public Vector(int n)
        {
            array = new int[n];
        }

        public void InitRandom(int a, int b)
        {
            Random generator = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = generator.Next(a, b + 1);
            }
        }

        public static bool IsPolindrom(int[] arr)
        {
            bool result = arr.Length > 0;
            for (int i = 0; i < arr.Length / 2; i++)
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

            int[] newarray = new int[max + 1];
            for (int i = 0; i < array.Length; i++)
            {
                newarray[array[i]]++;
            }

            int k = 0;
            for (int i = 0; i < max + 1; i++)
            {
                for (int j = 0; j < newarray[i]; j++)
                {
                    array[k] = i;
                    k++;
                };
            }

        }






        int PartitionMax(int[] array, int minIndex, int maxIndex)
        {
            //pivot max
            int buf;
            int pivot = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    buf = array[pivot];
                    array[pivot] = array[i];
                    array[i] = buf;
                }
            }
            pivot++;
            buf = array[pivot];
            array[pivot] = array[maxIndex];
            array[maxIndex] = buf;
            return pivot;
        }

        int PartitionMin(int[] array, int minIndex, int maxIndex)
        {
            //pivot min
            int buf;
            int pivot = minIndex;
            int left = minIndex;
            int right = maxIndex;
            while (left < right)
            {
                if (array[left] > array[pivot])
                {
                    while (array[right] > array[pivot] & array[right] < array[left])
                    {
                        right--;
                        if (right <= left) { break; }
                    }
                    buf = array[right];
                    array[right] = array[left];
                    array[left] = buf;
                }
                left++;

            }
            buf = array[right];
            array[right] = array[pivot];
            array[pivot] = buf;
            pivot = right;
            return pivot;
        }

        void QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex < maxIndex)
            {
                var pivotIndex = PartitionMin(array, minIndex, maxIndex);
                QuickSort(array, minIndex, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, maxIndex);
            }

        }

        public void QuickSort()
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public void RecSort()
        {
            int max = array[0];

        }

        public void marge(int left, int q, int right)
        {
            bool change = true;
            while (change)
            {
                change = false;
                for (int i = left; i <= q; i++)
                {
                    for (int j = right; j > q; j--)
                    {
                        if (array[i] > array[j])
                        {
                            int buf = array[j];

                            array[j] = array[i];

                            array[i] = buf;

                            change = true;
                            i = q;
                            break;
                        }
                    }
                }
            }

        }

        private void marge2(int l, int q, int r)
        {
            int i = l, j = q + 1;
            int[] temp = new int[r - l + 1];
            bool change = true;

        }

        public void ReadFromFile(String filename)
        {
            StreamReader reader = new StreamReader(filename);
            string[] splited = reader.ReadToEnd().Split(',');
            array = new int[splited.Length];
            for (int i = 0; i < splited.Length; i++)
            {
                array[i] = int.Parse(splited[i]);
            }
        }

        public void SplitMargeSort()
        {
            SplitMargeSort(0, array.Length - 1);
        }
        private void SplitMargeSort(int start, int end)
        {
            int middle = (start + end) / 2;
            if (end > start + 1)
            {
                SplitMargeSort(start, middle);
                SplitMargeSort(middle + 1, end);
            }
            marge(start, middle, end);
        }

        public void PiramidSort()
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                puttoheap(array, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                puttoheap(array, i, 0);
            }
        }

        void puttoheap(int[] arr, int n, int i)
        {
            int max = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && arr[l] > arr[max])
                max = l;

            if (r < n && arr[r] > arr[max])
                max = r;

            if (max != i)
            {
                int temp = arr[i];
                arr[i] = arr[max];
                arr[max] = temp;

                puttoheap(arr, n, max);
            }
        }

        public int summa()
        {
            int summa = 0;
            foreach (int i in array)
            {
                summa += i;
            }
            return summa;
        }

        public static bool operator >(Vector a, Vector b)
        {
            return a.array.Length > b.array.Length;
        }

        public static bool operator <(Vector a, Vector b)
        {
            return a.array.Length < b.array.Length;
        }



        public static Vector operator+(Vector a, int b)
        {
            Vector c = new Vector(a.array.Length);
            for (int i = 0; i < a.array.Length; i++)
            {
                c.array[i] = a.array[i] + b;
            }
            return c;
        }

        public static implicit operator Vector(int i)
        {
            Vector a = new Vector(1);
            a[0] = i;
            return a;
        }

        public static implicit operator int(Vector a)
        {
            return a[0];
        }

        public static int operator+(Vector a, Vector b) 
        {
            return a.summa() + b.summa();
        }

        //public static Vector operator+(Vector a, Vector b) 
        //{
           
        //    if (a.array.Length > b.array.Length)
        //    {
        //        (a,b) = (b,a);
        //    }
            
        //    Vector c = new Vector(b.array.Length);

        //    for (int i = 0; i < a.array.Length; i++)
        //    {
        //        c.array[i] = a.array[i]+ b.array[i];
        //    }

        //    for (int i = a.array.Length; i < b.array.Length; i++)
        //    {
        //        c.array[i] = b.array[i];
        //    }
        //    return c;

        //    //for (int i = 0; i < a.array.Length; i++)
        //    //{
        //    //    c.array[i] += a.array[i];
        //    //}

        //    //for (int i = 0; i < b.array.Length; i++)
        //    //{
        //    //    c.array[i] += b.array[i];
        //    //}

        //    //for (int i = 0; i < lengthRes; i++)
        //    //{
        //    //    if (a.array.Length > i)
        //    //    { c.array[i] += a.array[i]; }

        //    //    if (b.array.Length > i)
        //    //    { c.array[i] += b.array[i]; }
        //    //}

        //}

    }

}
