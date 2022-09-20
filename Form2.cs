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

namespace prog_poe_s02_task1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //FORM LOAD 
            //HIDING THE 3RD LISTBOX
            listBox3.Visible = false;

            //HIDING THE PROGRESSBAR 
            progressBar1.Visible = false;
           
            //ALLOW FOR DROPPING OF CALL NUMBERS IN BOTH LISTBOXES
            listBox1.AllowDrop = true;
            listBox2.AllowDrop = true;

            //CLEARING LIST BOX
            listBox1.Items.Clear();
          
            //GENERATING CALL NUMBERS - METHOD
            generateCallNumbers();

            //SORTING THE CALL NUMBERS - METHOD
            checklist();
        }

        public void generateCallNumbers()
        {
            string x;

            //GENERATING RANDOM METHOD
            Random random = new Random();

            //GENERATING 10 RANDOM ITEMS TO DISPLAY IN THE LIST
            for (var i = 0; i < 10; i++)
            {
                int index = random.Next(values.Count);
                x = values[index];
                listBox1.Items.Add(x);
                listBox3.Items.Add(x);

                //NOT REPEATING THE VALUES 
                values.RemoveAt(index);
            }
        }

        //LIST OF CALL NUMBERS 
        public static List<string> values = new List<string>
        {
            "001.70 JAM ",
             "002.71 POE ",
              "003.72 LIK ",
               "004.73 TOM ",
                "005.74 JPI ",
                 "006.75 ERM ",
                  "007.76 WEM ",
                   "008.77 YAM" ,
                    "009.78 JAL ",
                     "010.79 DYM ",
                      "011.80 CAM ",
                      "0012.70 JAM ",
             "013.71 LKM ",
              "014.72 PTI ",
               "015.73 SHJ ",
                "016.74 TPO ",
                 "017.75 WER ",
                  "018.76 QWE ",
                   "019.77 SDA" ,
                    "020.78 CVB ",
                     "021.79 ZXC ",
                      "022.80 MNB ",
                        "023.70 KLH ",
             "024.71 RTY ",
              "025.72 ERT ",
               "026.73 OPI ",
                "027.74 OPI ",
                 "028.75 OIU ",
                  "029.76 LKJ ",
                   "030.77 WED" ,
                    "031.78 NBV ",
                     "032.79 TYU ",
                      "033.80 ERF ",
                      "034.70 GHN ",
             "035.71 PLM ",
              "036.72 OKN ",
               "037.73 IJB ",
                "038.74 UHB ",
                 "039.75 YGV ",
                  "040.76 TFC ",
                   "041.77 RDX" ,
                    "042.78 ESZ ",
                     "043.79 WAQ ",
                      "044.80 QAZ ",
                        "045.70 WSX ",
             "046.71 EDC ",
              "047.72 RFV ",
               "048.73 TGB ",
                "049.74 YHN ",
                 "050.75 UJM ",
                  "051.76 IKL ",
                   "052.77 OPL" ,
                    "053.78 JAL ",
                     "054.79 ERF ",
                      "055.80 CRM ",
                      "056.70 VBI ",
             "057.71 RMI ",
              "058.72 SOP ",
               "059.73 ALM ",
                "060.74 WMO ",
                 "061.75 SEO ",
                  "062.76 WMI ",
                   "063.77 QNI" ,
                    "064.78 SBT ",
                     "065.79 RNO ",
                      "066.80 SDN ",
                        "067.70 WMO ",
             "068.71 ZOE ",
              "069.72 XOE ",
               "070.73 WSM ",
                "071.74 ALP ",
                 "072.75 QMI ",
                  "073.76 SLC ",
                   "074.77 CYM" ,
                    "075.78 EMP ",
                     "076.79 QLP ",
                      "077.80 ANN ",
                      "078.70 WMO ",
             "079.71 MOE ",
              "080.72 TOE ",
               "081.73 JOE ",
                "082.74 KOE ",
                 "083.75 TOE ",
                  "084.76 WOE ",
                   "085.77 SOE" ,
                    "086.78 DOE ",
                     "087.79 QOE ",
                      "088.80 ZOE ",
                        "089.70 VOE ",
             "090.71 LOK ",
              "091.72 SOK ",
               "092.73 EJN ",
                "093.74 DOE ",
                 "094.75 RNI ",
                  "095.76 NRI ",
                   "096.77 DCV" ,
                    "097.78 CDV ",
                     "098.79 DVD ",
                      "099.80 TMN ",
                      "100.70 WBB ",
             "101.71 QPO ",
              "102.72 ALK ",
               "103.73 ZMN ",
                "104.74 SKJ ",
                 "105.75 EOU ",
                  "106.76 ETS ",
                   "107.77 TSE" ,
                    "108.78 EDM ",
                     "109.79 EHS ",
                      "110.80 EST ",
                        "111.71 QPO ",
              "112.72 ALK ",
               "113.73 ZMN ",
                "114.74 SKJ ",
                 "115.75 EOU ",
                  "116.76 ETS ",
                   "117.77 TSE" ,
                    "118.78 EDM ",
                     "119.79 EHS ",
                      "120.80 EST ",
                       "121.71 QPO ",
              "122.72 ALK ",
               "123.73 ZMN ",
                "124.74 SKJ ",
                 "125.75 EOU ",
                  "126.76 ETS ",
                   "127.77 TSE" ,
                    "128.78 EDM ",
                     "129.79 EHS ",
                      "130.80 EST ",
                       "131.71 QPO ",
              "132.72 ALK ",
               "133.73 ZMN ",
                "134.74 SKJ ",
                 "135.75 EOU ",
                  "136.76 ETS ",
                   "137.77 TSE" ,
                    "138.78 EDM ",
                     "139.79 EHS ",
                      "140.80 EST ",
        };

        //METHODS - FOR DRAG DROP FROM LISTBOX1 TO LISTBOX2
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox2.DoDragDrop(listBox1.SelectedItem.ToString(), DragDropEffects.Copy);
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            listBox2.Items.Add(e.Data.GetData(DataFormats.Text));
            listBox1.Items.Remove(e.Data.GetData(DataFormats.Text));
        }

       //METHOD - FOR DRAG DROP FROM LISTBOX2 TO LISTBOX1
        private void listBox2_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.DoDragDrop(listBox2.SelectedItem.ToString(), DragDropEffects.Copy);
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            listBox1.Items.Add(e.Data.GetData(DataFormats.Text));
            listBox2.Items.Remove(e.Data.GetData(DataFormats.Text));
        }

        //SORTING THE LISTBOX(3)
        private void checklist()
        {
            //CREATING AN ARRAY
            ArrayList list = new ArrayList();
            
            //ADDING THE ARRAY TO THE LISTBOX
            foreach (object o in listBox3.Items)
            {
                list.Add(o);
            }
            list.Sort();

            listBox3.Sorted = true;
            listBox3.Items.Clear();

            foreach (object o in list)
            {
                //ADDING ITEMS TO LISTBOX
                listBox3.Items.Add(o);
            }
        }
     
        //BUTTON CLICK
        private void button1_Click(object sender, EventArgs e)
        {
            //MAKING THE PROGRESSBAR VISIBLE 
            progressBar1.Visible = true;

            //PROGRESS BAR SET UP
            int i;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1000;

            for (i = 0; i <= 1000; i++)
            {
                progressBar1.Value = i;
            }

            //CHECKING OF BOTH LISTBOXES (1 AND 2)
            //WORKING WITH ARRAYS 
            string[] array = new string[listBox2.Items.Count];

            for (int w = 0; w < listBox2.Items.Count; w++)
            {
                object s = listBox2.Items[w];
                array[w] = s.ToString();
            }

            string[] array2 = new string[listBox3.Items.Count];

            for (int v = 0; v < listBox3.Items.Count; v++)
            {
                object ss = listBox3.Items[v];
                array2[v] = ss.ToString();
            }

            //CHECKING IF BOTH ARRAYS ARE SAME OR NOT 
            bool areEqual = array.SequenceEqual(array2);
            //IF THE ARRAYS ARE EQUAL THEN :
            if(areEqual == true)
            {
                //BOTH LISTS MATCHED 
                string message1 = "List Matched!";
                string title1 = "Notification";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Information);
                if (result1 == DialogResult.OK)
                {
                    //IF USER CLICKS OK - TAKE THEM TO NEXT LEVEL 
                    string message2 = "You are moving to the next level?";
                    string title2 = "Congratulations!";
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Information);
                    if (result2 == DialogResult.OK)
                    {
                        //RELOAD THE FORM TO DISPLAY CALL NUMBERS 
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        listBox3.Items.Clear();
                        progressBar1.Visible = false;
                        generateCallNumbers();
                    }
                }

                //GIVING USER A POINT FOR BOTH LIST MATCHED
                var curr = 1;

                if (int.TryParse(label5.Text, out curr))
                    curr++;
                label5.Text = curr.ToString();

                //WHEN POINT REACHES 10 THEN DISPLAY TICKET
                int finalnum = 10;
                if (label5.Text.Equals(finalnum.ToString()))
                {
                    //DISPLAY TICKET FORM 
                    this.Hide();
                    var form3 = new Form3();
                    form3.Closed += (s, args) => this.Close();
                    form3.Show();
                }
            }
            //IF THE LISTS DID NOT MATCH 
            else
            {
                //LISTS DID NOT MATCH
                string message1 = "List did not Match!";
                string title1 = "Notification";
                MessageBoxButtons buttons1 = MessageBoxButtons.OK;
                DialogResult result1 = MessageBox.Show(message1, title1, buttons1, MessageBoxIcon.Hand);
                if (result1 == DialogResult.OK)
                {
                    //WHEN USER CLICKS OKAY - POP ANOTHER MESSAGE BOX WITH YES OR NO 
                    string message2 = "Do you want to try again?";
                    string title2 = "Notification";
                    MessageBoxButtons buttons2 = MessageBoxButtons.YesNo;
                    DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Question);
                    //IF USER CLICKS YES
                    if (result2 == DialogResult.Yes)
                    {
                        //GENERATE NEW LIST OF CALL NUMBERS 
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        listBox3.Items.Clear();
                        generateCallNumbers();
                    }
                    //IF USER CLICKS NO 
                    else
                    {
                        //HIDE THIS FORM AND SHOW MAIN FORM 
                        this.Hide();
                        var form1 = new Form1();
                        form1.Closed += (s, args) => this.Close();
                        form1.Show();
                    }
                }
            }
        }
     
    }
}
