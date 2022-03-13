using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D_Anjolell_7_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //Code that closes the program
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Richard D'Anjolell
            //Try catch statement if there is an error accessing the file

            try
            {
                //Declare variables
                int popularName = 0;
                const int ARRAY_SIZE = 200;
                string[] boyLines = new string[ARRAY_SIZE];
                string[] girlLines = new string[ARRAY_SIZE];
                string userInput = txtEntry.Text;
                StreamReader boyFile;
                StreamReader girlFile;

                //Open both files
                boyFile = File.OpenText("..\\..\\BoyNames.txt");
                girlFile = File.OpenText("..\\..\\GirlNames.txt");

                //Declare the index for the arrays
                int indexNum = 0;

                //Sends names from file into an array
                while (indexNum < boyLines.Length && !boyFile.EndOfStream)
                {
                    //Set array name to name in the file
                    boyLines[indexNum] = boyFile.ReadLine();

                    //Increment index counter
                    indexNum++;
                }

                //Resets index for next while loop
                indexNum = 0;

                //Sends name from file into an array
                while (indexNum < girlLines.Length && !girlFile.EndOfStream)
                {
                    //Set array name to name in the file
                    girlLines[indexNum] = girlFile.ReadLine();

                    //Increment index counter
                    indexNum++;
                }

                //Resets index for next while loop
                indexNum = 0;

                //Finds out if the inputed name is in the list
                while (indexNum < boyLines.Length)
                {
                    if (boyLines[indexNum] == userInput)
                    {
                        lblResult.Text = "The name you have entered (" + userInput + ") is among the most popular.";
                        popularName++;
                    }
                    else if (girlLines[indexNum] == userInput)
                    {
                        lblResult.Text = "The name you have entered (" + userInput + ") is among the most popular.";
                        popularName++;
                    }

                    //Increment index counter
                    indexNum++;
                }

                //If statement in case name isn't in the list
                if (popularName == 0)
                {
                    lblResult.Text = "The name you have entered (" + userInput + ") is not among the most popular.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
