using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation
{
    public class Connection
    {
        string con;

        public void connect() {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbHotelReserve;Integrated Security=True");
            con.Open();
        }
    }
}
