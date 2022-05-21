using learning1;

Product product1 = new Product("Макароны ");
product1.Price = 20;
product1.Wight = 1;

Product product2 = new Product("Мука", 30 , 2);

Buy buy1 = new Buy(product1);
buy1.SetQty(2);

Buy buy2 = new Buy(product2, 3);

Check check = new Check();
check.add(buy1);
check.add(buy2);
check.print();

