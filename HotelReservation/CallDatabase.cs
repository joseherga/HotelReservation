using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    internal class CallDatabase
    {

        string DatabasePath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hotel_db;Integrated Security=True;Encrypt=False";

        public string GetDatabasePath()
        {
            return DatabasePath;
        }
    }
}
