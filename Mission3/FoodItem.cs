using System;

namespace Mission3
{
    public class FoodItem
    {
        // these are properties that hold information about a food item
        // The { get; set; } syntax automatically creates getters (to retrieve the value) and setters (to update the value)
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }

        
        // A constructor initializes a new FoodItem object when it’s created
        public FoodItem(string name, string category, int quantity, DateTime expirationDate)
        {
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");
            
            // Parameters (name, category, quantity, expirationDate) are passed to the constructor when creating a new item. Example:
            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }

        // method is used when you want to display it as a string
        public override string ToString()
        {
            return $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration Date: {ExpirationDate:yyyy-MM-dd}";
        }
    }
}