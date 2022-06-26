using System;
using System.Collections.Generic;

namespace task9
{
    public class Order
    {
        Dictionary<String, int> order;

        public Order()
        {
            order = new Dictionary<string, int>();
        }

        public IEnumerable<string> keys => order.Keys;

        public int this[string key]
        {
            get => order[key];
        }

        public void add(string key, int value)
        {
            order.Add(key, value);
        }
    }
}
