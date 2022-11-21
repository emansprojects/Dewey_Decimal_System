using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog_poe_s02_task1
{
    class FindCallNumbers
    {
        //ASSIGNING VALUES 

        //NUM OF TOP LEVELS IN THE TEXT FILE 
        public static int top_level = 7;
        // TOTAL NUMBER OF LEVELS 
        public static int num_of_levels = 3;
        //TOTAL ANSWERS/OPTIONS
        public static int options = 4;

        //FILE PATH TO THE TEXT FILE WITH CALL NUMBERS IN IT 
        //ATTRIBUTION:
        //Path.GetDirectoryName Method - MICROSOFT
        //LINK - https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getdirectoryname?view=net-7.0 
        private static string file_path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName).FullName + @"\mydewey.txt";

        //ASSIGNING VALUES
        public static int crntLevel; //CURRENT LEVEL 
        public static int TopLevelNodes; //TOPE LEVEL NODES
        static NodeClass parentroot; //TREE AND NODE

        public static void Populating_Nodes(Button[] buttons)
        {
            //ATTRIBUTION:
            //TreeNode.Nodes Property - MICROSOFT 
            //LINK - https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.treenode.nodes?view=windowsdesktop-7.0 
            //Chapter 17 Trees and Graphs 
            //LINK: https://introprogramming.info/english-intro-csharp-book/read-online/chapter-17-trees-and-graphs/
            //ROOT NODE OF TREE
            parentroot = DeweyNode("Dewey Decimal", "System");

            //RESET CURRENT LEVEL TO 0 WHEN WE POPULATE THE TREE
            crntLevel = 0;

            //FILE TO READ AND GET TREE DATA FROM 
            string[] Lines = File.ReadAllLines(file_path);

            int lvl1 = 0; // level 1 index
            int lvl2 = 0; // level 2 index

            //ATTRIBUTION:
            //Performace of if-else if tree vs. Switch (multiple variables) in c#
            //LINK: https://www.c-sharpcorner.com/uploadfile/853a6a/performance-of-if-else-if-tree-vs-switch-multiple-variables-in-C-Sharp/
            //building a tree using data from txt file - C# forums 
            //LINK - https://csharpforums.net/threads/building-a-tree-using-the-data-from-txt-file.3828/
            //READIG EACH LINE IN TXT FILE 
            foreach (string line in Lines)
            {
                //USING '+' TO SEPERATE THE DIFFERENT CALL LEVELS IN LIST(.txt) 
                string[] selectedwords = line.Split('+');

                //CASE - IT IS THE NUM THAT IS LINKED WITH THE CALL NUMBER LEVEL EG. 1 2 AND 3 
                switch (selectedwords[0])
                {
                    case "1": //IF LEVEL IS 1 
                        parentroot.NodeList.Add(DeweyNode(selectedwords[1], selectedwords[2]));
                        lvl2 = 0;
                        lvl1++;
                        break;
                    case "2": //IF LEVEL IS 2 
                        parentroot.NodeList[lvl1 - 1].NodeList.Add(DeweyNode(selectedwords[1], selectedwords[2]));
                        lvl2++;
                        break;
                    case "3": //IF LEVEL IS 3 
                        parentroot.NodeList[lvl1 - 1].NodeList[lvl2 - 1].NodeList.Add(DeweyNode(selectedwords[1], selectedwords[2]));
                        break;
                }
            }
            TopLevelNodes = lvl1;
            //POPULATING THE BUTTONS WITH ANSWERS 
            Occupy_Buttons(buttons);
        }

        //NODE CLASS
        //ATTRIBUTION 
        //Creating a very simple linked list - StackOverflow
        //LINK: https://stackoverflow.com/questions/3823848/creating-a-very-simple-linked-list
        public class NodeClass
        {
            //ASSIGING VALUES 
            public string node_keys;
            public string node_values;

            //CREATING A LIST TO STORE THE NODES 
            public List<NodeClass> NodeList = new List<NodeClass>();
        };

        public static NodeClass DeweyNode(string nodekey, string nodevalue)
        {
            NodeClass nclass = new NodeClass();

            //USING VALUES FROM NODECLASS 
            nclass.node_keys = nodekey;
            nclass.node_values = nodevalue;
            return nclass;
        }

        //ASSIGNING VALUES
        public static int[] chosen = new int[num_of_levels]; //SELECTED FROM THE TXT FILE 
        public static string[] selectedanswers = new string[num_of_levels]; //USER ASNWERS 
        public static List<int> level_one = new List<int>(); //LEVEL ONE ANSWERS 

        public static void Occupy_Buttons(Button[] buttons)
        {
            //ADDING THE ANSWERS IN THE BUTTONS 
            string[] node_call = new string[options]; //OPTIONS - 4

            //SELECTING THE LEVEL OF CALL NUMBERS TO POPULATE THE ARRAY WITH 
            switch (crntLevel)
            {
                case 0:
                    for (int j = 0; j < options; j++)
                    {
                        node_call[j] = parentroot.NodeList[level_one[j]].node_keys + "\n" + parentroot.NodeList[level_one[j]].node_values;
                    }
                    break;
                case 1:
                    for (int k = 0; k < options; k++)
                    {
                        node_call[k] = parentroot.NodeList[chosen[0]].NodeList[k].node_keys + "\n" + parentroot.NodeList[chosen[0]].NodeList[k].node_values;
                    }
                    break;
                case 2:
                    for (int w = 0; w < options; w++)
                    {
                        node_call[w] = parentroot.NodeList[chosen[0]].NodeList[chosen[1]].NodeList[w].node_keys + "\n" + parentroot.NodeList[chosen[0]].NodeList[chosen[1]].NodeList[w].node_values;
                    }
                    break;
            }

            //POPULATING BUTTONS WITH CALL ARRAY VALUES
            for (int t = 0; t < buttons.Length; t++)
            {
                buttons[t].Text = node_call[t];
            }
        }

        //ASSIGNING VALUES
        public static Random random = new Random(); //USING RANDOM TO PRINT RANDOM QUESTIONS FOR THE USER 

        public static void InsertRandomLevelOneValue()
        {
            //RANDOM LEVEL 1 ENTRY GENERATED
            level_one.Clear();
            while (level_one.Count != 4) 
            {
                int randomlevelone = random.Next(0, top_level);
                if (!level_one.Contains(randomlevelone))
                {
                    level_one.Add(randomlevelone);
                }
            }
            level_one.Sort(); //RANDOM SORT METHOD 
        }

        public static void SetCallNumberAnswers()
        {
            //SETTING ANSWERS FOR QUESTION 
            selectedanswers[0] = parentroot.NodeList[chosen[0]].node_keys + "\n" + parentroot.NodeList[chosen[0]].node_values;
            selectedanswers[1] = parentroot.NodeList[chosen[0]].NodeList[chosen[1]].node_keys + "\n" + parentroot.NodeList[chosen[0]].NodeList[chosen[1]].node_values;
            selectedanswers[2] = parentroot.NodeList[chosen[0]].NodeList[chosen[1]].NodeList[chosen[2]].node_keys + "\n" + parentroot.NodeList[chosen[0]].NodeList[chosen[1]].NodeList[chosen[2]].node_values;
        }

        //QUESTION
        public static void Compute_Question(Label label)
        {
            //RANDONLY CHOOSE A TOP LEVEL CAT (LEVEL 1) 
            while (true)
            {
                //CHOOSING RADOME LEVEL 1 
                int ranlvl1 = random.Next(0, top_level);
                if (level_one.Contains(ranlvl1))
                {
                    chosen[0] = ranlvl1;
                    break;
                }
            }

            //SELECTING DESCRIPTION RANDOMLY
            for (int i = 1; i < num_of_levels; i++)
            {
                chosen[i] = random.Next(0, num_of_levels);
            }

            //SELECTING ANSWERS FOR THE CHOSEN QUESTIONS
            SetCallNumberAnswers();
            //PASSING THE QUESTION ONTO THE LABEL ON THE FORM
            label.Text = parentroot.NodeList[chosen[0]].NodeList[chosen[1]].NodeList[chosen[2]].node_values;
        }

        //WHEN BUTTON IS CLICKED 
        public static bool Trigger_Buttons(object btnSender, Button[] buttons, Label label)
        {
            Button button = (Button)btnSender;

            if (Check_User_Answer(button.Text))
            {
                crntLevel++;
                Adding_User_Points(label); //ADDING POINTS FOR USER IF ANSWER IS CORRECT
                if (crntLevel == 3) //IF SELECTED ANSWER IS CORRECT 
                {
                    MessageBox.Show("CORRECT!" +
                      "\nMoving onto next question!");
                    return true;
                }
                //NEXT LEVEL 
                Occupy_Buttons(buttons);
            }
            else //IF SELECTED ANSWER IS WRONG 
            {
                crntLevel++;
                MessageBox.Show("INCORRECT!" +
                    "\nThe Correct answer is:\n\n" +
                    selectedanswers[crntLevel - 1]);

                if (crntLevel == 3)
                {
                    return true;
                }
                //NEXT LEVEL 
                Occupy_Buttons(buttons);
            }
            return false;
        }

        public static bool Check_User_Answer(string answer)
        {
            //IF THE USERS ANSWER EQUALS TO THE SELECTED BUTTON THEN
            if (!answer.Equals(selectedanswers[crntLevel]))
            {
                return false;
            }
            return true;
        }

        //ATTRIBUTION
        //how to increment value in label on clicking the button 
        //LINK: https://www.codeproject.com/Questions/812709/how-to-increment-value-in-label-on-clicking-the-bu
        //SETTING SCORE LABEL TO 0 FIRST 
        private static int iCount = 0;
        public static void Adding_User_Points(Label label)
        {
            //GAMIFICATION FEATURE
            //IF USER GOT ANSWER CORRECT INCREASE SCORE 

            iCount = iCount + 10 ; //ADDING 10 FOR EACH CORRECT ASWER 
            label.Text = iCount.ToString();
        }
    }
}
