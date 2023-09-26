using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace InventoryManagment
{
    internal class FileHandler
    {
        private string filePath;

        public FileHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public List<ItemModel> ReadData()
        {
            List<ItemModel> items = new List<ItemModel>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 5)
                        {
                            int id = int.Parse(parts[0]);
                            string name = parts[1];
                            string description = parts[2];
                            int quantity = int.Parse(parts[3]);
                            decimal price = decimal.Parse(parts[4]);

                            ItemModel item = new ItemModel(id, name, description, quantity, price);
                            items.Add(item);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Inventory file not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading data from file: {ex.Message}");
            }

            return items;
        }

        public void WriteData(List<ItemModel> items)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (ItemModel item in items)
                    {
                        string line = $"{item.ItemID},{item.ItemName},{item.Description},{item.Quantity},{item.Price}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing data to file: {ex.Message}");
            }
        }

        public void AddItem(ItemModel newItem, List<ItemModel> currentItems)
        {
            currentItems.Add(newItem);
            WriteData(currentItems);
        }

        public void UpdateItem(ItemModel updatedItem, List<ItemModel> currentItems)
        {
            int index = currentItems.FindIndex(item => item.ItemID == updatedItem.ItemID);
            if (index != -1)
            {
                currentItems[index] = updatedItem;
                WriteData(currentItems);
            }
            else
            {
                Console.WriteLine("Item not found in the inventory.");
            }
        }

        public void DeleteItem(int itemId, List<ItemModel> currentItems)
        {
            int index = currentItems.FindIndex(item => item.ItemID == itemId);
            if (index != -1)
            {
                currentItems.RemoveAt(index);
                WriteData(currentItems);
            }
            else
            {
                Console.WriteLine("Item not found in the inventory.");
            }
        }
    }
}
