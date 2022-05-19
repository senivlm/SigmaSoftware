using System;
namespace learning1
{
    class Check
    {
        Buy[] arr;
        public Check()
        {
            arr = new Buy[0];
        }

        public void add(Buy buy)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length -1] = (buy);
        }

        public void print()
        {
            double weight = 0;
            double cost = 0;

            Console.WriteLine("CHECK");
            for (int i = 0; i < arr.Length; i++)
            {
                weight = weight + arr[i].Wight();
                cost = cost + arr[i].Cost();
                Console.WriteLine(arr[i].Cost().ToString());
                Console.WriteLine(arr[i].Position() + " - " + arr[i].Qty().ToString());
                Console.WriteLine( arr[i].Cost().ToString());

            }

            Console.WriteLine("Full cost -" + cost.ToString());
            Console.WriteLine("Full weight - "+ weight.ToString());


        }
    }

}

