using System;
using System.Collections.Generic;

namespace task9
{
    public class Dish
    {
        Dictionary<string, int> _ingredients;

        public Dish()
        {
            _ingredients = new Dictionary<string, int>();
        }

        public IEnumerable<string> keys => _ingredients.Keys;

        public int this[String key]
        {
            get => _ingredients[key];
        }

        public void add(String ingr, int weight)
        {
            _ingredients.Add(ingr, weight);
        }
    }
}
