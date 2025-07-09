using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using абстрактный_класс_Item.LibraryManagementSystem.Interfaces;

namespace абстрактный_класс_Item.LibraryManagementSystem.Models
{
    public class Magazine : Item, ICheckable, IReservable
    {
        public int IssueNumber { get; set; }

        private bool _isCheckedOut;
        private bool _isReserved;

        public Magazine(int id, string title, int year, int issueNumber)
            : base(id, title, year)
        {
            IssueNumber = issueNumber;
            _isCheckedOut = false;
            _isReserved = false;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"--- Magazine Details ---");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Year: {Year}");
            Console.WriteLine($"Issue Number: {IssueNumber}");
            Console.WriteLine($"Status: {(IsCheckedOut ? "Checked Out" : (IsReserved ? "Reserved" : "Available"))}");
            Console.WriteLine($"------------------------");
        }

        public bool IsCheckedOut => _isCheckedOut;

        public void CheckOut()
        {
            if (!_isCheckedOut && !_isReserved)
            {
                _isCheckedOut = true;
                Console.WriteLine($"Magazine '{Title}' (Issue {IssueNumber}) has been checked out.");
            }
            else if (_isCheckedOut)
            {
                Console.WriteLine($"Magazine '{Title}' (Issue {IssueNumber}) is already checked out.");
            }
            else
            {
                Console.WriteLine($"Cannot check out Magazine '{Title}' (Issue {IssueNumber}). It is currently reserved.");
            }
        }

        public void Return()
        {
            if (_isCheckedOut)
            {
                _isCheckedOut = false;
                Console.WriteLine($"Magazine '{Title}' (Issue {IssueNumber}) has been returned.");
            }
        
        
    else
    {
        Console.WriteLine($"Magazine '{Title}' (Issue {IssueNumber}) is not currently checked out.");
    }
}

public bool IsReserved => _isReserved;

public void Reserve()
{
    if (!_isReserved && !_isCheckedOut)
    {
        _isReserved = true;
        Console.WriteLine($"Magazine '{Title}' (Issue {IssueNumber}) has been reserved.");
    }
    else if (_isReserved)
    {
        Console.WriteLine($"Magazine '{Title}' (Issue {IssueNumber}) is already reserved.");
    }
    else
    {
        Console.WriteLine($"Cannot reserve Magazine '{Title}' (Issue {IssueNumber}). It is currently checked out.");
    }
}

public void CancelReservation()
{
    if (_isReserved)
    {
        _isReserved = false;
        Console.WriteLine($"Reservation for Magazine '{Title}' (Issue {IssueNumber}) has been cancelled.");
    }
    else
    {
        Console.WriteLine($"Magazine '{Title}' (Issue {IssueNumber}) is not currently reserved.");
    }
}
    }
}