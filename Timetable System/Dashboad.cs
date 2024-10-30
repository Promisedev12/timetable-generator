using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable_System
{
    public partial class Dashboad : Form
    {
        public Dashboad()
        {
            InitializeComponent();
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            lecturer1.Visible = true;
            lecturer1.BringToFront();

            hall1.Visible = false;
            specialty1.Visible = false;
            course1.Visible = false;

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            course1.Visible = true;
            course1.BringToFront();
            hall1.Visible = false;
            specialty1.Visible = false;
            
            lecturer1.Visible = false;
        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            createTimetable dd = new createTimetable();
            dd.Show();
            this.Hide();
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            specialty1.Visible = true;
            specialty1.BringToFront();
            hall1.Visible = false;
            
            course1.Visible = false;
            lecturer1.Visible = false;
        }

        private void lecturer1_Load(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            hall1.Visible = true;
            hall1.BringToFront();
            specialty1.Visible = false;
            course1.Visible = false;
            lecturer1.Visible = false;
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {

            this.Hide();
            managetimetable dd = new managetimetable();
            dd.Show();
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton8_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton9_Click(object sender, EventArgs e)
        {

        }

        private void Dashboad_Load(object sender, EventArgs e)
        {
            hall1.Visible = false;
            specialty1.Visible = false;
            course1.Visible = false;
            lecturer1.Visible = false;
        }

        private void lecturer1_Load_1(object sender, EventArgs e)
        {

        }

        private void timetableview1_Load(object sender, EventArgs e)
        {

        }
    }
}
