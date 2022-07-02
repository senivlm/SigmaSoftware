using System;
using System.Collections.Generic;

namespace task9
{
    public class Menu
    {
        Dictionary<String, Dish> menu;

        public Menu()
        {
            menu = new Dictionary<string, Dish>();
        }

        public IEnumerable<string> keys => menu.Keys;

        public Dish this[string key]
        {
            get => menu[key];
        }

        public void add(string key, Dish dish)
        {
            menu.Add(key, dish);
        }

        public bool HasDish(string key)
        {
            return menu.ContainsKey(key);
        }

        public IEnumerable<string> GetIngredientsForOrder(Order order)
        {
            return GetCalcultionForOrder(order).Keys;
        }

        public Dictionary<String, int> GetCalcultionForOrder(Order order)
        {
            Dictionary<String, int> ingredientsForOrder = new Dictionary<String, int>();
            foreach (string key in order.keys)
            {
                if (!HasDish(key))
                { throw new ArgumentException("No menu for dish -\"" + key + "\""); }

                Dish dish = menu[key];
                foreach (string ingr in dish.keys)
                {
                    if (!ingredientsForOrder.ContainsKey(ingr))
                    {
                        ingredientsForOrder.Add(ingr, 0);
                    }
                    ingredientsForOrder[ingr] += dish[ingr] * order[key];
                }
            }
            return ingredientsForOrder;
        }
    }
}
