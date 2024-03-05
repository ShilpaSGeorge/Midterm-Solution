using CSharpTutorials;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorials
{

    public class InventoryItem
    {

        //Fields
        string name;
        int id;
        double cost;
        int quantity;
        bool isStockAvailable;


        // Properties
        public string ItemName { get { return name; } }
        public int ItemId { get { return id; } }
        public double Price { get { return cost; } set { cost = value; } }
        public int QuantityInStock { get { return quantity; } set { quantity = value; } }

        public bool IsStockAvailable { get { return isStockAvailable; } set { isStockAvailable = value; } }

        // Constructor
        public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
        {
            // TODO: Initialize the properties with the values passed to the constructor.
            name = itemName;
            id = itemId;
            cost = price;
            quantity = quantityInStock;

        }

        InventoryItem[] items = new InventoryItem[10];
        int count = 0;
        // Methods

        public void AddItem(InventoryItem item)
        {
            items[count++] = item;
            PrintDetails();
        }

        // Update the price of the item
        public void UpdatePrice(double newPrice)
        {
            // TODO: Update the item's price with the new price.
            for (int i = 0; i < count; i++)
            {
                items[i].Price = newPrice;
            }
            Console.WriteLine("******Updated Price******");
            PrintDetails();
        }

        // Restock the item
        public void RestockItem(int additionalQuantity)
        {
            // TODO: Increase the item's stock quantity by the additional quantity.
            for (int i = 0; i < count; i++)
            {

                items[i].QuantityInStock += additionalQuantity;
            }
            Console.WriteLine("******Restocked Quantity******");
            PrintDetails();


        }

        // Sell an item
        public void SellItem(int quantitySold)
        {
            // TODO: Decrease the item's stock quantity by the quantity sold.
            // Make sure the stock doesn't go negative.

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("******Sold items quantity******");
                items[i].QuantityInStock -= quantitySold;
                isStockAvailable = true;
                
                PrintDetails();

                if (items[i].QuantityInStock == 0)
                {
                    
                    Console.WriteLine("******No more items for sale!!******");
                    isStockAvailable = false;
                    
                }

                else if (items[i].QuantityInStock < 0)
                {
                 
 
                    Console.WriteLine("******Items can not go below 0******");
                    isStockAvailable = false;
                    items[i].QuantityInStock = 0;

                }

            }

        }

        // Check if an item is in stock

        public bool IsInStock()

        {
            if (isStockAvailable)
            {
                Console.WriteLine("******Stock Available******");
                return true;
            }

            else
            {
                Console.WriteLine("******Stock not Available******");
                return false;
            }

        }

        // Print item details
        public void PrintDetails()
        {
            // TODO: Print the details of the item (name, id, price, and stock quantity).
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Itemname : {items[i].ItemName}\nItemid : {items[i].ItemId}\nPrice : {items[i].Price}\nQuantityInStock : {items[i].QuantityInStock}");
                Console.WriteLine();
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Creating instances of InventoryItem
            InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
            InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);

            // TODO: Implement logic to interact with these objects.
            // Example tasks:
            // 1. Print details of all items.
            // 2. Sell some items and then print the updated details.
            // 3. Restock an item and print the updated details.
            // 4. Check if an item is in stock and print a message accordingly.
            item1.AddItem(item1);
            item2.AddItem(item2);

            Console.WriteLine($"Details of {item1.ItemName}");

            Console.WriteLine($"Enter the new price for {item1.ItemName}:");
            double newPrice = Convert.ToDouble(Console.ReadLine());
            item1.UpdatePrice(newPrice);
            Console.WriteLine($"Enter no: of {item1.ItemName}'s to be added  :");
            int newItems = Convert.ToInt32(Console.ReadLine()); 
            item1.RestockItem(newItems);
            Console.WriteLine($"Enter no: of {item1.ItemName}'s to be sold:");
            int sellItems = Convert.ToInt32(Console.ReadLine());
            item1.SellItem(sellItems);
            item1.IsInStock();
            Console.WriteLine();
           
            Console.WriteLine($"Details of {item2.ItemName}");
            Console.WriteLine($"Enter the new price for {item2.ItemName}:");
            double newPrice2 = Convert.ToDouble(Console.ReadLine());
            item2.UpdatePrice(newPrice2);
            Console.WriteLine($"Enter no: of {item2.ItemName}'s to be added:");
            int newItems2 = Convert.ToInt32(Console.ReadLine());
            item2.RestockItem(newItems2);
            Console.WriteLine($"Enter no: of {item2.ItemName}'s to be sold:");
            int sellItems2 = Convert.ToInt32(Console.ReadLine());
            item2.SellItem(sellItems2);

            item2.IsInStock();


           


        }
    }
}
