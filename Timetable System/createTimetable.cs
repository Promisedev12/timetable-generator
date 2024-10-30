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
    public partial class createTimetable : Form
    {
        private SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Timetable System\TimetableSystemDB.mdf;Integrated Security=True;Connect Timeout=30");

        public createTimetable()
        {
            InitializeComponent();
        }

        // initializing the values for each period for a particular day
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

        private void createTimetable_Load(object sender, EventArgs e)
        {
            //getting the specialties and filling it in the combobox when the form loads
            conn.Open();
            string query = "Select * from [dbo].[specialty]";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conn.Close();

            guna2ComboBox1.DataSource = dt;
            guna2ComboBox1.DisplayMember = "specialtyName";
            guna2ComboBox1.ValueMember = "id";
            gunaButton1.Visible = false;
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            //getting the specialty id from the combobox
            int specialtyID = Convert.ToInt32(guna2ComboBox1.SelectedValue.ToString());

            //getting the week from the various date pickers
            string week = gunaDateTimePicker1.Value.ToString("dd MMMM yyy") + " to " + gunaDateTimePicker2.Value.ToString("dd MMMM yyy");

            //generating a random number for the timetable id
            Random rnd = new Random();
            int timetableID = rnd.Next(100000012, 199999999);

            //inserting the timetable properties into the timeTable table
            conn.Open();
            string query = "insert into timeTable(id, specialty, week) values('" + timetableID + "', '" + specialtyID + "', '" + week + "')";

            SqlCommand cmd1 = new SqlCommand(query, conn);
            cmd1.ExecuteNonQuery();
            conn.Close();

            //array to store the IDs for the dayObsID table
            int[] dayObsIDs = new int[7];

            //generating 6 random numbers for the dayObsID table and inserting into the table and storing in the
            //dayObsIDs array at the same time
            for (int i = 1; i <= 6; i++)
            {
                int dayObsID = rnd.Next(100000012, 199999999);
                insertDayObs(dayObsID, i, timetableID);
                dayObsIDs[i] = dayObsID;
            }

            //inserting periods for monday
            insertPeriod(dayObsIDs[1], mondayP1.periodID, mondayP1.getHall(), mondayP1.getLecturer(), mondayP1.getCourse()
                );
            insertPeriod(dayObsIDs[1], mondayP2.periodID, mondayP2.getHall(), mondayP2.getLecturer(), mondayP2.getCourse()
                );
            insertPeriod(dayObsIDs[1], mondayP3.periodID, mondayP3.getHall(), mondayP3.getLecturer(), mondayP3.getCourse()
                );
            insertPeriod(dayObsIDs[1], mondayP4.periodID, mondayP4.getHall(), mondayP4.getLecturer(), mondayP4.getCourse()
                );

            //inserting periods for teusday
            insertPeriod(dayObsIDs[2], teusdayP1.periodID, teusdayP1.getHall(), teusdayP1.getLecturer(), teusdayP1.getCourse()
                );
            insertPeriod(dayObsIDs[2], teusdayP2.periodID, teusdayP2.getHall(), teusdayP2.getLecturer(), teusdayP2.getCourse()
                );
            insertPeriod(dayObsIDs[2], teusdayP3.periodID, teusdayP3.getHall(), teusdayP3.getLecturer(), teusdayP3.getCourse()
                );
            insertPeriod(dayObsIDs[2], teusdayP4.periodID, teusdayP4.getHall(), teusdayP4.getLecturer(), teusdayP4.getCourse()
                );

            //inserting periods for wednesday
            insertPeriod(dayObsIDs[3], wednesdayP1.periodID, wednesdayP1.getHall(), wednesdayP1.getLecturer(), wednesdayP1.getCourse()
                );
            insertPeriod(dayObsIDs[3], wednesdayP2.periodID, wednesdayP2.getHall(), wednesdayP2.getLecturer(), wednesdayP2.getCourse()
                );
            insertPeriod(dayObsIDs[3], wednesdayP3.periodID, wednesdayP3.getHall(), wednesdayP3.getLecturer(), wednesdayP3.getCourse()
                );
            insertPeriod(dayObsIDs[3], wednesdayP4.periodID, wednesdayP4.getHall(), wednesdayP4.getLecturer(), wednesdayP4.getCourse()
                );

            //inserting periods for thursday
            insertPeriod(dayObsIDs[4], thursdayP1.periodID, thursdayP1.getHall(), thursdayP1.getLecturer(), thursdayP1.getCourse()
                );
            insertPeriod(dayObsIDs[4], thursdayP2.periodID, thursdayP2.getHall(), thursdayP2.getLecturer(), thursdayP2.getCourse()
                );
            insertPeriod(dayObsIDs[4], thursdayP3.periodID, thursdayP3.getHall(), thursdayP3.getLecturer(), thursdayP3.getCourse()
                );
            insertPeriod(dayObsIDs[4], thursdayP4.periodID, thursdayP4.getHall(), thursdayP4.getLecturer(), thursdayP4.getCourse()
                );

            //inserting periods for friday
            insertPeriod(dayObsIDs[5], fridayP1.periodID, fridayP1.getHall(), fridayP1.getLecturer(), fridayP1.getCourse()
                );
            insertPeriod(dayObsIDs[5], fridayP2.periodID, fridayP2.getHall(), fridayP2.getLecturer(), fridayP2.getCourse()
                );
            insertPeriod(dayObsIDs[5], fridayP3.periodID, fridayP3.getHall(), fridayP3.getLecturer(), fridayP3.getCourse()
                );
            insertPeriod(dayObsIDs[5], fridayP4.periodID, fridayP4.getHall(), fridayP4.getLecturer(), fridayP4.getCourse()
                );

            //inserting periods for saturday
            insertPeriod(dayObsIDs[6], saturdayP1.periodID, saturdayP1.getHall(), saturdayP1.getLecturer(), saturdayP1.getCourse()
                );
            insertPeriod(dayObsIDs[6], saturdayP2.periodID, saturdayP2.getHall(), saturdayP2.getLecturer(), saturdayP2.getCourse()
                );
            insertPeriod(dayObsIDs[6], saturdayP3.periodID, saturdayP3.getHall(), saturdayP3.getLecturer(), saturdayP3.getCourse()
                );
            insertPeriod(dayObsIDs[6], saturdayP4.periodID, saturdayP4.getHall(), saturdayP4.getLecturer(), saturdayP4.getCourse()
                );
            MessageBox.Show("Timetable Saved you can now print it or Save PDF");
            gunaButton1.Visible = true;
        }

        //function for to insert the varius values ie hall, course, and lecturer for a pacticular lecture
        //in a particular day
        private void insertPeriod(int dayObsID, int periodId, string hallName, string lectName, string courseName)
        {
            conn.Open();
            string query = "insert into periodObject(dayObs, periodID, hallName, lectName, courseName) values('" + dayObsID + "', '" + periodId + "', '" + hallName + "', '" + lectName + "', '" + courseName + "')";

            SqlCommand cmd1 = new SqlCommand(query, conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }

        //function to insert the day corresponding for a particular timetable
        private void insertDayObs(int dayObsID, int dayId, int timetabeID)
        {
            conn.Open();
            string query = "insert into dayObject(id, dayID, timetableID) values('" + dayObsID + "', '" + dayId + "', '" + timetabeID + "')";

            SqlCommand cmd1 = new SqlCommand(query, conn);
            cmd1.ExecuteNonQuery();
            conn.Close();
        }

        //setting the values for a particular lecture
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (getDetails(mondayP1))
            {
                gunaLabel23.Text = getHall(mondayP1.hallID);
                gunaLabel20.Text = getCourse(mondayP1.courseID);
                gunaLabel21.Text = getLecturer(mondayP1.LecID);
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (getDetails(mondayP2))
            {
                gunaLabel44.Text = getHall(mondayP2.hallID);
                gunaLabel47.Text = getCourse(mondayP2.courseID);
                gunaLabel46.Text = getLecturer(mondayP2.LecID);
            }
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            if (getDetails(mondayP3))
            {
                gunaLabel71.Text = getCourse(mondayP3.courseID);
                gunaLabel68.Text = getHall(mondayP3.hallID);
                gunaLabel70.Text = getLecturer(mondayP3.LecID);
            }
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            if (getDetails(mondayP4))
            {
                gunaLabel95.Text = getCourse(mondayP4.courseID);
                gunaLabel94.Text = getLecturer(mondayP4.LecID);
                gunaLabel92.Text = getHall(mondayP4.hallID);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (getDetails(teusdayP1))
            {
                gunaLabel27.Text = getCourse(teusdayP1.courseID);
                gunaLabel26.Text = getLecturer(teusdayP1.LecID);
                gunaLabel24.Text = getHall(teusdayP1.hallID);
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (getDetails(teusdayP2))
            {
                gunaLabel51.Text = getCourse(teusdayP2.courseID);
                gunaLabel50.Text = getLecturer(teusdayP2.LecID);
                gunaLabel48.Text = getHall(teusdayP2.hallID);
            }
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            if (getDetails(teusdayP3))
            {
                gunaLabel75.Text = getCourse(teusdayP3.courseID);
                gunaLabel74.Text = getLecturer(teusdayP3.LecID);
                gunaLabel72.Text = getHall(teusdayP3.hallID);
            }
        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {
            if (getDetails(teusdayP4))
            {
                gunaLabel99.Text = getCourse(teusdayP4.courseID);
                gunaLabel98.Text = getLecturer(teusdayP4.LecID);
                gunaLabel96.Text = getHall(teusdayP4.hallID);
            }
        }

        //function to to call the form for the user to select the lecturer, course and hall for a particular lecture
        private bool getDetails(Lecture lecture)
        {
            choseValues dd = new choseValues();
            dd.lecture = lecture; // Pass the Lecture object to choseValues
            if (dd.ShowDialog() == DialogResult.OK)
            {
                // Handle when the dialog returns OK
                return true;
            }
            else return false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (getDetails(wednesdayP1))
            {
                gunaLabel31.Text = getCourse(wednesdayP1.courseID);
                gunaLabel30.Text = getLecturer(wednesdayP1.LecID);
                gunaLabel28.Text = getHall(wednesdayP1.hallID);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            if (getDetails(wednesdayP2))
            {
                gunaLabel55.Text = getCourse(wednesdayP2.courseID);
                gunaLabel54.Text = getLecturer(wednesdayP2.LecID);
                gunaLabel52.Text = getHall(wednesdayP2.hallID);
            }
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            if (getDetails(wednesdayP3))
            {
                gunaLabel79.Text = getCourse(wednesdayP3.courseID);
                gunaLabel78.Text = getLecturer(wednesdayP3.LecID);
                gunaLabel76.Text = getHall(wednesdayP3.hallID);
            }
        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {
            if (getDetails(wednesdayP4))
            {
                gunaLabel103.Text = getCourse(wednesdayP4.courseID);
                gunaLabel102.Text = getLecturer(wednesdayP4.LecID);
                gunaLabel100.Text = getHall(wednesdayP4.hallID);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (getDetails(thursdayP1))
            {
                gunaLabel35.Text = getCourse(thursdayP1.courseID);
                gunaLabel34.Text = getLecturer(thursdayP1.LecID);
                gunaLabel32.Text = getHall(thursdayP1.hallID);
            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (getDetails(thursdayP2))
            {
                gunaLabel59.Text = getCourse(thursdayP2.courseID);
                gunaLabel58.Text = getLecturer(thursdayP2.LecID);
                gunaLabel56.Text = getHall(thursdayP2.hallID);
            }
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            if (getDetails(thursdayP3))
            {
                gunaLabel81.Text = getCourse(thursdayP3.courseID);
                gunaLabel82.Text = getLecturer(thursdayP3.LecID);
                gunaLabel80.Text = getHall(thursdayP3.hallID);
            }
        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {
            if (getDetails(thursdayP4))
            {
                gunaLabel107.Text = getCourse(thursdayP4.courseID);
                gunaLabel106.Text = getLecturer(thursdayP4.LecID);
                gunaLabel104.Text = getHall(thursdayP4.hallID);
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (getDetails(fridayP1))
            {
                gunaLabel39.Text = getCourse(fridayP1.courseID);
                gunaLabel38.Text = getLecturer(fridayP1.LecID);
                gunaLabel36.Text = getHall(fridayP1.hallID);
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            if (getDetails(fridayP2))
            {
                gunaLabel63.Text = getCourse(fridayP2.courseID);
                gunaLabel62.Text = getLecturer(fridayP2.LecID);
                gunaLabel60.Text = getHall(fridayP2.hallID);
            }
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            if (getDetails(fridayP3))
            {
                gunaLabel87.Text = getCourse(fridayP3.courseID);
                gunaLabel86.Text = getLecturer(fridayP3.LecID);
                gunaLabel84.Text = getHall(fridayP3.hallID);
            }
        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {
            if (getDetails(fridayP4))
            {
                gunaLabel100.Text = getCourse(fridayP4.courseID);
                gunaLabel110.Text = getLecturer(fridayP4.LecID);
                gunaLabel108.Text = getHall(fridayP4.hallID);
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (getDetails(saturdayP1))
            {
                gunaLabel43.Text = getCourse(saturdayP1.courseID);
                gunaLabel42.Text = getLecturer(saturdayP1.LecID);
                gunaLabel40.Text = getHall(saturdayP1.hallID);
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (getDetails(saturdayP2))
            {
                gunaLabel69.Text = getCourse(saturdayP2.courseID);
                gunaLabel68.Text = getLecturer(saturdayP2.LecID);
                gunaLabel64.Text = getHall(saturdayP2.hallID);
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            if (getDetails(saturdayP3))
            {
                gunaLabel91.Text = getCourse(saturdayP4.courseID);
                gunaLabel90.Text = getLecturer(saturdayP4.LecID);
                gunaLabel88.Text = getHall(saturdayP4.hallID);
            }
        }

        private string getHall(int hallID)
        {
            conn.Open();
            string query = "select hallName from [dbo].[Hall] where id = '" + hallID + "'";
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
                return "";
            }
        }

        //function to get the course name for a course by passing in the id
        private string getCourse(int courseID)
        {
            conn.Open();
            string query = "select cName from [dbo].[course] where id = '" + courseID + "'";
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
                return "";
            }
        }

        //function to get the lecturer  name for a course by passing in the id
        private string getLecturer(int lecturerID)
        {
            conn.Open();
            string query = "select lectFullName from [dbo].[Lecturer] where id = '" + lecturerID + "'";
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
                return "";
            }
        }

        //function to get the hall name for a lecture by passing in the id
        private void guna2Button24_Click(object sender, EventArgs e)
        {
            if (getDetails(saturdayP4))
            {
                gunaLabel115.Text = getCourse(saturdayP4.courseID);
                gunaLabel114.Text = getLecturer(saturdayP4.LecID);
                gunaLabel112.Text = getHall(saturdayP4.hallID);
            }
        }

        private void gunaDateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}