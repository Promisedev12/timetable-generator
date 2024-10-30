using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Timetable_System
{
    public partial class hall : UserControl
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Timetable System\TimetableSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
        public hall()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {

            if (!(guna2TextBox2.Text == ""))
            {
                //inserting data into database


                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Hall (hallName) values('" + guna2TextBox2.Text + "' )", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Hall added");
                conn.Close();


            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }
        int currentLecID = 0;
        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            if (currentLecID != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update Hall set hallName = '" + guna2TextBox2.Text + "' where id = '" + currentLecID + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("hall infor Updated");
                currentLecID = 0;
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please Chose a hall to update infor");
            }
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            if (currentLecID != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from Hall where id = '" + currentLecID + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Hall Deleted");
                currentLecID = 0;
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please Chose a Hall to delete");
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from [dbo].[Hall] where hallName like '%" + guna2TextBox1.Text + "%'", conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            conn.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];
                currentLecID = Convert.ToInt32(row.Cells["id"].Value.ToString());
                guna2TextBox2.Text = row.Cells["hallName"].Value.ToString();


            }
        }
    }
}
