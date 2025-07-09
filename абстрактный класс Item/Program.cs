using System;
using абстрактный_класс_Item.LibraryManagementSystem.Interfaces;
using абстрактный_класс_Item.LibraryManagementSystem.Models;
using абстрактный_класс_Item.LibraryManagementSystem.Services;

namespace абстрактный_класс_Item
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Library myLibrary = new Library();

            Console.WriteLine("--- Section 1: Basic Classes & OOP ---");
            Book book1 = new Book(1, "The Lord of the Rings", 1954, "J.R.R. Tolkien", "978-0618053267");
            Magazine magazine1 = new Magazine(2, "National Geographic", 2023, 10);
            Book book2 = new Book(3, "1984", 1949, "George Orwell", "978-0451524935");
            Magazine magazine2 = new Magazine(4, "Scientific American", 2023, 11);
            Book book3 = new Book(5, "The Hitchhiker's Guide to the Galaxy", 1979, "Douglas Adams", "978-0345391803");

            myLibrary.AddItem(book1);
            myLibrary.AddItem(magazine1);
            myLibrary.AddItem(book2);
            myLibrary.AddItem(magazine2);
            myLibrary.AddItem(book3);

            Console.WriteLine("\nDisplaying info for a book and a magazine:");
            book1.DisplayInfo();
            magazine1.DisplayInfo();

            myLibrary.AddItem(new Book(1, "Duplicate Book", 2000, "Author", "ISBN"));

            Console.WriteLine("\n--- Section 2: Interfaces & Polymorphism ---");
            Console.WriteLine("\n--- Demonstrating Book Interfaces ---");
            ICheckable checkableBook = book1;
            IReservable reservableBook = book1;

            Console.WriteLine($"Is '{book1.Title}' checked out? {checkableBook.IsCheckedOut}");
            Console.WriteLine($"Is '{book1.Title}' reserved? {reservableBook.IsReserved}");

            checkableBook.CheckOut();
            Console.WriteLine($"Is '{book1.Title}' checked out? {checkableBook.IsCheckedOut}");
            checkableBook.CheckOut();
            reservableBook.Reserve();

            checkableBook.Return();
            Console.WriteLine($"Is '{book1.Title}' checked out? {checkableBook.IsCheckedOut}");

            reservableBook.Reserve();
            Console.WriteLine($"Is '{book1.Title}' reserved? {reservableBook.IsReserved}");
            checkableBook.CheckOut();

            reservableBook.CancelReservation();
            Console.WriteLine($"Is '{book1.Title}' reserved? {reservableBook.IsReserved}");

            Console.WriteLine("\n--- Demonstrating Magazine Interfaces ---");
            ICheckable checkableMagazine = magazine1;
            IReservable reservableMagazine = magazine1;

            checkableMagazine.CheckOut();
            reservableMagazine.Reserve();
            checkableMagazine.Return();
            reservableMagazine.Reserve();
            reservableMagazine.CancelReservation();

            Console.WriteLine("\n--- Section 3: Collections & LINQ ---");

            myLibrary.DisplayAllItems();

            Console.WriteLine("\n--- Search by Title (keyword 'the') ---");
            List<Item> searchResults = myLibrary.SearchByTitle("the");
            if (searchResults.Any())
            {
                foreach (var item in searchResults)
                {
                    item.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("No items found matching the keyword.");
            }

            Console.WriteLine("\n--- Items from Year 2023 ---");
            List<Item> items2023 = myLibrary.GetItemsByYear(2023);
            if (items2023.Any())
            {
                foreach (var item in items2023)
                {
                    item.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("No items found from year 2023.");
            }

            Console.WriteLine("\n--- Grouping Items by Year ---");
            var groupedItems = myLibrary.GroupItemsByYear();
            foreach (var group in groupedItems)
            {
                Console.WriteLine($"\nYear: {group.Key}");
                foreach (var item in group)
                {
                    string itemType = item.GetType().Name;
                    Console.WriteLine($"  - [{itemType}] {item.Title}");
                }
            }

            Console.WriteLine("\n--- Removing Item (ID: 2) ---");
            myLibrary.RemoveItem(2);
            myLibrary.RemoveItem(99);
            myLibrary.DisplayAllItems();

            Console.WriteLine("\n--- End of Demonstration ---");
            Console.ReadKey();
        }
    }
}
