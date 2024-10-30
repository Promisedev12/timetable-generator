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

namespace Timetable_System
{
    public partial class managetimetable : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Timetable System\TimetableSystemDB.mdf;Integrated Security=True;Connect Timeout=30");

        public managetimetable()
        {
            InitializeComponent();
        }

        private void managetimetable_Load(object sender, EventArgs e)
        {
            conn.Open();
            string query = "Select * from [dbo].[specialty]";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            guna2ComboBox1.DataSource = dt;
            guna2ComboBox1.DisplayMember = "specialtyName";
            guna2ComboBox1.ValueMember = "id";

            string query1 = "Select week, id from [dbo].[timeTable] order by week desc";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            conn.Close();

            guna2ComboBox2.DataSource = dt1;
            guna2ComboBox2.DisplayMember = "week";
            guna2ComboBox2.ValueMember = "week";
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            int specialtyID = Convert.ToInt32(guna2ComboBox1.SelectedValue.ToString());
            string week = guna2ComboBox2.SelectedValue.ToString();

            conn.Open();
            string query = "Select id from [dbo].[timeTable] where specialty = '" + specialtyID + "' and week = '" + week + "' ";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();

            if (dt.Rows.Count > 0)
            {
                int timetableID = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                timetableview1.loadTimetabel(timetableID);
            }
            else
            {
                MessageBox.Show("No saved timetable found for the selected week and specialty. Go create one");
            }
        }
    }
}