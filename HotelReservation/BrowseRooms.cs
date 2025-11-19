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
    public partial class BrowseRooms : Form
    {
        public BrowseRooms()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserDashboard userDash = new UserDashboard();
            this.Close();
        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {
        }
    }
}
