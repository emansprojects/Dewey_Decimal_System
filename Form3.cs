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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //USER CLICKS ACCEPT BUTTON - DISPLAY MESSAGE BOX 
            string message2 = "YAY! You have recieved the golden ticket.";
            string title2 = "Congratulations!";
            MessageBoxButtons buttons2 = MessageBoxButtons.OK;
            DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Information);
            if (result2 == DialogResult.OK)
            {
                //AFTER USER HAS ACCEPTED THE TICKET - BACK TO MAIN FORM
                this.Hide();
                var form1 = new Form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
        }
    }
}
