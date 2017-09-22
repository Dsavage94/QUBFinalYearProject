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
    public partial class TimetableLab1 : Form
    {
        Form previousForm;
        bool BackButtonPressed = false;
        public TimetableLab1(Form sender)
        {
            InitializeComponent();
            previousForm = sender;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StartMenu SM1 = new StartMenu();
            SM1.Show();
            BackButtonPressed = true;
            this.Hide();
        }

        private void TimetableLab1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BackButtonPressed)
            { }
            else
            { Application.Exit(); }
        }

        private void TimetableLab1_Load(object sender, EventArgs e)
        {
            this.tblbookingsTableAdapter.Fill(this.dsavage11DataSet.tblbookings);
            this.tblcomputersTableAdapter.Fill(this.dsavage11DataSet.tblcomputers);
            colourTheButtons(btnCWTimeSlot1);
            colourTheButtons(btnCWTimeSlot2);
            colourTheButtons(btnCWTimeSlot3);
            colourTheButtons(btnCWTimeSlot4);
            colourTheButtons(btnCWTimeSlot5);
            colourTheButtons(btnCWTimeSlot6);
            colourTheButtons(btnCWTimeSlot7);
            colourTheButtons(btnCWTimeSlot8);
            colourTheButtons(btnCWTimeSlot9);
            colourTheButtons(btnCWTimeSlot10);
            colourTheButtons(btnCWTimeSlot11);
            colourTheButtons(btnCWTimeSlot12);
            colourTheButtons(btnCWTimeSlot13);
            colourTheButtons(btnCWTimeSlot14);
            colourTheButtons(btnCWTimeSlot15);
            colourTheButtons(btnCWTimeSlot16);
            colourTheButtons(btnCWTimeSlot17);
            colourTheButtons(btnCWTimeSlot18);
            colourTheButtons(btnCWTimeSlot19);
            colourTheButtons(btnCWTimeSlot20);
            colourTheButtons(btnCWTimeSlot21);
            colourTheButtons(btnCWTimeSlot22);
            colourTheButtons(btnCWTimeSlot23);
            colourTheButtons(btnCWTimeSlot24);
            colourTheButtons(btnCWTimeSlot25);
            colourTheButtons(btnCWTimeSlot26);
            colourTheButtons(btnCWTimeSlot27);
            colourTheButtons(btnCWTimeSlot28);
            colourTheButtons(btnCWTimeSlot29);
            colourTheButtons(btnCWTimeSlot30);
            colourTheButtons(btnCWTimeSlot31);
            colourTheButtons(btnCWTimeSlot32);
            colourTheButtons(btnCWTimeSlot33);
            colourTheButtons(btnCWTimeSlot34);
            colourTheButtons(btnCWTimeSlot35);
            colourTheButtons(btnCWTimeSlot36);
            colourTheButtons(btnCWTimeSlot37);
            colourTheButtons(btnCWTimeSlot38);
            colourTheButtons(btnCWTimeSlot39);
            colourTheButtons(btnCWTimeSlot40);
            colourTheButtons(btnCWTimeSlot41);
            colourTheButtons(btnCWTimeSlot42);
            colourTheButtons(btnCWTimeSlot43);
            colourTheButtons(btnCWTimeSlot44);
            colourTheButtons(btnCWTimeSlot45);
            colourTheButtons(btnCWTimeSlot46);
            colourTheButtons(btnCWTimeSlot47);
            colourTheButtons(btnCWTimeSlot48);
            colourTheButtons(btnCWTimeSlot49);
            colourTheButtons(btnCWTimeSlot50);
            colourTheButtons(btnNWTimeSlot51);
            colourTheButtons(btnNWTimeSlot52);
            colourTheButtons(btnNWTimeSlot53);
            colourTheButtons(btnNWTimeSlot54);
            colourTheButtons(btnNWTimeSlot55);
            colourTheButtons(btnNWTimeSlot56);
            colourTheButtons(btnNWTimeSlot57);
            colourTheButtons(btnNWTimeSlot58);
            colourTheButtons(btnNWTimeSlot59);
            colourTheButtons(btnNWTimeSlot60);
            colourTheButtons(btnNWTimeSlot61);
            colourTheButtons(btnNWTimeSlot62);
            colourTheButtons(btnNWTimeSlot63);
            colourTheButtons(btnNWTimeSlot64);
            colourTheButtons(btnNWTimeSlot65);
            colourTheButtons(btnNWTimeSlot66);
            colourTheButtons(btnNWTimeSlot67);
            colourTheButtons(btnNWTimeSlot68);
            colourTheButtons(btnNWTimeSlot69);
            colourTheButtons(btnNWTimeSlot70);
            colourTheButtons(btnNWTimeSlot71);
            colourTheButtons(btnNWTimeSlot72);
            colourTheButtons(btnNWTimeSlot73);
            colourTheButtons(btnNWTimeSlot74);
            colourTheButtons(btnNWTimeSlot75);
            colourTheButtons(btnNWTimeSlot76);
            colourTheButtons(btnNWTimeSlot77);
            colourTheButtons(btnNWTimeSlot78);
            colourTheButtons(btnNWTimeSlot79);
            colourTheButtons(btnNWTimeSlot80);
            colourTheButtons(btnNWTimeSlot81);
            colourTheButtons(btnNWTimeSlot82);
            colourTheButtons(btnNWTimeSlot83);
            colourTheButtons(btnNWTimeSlot84);
            colourTheButtons(btnNWTimeSlot85);
            colourTheButtons(btnNWTimeSlot86);
            colourTheButtons(btnNWTimeSlot87);
            colourTheButtons(btnNWTimeSlot88);
            colourTheButtons(btnNWTimeSlot89);
            colourTheButtons(btnNWTimeSlot90);
            colourTheButtons(btnNWTimeSlot91);
            colourTheButtons(btnNWTimeSlot92);
            colourTheButtons(btnNWTimeSlot93);
            colourTheButtons(btnNWTimeSlot94);
            colourTheButtons(btnNWTimeSlot95);
            colourTheButtons(btnNWTimeSlot96);
            colourTheButtons(btnNWTimeSlot97);
            colourTheButtons(btnNWTimeSlot98);
            colourTheButtons(btnNWTimeSlot99);
            colourTheButtons(btnNWTimeSlot100);
        }

        private void colourTheButtons(Button currentButton)
        {
            DataTable dtBookings = dsavage11DataSet.tblbookings;
            DataTable dtComputers = dsavage11DataSet.tblcomputers;
            int currentTimeSlot;
            currentTimeSlot = Convert.ToInt32((currentButton.Name.Substring(13)));
            int Lab1ComputerIndex = 0;
            int currentLabPercentage = 0;
            string[] strLab1Computers = new string[150];
            int numberOfBookedComputers = 0;
            foreach (DataRow row in dtComputers.Rows)
            {
                if (row["idLab"].ToString() == "LAB001")
                {
                    strLab1Computers[Lab1ComputerIndex] = row["idComputer"].ToString();
                    Lab1ComputerIndex++;
                }

            }
            Lab1ComputerIndex = 0;
            string[,] Lab1Status = new string[150, 4];
            foreach (DataRow row in dtBookings.Rows)
            {
                if (Lab1ComputerIndex <150 && Convert.ToInt32(row["idTimeSlot"]) == currentTimeSlot && row["idComputer"].ToString() == strLab1Computers[Lab1ComputerIndex])
                {
                    Lab1Status[Lab1ComputerIndex, 0] = row["idBookings"].ToString();
                    Lab1Status[Lab1ComputerIndex, 1] = row["idComputer"].ToString();
                    Lab1Status[Lab1ComputerIndex, 2] = row["idTimeslot"].ToString();
                    Lab1Status[Lab1ComputerIndex, 3] = row["Status"].ToString();
                    Lab1ComputerIndex++;
                }

            }
            for (int Lab1StatusIndex = 0; Lab1StatusIndex < Lab1Status.GetLength(0); Lab1StatusIndex++)
            {
                if (Lab1Status[Lab1StatusIndex, 3].ToString() != "Open")
                {
                    numberOfBookedComputers++;
                }
            }
            currentLabPercentage = Convert.ToInt32((numberOfBookedComputers / 1.5));
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            string percentage = "The lab is " + currentLabPercentage + "% booked during this time slot.";
            ToolTip1.SetToolTip(currentButton, percentage);

            if (currentLabPercentage < 10)
            {
                //The Lab for this Time Slot is less than 10% booked
                //currentButton.BackColor = new SolidBrush(Color.Aquamarine);
                //currentButton.BackColor = Color.FromArgb(37, 191, 0);
                currentButton.BackColor = Color.FromArgb(0, 229, 7);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#0EE500");
            }
            else if (currentLabPercentage < 20)
            {
                //The Lab for this Time Slot is between 10% and 20% booked
                //currentButton.BackColor = Color.FromArgb(58, 169, 0);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#37E100");
            }
            else if (currentLabPercentage < 30)
            {
                //The Lab for this Time Slot is between 20% and 30% booked
                //currentButton.BackColor = Color.FromArgb(79, 148, 0);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#60DD00");
            }
            else if (currentLabPercentage < 40)
            {
                //The Lab for this Time Slot is between 30% and 40% booked
                //currentButton.BackColor = Color.FromArgb(101, 127, 0);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#87D900");
            }
            else if (currentLabPercentage < 50)
            {
                //The Lab for this Time Slot is between 40% and 50% booked
                //currentButton.BackColor = Color.FromArgb(122, 106, 0);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#ADD500");
            }
            else if (currentLabPercentage < 60)
            {
                //The Lab for this Time Slot is between 50% and 60% booked
                //currentButton.BackColor = Color.FromArgb(143, 84, 0);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#D1D200");
            }
            else if (currentLabPercentage < 70)
            {
                //The Lab for this Time Slot is between 60% and 70% booked
                //currentButton.BackColor = Color.FromArgb(165, 63, 0);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#CEA800");
            }
            else if (currentLabPercentage < 80)
            {
                //The Lab for this Time Slot is between 70% and 80% booked
                //currentButton.BackColor = Color.FromArgb(186, 42, 0);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#CA7F00");
            }
            else if (currentLabPercentage < 90)
            {
                //The Lab for this Time Slot is between 80% and 90% booked
                //currentButton.BackColor = Color.FromArgb(207, 21, 0);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#C65700");
            }
            else if (currentLabPercentage < 100)
            {
                //The Lab for this Time Slot is between 90% and 100% booked
                //currentButton.BackColor = Color.FromArgb(227, 9, 0);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#C23100");
            }
            else
            {
                //The lab is 100% booked.
                //currentButton.BackColor = Color.FromArgb(255, 0, 0);
                currentButton.BackColor = System.Drawing.ColorTranslator.FromHtml("#BF0C00");
            }

            //}
        }

        private void btnTimeSlotPicked_Click(object sender, EventArgs e)
        {
            Button SelectedButton = (Button)sender;
            int currentTimeSlot;
            currentTimeSlot = Convert.ToInt32((SelectedButton.Name.Substring(13)));
            MapLab1 M1 = new MapLab1(currentTimeSlot, ActiveForm);
            M1.Show();
            this.Hide();
        }
    }
}
