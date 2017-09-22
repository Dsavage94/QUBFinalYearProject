using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Year_Project_Application
{
    public partial class MapLab2 : Form
    {
        int intCurrentTimeSlot = 0;
        Form previousForm;
        public MapLab2(int intTimeSlot, Form sender)
        {
            InitializeComponent();
            intCurrentTimeSlot = intTimeSlot;
            previousForm = sender;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TimetableLab2 T2 = new TimetableLab2(ActiveForm);
            T2.Show();
            this.Hide();
        }

        private void MapLab2_FormClosing(object sender, FormClosingEventArgs e)
        {
             Application.Exit(); 
        }

        private void MapLab2_Load(object sender, EventArgs e)
        {
            if (intCurrentTimeSlot == 0)
            {
                intCurrentTimeSlot = 1;
            }
            this.tblbookingsTableAdapter.Fill(this.dsavage11DataSet.tblbookings);
            DataTable dtBookings = dsavage11DataSet.tblbookings;
            Control[] Lab1ComputerButtons = new Control[200];
            Lab1ComputerButtons = fillButtonArray();
            string[,] LabStatus = new string[200, 2];
            int index = 0;
            int computerIndex = 151;
            for (index = 0; index < LabStatus.GetLength(0); index++)
            {
                
                    LabStatus[index, 0] = "COMP0" + computerIndex + "";
                
                computerIndex++;
            }
            index = 0;
            foreach (DataRow row in dtBookings.Rows)
            {
                if (row.ItemArray[2].ToString() == "11")
                {
                    //label1.Text = "Did someone say breakpoint?";
                }
                if (index < 200 && Convert.ToInt32(row["idTimeSlot"]) == intCurrentTimeSlot && row["idComputer"].ToString() == LabStatus[index, 0])
                {
                    LabStatus[index, 1] = row["Status"].ToString();
                    index++;
                }
            }
            for (index = 0; index < 200; index++)
            {
                if (LabStatus[index, 1].Equals("Open"))
                {
                    //This computer is free, set colour to green
                    Lab1ComputerButtons[index].BackColor = System.Drawing.ColorTranslator.FromHtml("#0EE500");
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    ToolTip1.SetToolTip(Lab1ComputerButtons[index], "Open");
                }
                else if (LabStatus[index, 1].Equals("Private Use"))
                {
                    //This computer has been booked by a student, set colour to yellow and hover over text to "Private Use"
                    Lab1ComputerButtons[index].BackColor = System.Drawing.ColorTranslator.FromHtml("#D1D200");
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    ToolTip1.SetToolTip(Lab1ComputerButtons[index], "Private Use");
                }
                else
                {
                    //This computer has been booked for a class, set colour to red and hover over text to the class
                    Lab1ComputerButtons[index].BackColor = System.Drawing.ColorTranslator.FromHtml("#BF0C00");
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    ToolTip1.SetToolTip(Lab1ComputerButtons[index], LabStatus[index, 1]);
                }
            }
        }

        private Control[] fillButtonArray()
        {
            Control[] Lab1ComputerButtons = new Control[200];
            int computerIndex = 1;
            for (int index = 0; index < 200; index++)
            {
                if (index < 9)
                {
                    Lab1ComputerButtons[index] = findButton("btnComp000" + computerIndex);
                }
                else if (index < 99)
                {
                    Lab1ComputerButtons[index] = findButton("btnComp00" + computerIndex);
                }
                else
                {
                    Lab1ComputerButtons[index] = findButton("btnComp0" + computerIndex);
                }
                computerIndex++;
            }
            return Lab1ComputerButtons;
        }

        private Control findButton(string buttonName)
        {
            Control control = Controls[buttonName];
            if (control != null)
            {
                return control;
            }
            return null; ;
        }

        private void btnComp_Click(object sender, EventArgs e)
        {
            DataTable dtBookings = dsavage11DataSet.tblbookings;
            string strSelectedComputer = ((Button)sender).Name;
            strSelectedComputer = strSelectedComputer.Substring(3);
            int intSelectedComputerNumber = Convert.ToInt32(strSelectedComputer.Substring(4));
            intSelectedComputerNumber = intSelectedComputerNumber + 150;
            strSelectedComputer = "Comp0" + intSelectedComputerNumber.ToString();
            string strSelectedComputerStatus = "";
            foreach (DataRow Row in dtBookings.Rows)
            {
                if (Row[1].ToString().Equals(strSelectedComputer, StringComparison.InvariantCultureIgnoreCase) && Convert.ToInt32(Row[2]) == intCurrentTimeSlot)
                {
                    strSelectedComputerStatus = Row["Status"].ToString();
                }
            }
            if (strSelectedComputerStatus.Equals("Private Use"))
            {
                MessageBox.Show("Sorry but this computer has already been booked by another student for private use.");
            }
            else if (strSelectedComputerStatus.Equals("Open"))
            {
                string strSQL = "";
                if (intCurrentTimeSlot < 10)
                {
                    strSQL = "UPDATE tblbookings SET Status = 'Private Use' WHERE idTimeSlot = '0" + intCurrentTimeSlot + "' AND idComputer = '" + strSelectedComputer + "';";
                }
                else
                {
                    strSQL = "UPDATE tblbookings SET Status = 'Private Use' WHERE idTimeSlot = '" + intCurrentTimeSlot + "' AND idComputer = '" + strSelectedComputer + "';";
                }

                string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
                MySqlConnection sqlConn = new MySqlConnection(connectionString);
                MySqlCommand sqlComm = new MySqlCommand(strSQL, sqlConn);
                try
                {
                    sqlConn.Open();
                    if (sqlConn.State.ToString() == "Open")
                    {
                        sqlComm.ExecuteNonQuery();
                        MessageBox.Show("This computer has now been booked for private use.");
                    }
                    sqlConn.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); };
                ((Button)sender).BackColor = System.Drawing.ColorTranslator.FromHtml("#D1D200");
                System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.SetToolTip(((Button)sender), "Private Use");
            }
            else
            {
                MessageBox.Show("Sorry but this computer has already been booked for " + strSelectedComputerStatus + ".");
            }
        }
    }
}
