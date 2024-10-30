using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Timetable_System
{
    public partial class choseValues : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Timetable System\TimetableSystemDB.mdf;Integrated Security=True;Connect Timeout=30");

        public choseValues()
        {
            InitializeComponent();
        }

        public Lecture lecture { get; set; }

        private void choseValues_Load(object sender, EventArgs e)
        {
            lecID = -1;
            hallID = -1;
            courseID = -1;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from [dbo].[Lecturer] where lectFullName like '%" + guna2TextBox1.Text + "%'", conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gunaDataGridView1.DataSource = dt;
            conn.Close();
        }

        private int lecID = -1;
        private int hallID = -1;
        private int courseID = -1;

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            if (!(lecID == -1 || hallID == -1 || courseID == -1))
            {
                lecture.LecID = lecID;
                lecture.courseID = courseID;
                lecture.hallID = hallID;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Chose All values");
            }
        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gunaDataGridView1.Rows[e.RowIndex];
                lecID = Convert.ToInt32(row.Cells["id"].Value.ToString());
                gunaLabel3.Text = row.Cells["lectFullName"].Value.ToString();
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from [dbo].[course] where cName like '%" + guna2TextBox1.Text + "%'", conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gunaDataGridView2.DataSource = dt;
            conn.Close();
        }

        private void gunaDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gunaDataGridView2.Rows[e.RowIndex];
                courseID = Convert.ToInt32(row.Cells["id"].Value.ToString());
                gunaLabel4.Text = row.Cells["cName"].Value.ToString();
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from [dbo].[Hall] where hallName like '%" + guna2TextBox1.Text + "%'", conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gunaDataGridView3.DataSource = dt;
            conn.Close();
        }

        private void gunaDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gunaDataGridView3.Rows[e.RowIndex];
                hallID = Convert.ToInt32(row.Cells["id"].Value.ToString());
                gunaLabel8.Text = row.Cells["hallName"].Value.ToString();
            }
        }
    }
}