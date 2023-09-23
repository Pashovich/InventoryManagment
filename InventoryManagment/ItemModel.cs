using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagment
{
    internal class ItemModel
    {
        public int ItemID { get; set; }    
        public string ItemName { get; set; }
        public string Description { get; set; } 
        public int Quantity { get; set; }   
        public decimal Price { get; set; }   

        
        public ItemModel(int itemId, string itemName, string description, int quantity, decimal price)
        {
            ItemID = itemId;
            ItemName = itemName;
            Description = description;
            Quantity = quantity;
            Price = price;
        }

        // Default constructor
        public ItemModel()
        {
            
        }

    }
}
