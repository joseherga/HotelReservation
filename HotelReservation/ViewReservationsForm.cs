using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class ViewReservationsForm : Form
    {
        private string Username;
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel_db;Integrated Security=True");
        public ViewReservationsForm(string currentUser )
        {
            InitializeComponent();
        }

        private void ViewReservationsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
