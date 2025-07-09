using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using абстрактный_класс_Item.LibraryManagementSystem.Models;

namespace абстрактный_класс_Item.LibraryManagementSystem.Services
{
    public class Library
    {
        private List<Item> _items;

        public Library()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (item == null)
            {
                Console.WriteLine("Cannot add a null item.");
                return;
            }
            if (_items.Any(i => i.Id == item.Id))
            {
                Console.WriteLine($"Error: Item with ID {item.Id} already exists.");
                return;
            }
            _items.Add(item);
            Console.WriteLine($"Item '{item.Title}' (ID: {item.Id}) added to the library.");
        }

        public void RemoveItem(int id)
        {
            var itemToRemove = _items.FirstOrDefault(i => i.Id == id);
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
                Console.WriteLine($"Item '{itemToRemove.Title}' (ID: {id}) removed from the library.");
            }
            else
            {
                Console.WriteLine($"Error: Item with ID {id} not found.");
            }
        }
        public List<Item> SearchByTitle(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("Search keyword cannot be empty.");
                return new List<Item>();
            }
            return _items.Where(item => item.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Item> GetItemsByYear(int year)
        {
            return _items.Where(item => item.Year == year).ToList();
        }

        public IEnumerable<IGrouping<int, Item>> GroupItemsByYear()
        {
            return _items.GroupBy(item => item.Year);
        }

        public void DisplayAllItems()
        {
            if (!_items.Any())
            {
                Console.WriteLine("\nLibrary is empty.");
                return;
            }
            Console.WriteLine("\n--- All Items in Library ---");
            foreach (var item in _items)
            {
                item.DisplayInfo();
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------\n");
        }
    }
}
