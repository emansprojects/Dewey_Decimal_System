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
using static prog_poe_s02_task1.FindCallNumbers;


namespace prog_poe_s02_task1
{
    public partial class Form5 : Form
    {
     
        private Button[] AnswerButtons;
        private Label Question;

        public Form5()
        {
            InitializeComponent();
            //INSTANCIATING THE METHOD TO START FINDING CALL NUMBERS
            FindingCallNums();
        }

        private void FindingCallNums()
        {
            AnswerButtons = new Button[] { button1, button2, button3, button4 }; //BUTTONS 
            Question = lblquestion; //LABEL

            //ALL METHODS FROM FINDING CALL NUMBERS CLASS
            InsertRandomLevelOneValue();
            Populating_Nodes(AnswerButtons);
            Compute_Question(Question);
        }

        //BUTTON ANSWERS CLICKED 
        //BUTTON 1 CLICKED 
        private void button1_Click(object sender, EventArgs e)
        {
            if (Trigger_Buttons(sender, AnswerButtons, lblCurrentPoints))
            {
                FindingCallNums();
            };
        }
        //BUTTON 2 CLICKED 
        private void button2_Click(object sender, EventArgs e)
        {
            if (Trigger_Buttons(sender, AnswerButtons, lblCurrentPoints))
            {
                FindingCallNums();
            };
        }
        //BUTTON 3 CLICKED 
        private void button3_Click(object sender, EventArgs e)
        {
            if (Trigger_Buttons(sender, AnswerButtons, lblCurrentPoints))
            {
                FindingCallNums();
            };
        }
        //BUTTON 4 CLICKED 
        private void button4_Click(object sender, EventArgs e)
        {
            if (Trigger_Buttons(sender, AnswerButtons, lblCurrentPoints))
            {
                FindingCallNums();
            };
        }

        //INSTRUCTIONS BUTTON CLICKED 
        private void button5_Click(object sender, EventArgs e)
        {
            //GIVES USER INSTRUCTIONS ON HOW TO FIND CALL NUMBERS 
            string message = "Follow the instructions to complete this task:" +
                "\n 1. A question will be given to you." +
                "\n 2. Four options will be provided from each level." +
                "\n 3. One correct answer from each level must be chosen to receive a 10 points."+
                "\n 4. Choose the correct answer to move to the next level options." + 
                "\n 5. After answering from the 3 levels a new questions will be asked. Goodluck!";
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


