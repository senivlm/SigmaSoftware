using System;
namespace test2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Storage storage = new Storage();
            storage[0] = new Meat("BEEF", 100, Grade.XO, MeatType.Beef);
            storage[1] = new Product("PAPER", 100);
            storage[2] = new DailyProduct("MILK", 100, Term.Weak);
            storage[3] = new DailyProduct("BREAD", 100, Term.Day);
            storage[4] = new Meat("PORK", 100, Grade.VVSOP, MeatType.Pork);

            Console.WriteLine("Input meat name! ");
            String meatName = Console.ReadLine();


            Console.WriteLine("Input meat price!");
            Double meatPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Input meat grade!");
            String meatGrade = Console.ReadLine();

            Console.WriteLine("Input meat type!");
            String meatType = Console.ReadLine();

            object tgrade;
            if (Enum.TryParse(typeof(Grade), meatGrade, true, out tgrade))
            {
                Grade ttgrade = (Grade)Enum.Parse(typeof(Grade), meatGrade);
            }




            storage.PrintMeat();
            storage.IncrisePrice(10);
            storage.Printall();

        }
    }
}
