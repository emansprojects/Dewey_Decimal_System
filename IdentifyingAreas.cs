using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prog_poe_s02_task1
{
    static class IdentifyingAreas
    {
        //ATTRIBUTION 
        //C# Dictionary - Dictionary <TKey, TValue> - https://www.tutorialsteacher.com/csharp/csharp-dictionary 
        //2022
        //DICTIONARY STORING ALL VALUES AND KEYS  OF THE DEWEY SYSTEM
        public static Dictionary<string, string> callNumbersAndDescription = new Dictionary<string, string>() {
            { "000", "GENERAL KNOWLEDGE" },
            { "100", "PHILOSOPHY AND PSYCHOLOGY" },
            { "200", "RELIGION" },
            { "300", "SOCIAL SCIENCES" },
            { "400", "LANGUAGES" },
            { "500", "SCIENCE" },
            { "600", "TECHNOLOGY" },
            { "700", "ARTS AND RECREATION" },
            { "800", "LITERATURE" },
            { "900", "HISTORY AND GEOGRAPHY" }
        };

        //DECLARE VARIABLES
        //IF THE LEFT COLUMN HAS CALL NUMBERS OR DESCRIPTIONS WILL USED FOR DIFFERENTIATING LATER
        public static bool LeftColumnCallNumbers;

        //RANDOM IS USED TO GENERATE RANDOM CALL NUMBERS AND DESCRIPTION
        private static Random random = new Random();

        //CURRENT LEFT BUTTON(QUESTION) USER HAS CLICKED
        public static Button currentQuestion;

        //CURRENT RIGHT BUTTON(ASNWER) USER HAS CLICKED
        public static Button currentAnswer;

        //BEGIN THE GENERATION OF CALL NUMBERS
        public static void GenerateCallNumbers(Button[] leftButtons, int numberOfLeftButtons, Button[] rightButtons, int numberOfRightButtons)
        {
            //IMPLEMENTING THE COLOUR CHANGING METHOD FOR RIGHT COLUMN
            GeneratingRightColumnColors(rightButtons, numberOfRightButtons);

            LeftColumnCallNumbers = false;

            if (random.Next(0, 2) == 0)
            {
                LeftColumnCallNumbers = true;
            }

            //IMPLEMENTING COLUMN METHOD ON APP START
            CreatingColumns(leftButtons, numberOfLeftButtons, rightButtons, numberOfRightButtons);
        }

        //ATTRIBUTION
        //Color.FromArgb Method - https://learn.microsoft.com/en-us/dotnet/api/system.drawing.color.fromargb?view=net-6.0 
        //2022
        public static void GeneratingRightColumnColors(Button[] rightButtons, int numberOfRightButtons)
        {
            //THIS METHOD CHANGES THE COLOUR OF ALL THE RIGHT COLUMN BUTTONS TO GREY
            for (int i = 0; i < numberOfRightButtons; i++)
            {
                //ATTRIBUTION 
                //Flounder.com - http://www.flounder.com/csharp_color_table.htm 
                //14 May 2011 
                rightButtons[i].Text = (i + 1).ToString();
                //GENERATES A GREYISH COLOUR FOR ALL RIGHT COLUMN BUTTONS 
                rightButtons[i].BackColor = Color.FromArgb(119, 136, 153);
                rightButtons[i].ForeColor = Color.White;
            }
        }

        //GENERATING THE COLUMNS - LEFT AND RIGHT 
        public static void CreatingColumns(Button[] leftButtons, int numberOfLeftButtons, Button[] rightButtons, int numberOfRightButtons)
        {
            //STORING LIST OF KEY/VALUE FROM DICTIONARY TO LIST FOR LEFT COLUMN (QUESTIONS)
            List<string> leftColumn = new List<string>();

            //STORING LIST OF KEY/VALUE FROM DICTIONARY TO LIST FOR RIGHT COLUMN (ANSWERS)
            List<string> rightColumn = new List<string>();

            //LEFT COLUMN (QUESTIONS)
            //POPULATING THE LEFT COLUMN LIST AND START OF RIGHT
            //WHILE THE COUNT OF THE LEFT COLUMN IS LESS THAN THE NUMBER OF LEFT BUTTONS(4):
            while (leftColumn.Count < numberOfLeftButtons)
            {
                //GENERATING RANDOMLY FROM THE LIST
                int number = random.Next(0, 9);
                
                string string1;
                string string2;

                if (LeftColumnCallNumbers)
                {
                    //ADDING THE KEY FROM DICTIONARY - CALL NUMS
                    string1 = callNumbersAndDescription.ElementAt(number).Key;
                    //ADDING THE VALUE FROM DICTIONARY - DESCRIPTION
                    string2 = callNumbersAndDescription.ElementAt(number).Value;
                }
                else
                {
                    //ALTERNATING CALL NUMS AND DESC IN DIFF COLUMNS 
                    //ADDING THE VALUE - DESCRIPTION
                    string1 = callNumbersAndDescription.ElementAt(number).Value;
                    //ADDING THE KEY - CALL NUMS
                    string2 = callNumbersAndDescription.ElementAt(number).Key;
                }

                if (!leftColumn.Contains(string1))
                {
                    //INSERT INTO LEFT COLUMN 
                    leftColumn.Add(string1);
                    rightColumn.Add(string2);
                }
            }

            //RIGHT COLUMN (ANSWERS)
            //ADDING ITEMS IN RIGHT COLUMN LIST WITH FAKE ANSWERS AS WELL
            //WHILE THE COUNT OF THE RIGHT COLUMN IS LESS THAN THE NUMBER OF RIGHT BUTTONS(7):
            while (rightColumn.Count < numberOfRightButtons)
            {
                //GENERATING RANDOMLY FROM THE LIST
                int number = random.Next(0, 9);
                string string3;
                if (LeftColumnCallNumbers)
                {
                    //ADDING THE VALUE (DESCRIPTION) 
                    string3 = callNumbersAndDescription.ElementAt(number).Value;
                }
                else
                {
                    //ADDING THE KEY (CALL NUMBER)
                    string3 = callNumbersAndDescription.ElementAt(number).Key;
                }

                //IF THE RIGHT COLUMN DOES NOT CONTAIN THE VALUE OR KEY THEN: 
                if (!rightColumn.Contains(string3))
                {
                    rightColumn.Add(string3);
                }
            }

            // POPULATES THE LEFT COLUMN (QUESTIONS)
            for (int i = 0; i < numberOfLeftButtons; i++)
            {
                leftButtons[i].Text = leftColumn[i];
            }

            //SHUFFLE THE RIGHT COLUMN SO THAT WE DONT HAVE THE ANSWERS LINE UP AND ANSWERS APPEAR IN ANY ORDER
            ReArrange(rightColumn); 

            // POPULATES THE RIGHT COLUMN (ASNWERS)
            for (int i = 0; i < numberOfRightButtons; i++)
            {
                rightButtons[i].Text = rightColumn[i];
            }
        }

        public static void ReArrange<T>(this IList<T> list)
        {
            //ATTRIBUTION
            //Stack Overflow :Randomize a list<T> - https://stackoverflow.com/questions/273313/randomize-a-listt 
            //2009
            //RE ARRANGE METHOD - WILL NOT ALLOW ANSWERS TO PILE UP
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        //ATTRIBUTION 
        //MICROSOFT - BUTTONBASE.FLATSTYLE PROPERTY - https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.buttonbase.flatstyle?view=windowsdesktop-7.0 
        //2022
        public static void ActivateLeftButton(object btnSender)
        {
            //ACTIVATING THE LEFT BUTTONS (LEFT COLUMN - QUESTIONS)
            //SETS THE BUTTON TO THE SELECTED CALL NUMBER 
            if (btnSender != null)
            {
                //IF PREVIOUS ONE WAS CHOSEN THEN DESELECT IT
                if (currentQuestion != null)
                {
                    currentQuestion.FlatStyle = FlatStyle.Flat;
                    currentQuestion = null;
                }

                //HIGHLIGHT SELECTED BUTTON AND SET IT TO CURRENTLEFTBUTTON
                if (currentQuestion != (Button)btnSender)
                {
                    currentQuestion = (Button)btnSender;
                    currentQuestion.FlatStyle = FlatStyle.Popup;
                }
            }
        }

        public static void ActivateRightButton(object btnSender, int numberOfRightButtons, Button[] rightButtons, Button[] leftButtons)
        {
            //ACTIVATING THE RIGHT BUTTONS (RIGHT COLUMN - ANSWERS)
            if (btnSender == null)
            {
                return;
            }

            //IF NO CALL NUM WAS CLICKED, RETURN
            if (currentQuestion == null)
            {
                return;
            }

            currentAnswer = (Button)btnSender;

            //IMPLEMENTING THE CHECKIFMATCHED METHOD
            CheckIfMatched(numberOfRightButtons, rightButtons);

            //ATTRIBUTION 
            //MICROSOFT - BUTTONBASE.FLATSTYLE PROPERTY 
            //SETTING COLOURS OF BUTTONS 
            currentAnswer.BackColor = currentQuestion.BackColor;
            currentAnswer.ForeColor = currentQuestion.ForeColor;

            currentQuestion.FlatStyle = FlatStyle.Flat;
            currentQuestion = null;
        }

        public static bool CheckUserAnswer(Button[] leftButtons, int numberOfLeftButtons, Button[] rightButtons, int numberOfRightButtons)
        {
            //CHECKING ANSWERS
            int useranswers = 0; // NUMBERS OF ANSWERS COUNTER 

            //LEFT COLUMN (QUESTIONS)
            for (int i = 0; i < numberOfLeftButtons; i++)
            {
                //RIGHT COLUMN (ANSWERS)
                for (int j = 0; j < numberOfRightButtons; j++)
                {
                    //IF THE BACKGROUND COLOUR OF THE QUESTION IS SAME AS THE BACKGROUND COLOUR OF THE ANSWER 
                    if (leftButtons[i].BackColor == rightButtons[j].BackColor)
                    {
                        useranswers++;
                        //CHECKING DATA FROM DICTIONARY AND COMPARING IT WITH THE TWO COLUMNS
                        if (LeftColumnCallNumbers)
                        {
                            //FIRST CHECK THE RIGHT COLUMN AGAINST THE LEFT COLUMN (BECAUSE OF ALTERNATION)
                            if (rightButtons[j].Text != callNumbersAndDescription[leftButtons[i].Text])
                            {
                                return false;
                            }
                        }
                        else
                        {
                            //THEN CHECK THE LEFT COLUMN AGAINST THE RIGHT COLUMN (BECASUE OF ALTERNATION)
                            if (leftButtons[i].Text != callNumbersAndDescription[rightButtons[j].Text])
                            {
                                return false;
                            }
                        }

                    }
                }
            }
            //IF THERE AR'NT 4 ANSWERS IN TOTAL
            if (useranswers != 4) //IT IS 4 BECAUSE IN TOTAL THERE ARE 4 QUESTIONS
            {
                return false;
            }
            return true;
        }

        public static void CheckIfMatched(int numberOfRightButtons, Button[] rightButtons)
        {
            for (int i = 0; i < numberOfRightButtons; i++)
            {
                //IF THE ANSWERS WERE CORRECT THEN CHANGE THE COLOUR BACK TO GREY SO THAT USER DOES NOT GET CONFUSED
                if (rightButtons[i].BackColor == currentQuestion.BackColor)
                {
                    rightButtons[i].BackColor = Color.FromArgb(119, 136, 153);
                }
            }
        }
    }
}
