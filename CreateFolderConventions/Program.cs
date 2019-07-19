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
            int sel = Console.Read();
            if (sel == '1') NameAndNumber();
            if (sel == '2') NameAndDate();
            if (sel == '3') return 1;
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

                //Enter top-folder location
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
                //Enter folder names
                FlushInput();
                Console.Write("Folder name: ");
                string subfolder = Console.ReadLine();
                FlushInput();

                //Enter first folder number
                Console.Write("Number of FIRST folder: ");
                string inputa = Console.ReadLine();
                int number;
                int.TryParse(inputa, out number);
                FlushInput();

                //Enter last folder number
                Console.WriteLine("Number of LAST folder: ");
                string inputb = Console.ReadLine();
                int count;
                int.TryParse(inputb, out count);
                FlushInput();

                //For-loop that creates the folders from the given directory
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

                //Prompt to start again/exit
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
            Console.WriteLine("# # # # # # NAME and DATE of a SINGLE folder");
            Console.WriteLine("");
            bool cont = true;
            string dateFormat = "";
            while (cont == true)
            {
                string folderInput = "";
                string folderName = "";
                bool valid = true;

                //Enter top-folder location
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
                //Enter folder names
                FlushInput();
                Console.Write("Folder name: ");
                string subfolder = Console.ReadLine();
                
                //Enter date format of folder
                while (valid)
                {
                    FlushInput();
                    Console.WriteLine("Choose a DATE format:");
                    Console.WriteLine("    1) January 1 2019");
                    Console.WriteLine("    2) Jan 1 2019");
                    Console.WriteLine("    3) 01 01 2019");
                    Console.WriteLine("    4) 01012019");
                    int selDateFormat = Console.Read();
                    if(selDateFormat == '1')
                    {
                        dateFormat = "_MMMM dd yyyy";
                        break;
                    }
                    else if(selDateFormat == '2')
                    {
                        dateFormat = "_MMM dd yyyy";
                        break;
                    }
                    else if(selDateFormat == '3')
                    {
                        dateFormat = "_MM dd yyyy";
                        break;
                    }
                    else if(selDateFormat == '4')
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
                DateTime date = DateTime.Now;
                string dateVal = date.ToString(dateFormat);
                FlushInput();
              
                //Creates the folder from the given directory
                Console.WriteLine("Spinning up...");
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

                //Prompt to start again/exit
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
        //Empties the input stream buffer
        private static void FlushInput()
        {
            while (Console.In.Peek() != -1)
                Console.In.Read();
        }


    }


}
