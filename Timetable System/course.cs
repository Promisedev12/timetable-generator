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
    public partial class course : UserControl
    {

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Timetable System\TimetableSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
        public course()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            if (!(guna2TextBox2.Text == ""))
            {
                //inserting data into database


                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into course (cName) values('" + guna2TextBox2.Text + "' )", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Course added");
                conn.Close();


            }
            else
            {
                MessageBox.Show("Please fill in all fields");
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.guna2DataGridView1.Rows[e.RowIndex];
                currentLecID = Convert.ToInt32(row.Cells["id"].Value.ToString());
                guna2TextBox2.Text = row.Cells["cName"].Value.ToString();


            }
        }
        int currentLecID = 0;

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {
            if (currentLecID != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update course set cName = '" + guna2TextBox2.Text + "' where id = '" + currentLecID + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Course infor Updated");
                currentLecID = 0;
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please Chose a Course to update infor");
            }
        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {
            if (currentLecID != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from course where id = '" + currentLecID + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("course Deleted");
                currentLecID = 0;
                conn.Close();
            }
            else
            {
                MessageBox.Show("Please Chose a course to delete");
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from [dbo].[course] where cName like '%" + guna2TextBox1.Text + "%'", conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            guna2DataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
