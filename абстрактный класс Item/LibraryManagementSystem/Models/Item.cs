using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace абстрактный_класс_Item.LibraryManagementSystem.Models
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public Item(int id, string title, int year)
        {
            Id = id;
            Title = title;
            Year = year;
        }
        public abstract void DisplayInfo();
    }
}
