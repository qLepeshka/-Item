using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using абстрактный_класс_Item.LibraryManagementSystem.Interfaces;

namespace абстрактный_класс_Item.LibraryManagementSystem.Models
{
    public class Book : Item, ICheckable, IReservable
    {
        public string Author { get; set; }
        public string ISBN { get; set; }

        private bool _isCheckedOut;
        private bool _isReserved;

        public Book(int id, string title, int year, string author, string isbn)
            : base(id, title, year)
        {
            Author = author;
            ISBN = isbn;
            _isCheckedOut = false;
            _isReserved = false;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"--- Book Details ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Status: {(IsCheckedOut ? "Checked Out" : (IsReserved ? "Reserved" : "Available"))}");
            Console.WriteLine($"--------------------");
        }

        public bool IsCheckedOut => _isCheckedOut;

        public void CheckOut()
        {
            if (!_isCheckedOut && !_isReserved)
            {
                _isCheckedOut = true;
                Console.WriteLine($"'{Title}' by {Author} has been checked out.");
            }
            else if (_isCheckedOut)
            {
                Console.WriteLine($"'{Title}' is already checked out.");
            }
            else
            {
                Console.WriteLine($"Cannot check out '{Title}'. It is currently reserved.");
            }
        }

    public void Return()
        {
            if (_isCheckedOut)
            {
                _isCheckedOut = false;
                Console.WriteLine($"'{Title}' by {Author} has been returned.");
            }
            else
            {
                Console.WriteLine($"'{Title}' is not currently checked out.");
            }
        }

        // Реализация интерфейса IReservable
        public bool IsReserved => _isReserved;

        public void Reserve()
        {
            if (!_isReserved && !_isCheckedOut)
            {
                _isReserved = true;
                Console.WriteLine($"'{Title}' by {Author} has been reserved.");
            }
            else if (_isReserved)
            {
                Console.WriteLine($"'{Title}' is already reserved.");
            }
            else // _isCheckedOut
            {
                Console.WriteLine($"Cannot reserve '{Title}'. It is currently checked out.");
            }
        }

        public void CancelReservation()
        {
            if (_isReserved)
            {
                _isReserved = false;
                Console.WriteLine($"Reservation for '{Title}' by {Author} has been cancelled.");
            }
            else
            {
                Console.WriteLine($"'{Title}' is not currently reserved.");
            }
        }
    }
}
