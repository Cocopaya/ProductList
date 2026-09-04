using Product_List_Level_1;

List<string> products = [];
bool inventoryOpen = true;

Console.WriteLine("PRODUCT INVENTORY SYSTEM");

while (inventoryOpen)
{
    Console.WriteLine(" ");
    Console.WriteLine("1. Add Products");
    Console.WriteLine("2. View Products");
    Console.WriteLine("3. Search Product");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Statistics");
    Console.WriteLine("6. Exit");
    Console.WriteLine(" ");

    string choice = Console.ReadLine()?.Trim() ?? string.Empty;

    // Add Products
    if (choice == "1")
    {
        List<string> newProducts = Functions.AddProducts(products);

        foreach (string product in newProducts)
        {
            products.Add(product);
        }

        Console.ResetColor();
        continue;
    }

    // View Products
    else if (choice == "2")
    {
        List<string> copy = new List<string>(products);
        Console.WriteLine(" ");
        Console.WriteLine("LIST OF PRODUCTS:");
        Console.WriteLine(" ");

        if (copy.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You haven't added any products yet.");
        }
        else
        {
            copy.Sort();
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (string product in copy)
            {
                Console.WriteLine(product);
            }
        }

        Console.ResetColor();
        continue;
    }

    // Search Product
    else if (choice == "3")
    {
        Console.WriteLine(" ");
        Console.WriteLine("SEARCH PRODUCT:");
        Console.WriteLine(" ");
        string userInput = Console.ReadLine()?.Trim() ?? string.Empty;
        Console.WriteLine(" ");
        bool productFound = false;

        foreach (string product in products)
        {
            if (product.Contains(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Found product: {product}");
                productFound = true;
            }
        }

        if (!productFound)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product not found.");
        }

        Console.ResetColor();
        continue;
    }

    // Delete Product
    else if (choice == "4")
    {
        Console.WriteLine(" ");
        Console.WriteLine("DELETE PRODUCT:");
        Console.WriteLine(" ");
        string userInput = Console.ReadLine()?.Trim() ?? string.Empty;
        Console.WriteLine(" ");
        bool productExists = false;

        foreach (string product in products)
        {
            if (product == userInput)
            {
                products.Remove(product);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Removed product: {userInput}");
                productExists = true;
                break;
            }
        }
        if (!productExists) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Product not found.");
        }
        Console.ResetColor();
        continue;
    }

    // Show statistics
    else if (choice == "5")
    {
        Console.WriteLine(" ");
        Console.WriteLine("STATISTICS:");
        Console.WriteLine(" ");
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
