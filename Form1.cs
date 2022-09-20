using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog_poe_s02_task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //REPLACING BOOKS 
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //HIDES THE CURRENT FORM AND SHOWS A NEW FORM
            //MADE AVAILABLE 
            this.Hide();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        //IDENTIFYING AREAS
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MADE UNAVAILABLE - MESSAGEBOX
            string message = "Item not Available!";
            string title = "Notification";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result1 = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
        }

        //FINDING CALL NUMBERS
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //MADE UNAVAILABE - MESSAGEBOX
            string message = "Item not Available!";
            string title = "Notification";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result1 = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
        }
    }
}
