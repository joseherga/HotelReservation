using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    internal class CallDatabase
    {

        string DatabasePath = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\OneDrive\\Documents\\hotel_db\\hotel_db.mdf;Integrated Security=True;Connect Timeout=30";

        public string GetDatabasePath()
        {
            return DatabasePath;
        }

    }

}
