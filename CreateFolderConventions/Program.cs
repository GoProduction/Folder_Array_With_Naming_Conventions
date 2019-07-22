using System;
using System.IO;

namespace CreateFolderConventions
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            while (Menu() == 0) ;
            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }
        public static void Context()
        {
            Console.WriteLine("To create a series of folders with naming conventions, please select from the following: ");
            Console.WriteLine("1) Name of folder - number (Test_1)");
            Console.WriteLine("2) Name of folder - date (Test_01012019)");
        }
        public static int Menu()
        {
            Console.Clear();
            Context();
            try
            {
                int sel = int.Parse(Console.ReadLine());
                if (sel == 1) NameAndNumber();
                if (sel == 2) NameAndDate();
                if (sel == 3) return 1;
            }
            catch
            {
                Console.WriteLine("Invalid input. Try again...");
                FlushInput();
            }
            return 0;
        }
        public static int NameAndNumber()
        {
            Console.Clear();
            Console.WriteLine("# # # # # # NAME and NUMBER folder format # # # # # #");
            Console.WriteLine();
            bool cont = true;
            while (cont == true)
            {
                string folderInput = "";
                string folderName = "";
                bool valid = true;

                //ENTER TOP-FOLDER LOCATION
                while (valid)
                {
                    FlushInput();
                    Console.Write("Location of the top folder: ");
                    folderInput = Console.ReadLine();
                    folderName = @"" + folderInput;
                    if (Directory.Exists(folderInput)) break;
                    else
                    {
                        Console.WriteLine("That is not a valid folder... Please try again.");
                        continue;
                    }
                }
                //ENTER FOLDER NAMES
                FlushInput();
                Console.Write("Folder name: ");
                string subfolder = Console.ReadLine();
                FlushInput();

                //ENTER FIRST FOLDER NUMBER
                Console.Write("Number of FIRST folder: ");
                int number = int.Parse(Console.ReadLine());
                FlushInput();

                //ENTER LAST FOLDER NUMBER
                Console.WriteLine("Number of LAST folder: ");
                int count = int.Parse(Console.ReadLine());
                FlushInput();

                //FOR-LOOP THAT CREATES THE FOLDERS IN THE GIVEN DIRECTORY
                Console.WriteLine("Spinning up...");
                for (double i = number; i <= count; i++)
                {
                    string pathString = Path.Combine(folderName, subfolder + "_" + i);
                    if (!Directory.Exists(pathString))
                    {
                        Directory.CreateDirectory(pathString);
                        Console.WriteLine("Created: " + subfolder + "_" + i);
                    }
                    else
                    {
                        Console.WriteLine("File \"{0}\" already exists.", pathString);
                        break;
                    }

                }

                //PROMPT TO START AGAIN/EXIT
                Console.WriteLine("Would you like to try again? y/n");
                string sel = Console.ReadLine();
                if (sel == "y") continue;
                else
                {
                    cont = false;
                    break;
                }
            }
            return 0;
        }

        public static int NameAndDate()
        {
            Console.Clear();
            Console.WriteLine("# # # # # # NAME and DATE of folder(s) # # # # # #");
            Console.WriteLine("");
            bool cont = true;
            string dateFormat = "";
            while (cont == true)
            {
                string folderInput = "";
                string folderName = "";
                int selTypeInput = 0;
                DateTime dateStart = new DateTime();
                DateTime dateEnd = new DateTime();
                TimeSpan dateSpan;
                DateTime[] dateArray;
                bool valid = true;

                //SELECT TYPE OF ARRAY
                while (valid)
                {
                    FlushInput();
                    Console.WriteLine("Enter what type of folder array you would like to create:");
                    Console.WriteLine("1) Today's date (one folder)");
                    Console.WriteLine("2) Another date (one folder)");
                    Console.WriteLine("3) Several dates (multiple folders)");
                    try
                    {
                        selTypeInput = int.Parse(Console.ReadLine());
                        FlushInput();
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. Please try again...");
                        FlushInput();
                        continue;
                    }
                    
                    if(selTypeInput == 1)
                    {
                        dateStart = DateTime.Now;
                        dateEnd = DateTime.Now;
                        Console.WriteLine("CONSOLE: dateStart is " + dateStart);
                        Console.WriteLine("CONSOLE: dateEnd is " + dateEnd);
                        break;
                    }
                    else if(selTypeInput == 2)
                    {
                        Console.Write("Please enter a date with a valid format (ex. January 1st, 2010 would be 01/01/2010)");
                        dateStart = DateTime.Parse(Console.ReadLine());
                        dateEnd = dateStart;
                        Console.WriteLine("CONSOLE: dateStart is " + dateStart);
                        Console.WriteLine("CONSOLE: dateEnd is " + dateEnd);
                        break;
                    }
                    else if (selTypeInput == 3)
                    {
                        Console.WriteLine("Enter the start date with a valid format (January 1st, 2010 would be 01/01/2010");
                        dateStart = DateTime.Parse(Console.ReadLine());
                        FlushInput();
                        Console.WriteLine("Enter the end date with a valid format (January 1st, 2010 would be 01/01/2010");
                        dateEnd = DateTime.Parse(Console.ReadLine());
                        FlushInput();
                        Console.WriteLine("CONSOLE: dateStart is " + dateStart);
                        Console.WriteLine("CONSOLE: dateEnd is " + dateEnd);
                        break;
                    }

                }

                //ENTER TOP-FOLDER DIRECTORY
                while (valid)
                {
                    FlushInput();
                    Console.Write("Location of the top folder: ");
                    folderInput = Console.ReadLine();
                    folderName = @"" + folderInput;
                    if (Directory.Exists(folderInput)) break;
                    else
                    {
                        Console.WriteLine("That is not a valid folder... Please try again.");
                        continue;
                    }
                }
                //ENTER FOLDER NAMES
                FlushInput();
                Console.Write("Folder name: ");
                string subfolder = Console.ReadLine();
                
                //ENTER DATE FORMAT OF FOLDER
                while (valid)
                {
                    FlushInput();
                    Console.WriteLine("Choose a DATE format:");
                    Console.WriteLine("    1) January 1 2019");
                    Console.WriteLine("    2) Jan 1 2019");
                    Console.WriteLine("    3) 01 01 2019");
                    Console.WriteLine("    4) 01012019");
                    int selDateFormat = int.Parse(Console.ReadLine());
                    if(selDateFormat == 1)
                    {
                        dateFormat = "_MMMM dd yyyy";
                        break;
                    }
                    else if(selDateFormat == 2)
                    {
                        dateFormat = "_MMM dd yyyy";
                        break;
                    }
                    else if(selDateFormat == 3)
                    {
                        dateFormat = "_MM dd yyyy";
                        break;
                    }
                    else if(selDateFormat == 4)
                    {
                        dateFormat = "_MMddyyyy";
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Try again...");
                        continue;
                    }

                }
                
                FlushInput();
                //INITIALIZE DATE VARIABLES FOR CALCULATION
                dateSpan = dateEnd.Subtract(dateStart);
                dateArray = new DateTime[dateSpan.Days];
              
                //CREATES TO FOLDER(S) FROM THE GIVEN DIRECTORY
                Console.WriteLine("Spinning up...");
                for(int i = 0; i < dateSpan.Days; i++)
                {
                    
                    dateArray[i] = dateStart;
                    string dateVal = dateStart.ToString(dateFormat);
                    dateStart = dateStart.AddDays(1);
                    string pathString = Path.Combine(folderName, subfolder + dateVal);
                    if (!Directory.Exists(pathString))
                    {
                        Directory.CreateDirectory(pathString);
                        Console.WriteLine("Created: " + subfolder + dateVal);
                    }
                    else
                    {
                        Console.WriteLine("File \"{0}\" already exists.", pathString);
                        break;
                    }
                }
                
                //PROMPT TO START AGAIN/EXIT
                Console.WriteLine(dateFormat);
                Console.WriteLine("Would you like to try again? y/n");
                string sel = Console.ReadLine();
                if (sel == "y") continue;
                else
                {
                    cont = false;
                    break;
                }
            }
            return 0;
        }

        //EMPTIES THE INPUT STREAM BUFFER
        private static void FlushInput()
        {
            while (Console.In.Peek() != -1)
                Console.In.Read();
        }


    }


}
