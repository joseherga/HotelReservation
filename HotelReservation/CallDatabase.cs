using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    // This class is responsible for storing and providing the database connection string.
    // It acts like a helper so other forms can easily get the path without repeating code.
    internal class CallDatabase
    {
        // Connection string pointing to the SQL Server database (hotel_db).
        // Integrated Security=True means it uses Windows authentication.
        string DatabasePath = @"Data Source=.\SQLEXPRESS;Initial Catalog=hotel_db;Integrated Security=True";

        // Public method to return the database path when needed.
        // Other classes call this to open a connection.
        public string GetDatabasePath()
        {
            return DatabasePath;
        }
    }
}