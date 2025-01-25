using System;
using System.Collections.Generic;
using System.Linq;

namespace Mission3
{
    class Program
    {
        // Stores all the food items in memory
        static List<FoodItem> foodItems = new List<FoodItem>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n Welcome! Food Bank!");
                Console.WriteLine("1.Add Food Item");
                Console.WriteLine("2.Delete Food Item");
                Console.WriteLine("3.Print List of Current Food Items");
                Console.WriteLine("4.Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                
                // this is like an if statement 
                switch (choice)
                {
                    case "1":
                        AddFoodItem();
                        break;
                    case "2":
                        DeleteFoodItem();
                        break;
                    case "3":
                        PrintFoodItems();
                        break;
                    case "4":
                        Console.WriteLine("Thank you. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddFoodItem()
        {
            try
            {
                Console.Write("Enter food name: ");
                string name = Console.ReadLine();

                Console.Write("Enter category: ");
                string category = Console.ReadLine();

                Console.Write("Enter quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    return;
                }

                Console.Write("Enter expiration date (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime expirationDate))
                {
                    Console.WriteLine("Invalid date format. Use yyyy-MM-dd.");
                    return;
                }

                FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
                foodItems.Add(newItem);
                Console.WriteLine("Food item added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        
        // i need this so i can find a food item by name and delete it from the list
        static void DeleteFoodItem()
        {
            Console.Write("Enter the name of the food item to delete: ");
            string name = Console.ReadLine();

            FoodItem itemToRemove = foodItems.FirstOrDefault(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (itemToRemove != null)
            {
                foodItems.Remove(itemToRemove);
                Console.WriteLine("Food item deleted successfully.");
            }
            else
            {
                Console.WriteLine("Food item not found.");
            }
        }

        // Loops through the list and prints all food items using their ToString method
        static void PrintFoodItems()
        {
            if (foodItems.Count == 0)
            {
                Console.WriteLine("No food items in inventory.");
                return;
            }

            Console.WriteLine("\nCurrent Food Items:");
            foreach (var item in foodItems)
            {
                Console.WriteLine(item);
            }
        }
    }
}
