using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable_System
{
    public class Lecture
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Timetable System\TimetableSystemDB.mdf;Integrated Security=True;Connect Timeout=30");
        public int dayID { get; set; }
        public int periodID { get; set; }
        public int LecID { get; set; }
        public int courseID { get; set; }
        public int hallID { get; set; }

        public string getCourse()
        {
            conn.Open();
            string query = "select cName from [dbo].[course] where id = '" + this.courseID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                string courseName = dt.Rows[0]["cName"].ToString();
                return courseName;
            }
            else
            {
                return "//";
            }
        }

        public string getLecturer()
        {
            conn.Open();
            string query = "select lectFullName from [dbo].[Lecturer] where id = '" + this.LecID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                string lecturerName = dt.Rows[0]["lectFullName"].ToString();
                return lecturerName;
            }
            else
            {
                return "//";
            }
        }

        public string getHall()
        {
            conn.Open();
            string query = "select hallName from [dbo].[Hall] where id = '" + this.hallID + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                string hallName = dt.Rows[0]["hallName"].ToString();
                return hallName;
            }
            else
            {
                return "//";
            }
        }

        public string viewCourse(int dayObs)
        {
            conn.Open();
            string sql = "select courseName from periodObject where dayObs = '" + dayObs + "' and periodID = '" + this.periodID + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                string courseName = dt.Rows[0]["courseName"].ToString();
                return courseName;
            }
            else
            {
                return "//";
            }
        }

        public string viewHall(int dayObs)
        {
            conn.Open();
            string sql = "select hallName from periodObject where dayObs = '" + dayObs + "' and periodID = '" + this.periodID + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                string hallName = dt.Rows[0]["hallName"].ToString();
                return hallName;
            }
            else
            {
                return "//";
            }
        }

        public string viewLecturer(int dayObs)
        {
            conn.Open();
            string sql = "select lectName from periodObject where dayObs = '" + dayObs + "' and periodID = '" + this.periodID + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                string lectName = dt.Rows[0]["lectName"].ToString();
                return lectName;
            }
            else
            {
                return "//";
            }
        }
    }
}