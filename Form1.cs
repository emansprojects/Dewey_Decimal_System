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
            //HIDES THE CURRENT FORM AND SHOWS A NEW FORM
            //MADE AVAILABLE 
            this.Hide();
            var form4 = new Form4();
            form4.Closed += (s, args) => this.Close();
            form4.Show();
        }

        //FINDING CALL NUMBERS
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //HIDES THE CURRENT FORM AND SHOWS A NEW FORM
            //MADE AVAILABLE 
            this.Hide();
            var form5 = new Form5();
            form5.Closed += (s, args) => this.Close();
            form5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}
