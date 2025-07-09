using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace абстрактный_класс_Item.LibraryManagementSystem.Interfaces
{
    public interface IReservable
    {
        bool IsReserved { get; }
        void Reserve();
        void CancelReservation();
    }
}
