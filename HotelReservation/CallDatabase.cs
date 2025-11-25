using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    internal class CallDatabase
    {

        string DatabasePath = @"Data Source=.\SQLEXPRESS;Initial Catalog=hotel_db;Integrated Security=True";

        public string GetDatabasePath()
        {
            return DatabasePath;
        }
    }
}
