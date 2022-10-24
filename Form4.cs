using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static prog_poe_s02_task1.IdentifyingAreas;


namespace prog_poe_s02_task1
{
    public partial class Form4 : Form
    {
        //BUTTON FIELDS 
        //SETTING THE NUM OF LEFT BUTTONS 
        private int numofleftbtn = 4;

        //SETTING THE NUM OF RIGHT BUTTONS
        private int numofrightbtn = 7;

        //BUTTONS
        private Button[] leftColumnButtons;
        private Button[] rightColumnButtons;

        public Form4()
        {
            InitializeComponent();
            {
                //START THE APP
                StartTask();
            }
        }

        private void StartTask()
        {
            //RESETTING VARIABLES

            //ASSIGNING LEFT BUTTONS FROM FORM
            leftColumnButtons = new Button[] { btnLeft1, btnLeft2, btnLeft3, btnLeft4 };

            //ASSIGNING RIGHT BUTTONS FROM FORM
            rightColumnButtons = new Button[] { btnRight1, btnRight2, btnRight3, btnRight4, btnRight5, btnRight6, btnRight7 };

            //IMPLEMENTING METHOD FROM IDENTIFYING AREAS CLASS
            GenerateCallNumbers(leftColumnButtons, numofleftbtn, rightColumnButtons, numofrightbtn);

            //REFRESHING THE PAGE 
            this.Refresh();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //WHEN THE CHECK BUTTON IS CLICKED
            //CHECKS THE USERS ANSWER
            if (CheckUserAnswer(leftColumnButtons, numofleftbtn, rightColumnButtons, numofrightbtn))
            {
                //GENERATING ERROR AND SUCCESS MESSAGES FOR USER 
                //SUCCESS MESSAGE  
                string message = "Correct Matching! \n You are moving to the next level!";
                string title = "Results";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

                //USER CLICKED OK
                if (result == DialogResult.OK)
                {
                    //GAMIFICATION FEATURE
                    //INCREASE USER SCORES IF THEY PASSED THE LEVEL
                    var curr = 1;
                    if (int.TryParse(label2.Text, out curr))
                        curr++;
                    label2.Text = curr.ToString();

                    //RESTART THE TASK 
                    StartTask();
                }

                //USER CLICKED CANCEL
                if (result == DialogResult.Cancel)
                {
                    //HIDES THE CURRENT FORM AND SHOWS A NEW FORM
                    this.Hide();
                    var form1 = new Form1();
                    form1.Closed += (s, args) => this.Close();
                    form1.Show();
                }
            }
            else
            {
                //ERROR MESSAGE
                string message ="Incorrect! \n Please check your matching again!";
                string title = "Results";
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);

                //USER CLICKED OK
                if (result == DialogResult.OK)
                {
                    //GAMIFICATION FEATURE
                    //DECREASE USER SCORES IF THEY FAILED THE LEVEL
                    var curr = 1;
                    if (int.TryParse(label2.Text, out curr))
                        curr--;
                    label2.Text = curr.ToString();
                }

                //USER CLICKED CANCEL
                if (result == DialogResult.Cancel)
                {
                    //HIDES THE CURRENT FORM AND SHOWS A NEW FORM
                    this.Hide();
                    var form1 = new Form1();
                    form1.Closed += (s, args) => this.Close();
                    form1.Show();
                }
            }

        }

        private void RESETbtn_Click(object sender, EventArgs e)
        {
            //IF USER CLICKS ON RESET BUTTON THE GAME BEGINS AGAIN
            StartTask();
        }

        //ALL LEFT BUTTONS CLICKED (LEFT COLUMN)
        private void btnLeft1_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateLeftButton(sender);
        }

        private void btnLeft2_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateLeftButton(sender);
        }

        private void btnLeft3_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateLeftButton(sender);
        }

        private void btnLeft4_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateLeftButton(sender);
        }

        //ALL RIGHT BUTTONS CLICKED (RIGHT COLUMN)
        private void btnRight1_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateRightButton(sender, numofrightbtn, rightColumnButtons, leftColumnButtons);
            this.Refresh();
        }

        private void btnRight2_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateRightButton(sender, numofrightbtn, rightColumnButtons, leftColumnButtons);
            this.Refresh();
        }

        private void btnRight3_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateRightButton(sender, numofrightbtn, rightColumnButtons, leftColumnButtons);
            this.Refresh();
        }

        private void btnRight4_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateRightButton(sender, numofrightbtn, rightColumnButtons, leftColumnButtons);
            this.Refresh();
        }

        private void btnRight5_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateRightButton(sender, numofrightbtn, rightColumnButtons, leftColumnButtons);
            this.Refresh();
        }

        private void btnRight6_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateRightButton(sender, numofrightbtn, rightColumnButtons, leftColumnButtons);
            this.Refresh();
        }

        private void btnRight7_Click(object sender, EventArgs e)
        {
            //IMPLEMENTING THE METHOD FROM IDENTIFYINGAREAS CLASS
            ActivateRightButton(sender, numofrightbtn, rightColumnButtons, leftColumnButtons);
            this.Refresh();
        }

        private void instructionsbtn_Click(object sender, EventArgs e)
        {
            //GIVES USER INSTRUCTIONS ON HOW TO IDENTIFY AREAS
            string message = "Follow the instructions to complete this task:" +
                "\n 1. Click the item in column 1 first." +
                "\n 2. Next click the answer in column 2, you will know" +
                "\n when your asnwer is selected. The answer will turn into a " +
                "\n different colour." +
                "\n 3. Complete all 4 questions before clicking the check button.";
            string title = "Instructions";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

            //USER CLICKED OK
            if (result == DialogResult.OK)
            {
                //DO NOTHING 
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MAIN MENU BUTTON IS CLICKED
            //HIDES THE CURRENT FORM AND SHOWS A NEW FORM
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}

