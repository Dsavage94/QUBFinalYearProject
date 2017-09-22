using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Year_Project_Application
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void btnLab1Timetable_Click(object sender, EventArgs e)
        {
            TimetableLab1 T1 = new TimetableLab1(ActiveForm);
            T1.Show();
            this.Hide();
        }

        private void btnLab2Timetable_Click(object sender, EventArgs e)
        {
            TimetableLab2 T2 = new TimetableLab2(ActiveForm);
            T2.Show();
            this.Hide();
        }

        private void StartMenu_Load(object sender, EventArgs e)
        {

        }

        private void StartMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
              Application.Exit(); 
        }

        private void btnLabClassesGen_Click(object sender, EventArgs e)
        {
            ModuleTimetableGeneration MTG = new ModuleTimetableGeneration(ActiveForm);
            MTG.Show();
            this.Hide();
        }
    }
}
