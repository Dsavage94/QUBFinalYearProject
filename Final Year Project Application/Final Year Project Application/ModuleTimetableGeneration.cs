using System;
using System.Collections;
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


    public partial class ModuleTimetableGeneration : Form
    {
        int RetryCount = 0;
        Form previousForm;
        public ModuleTimetableGeneration(Form sender)
        {
            InitializeComponent();
            previousForm = sender;
        }

        private void ModuleTimetableGeneration_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsavage11DataSet.tbltimeslots' table. You can move, or remove it, as needed.
            this.tbltimeslotsTableAdapter1.Fill(this.dsavage11DataSet.tbltimeslots);
            // TODO: This line of code loads data into the 'dsavage11DataSet.tblmodules' table. You can move, or remove it, as needed.
            this.tblmodulesTableAdapter1.Fill(this.dsavage11DataSet.tblmodules);
            // TODO: This line of code loads data into the 'dsavage11DataSet.tblcomputers' table. You can move, or remove it, as needed.
            this.tblcomputersTableAdapter1.Fill(this.dsavage11DataSet.tblcomputers);
            // TODO: This line of code loads data into the 'dsavage11DataSet.tblbookings' table. You can move, or remove it, as needed.
            this.tblbookingsTableAdapter1.Fill(this.dsavage11DataSet.tblbookings);
            string[] Modules = new string[dsavage11DataSet.tblmodules.Rows.Count];
            int[] intStudentCount = new int[dsavage11DataSet.tblmodules.Rows.Count];
            DataTable dtModules = this.dsavage11DataSet.tblmodules;
            int index = 0;
            foreach (DataRow row in dtModules.Rows)
            {
                Modules[index] = row["Modules"].ToString();
                //ModulesAndStudents[index,] = row["Number Of Students"].ToString();
                intStudentCount[index] = Convert.ToInt32(row["Number Of Students"]);
                index++;
            }
            Dictionary<string, int> practicalClasses = new Dictionary<string, int>();
            //GeneratePracitcalClasses(Modules, intStudentCount, practicalClasses);
            //BookPracitcalClasses(practicalClasses);
            //System.IO.File.WriteAllText(@"L:\FYPProj\FYPProj-master-6d6cb5defa3131c284ed86bfd0a5e0b157c\OutputTest.txt", OutputTest);
        }

        public void GeneratePracitcalClasses(string[] Modules, int[] intStudentCount, Dictionary<string, int> practicalClasses, double thresholdPercentage)
        {
            /*
             * This method starts the booking process by pulling in a list of modules and their student counts and breaking them down into classes that will be assigned a lab to be booked in.
             */
            int index = 0;
            //Create a datatable from the database and store the modules and their student counts in two arrays, then bubble sort them
            DataTable dtModules = this.dsavage11DataSet.tblmodules;
            foreach (DataRow row in dtModules.Rows)
            {
                Modules[index] = row["Modules"].ToString();
                intStudentCount[index] = Convert.ToInt32(row["Number Of Students"]);
                index++;
            }
            index = 0;
            bool flag = true;
            int inttemp = 0;
            string strtemp = "";
            while (flag)
            {
                flag = false;
                for (int forindex = 0; forindex < (intStudentCount.Count() - 1); forindex++)
                {
                    if (intStudentCount[forindex + 1] > intStudentCount[forindex])
                    {
                        inttemp = intStudentCount[forindex];
                        intStudentCount[forindex] = intStudentCount[forindex + 1];
                        intStudentCount[forindex + 1] = inttemp;

                        strtemp = Modules[forindex];
                        Modules[forindex] = Modules[forindex + 1];
                        Modules[forindex + 1] = strtemp;

                        flag = true;
                    }
                }
            }
            //Start breaking the modules down into class groupings
            string currentModule = Modules[index];
            int TotalStudentModuleCount = intStudentCount[index];
            int StudentsRemaing = intStudentCount[index];
            int StudentsAssigned = 0;
            bool ready = false;
            int GroupsIndex = 0;
            int ModulesIndex = 0;
            string tempModule;
            while (!ready)
            {
                ready = true;
                if (StudentsRemaing > (200 * thresholdPercentage)) //If the student count is more than X% of the largest lab, then break it into two classes
                {
                    StudentsRemaing = StudentsRemaing / 2;
                    ready = false;
                }
                else if (StudentsRemaing > (150 * thresholdPercentage)) //If the student count is less than X% of the largest lab and bigger than X% of the smaller lab, schedule it for lab2
                {
                    GroupsIndex++;
                    tempModule = currentModule + GroupsIndex.ToString();
                    practicalClasses.Add(tempModule, StudentsRemaing);
                    StudentsAssigned += StudentsRemaing;
                    StudentsRemaing = 0;
                    StudentsRemaing = TotalStudentModuleCount - StudentsAssigned;
                    if (StudentsRemaing == 0)
                    {
                        GroupsIndex = 0;
                        ModulesIndex++;
                        if (ModulesIndex < Modules.Count())
                        {
                            currentModule = Modules[ModulesIndex];
                            StudentsRemaing = intStudentCount[ModulesIndex];
                            TotalStudentModuleCount = intStudentCount[ModulesIndex];
                            StudentsAssigned = 0;
                        }
                    }

                    ready = false;
                }
                else //Otherwise the student count must be less than X% of the smaller lab and can be scheduled in it
                {
                    GroupsIndex++;
                    tempModule = currentModule + GroupsIndex.ToString();
                    practicalClasses.Add(tempModule, StudentsRemaing);
                    StudentsAssigned += StudentsRemaing;
                    StudentsRemaing = 0;
                    StudentsRemaing = TotalStudentModuleCount - StudentsAssigned;
                    if (StudentsRemaing == 0)
                    {
                        GroupsIndex = 0;
                        ModulesIndex++;
                        if (ModulesIndex < Modules.Count())
                        {
                            currentModule = Modules[ModulesIndex];
                            StudentsRemaing = intStudentCount[ModulesIndex];
                            TotalStudentModuleCount = intStudentCount[ModulesIndex];
                            StudentsAssigned = 0;
                        }
                    }

                    ready = false;
                }
                if (ModulesIndex >= Modules.Count())
                {
                    ready = true;
                }
            }

        }

        public void BookPracitcalClasses(Dictionary<string, int> practicalClasses, double thresholdPercentage)
        {
            /*
             * This method takes the class groupings and book them into the table
            */
            //Create two arrays to seperately store all the computers in lab1 and lab2, then store the information on the time slots in a 2D array.
            int index = 0;
            int index2 = 0;
            string[] strLab1Computers = new string[150];
            string[] strLab2Computers = new string[200];
            DataTable dtComputers = this.dsavage11DataSet.tblcomputers;
            DataTable dtTimeSlots = this.dsavage11DataSet.tbltimeslots;
            foreach (DataRow row in dtComputers.Rows)
            {
                if (row["idLab"].ToString() == "LAB001")
                {
                    strLab1Computers[index] = row["idComputer"].ToString();
                    index++;
                }
                else
                {
                    strLab2Computers[index2] = row["idComputer"].ToString();
                    index2++;
                }

            }

            string[,] strTimeSlots = new string[((dtTimeSlots.Rows.Count / 2)-10), 3];
            index = 0;
            foreach (DataRow row in dtTimeSlots.Rows)
            {
                if (row["Week"].ToString() == "Current Week" && !(row["idTimeSlot"].ToString().EndsWith("0") || row["idTimeSlot"].ToString().EndsWith("1")))
                {
                    strTimeSlots[index, 0] = row["idTimeslot"].ToString();
                    strTimeSlots[index, 1] = row["Time Slot"].ToString();
                    strTimeSlots[index, 2] = row["Week"].ToString();
                    index++;
                }
            }
            //Take the class groupings out of the dictionary that was used to pass them in and bubble sort them so the biggest class is at the top
            bool flag = true;
            string[,] arrPracticalClasses = new string[practicalClasses.Keys.Count, 2];
            index = 0;
            int forlimit = practicalClasses.Count;
            string tempModuleName = "";
            for (index = 0; index < forlimit; index++)
            {
                tempModuleName = practicalClasses.Keys.First().ToString();
                arrPracticalClasses[index, 0] = tempModuleName.Substring(0, (tempModuleName.Length - 1));
                arrPracticalClasses[index, 1] = practicalClasses.Values.First().ToString();
                practicalClasses.Remove(tempModuleName);
            }
            string tmpModuleGroup;
            string tmpGroupStudentCount;
            while (flag)
            {
                flag = false;
                for (int forindex = 0; forindex < (forlimit - 1); forindex++)
                {
                    if (Convert.ToInt32(arrPracticalClasses[forindex + 1, 1]) > Convert.ToInt32(arrPracticalClasses[forindex, 1]))
                    {
                        tmpModuleGroup = arrPracticalClasses[forindex, 0];
                        arrPracticalClasses[forindex, 0] = arrPracticalClasses[forindex + 1, 0];
                        arrPracticalClasses[forindex + 1, 0] = tmpModuleGroup;

                        tmpGroupStudentCount = arrPracticalClasses[forindex, 1];
                        arrPracticalClasses[forindex, 1] = arrPracticalClasses[forindex + 1, 1];
                        arrPracticalClasses[forindex + 1, 1] = tmpGroupStudentCount;

                        flag = true;
                    }
                }
            }

            RandomiseArrayOrder(strTimeSlots);
            /* Start on the first timeslot ID and if there are not enough computers free, move on to the next
            Start by checking the student count for the group*/
            int LabSelection = 0;
            int TimeSlotIndex = 1;
            int currentTimeSlot = Convert.ToInt32(strTimeSlots[0, 0]);
            int forindex1 = 0;
            int forindex2 = 0;
            bool currentTimeSlotValid = false;
            bool atLeastOneClassFailedBooking = false;
            string[,] arrClassesBookingFailed = new string[arrPracticalClasses.GetLength(0), 2];
            int intClassesFailedIndex = 0;
            //Go through all the classes that need booked
            for (int intBookingIndex = 0; intBookingIndex < arrPracticalClasses.GetLength(0); intBookingIndex++)
            {
                this.tblbookingsTableAdapter1.Fill(this.dsavage11DataSet.tblbookings);
                DataTable dtBookings = dsavage11DataSet.tblbookings;
                currentTimeSlotValid = true;
                //Started at the first time slot in the array of time slots go until the time slot isn't valid
                while (currentTimeSlotValid)
                {
                    //If the TimeSlotIndex is greater than 50 it means that it couldn't be booked in any of the first weeks time slots and as the class schedule shouldn't spread over more than a
                    //week this means the class has failed to be booked. Store it and the amount of student that failed to be booked. If a class for this module has already failed, add the student
                    //counts together.
                    if (TimeSlotIndex >= 50)
                    {
                        //MessageBox.Show("The Class "+arrPracticalClasses[intBookingIndex,0]+" Could Not Be Booked.");
                        bool ModuleAlreadyHasAClassFailedToBook = false;
                        atLeastOneClassFailedBooking = true;
                        currentTimeSlotValid = false;
                        for (int FailedArrayIndex = 0; FailedArrayIndex < arrClassesBookingFailed.GetLength(0); FailedArrayIndex++)
                        {
                            if (arrPracticalClasses[intBookingIndex, 0].Equals(arrClassesBookingFailed[FailedArrayIndex, 0]))
                            {
                                ModuleAlreadyHasAClassFailedToBook = true;
                                arrClassesBookingFailed[FailedArrayIndex, 1] = (Convert.ToInt32(arrClassesBookingFailed[FailedArrayIndex, 1]) + Convert.ToInt32(arrPracticalClasses[intBookingIndex, 1])).ToString();
                            }
                        }
                        if (!ModuleAlreadyHasAClassFailedToBook)
                        {
                            arrClassesBookingFailed[intClassesFailedIndex, 0] = arrPracticalClasses[intBookingIndex, 0];
                            arrClassesBookingFailed[intClassesFailedIndex, 1] = arrPracticalClasses[intBookingIndex, 1];
                            intClassesFailedIndex++;
                        }
                    }
                    else
                    {
                        //This time slot is still within the bounds of one work and we can therefore decide which lab it will be booked in
                        if (Convert.ToInt32(arrPracticalClasses[intBookingIndex, 1]) > 150)
                        {
                            LabSelection = 2;
                        }
                        else
                        {
                            LabSelection = 1;
                        }
                        index = 0;
                        switch (LabSelection)
                        {
                            case 1: //Practical Class will be booked into Lab1
                                string[,] Lab1Status = new string[150, 4];
                                int intNumberOfFreeComputers = 0;
                                //Get the status of every lab1 computer for the current time slot
                                foreach (DataRow row in dtBookings.Rows)
                                {
                                    if (index < 150 && Convert.ToInt32(row["idTimeSlot"]) == currentTimeSlot && row["idComputer"].ToString() == strLab1Computers[index])
                                    {
                                        Lab1Status[index, 0] = row["idBookings"].ToString();
                                        Lab1Status[index, 1] = row["idComputer"].ToString();
                                        Lab1Status[index, 2] = row["idTimeslot"].ToString();
                                        Lab1Status[index, 3] = row["Status"].ToString();
                                        index++;
                                    }

                                }
                                //Count how many of the computers are free at this time
                                for (forindex1 = 0; forindex1 < Lab1Status.GetLength(0); forindex1++)
                                {
                                    if (Lab1Status[forindex1, 3] == "Open")
                                    {
                                        intNumberOfFreeComputers++;
                                    }
                                }
                                //If the current class can fit into the the free computers available
                                if (Convert.ToInt32(arrPracticalClasses[intBookingIndex, 1]) <= (intNumberOfFreeComputers))
                                {
                                    //Create an area of just the computer that are free to be booked
                                    string[,] arrFreeComputerInLab1 = new string[intNumberOfFreeComputers, 4];
                                    int intFreeComputersIndex = 0;
                                    for (forindex1 = 0; forindex1 < Lab1Status.GetLength(0); forindex1++)
                                    {
                                        if (Lab1Status[forindex1, 3] == "Open")
                                        {
                                            arrFreeComputerInLab1[intFreeComputersIndex, 0] = Lab1Status[forindex1, 0];
                                            arrFreeComputerInLab1[intFreeComputersIndex, 1] = Lab1Status[forindex1, 1];
                                            arrFreeComputerInLab1[intFreeComputersIndex, 2] = Lab1Status[forindex1, 2];
                                            arrFreeComputerInLab1[intFreeComputersIndex, 3] = Lab1Status[forindex1, 3];
                                            intFreeComputersIndex++;
                                        }
                                    }
                                    //Start booking the free computers until enough are booked to cover the class
                                    string QueryString = "";
                                    string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
                                    index = 0;
                                    for (forindex2 = 0; forindex2 < Convert.ToInt32(arrPracticalClasses[intBookingIndex, 1]); forindex2++)
                                    {
                                        QueryString += "UPDATE tblbookings SET Status='" + arrPracticalClasses[intBookingIndex, 0] + "' WHERE idBookings=" + arrFreeComputerInLab1[forindex2, 0] + ";\n";
                                        index++;
                                    }
                                    MySqlConnection sqlConn = new MySqlConnection(connectionString);
                                    MySqlCommand sqlComm = new MySqlCommand(QueryString, sqlConn);
                                    sqlConn.Open();
                                    if (sqlConn.State.ToString() == "Open")
                                    {
                                        sqlComm.ExecuteNonQuery();
                                    }
                                    sqlConn.Close();
                                    currentTimeSlotValid = false;
                                    TimeSlotIndex = 1;
                                    currentTimeSlot = Convert.ToInt32(strTimeSlots[0, 0]);                                   
                                }
                                else
                                {
                                    //Booking in the chosen Timeslot has failed as the required lab does not have enough computers left for that timeslot
                                    //increase the timeslot index and try again
                                    currentTimeSlot = Convert.ToInt32(strTimeSlots[TimeSlotIndex, 0]);
                                    TimeSlotIndex++;
                                    currentTimeSlotValid = true;
                                }
                                break;
                            case 2: //Practical Class will be booked into Lab 2 - Process is exactly the same as with case 1, see comments there
                                string[,] Lab2Status = new string[200, 4];
                                intNumberOfFreeComputers = 0;
                                foreach (DataRow row in dtBookings.Rows)
                                {
                                    if (Convert.ToInt32(row["idTimeSlot"]) == currentTimeSlot && row["idComputer"].ToString() == strLab2Computers[index])
                                    {
                                        Lab2Status[index, 0] = row["idBookings"].ToString();
                                        Lab2Status[index, 1] = row["idComputer"].ToString();
                                        Lab2Status[index, 2] = row["idTimeslot"].ToString();
                                        Lab2Status[index, 3] = row["Status"].ToString();
                                        index++;
                                    }

                                }
                                for (forindex1 = 0; forindex1 < Lab2Status.GetLength(0); forindex1++)
                                {
                                    if (Lab2Status[forindex1, 3] == "Open")
                                    {
                                        intNumberOfFreeComputers++;
                                    }
                                }
                                if (Convert.ToInt32(arrPracticalClasses[intBookingIndex, 1]) <= (intNumberOfFreeComputers*1))
                                {
                                    string[,] arrFreeComputerInLab2 = new string[intNumberOfFreeComputers, 4];
                                    int intFreeComputersIndex = 0;
                                    for (forindex1 = 0; forindex1 < Lab2Status.GetLength(0); forindex1++)
                                    {
                                        if (Lab2Status[forindex1, 3] == "Open")
                                        {
                                            arrFreeComputerInLab2[intFreeComputersIndex, 0] = Lab2Status[forindex1, 0];
                                            arrFreeComputerInLab2[intFreeComputersIndex, 1] = Lab2Status[forindex1, 1];
                                            arrFreeComputerInLab2[intFreeComputersIndex, 2] = Lab2Status[forindex1, 2];
                                            arrFreeComputerInLab2[intFreeComputersIndex, 3] = Lab2Status[forindex1, 3];
                                            intFreeComputersIndex++;
                                        }
                                    }
                                    string QueryString = "";
                                    string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
                                    index = 0;
                                    for (forindex2 = 0; forindex2 < Convert.ToInt32(arrPracticalClasses[intBookingIndex, 1]); forindex2++)
                                    {
                                        QueryString += "UPDATE tblbookings SET Status='" + arrPracticalClasses[intBookingIndex, 0] + "' WHERE idBookings=" + Lab2Status[forindex2, 0] + ";\n";
                                        index++;
                                    }
                                    MySqlConnection sqlConn = new MySqlConnection(connectionString);
                                    MySqlCommand sqlComm = new MySqlCommand(QueryString, sqlConn);
                                    sqlConn.Open();
                                    if (sqlConn.State.ToString() == "Open")
                                    {
                                        sqlComm.ExecuteNonQuery();
                                    }
                                    sqlConn.Close();
                                    currentTimeSlotValid = false;
                                    TimeSlotIndex = 1;
                                    currentTimeSlot = Convert.ToInt32(strTimeSlots[0, 0]);
                                }
                                else
                                {
                                    //Booking in the chosen Timeslot has failed as the required lab does not have enough computers left for that timeslot
                                    //increase the timeslot index and try again
                                    currentTimeSlot = Convert.ToInt32(strTimeSlots[TimeSlotIndex, 0]);
                                    TimeSlotIndex++;
                                    currentTimeSlotValid = true;
                                }
                                break;
                        }
                    }
                }

            }
            //Check if any classes couldn't be booked
            if (atLeastOneClassFailedBooking)
            {
                //If the system has already tried to book classes three times and some still don't fit, call off the booking. Reducing the class size anymore will start to be unrealisitic
                if (RetryCount == 2)
                {
                    MessageBox.Show("Three attempts have been made to book the classes.");
                }
                else
                {
                    RetryCount++;
                    string[] ModulesFailed = new string[arrClassesBookingFailed.GetLength(0)];
                    int[] ModulesStudentsFailed = new int[arrClassesBookingFailed.GetLength(0)];
                    for (int indexFailed = 0; indexFailed < arrClassesBookingFailed.GetLength(0); indexFailed++)
                    {
                        ModulesFailed[indexFailed] = arrClassesBookingFailed[indexFailed, 0];
                        ModulesStudentsFailed[indexFailed] = Convert.ToInt32(arrClassesBookingFailed[indexFailed, 1]);
                    }
                    ModulesFailed = ModulesFailed.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    ModulesStudentsFailed = ModulesStudentsFailed.Where(x => !int.Equals(x,0)).ToArray();
                    Dictionary<string, int> practicalClassesFailed = new Dictionary<string, int>();
                    practicalClasses.Clear();
                    double newThresholdPercentage = thresholdPercentage - 0.1;
                    GeneratePracticalClassesFailed(ModulesFailed, ModulesStudentsFailed, practicalClassesFailed, newThresholdPercentage);
                    BookPracitcalClassesFailed(practicalClassesFailed, newThresholdPercentage);
                }
            }
        }

        public void GeneratePracticalClassesFailed(string[] Modules, int[] intStudentCount, Dictionary<string, int> practicalClasses, double thresholdPercentage)
        {
            //This method is almost identical to the normal version of GeneratePracticalClasses - just with one part where it get data from the database removed
            int index = 0;
            bool flag = true;
            int inttemp = 0;
            string strtemp = "";
            while (flag)
            {
                flag = false;
                for (int forindex = 0; forindex < (intStudentCount.Count() - 1); forindex++)
                {
                    if (intStudentCount[forindex + 1] > intStudentCount[forindex])
                    {
                        inttemp = intStudentCount[forindex];
                        intStudentCount[forindex] = intStudentCount[forindex + 1];
                        intStudentCount[forindex + 1] = inttemp;

                        strtemp = Modules[forindex];
                        Modules[forindex] = Modules[forindex + 1];
                        Modules[forindex + 1] = strtemp;

                        flag = true;
                    }
                }
            }


            string currentModule = Modules[index];
            int TotalStudentModuleCount = intStudentCount[index];
            int StudentsRemaing = intStudentCount[index];
            int StudentsAssigned = 0;
            bool ready = false;
            int GroupsIndex = 0;
            int ModulesIndex = 0;
            string tempModule;
            while (!ready)
            {
                ready = true;
                if (StudentsRemaing > (200 * thresholdPercentage)) //If the student count is more than X% of the largest lab, then break it into two classes
                {
                    StudentsRemaing = StudentsRemaing / 2;
                    ready = false;
                }
                else if (StudentsRemaing > (150 * thresholdPercentage)) //If the student count is less than X% of the largest lab and bigger than X% of the smaller lab, can be booked in lab2
                {
                    GroupsIndex++;
                    tempModule = currentModule + GroupsIndex.ToString();
                    practicalClasses.Add(tempModule, StudentsRemaing);
                    StudentsAssigned += StudentsRemaing;
                    StudentsRemaing = 0;
                    StudentsRemaing = TotalStudentModuleCount - StudentsAssigned;
                    if (StudentsRemaing == 0)
                    {
                        GroupsIndex = 0;
                        ModulesIndex++;
                        if (ModulesIndex < Modules.Count())
                        {
                            currentModule = Modules[ModulesIndex];
                            StudentsRemaing = intStudentCount[ModulesIndex];
                            TotalStudentModuleCount = intStudentCount[ModulesIndex];
                            StudentsAssigned = 0;
                        }
                    }

                    ready = false;
                }
                else //Otherwise the student count must be less than X% of the smaller lab and can be booked in it
                {
                    GroupsIndex++;
                    tempModule = currentModule + GroupsIndex.ToString();
                    practicalClasses.Add(tempModule, StudentsRemaing);
                    StudentsAssigned += StudentsRemaing;
                    StudentsRemaing = 0;
                    StudentsRemaing = TotalStudentModuleCount - StudentsAssigned;
                    if (StudentsRemaing == 0)
                    {
                        GroupsIndex = 0;
                        ModulesIndex++;
                        if (ModulesIndex < Modules.Count())
                        {
                            currentModule = Modules[ModulesIndex];
                            StudentsRemaing = intStudentCount[ModulesIndex];
                            TotalStudentModuleCount = intStudentCount[ModulesIndex];
                            StudentsAssigned = 0;
                        }
                    }

                    ready = false;
                }
                if (ModulesIndex >= Modules.Count())
                {
                    ready = true;
                }
            }
        }

        public void BookPracitcalClassesFailed(Dictionary<string, int> practicalClasses, double thresholdPercentage)
        {
            //The first half of this method is identical to the normal BookPracticalClasses method
            int index = 0;
            int index2 = 0;
            string[] strLab1Computers = new string[150];
            string[] strLab2Computers = new string[200];
            DataTable dtComputers = this.dsavage11DataSet.tblcomputers;
            DataTable dtTimeSlots = this.dsavage11DataSet.tbltimeslots;
            foreach (DataRow row in dtComputers.Rows)
            {
                if (row["idLab"].ToString() == "LAB001")
                {
                    strLab1Computers[index] = row["idComputer"].ToString();
                    index++;
                }
                else
                {
                    strLab2Computers[index2] = row["idComputer"].ToString();
                    index2++;
                }

            }
            string[,] strTimeSlots = new string[dtTimeSlots.Rows.Count / 2, 3];
            index = 0;
            foreach (DataRow row in dtTimeSlots.Rows)
            {
                if (row["Week"].ToString() == "Current Week")
                {
                    strTimeSlots[index, 0] = row["idTimeslot"].ToString();
                    strTimeSlots[index, 1] = row["Time Slot"].ToString();
                    strTimeSlots[index, 2] = row["Week"].ToString();
                    index++;
                }
            }
            bool flag = true;
            string tmpidTimeslot = "";
            string tmpTimeslot = "";
            string tmpWeek = "";
            while (flag)
            {
                flag = false;
                for (int forindex = 0; forindex <= ((dtTimeSlots.Rows.Count / 2) - 2); forindex++)
                {
                    if (Convert.ToInt32(strTimeSlots[forindex + 1, 0]) < Convert.ToInt32(strTimeSlots[forindex, 0]))
                    {
                        tmpidTimeslot = strTimeSlots[forindex + 1, 0];
                        strTimeSlots[forindex + 1, 0] = strTimeSlots[forindex, 0];
                        strTimeSlots[forindex, 0] = tmpidTimeslot;

                        tmpTimeslot = strTimeSlots[forindex + 1, 1];
                        strTimeSlots[forindex + 1, 1] = strTimeSlots[forindex, 1];
                        strTimeSlots[forindex, 1] = tmpTimeslot;

                        tmpWeek = strTimeSlots[forindex + 1, 2];
                        strTimeSlots[forindex + 1, 2] = strTimeSlots[forindex, 2];
                        strTimeSlots[forindex, 2] = tmpWeek;

                        flag = true;
                    }
                }
            }
            string[,] arrPracticalClasses = new string[practicalClasses.Keys.Count, 2];
            index = 0;
            int forlimit = practicalClasses.Count;
            string tempModuleName = "";
            for (index = 0; index < forlimit; index++)
            {
                tempModuleName = practicalClasses.Keys.First().ToString();
                arrPracticalClasses[index, 0] = tempModuleName.Substring(0, (tempModuleName.Length - 1));
                arrPracticalClasses[index, 1] = practicalClasses.Values.First().ToString();
                practicalClasses.Remove(tempModuleName);
            }
            string tmpModuleGroup;
            string tmpGroupStudentCount;
            flag = true;
            while (flag)
            {
                flag = false;
                for (int forindex = 0; forindex < (forlimit - 1); forindex++)
                {
                    if (Convert.ToInt32(arrPracticalClasses[forindex + 1, 1]) > Convert.ToInt32(arrPracticalClasses[forindex, 1]))
                    {
                        tmpModuleGroup = arrPracticalClasses[forindex, 0];
                        arrPracticalClasses[forindex, 0] = arrPracticalClasses[forindex + 1, 0];
                        arrPracticalClasses[forindex + 1, 0] = tmpModuleGroup;

                        tmpGroupStudentCount = arrPracticalClasses[forindex, 1];
                        arrPracticalClasses[forindex, 1] = arrPracticalClasses[forindex + 1, 1];
                        arrPracticalClasses[forindex + 1, 1] = tmpGroupStudentCount;

                        flag = true;
                    }
                }
            }
            //This time, instead of starting with a class and looking for a time slot where it can be booked in one lab or the other, here it starts with a time slot, works out how many free
            //computers each lab has at that time and goes through the list of classes until it finds a module that can fit in either of the labs. It then books it and moves on to the next time
            //slot
            RandomiseArrayOrder(strTimeSlots);
            int forindex1 = 0;
            int forindex2 = 0;
            bool atLeastOneClassFailedBooking = false;
            string[,] arrClassesBookingFailed = new string[arrPracticalClasses.GetLength(0), 2];
            int intClassesFailedIndex = 0;
            for (int tempIndex = 1; tempIndex <= 50; tempIndex++) //For every timeslot in the week
            {
                this.tblbookingsTableAdapter1.Fill(this.dsavage11DataSet.tblbookings);
                DataTable dtBookings = dsavage11DataSet.tblbookings;
                string[,] Lab1Status = new string[150, 4];
                string[,] Lab2StatusFailed = new string[200, 4];
                int lab2Index = 0;
                index = 0;
                foreach (DataRow row in dtBookings.Rows) //Get the status of all computers in both labs for the current timeslot
                {
                    if (index < 150 && Convert.ToInt32(row["idTimeSlot"]) == tempIndex && row["idComputer"].ToString() == strLab1Computers[index])
                    {
                        Lab1Status[index, 0] = row["idBookings"].ToString();
                        Lab1Status[index, 1] = row["idComputer"].ToString();
                        Lab1Status[index, 2] = row["idTimeslot"].ToString();
                        Lab1Status[index, 3] = row["Status"].ToString();
                        index++;
                    }
                    if (Convert.ToInt32(row["idTimeSlot"]) == tempIndex && row["idComputer"].ToString() == strLab2Computers[lab2Index])
                    {
                        Lab2StatusFailed[lab2Index, 0] = row["idBookings"].ToString();
                        Lab2StatusFailed[lab2Index, 1] = row["idComputer"].ToString();
                        Lab2StatusFailed[lab2Index, 2] = row["idTimeslot"].ToString();
                        Lab2StatusFailed[lab2Index, 3] = row["Status"].ToString();
                        lab2Index++;
                    }
                }
                /* Find out how many of the computers are free in both labs for the current time slot
                 * 
                 */
                int intNumberOfFreeComputers = 0;
                int intNumberOfFreeComputersLab2 = 0;
                for (forindex1 = 0; forindex1 < Lab1Status.GetLength(0); forindex1++)
                {
                    if (Lab1Status[forindex1, 3] == "Open")
                    {
                        intNumberOfFreeComputers++;
                    }
                }
                for (forindex1 = 0; forindex1 < Lab2StatusFailed.GetLength(0); forindex1++)
                {
                    if (Lab2StatusFailed[forindex1, 3] == "Open")
                    {
                        intNumberOfFreeComputersLab2++;
                    }
                }
                //For the current timeslot, go through all the classes that have been failed to book once
                for (int intClassesIndex = 0; intClassesIndex < arrPracticalClasses.GetLength(0); intClassesIndex++)
                {
                    if (arrPracticalClasses[intClassesIndex, 0] == null)
                    { }
                    else if (Convert.ToInt32(arrPracticalClasses[intClassesIndex, 1]) <= (intNumberOfFreeComputers)) //If the current class can fit in lab1 at the current time, then book them
                    {
                        string[,] arrFreeComputerInLab1 = new string[intNumberOfFreeComputers, 4];
                        int intFreeComputersIndex = 0;
                        for (forindex1 = 0; forindex1 < Lab1Status.GetLength(0); forindex1++)
                        {
                            if (Lab1Status[forindex1, 3] == "Open")
                            {
                                arrFreeComputerInLab1[intFreeComputersIndex, 0] = Lab1Status[forindex1, 0];
                                arrFreeComputerInLab1[intFreeComputersIndex, 1] = Lab1Status[forindex1, 1];
                                arrFreeComputerInLab1[intFreeComputersIndex, 2] = Lab1Status[forindex1, 2];
                                arrFreeComputerInLab1[intFreeComputersIndex, 3] = Lab1Status[forindex1, 3];
                                intFreeComputersIndex++;
                            }
                        }
                        string QueryString = "";
                        string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
                        index = 0;
                        for (forindex2 = 0; forindex2 < Convert.ToInt32(arrPracticalClasses[intClassesIndex, 1]); forindex2++)
                        {
                            QueryString += "UPDATE tblbookings SET Status='" + arrPracticalClasses[intClassesIndex, 0] + "' WHERE idBookings=" + arrFreeComputerInLab1[forindex2, 0] + ";\n";
                            index++;
                        }
                        MySqlConnection sqlConn = new MySqlConnection(connectionString);
                        MySqlCommand sqlComm = new MySqlCommand(QueryString, sqlConn);
                        sqlConn.Open();
                        if (sqlConn.State.ToString() == "Open")
                        {
                            sqlComm.ExecuteNonQuery();
                        }
                        else { MessageBox.Show("An SQL Connection Error Has Occured."); }
                        sqlConn.Close();
                        arrPracticalClasses[intClassesIndex, 0] = null;
                        arrPracticalClasses[intClassesIndex, 1] = null;
                        break;
                    }
                    else if (Convert.ToInt32(arrPracticalClasses[intClassesIndex, 1]) <= (intNumberOfFreeComputersLab2))//If the current class can fit in lab2 at the current time, then book them
                    {
                        int intFreeComputersIndex = 0;
                        string[,] arrFreeComputerInLab2 = new string[intNumberOfFreeComputersLab2, 4];
                        for (forindex1 = 0; forindex1 < Lab2StatusFailed.GetLength(0); forindex1++)
                        {
                            if (Lab2StatusFailed[forindex1, 3] == "Open")
                            {
                                arrFreeComputerInLab2[intFreeComputersIndex, 0] = Lab2StatusFailed[forindex1, 0];
                                arrFreeComputerInLab2[intFreeComputersIndex, 1] = Lab2StatusFailed[forindex1, 1];
                                arrFreeComputerInLab2[intFreeComputersIndex, 2] = Lab2StatusFailed[forindex1, 2];
                                arrFreeComputerInLab2[intFreeComputersIndex, 3] = Lab2StatusFailed[forindex1, 3];
                                intFreeComputersIndex++;
                            }
                        }
                        string QueryString = "";
                        string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
                        index = 0;
                        for (forindex2 = 0; forindex2 < Convert.ToInt32(arrPracticalClasses[intClassesIndex, 1]); forindex2++)
                        {
                            QueryString += "UPDATE tblbookings SET Status='" + arrPracticalClasses[intClassesIndex, 0] + "' WHERE idBookings=" + arrFreeComputerInLab2[forindex2, 0] + ";\n";
                            index++;
                        }
                        MySqlConnection sqlConn = new MySqlConnection(connectionString);
                        MySqlCommand sqlComm = new MySqlCommand(QueryString, sqlConn);
                        sqlConn.Open();
                        if (sqlConn.State.ToString() == "Open")
                        {
                            sqlComm.ExecuteNonQuery();
                        }
                        sqlConn.Close();
                        arrPracticalClasses[intClassesIndex, 0] = null;
                        arrPracticalClasses[intClassesIndex, 1] = null;
                        break;
                    }
                }
            }

            for (int tempNullCheckIndex = 0; tempNullCheckIndex < arrPracticalClasses.GetLength(0); tempNullCheckIndex++)
            {
                if (arrPracticalClasses[tempNullCheckIndex, 0] != null)
                {
                    atLeastOneClassFailedBooking = true;
                    arrClassesBookingFailed[intClassesFailedIndex, 0] = arrPracticalClasses[tempNullCheckIndex, 0];
                    arrClassesBookingFailed[intClassesFailedIndex, 1] = arrPracticalClasses[tempNullCheckIndex, 1];
                    intClassesFailedIndex++;
                }
            }
                
            if (atLeastOneClassFailedBooking)
            {
                if (RetryCount == 2)
                {
                    MessageBox.Show("Three attempts have been made to book the classes.");
                }
                else
                {
                    RetryCount++;
                    string[] ModulesFailed = new string[arrClassesBookingFailed.GetLength(0)];
                    int[] ModulesStudentsFailed = new int[arrClassesBookingFailed.GetLength(0)];
                    for (int indexFailed = 0; indexFailed < arrClassesBookingFailed.GetLength(0); indexFailed++)
                    {
                        ModulesFailed[indexFailed] = arrClassesBookingFailed[indexFailed, 0];
                        ModulesStudentsFailed[indexFailed] = Convert.ToInt32(arrClassesBookingFailed[indexFailed, 1]);
                    }
                    ModulesFailed = ModulesFailed.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    ModulesStudentsFailed = ModulesStudentsFailed.Where(x => !int.Equals(x, 0)).ToArray();
                    Dictionary<string, int> practicalClassesFailed = new Dictionary<string, int>();
                    practicalClasses.Clear();
                    double newThresholdPercentage = thresholdPercentage - 0.1;
                    GeneratePracticalClassesFailed(ModulesFailed, ModulesStudentsFailed, practicalClassesFailed, newThresholdPercentage);
                    BookPracitcalClassesFailed(practicalClassesFailed, newThresholdPercentage);
                }
            }
        }

        private void ModuleTimetableGeneration_FormClosing(object sender, FormClosingEventArgs e)
        {
            
             Application.Exit();
        }

        private void btnRunCode_Click(object sender, EventArgs e)
        {
            dsavage11DataSet.GetChanges();
            string[] Modules = new string[dsavage11DataSet.tblmodules.Rows.Count];
            int[] intStudentCount = new int[dsavage11DataSet.tblmodules.Rows.Count];
            Dictionary<string, int> practicalClasses = new Dictionary<string, int>();
            double ThresholdPercentage = 0.9;
            GeneratePracitcalClasses(Modules, intStudentCount, practicalClasses, ThresholdPercentage);
            BookPracitcalClasses(practicalClasses, ThresholdPercentage);
            copyTheBookingsToNextWeek();
        }

        private void btnResetTheBookingTable_Click(object sender, EventArgs e)
        {
            string ResetString = "UPDATE tblbookings SET Status = 'Open'";
            string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
            MySqlConnection resetConnection = new MySqlConnection(connectionString);
            MySqlCommand resetCommand = new MySqlCommand(ResetString, resetConnection);
            resetConnection.Open();
            resetCommand.ExecuteNonQuery();
            resetConnection.Close();
            this.tblbookingsTableAdapter1.Fill(this.dsavage11DataSet.tblbookings);
            MessageBox.Show("The tblbookings Table Has Been Reset.");
        }

        private static Array RandomiseArrayOrder(string[,] array)
        {
            Random rng = new Random();
            int n = array.GetLength(0);
            string tmpidTimeslot, tmpTimeslot, tmpWeek;
            while (n > 1)
            {
                int k = rng.Next(n--);

                tmpidTimeslot = array[n, 0];
                array[n, 0] = array[k, 0];
                array[k, 0] = tmpidTimeslot;

                tmpTimeslot = array[n, 1];
                array[n, 1] = array[k, 1];
                array[k, 1] = tmpTimeslot;

                tmpWeek = array[n, 2];
                array[n, 2] = array[k, 2];
                array[k, 2] = tmpWeek;
            }
            return array;
        }

        private void copyTheBookingsToNextWeek()
        {
            //Now that classes have been generated and the computers have been booked for the classes for one week we need to copy those bookings over to the next week
            DataTable dtBookings = this.dsavage11DataSet.tblbookings;
            string[,] LabStatus = new string[350, 3];
            int computerIndex = 0;
            Boolean foundABookedClass = false;
            int tmpTimeSlot = 0;
            string QueryString = "";
            string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
            MySqlConnection sqlConn = new MySqlConnection(connectionString);
            for (int index = 1; index <= 50; index++)
            {
                foreach (DataRow row in dtBookings.Rows)
                {
                    if (computerIndex < 350 && Convert.ToInt32(row["idTimeSlot"]) == index)
                    {
                        foundABookedClass = true;
                        LabStatus[computerIndex, 0] = row["idComputer"].ToString();
                        LabStatus[computerIndex, 1] = row["idTimeSlot"].ToString();
                        LabStatus[computerIndex, 2] = row["Status"].ToString();
                        computerIndex++;
                    }
                }
                if (foundABookedClass)
                {
                    for (int updateTimeSlotIndex = 0; updateTimeSlotIndex < computerIndex; updateTimeSlotIndex++)
                    {
                        tmpTimeSlot = Convert.ToInt32(LabStatus[updateTimeSlotIndex, 1]);
                        tmpTimeSlot = tmpTimeSlot + 50;
                        LabStatus[updateTimeSlotIndex, 1] = tmpTimeSlot.ToString();
                    }

                    for (int queryStringIndex = 0; queryStringIndex < computerIndex; queryStringIndex++)
                    {
                        QueryString += "UPDATE tblbookings SET Status = '" + LabStatus[queryStringIndex, 2] + "' WHERE idTimeSlot = '" + LabStatus[queryStringIndex, 1] + "' AND idComputer = '" + LabStatus[queryStringIndex, 0] + "';\n";
                    }

                    MySqlCommand sqlComm = new MySqlCommand(QueryString, sqlConn);
                    sqlConn.Open();
                    if (sqlConn.State.ToString() == "Open")
                    {
                        sqlComm.ExecuteNonQuery();
                    }
                    sqlConn.Close();
                }
                foundABookedClass = false;
                QueryString = "";
                computerIndex = 0;
            }
            MessageBox.Show("A class schedule has been generated and booked.");
        }

        private void btnResetAndRun_Click(object sender, EventArgs e)
        {
            string ResetString = "UPDATE tblbookings SET Status = 'Open' WHERE Status <> 'Private Use';";
            string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
            MySqlConnection resetConnection = new MySqlConnection(connectionString);
            MySqlCommand resetCommand = new MySqlCommand(ResetString, resetConnection);
            resetConnection.Open();
            resetCommand.ExecuteNonQuery();
            resetConnection.Close();

            dsavage11DataSet.GetChanges();
            string[] Modules = new string[dsavage11DataSet.tblmodules.Rows.Count];
            int[] intStudentCount = new int[dsavage11DataSet.tblmodules.Rows.Count];
            Dictionary<string, int> practicalClasses = new Dictionary<string, int>();
            double ThresholdPercentage = 0.85;
            GeneratePracitcalClasses(Modules, intStudentCount, practicalClasses, ThresholdPercentage);
            BookPracitcalClasses(practicalClasses, ThresholdPercentage);
            copyTheBookingsToNextWeek();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StartMenu SM = new StartMenu();
            SM.Show();
            this.Hide();
        }

        private void btnProgressTheWeek_Click(object sender, EventArgs e)
        {
            generateStatistics();
            DataTable dtBookings = dsavage11DataSet.tblbookings;
            string strSQL = "UPDATE tblbookings SET Status = 'Open' WHERE idTimeSlot < 51;";
            foreach (DataRow row in dtBookings.Rows)
            {
                if (Convert.ToInt32(row["idTimeSlot"]) > 50 && !row["Status"].ToString().Equals("Open"))
                {
                    if ((Convert.ToInt32(row["idTimeSlot"]) - 50) > 9)
                    {
                        strSQL += "\n" + "UPDATE tblbookings SET Status = '" + row["Status"] + "' WHERE idTimeSlot = '" + (Convert.ToInt32(row["idTimeSlot"]) - 50) + "' AND idComputer = '" + row["idComputer"] + "';";
                    }
                    else
                    {
                        string strCurrentTimeSlot = "0" + (Convert.ToInt32(row["idTimeSlot"]) - 50);
                        strSQL += "\n" + "UPDATE tblbookings SET Status = '" + row["Status"] + "' WHERE idTimeSlot = '" + strCurrentTimeSlot + "' AND idComputer = '" + row["idComputer"] + "';";
                    }
                    if (row["Status"].ToString().Equals("Private Use"))
                    {
                        strSQL += "\nUPDATE tblbookings SET Status = 'Open' WHERE idBookings = '" + row["idBookings"] + "';";
                    }
                }
            }
            string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
            MySqlConnection sqlConn = new MySqlConnection(connectionString);
            MySqlCommand sqlComm = new MySqlCommand(strSQL, sqlConn);
            sqlConn.Open();
            if (sqlConn.State.ToString() == "Open")
            {
                sqlComm.ExecuteNonQuery();
                MessageBox.Show("The changes have been successfully sent to the database.");
            }
            sqlConn.Close();
        }

        private void generateStatistics()
        {
            DataTable dtbookings = dsavage11DataSet.tblbookings;
            string strOutputString = "";
            string strFilePath = "I:\\FYPProj\\FYPProj-master-6d6cb5de2f0defa3131c284ed86bfd0a5e0b157c\\Usage Statistics\\Statistics File " + DateTime.Now.Date.ToLongDateString() + ".txt";
            double dblPercentageUnbookedLab1 = 0;
            double dblPercentagePrivateUseLab1 = 0;
            double dblPercentageUnbookedLab2 = 0;
            double dblPercentagePrivateUseLab2 = 0;
            for (int index = 1; index < 51; index++)
            {
                foreach (DataRow row in dtbookings.Rows)
                {
                    if (Convert.ToInt32(row["idTimeSlot"]) == index)
                    {
                        if (Convert.ToInt32(row["idComputer"].ToString().Substring(4)) <= 150)
                        {
                            if (row["Status"].ToString().Equals("Open"))
                            {
                                dblPercentageUnbookedLab1++;
                            }
                            else if (row["Status"].ToString().Equals("Private Use"))
                            {
                                dblPercentagePrivateUseLab1++;
                            }
                        }
                        else if (Convert.ToInt32(row["idComputer"].ToString().Substring(4)) <= 350)
                        {
                            if (row["Status"].ToString().Equals("Open"))
                            {
                                dblPercentageUnbookedLab2++;
                            }
                            else if (row["Status"].ToString().Equals("Private Use"))
                            {
                                dblPercentagePrivateUseLab2++;
                            }
                        }
                    }
                }
                dblPercentageUnbookedLab1 = Math.Round(((dblPercentageUnbookedLab1 / 150)*100),2);
                dblPercentagePrivateUseLab1 = Math.Round(((dblPercentagePrivateUseLab1 / 150)*100),2);
                dblPercentageUnbookedLab2 = Math.Round(((dblPercentageUnbookedLab2 / 200)*100),2);
                dblPercentagePrivateUseLab2 = Math.Round(((dblPercentagePrivateUseLab2 / 200)*100),2);

                strOutputString += "Time Slot " + index + ":\nLab 1 - " + dblPercentageUnbookedLab1 + "% Open, " + dblPercentagePrivateUseLab1 + "% Private Use, " + (100 - (dblPercentagePrivateUseLab1 + dblPercentageUnbookedLab1)) + "% Classes\nLab 2 - " + dblPercentageUnbookedLab2 + "% Open, " + dblPercentagePrivateUseLab2 + "% Private Use, " + (100 - (dblPercentagePrivateUseLab2 + dblPercentageUnbookedLab2)) + "% Classes\n\n";
                dblPercentagePrivateUseLab1 = 0;
                dblPercentagePrivateUseLab2 = 0;
                dblPercentageUnbookedLab1 = 0;
                dblPercentageUnbookedLab2 = 0;
            }
            System.IO.File.WriteAllText(strFilePath,strOutputString);
        }

        private void btnDeleteModule_Click(object sender, EventArgs e)
        {
            string strSQL = "DELETE FROM tblmodules WHERE Modules = '"+txtModuleToDelete.Text.ToString()+"';";
            string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
            MySqlConnection sqlConn = new MySqlConnection(connectionString);
            MySqlCommand sqlComm = new MySqlCommand(strSQL, sqlConn);
            try
            {
                sqlConn.Open();
                if (sqlConn.State.ToString() == "Open")
                {
                    sqlComm.ExecuteNonQuery();
                    MessageBox.Show(txtModuleToDelete.Text.ToString() + " has been deleted.");
                }
                sqlConn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); };
            txtModuleToDelete.Text = "";
        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            string strSQL;
            strSQL = "INSERT INTO tblmodules VALUES('"+txtCourseCodeToAdd.Text.ToString()+"','"+txtModuleToAdd.Text.ToString()+"','"+txtStudentsToAdd.Text.ToString()+"','"+txtCourseLevelToAdd.Text.ToString()+"');";
            string connectionString = "server=lamp.eeecs.qub.ac.uk;user id=dsavage11;password=0pgnhd1f282nd34b;database=dsavage11;Connection Timeout=30";
            MySqlConnection sqlConn = new MySqlConnection(connectionString);
            MySqlCommand sqlComm = new MySqlCommand(strSQL, sqlConn);
            sqlConn.Open();
            if (sqlConn.State.ToString() == "Open")
            {
                sqlComm.ExecuteNonQuery();
                MessageBox.Show(txtModuleToAdd.Text.ToString() + " has been added to the database.");
            }
            sqlConn.Close();
            txtCourseCodeToAdd.Text = "";
            txtCourseLevelToAdd.Text = "";
            txtModuleToAdd.Text = "";
            txtStudentsToAdd.Text = "";
        }

        private void btnFindClasses_Click(object sender, EventArgs e)
        {
            DataTable dtBookings = dsavage11DataSet.tblbookings;
            DataTable dtComputers = dsavage11DataSet.tblcomputers;
            string strRequestedModule = txtModuleToFind.Text.ToString();
            string [] computerID = new string [50];
            string [] strFoundTimeslots = new string [100];
            string [] strFoundTimeslotsTimes = new string[100];
            int index = 0;
            foreach (DataRow row in dtBookings.Rows)
            {
                if (Convert.ToInt32(row["idTimeSlot"]) > 50 && row["Status"].ToString().Equals(strRequestedModule))
                {
                    if (strFoundTimeslots.Contains<string>(row["idTimeSlot"].ToString()))
                    {
                    }
                    else
                    {
                        strFoundTimeslots[index] = row["idTimeSlot"].ToString();
                        computerID[index] = row["idComputer"].ToString();
                        index++;
                    }
                }
            }
            computerID = computerID.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string [] strLabs = new string [computerID.Length];
            int intLabFoundIndex = 0;
            foreach (DataRow row in dtComputers.Rows)
            {
                for (index = 0; index < computerID.Length; index++)
                {
                    if (row["idComputer"].ToString().Equals(computerID[index]))
                    { strLabs[intLabFoundIndex] = row["idLab"].ToString();
                    intLabFoundIndex++;
                    }
                }
            }
            for (index = 0; index < strLabs.Length; index++)
            {
                if (strLabs[index].Equals("LAB001"))
                {
                    strLabs[index] = "Lab 1";
                }
                else if (strLabs[index].Equals("LAB002"))
                {
                    strLabs[index] = "Lab 2";
                }
            }
            strFoundTimeslots = strFoundTimeslots.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            DataTable dtTimeSlots = dsavage11DataSet.tbltimeslots;
            int ArrayIndex = 0;
            foreach (DataRow row in dtTimeSlots.Rows)
            {
                for (index = 0; index <strFoundTimeslots.Length;index++)
                {
                    if (row["idtimeslot"].ToString().Equals(strFoundTimeslots[index]))
                    {
                        strFoundTimeslotsTimes[ArrayIndex] = row["Time Slot"].ToString();
                        ArrayIndex++;
                    }
                }
            }
            strFoundTimeslotsTimes = strFoundTimeslotsTimes.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (strFoundTimeslotsTimes.Length > 0)
            {
                string strMessageBoxText = "This module is booked in the follow times:";
                for (index = 0; index < strFoundTimeslotsTimes.Length; index++)
                {
                    strMessageBoxText += "\n" + strFoundTimeslotsTimes[index]+" in "+strLabs[index];
                }
                MessageBox.Show(strMessageBoxText);
            }
            else { MessageBox.Show("This module doesn't have any classes currently booked."); }
            txtModuleToFind.Text = "";
        }

    }
}
