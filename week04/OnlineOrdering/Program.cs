using System;

class Program
{
    static void Main(string[] args)
    {
        // =========================
        // ORDER 1
        // =========================

        Address address1 = new Address(
            "123 Main Street",
            "Seattle",
            "Washington",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Order order1 = new Order(customer1);

        Product product1 = new Product(
            "Laptop",
            "P001",
            800,
            1
        );

        Product product2 = new Product(
            "Mouse",
            "P002",
            25,
            2
        );

        Product product3 = new Product(
            "Keyboard",
            "P003",
            50,
            1
        );

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // =========================
        // ORDER 2
        // =========================

        Address address2 = new Address(
            "45 Victoria Road",
            "London",
            "England",
            "UK"
        );

        Customer customer2 = new Customer(
            "Mary Johnson",
            address2
        );

        Order order2 = new Order(customer2);

        Product product4 = new Product(
            "Headphones",
            "P004",
            60,
            1
        );

        Product product5 = new Product(
            "Phone Case",
            "P005",
            20,
            2
        );

        Product product6 = new Product(
            "USB Cable",
            "P006",
            10,
            3
        );

        order2.AddProduct(product4);
        order2.AddProduct(product5);
        order2.AddProduct(product6);


        // =========================
        // DISPLAY ORDER 1
        // =========================

        Console.WriteLine("ORDER 1");
        Console.WriteLine();

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");

        Console.WriteLine();
        Console.WriteLine("============================");
        Console.WriteLine();


        // =========================
        // DISPLAY ORDER 2
        // =========================

        Console.WriteLine("ORDER 2");
        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}