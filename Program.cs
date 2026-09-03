using Product_List_Level_1;

List<string> products = [];
bool inventoryOpen = true;

Console.WriteLine("PRODUCT INVENTORY SYSTEM");

while (inventoryOpen)
{
    Console.WriteLine("1. Add Products");
    Console.WriteLine("2. View Products");
    Console.WriteLine("3. Search Product");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Statistics");
    Console.WriteLine("6. Exit");

    string choice = Console.ReadLine();

    // Add Products
    if (choice == "1")
    {
        List<string> newProducts = Functions.AddProducts(products);

        foreach (string product in newProducts)
        {
            products.Add(product);
        }

        continue;
    }

    // View Products
    else if (choice == "2")
    {
        List<string> copy = new List<string>(products);
        copy.Sort();
        foreach (string product in copy)
        {
            Console.WriteLine(product);
        }

        continue;
    }

    // Search Product
    else if (choice == "3")
    {
        string userInput = Console.ReadLine();
        foreach (string product in products)
        {
            if (product.Contains(userInput))
            {
                Console.WriteLine(product);
            }
        }

        continue;
    }

    // Delete Product
    else if (choice == "4")
    {
        string userInput = Console.ReadLine();
        foreach (string product in products)
        {
            if (product == userInput)
            {
                products.Remove(product);
                Console.WriteLine($"Removed product: {userInput}");
                break;
            }
            else
            {
                Console.WriteLine($"Couldn't find product: {userInput}");
            }
        }

        continue;
    }

    // Show statistics
    else if (choice == "5")
    {
        Console.WriteLine("Statistics");
        Console.WriteLine($"Total Products: {products.Count}");
        int lowestNumber = 500;
        int highestNumber = 0;
        int sum = 0;

        foreach (string product in products)
        {
            string[] parts = product.Split('-');
            int productNumber = Convert.ToInt32(parts[1]);
            if (productNumber < lowestNumber)
            {
                lowestNumber = productNumber;
            }
            if (productNumber > highestNumber)
            {
                highestNumber = productNumber;
            }
            sum += productNumber;
        }

        Console.WriteLine($"Lowest Number: {lowestNumber}");
        Console.WriteLine($"Highest Number: {highestNumber}");
        Console.WriteLine($"Average Number: {sum / products.Count}");
    }

    // Exit Application
    else if (choice == "6")
    {
        inventoryOpen = false;
    }
}

Console.ReadLine();
