using System;
using System.Collections.Generic;
using System.Text;

namespace Product_List_Level_1
{
    internal class Functions
    {
        public static List<string> AddProducts(List<string> currentList)
        {
            Console.WriteLine("Enter product names");
            Console.WriteLine("Type exit to finish");
            Console.WriteLine("-------------------");

            List<string> newProducts = [];

            while (newProducts.Count < 10)
            {
                string userInput = Console.ReadLine();
                string response = AddProduct(userInput);

                if (response == "exit")
                {
                    break;
                }
                else if (response == userInput)
                {

                    if (newProducts.Contains(userInput) || currentList.Contains(userInput))
                    {
                        Console.WriteLine("WARNING: Product already exists");
                    }
                    else
                    {
                        Console.WriteLine($"Product Added: {response}");
                        newProducts.Add(userInput);
                    }

                    continue;
                }
                else
                {
                    Console.WriteLine(response);
                    continue;
                }
            }
            return newProducts;
        }
        public static string AddProduct(string userInput)
        {
                string[] inputParts = userInput.Split('-');

                if (userInput.ToLower().Trim() == "exit")
                {
                    return "exit";
                }
                if (userInput.Trim().Length == 0)
                {
                    return "Input can not be empty";
                }
                if (!userInput.Contains("-"))
                {
                    return "Product must contain a dash (-)";
                }
                if (!inputParts[0].All(char.IsLetter))
                {
                    return "The left side must contain letters only";
                }
                if (!inputParts[1].All(char.IsDigit))
                {
                    return "The right side must contain numbers only";
                }
                else if (Convert.ToInt32(inputParts[1]) < 200 || (Convert.ToInt32(inputParts[1]) > 500))
                {
                    return "The numeric part must be between 200 and 500";
                }
                else 
                {
                    return userInput;
                }
        } 
    }
}
