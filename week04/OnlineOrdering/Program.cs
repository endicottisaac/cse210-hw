using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple Street", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("Joseph Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LAP-001", 999.99, 1));
        order1.AddProduct(new Product("Wireless Mouse", "MOU-205", 29.99, 2));
        order1.AddProduct(new Product("USB-C Cable", "CAB-103", 15.99, 3));

        Address address2 = new Address("456 Oak Avenue", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Mary Smith", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "KEY-789", 149.99, 1));
        order2.AddProduct(new Product("Monitor Stand", "STD-042", 49.99, 1));

        Console.WriteLine("Order 1");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotal():F2}");
        Console.WriteLine();

        Console.WriteLine("Order 2");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotal():F2}");
    }
}