using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Timetable_System
{
    public partial class timetableview : UserControl
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Timetable System\TimetableSystemDB.mdf;Integrated Security=True;Connect Timeout=30");

        public timetableview()
        {
            InitializeComponent();
        }

        private void lineShape1_Click(object sender, EventArgs e)
        {
        }

        private void lineShape9_Click(object sender, EventArgs e)
        {
        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
        }

        public Lecture mondayP1 = new Lecture
        {
            dayID = 1,
            periodID = 1
        };

        public Lecture mondayP2 = new Lecture
        {
            dayID = 1,
            periodID = 2
        };

        public Lecture mondayP3 = new Lecture
        {
            dayID = 1,
            periodID = 3
        };

        public Lecture mondayP4 = new Lecture
        {
            dayID = 1,
            periodID = 4
        };

        public Lecture teusdayP1 = new Lecture
        {
            dayID = 2,
            periodID = 1
        };

        public Lecture teusdayP2 = new Lecture
        {
            dayID = 2,
            periodID = 2
        };

        public Lecture teusdayP3 = new Lecture
        {
            dayID = 2,
            periodID = 3
        };

        public Lecture teusdayP4 = new Lecture
        {
            dayID = 2,
            periodID = 4
        };

        public Lecture wednesdayP1 = new Lecture
        {
            dayID = 3,
            periodID = 1
        };

        public Lecture wednesdayP2 = new Lecture
        {
            dayID = 3,
            periodID = 2
        };

        public Lecture wednesdayP3 = new Lecture
        {
            dayID = 3,
            periodID = 3
        };

        public Lecture wednesdayP4 = new Lecture
        {
            dayID = 3,
            periodID = 4
        };

        public Lecture thursdayP1 = new Lecture
        {
            dayID = 4,
            periodID = 1
        };

        public Lecture thursdayP2 = new Lecture
        {
            dayID = 4,
            periodID = 2
        };

        public Lecture thursdayP3 = new Lecture
        {
            dayID = 4,
            periodID = 3
        };

        public Lecture thursdayP4 = new Lecture
        {
            dayID = 4,
            periodID = 4
        };

        public Lecture fridayP1 = new Lecture
        {
            dayID = 5,
            periodID = 1
        };

        public Lecture fridayP2 = new Lecture
        {
            dayID = 5,
            periodID = 2
        };

        public Lecture fridayP3 = new Lecture
        {
            dayID = 5,
            periodID = 3
        };

        public Lecture fridayP4 = new Lecture
        {
            dayID = 5,
            periodID = 4
        };

        public Lecture saturdayP1 = new Lecture
        {
            dayID = 6,
            periodID = 1
        };

        public Lecture saturdayP2 = new Lecture
        {
            dayID = 6,
            periodID = 2
        };

        public Lecture saturdayP3 = new Lecture
        {
            dayID = 6,
            periodID = 3
        };

        public Lecture saturdayP4 = new Lecture
        {
            dayID = 6,
            periodID = 4
        };

        public void loadTimetabel(int timeTableID)
        {
            int[] dayObsIDs = new int[7];

            conn.Open();
            SqlCommand sql = new SqlCommand("select dayID, id from [dbo].[dayObject] where timetableID = @timeTableID order by dayID;", conn);
            sql.Parameters.AddWithValue("@timeTableID", timeTableID);
            SqlDataAdapter adapter = new SqlDataAdapter(sql);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            conn.Close();

            int index = 1;

            foreach (DataRow row in dataTable.Rows)
            {
                if (index < dayObsIDs.Length)
                {
                    dayObsIDs[index] = Convert.ToInt32(row["id"]);
                    index++;
                }
            }
            // setting the values of the courses, lecturer and hall for monday
            gunaLabel20.Text = mondayP1.viewCourse(dayObsIDs[1]);
            gunaLabel21.Text = mondayP1.viewLecturer(dayObsIDs[1]);
            gunaLabel23.Text = mondayP1.viewHall(dayObsIDs[1]);

            gunaLabel47.Text = mondayP2.viewCourse(dayObsIDs[1]);
            gunaLabel46.Text = mondayP2.viewLecturer(dayObsIDs[1]);
            gunaLabel44.Text = mondayP2.viewHall(dayObsIDs[1]);

            gunaLabel71.Text = mondayP3.viewCourse(dayObsIDs[1]);
            gunaLabel70.Text = mondayP3.viewLecturer(dayObsIDs[1]);
            gunaLabel68.Text = mondayP3.viewHall(dayObsIDs[1]);

            gunaLabel95.Text = mondayP4.viewCourse(dayObsIDs[1]);
            gunaLabel94.Text = mondayP4.viewLecturer(dayObsIDs[1]);
            gunaLabel92.Text = mondayP4.viewHall(dayObsIDs[1]);

            // setting the values of the courses, lecturer and hall for Teusday
            gunaLabel27.Text = teusdayP1.viewCourse(dayObsIDs[2]);
            gunaLabel26.Text = teusdayP1.viewLecturer(dayObsIDs[2]);
            gunaLabel24.Text = teusdayP1.viewHall(dayObsIDs[2]);

            gunaLabel51.Text = teusdayP2.viewCourse(dayObsIDs[2]);
            gunaLabel50.Text = teusdayP2.viewLecturer(dayObsIDs[2]);
            gunaLabel48.Text = teusdayP2.viewHall(dayObsIDs[2]);

            gunaLabel75.Text = teusdayP3.viewCourse(dayObsIDs[2]);
            gunaLabel74.Text = teusdayP3.viewLecturer(dayObsIDs[2]);
            gunaLabel72.Text = teusdayP3.viewHall(dayObsIDs[2]);

            gunaLabel99.Text = teusdayP4.viewCourse(dayObsIDs[2]);
            gunaLabel98.Text = teusdayP4.viewLecturer(dayObsIDs[2]);
            gunaLabel96.Text = teusdayP4.viewHall(dayObsIDs[2]);

            // setting the values of the courses, lecturer and hall for wednesday
            gunaLabel31.Text = wednesdayP1.viewCourse(dayObsIDs[3]);
            gunaLabel30.Text = wednesdayP1.viewLecturer(dayObsIDs[3]);
            gunaLabel28.Text = wednesdayP1.viewHall(dayObsIDs[3]);

            gunaLabel55.Text = wednesdayP2.viewCourse(dayObsIDs[3]);
            gunaLabel54.Text = wednesdayP2.viewLecturer(dayObsIDs[3]);
            gunaLabel52.Text = wednesdayP2.viewHall(dayObsIDs[3]);

            gunaLabel79.Text = wednesdayP3.viewCourse(dayObsIDs[3]);
            gunaLabel78.Text = wednesdayP3.viewLecturer(dayObsIDs[3]);
            gunaLabel76.Text = wednesdayP3.viewHall(dayObsIDs[3]);

            gunaLabel103.Text = wednesdayP4.viewCourse(dayObsIDs[3]);
            gunaLabel102.Text = wednesdayP4.viewLecturer(dayObsIDs[3]);
            gunaLabel100.Text = wednesdayP4.viewHall(dayObsIDs[3]);

            // setting the values of the courses, lecturer and hall for thursday

            gunaLabel35.Text = thursdayP1.viewCourse(dayObsIDs[4]);
            gunaLabel34.Text = thursdayP1.viewLecturer(dayObsIDs[4]);
            gunaLabel32.Text = thursdayP1.viewHall(dayObsIDs[4]);

            gunaLabel59.Text = thursdayP2.viewCourse(dayObsIDs[4]);
            gunaLabel58.Text = thursdayP2.viewLecturer(dayObsIDs[4]);
            gunaLabel56.Text = thursdayP2.viewHall(dayObsIDs[4]);

            gunaLabel83.Text = thursdayP3.viewCourse(dayObsIDs[4]);
            gunaLabel82.Text = thursdayP3.viewLecturer(dayObsIDs[4]);
            gunaLabel80.Text = thursdayP3.viewHall(dayObsIDs[4]);

            gunaLabel107.Text = thursdayP4.viewCourse(dayObsIDs[4]);
            gunaLabel106.Text = thursdayP4.viewLecturer(dayObsIDs[4]);
            gunaLabel104.Text = thursdayP4.viewHall(dayObsIDs[4]);

            // setting the values of the courses, lecturer and hall for friday
            gunaLabel39.Text = fridayP1.viewCourse(dayObsIDs[5]);
            gunaLabel38.Text = fridayP1.viewLecturer(dayObsIDs[5]);
            gunaLabel36.Text = fridayP1.viewHall(dayObsIDs[5]);

            gunaLabel63.Text = fridayP2.viewCourse(dayObsIDs[5]);
            gunaLabel62.Text = fridayP2.viewLecturer(dayObsIDs[5]);
            gunaLabel60.Text = fridayP2.viewHall(dayObsIDs[5]);

            gunaLabel87.Text = fridayP3.viewCourse(dayObsIDs[5]);
            gunaLabel86.Text = fridayP3.viewLecturer(dayObsIDs[5]);
            gunaLabel84.Text = fridayP3.viewHall(dayObsIDs[5]);

            gunaLabel111.Text = fridayP4.viewCourse(dayObsIDs[5]);
            gunaLabel110.Text = fridayP4.viewLecturer(dayObsIDs[5]);
            gunaLabel108.Text = fridayP4.viewHall(dayObsIDs[5]);

            // setting the values of the courses, lecturer and hall for saturday
            gunaLabel43.Text = saturdayP1.viewCourse(dayObsIDs[6]);
            gunaLabel42.Text = saturdayP1.viewLecturer(dayObsIDs[6]);
            gunaLabel40.Text = saturdayP1.viewHall(dayObsIDs[6]);

            gunaLabel67.Text = saturdayP2.viewCourse(dayObsIDs[6]);
            gunaLabel66.Text = saturdayP2.viewLecturer(dayObsIDs[6]);
            gunaLabel64.Text = saturdayP2.viewHall(dayObsIDs[6]);

            gunaLabel90.Text = saturdayP3.viewCourse(dayObsIDs[6]);
            gunaLabel90.Text = saturdayP3.viewLecturer(dayObsIDs[6]);
            gunaLabel88.Text = saturdayP3.viewHall(dayObsIDs[6]);

            gunaLabel115.Text = saturdayP4.viewCourse(dayObsIDs[6]);
            gunaLabel114.Text = saturdayP4.viewLecturer(dayObsIDs[6]);
            gunaLabel112.Text = saturdayP4.viewHall(dayObsIDs[6]);
        }

        private void timetableview_Load(object sender, EventArgs e)
        {
        }

        private void gunaLabel24_Click(object sender, EventArgs e)
        {
        }
    }
}