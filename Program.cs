//jade
//C Unit project
//april 1


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegareUnitCProject
{
    class Program
    {
        static void Main(string[] args)
        {


            // Initialize variables
            bool keepGoing = true;
            string postalCode = "";
            var input = "";
            int choice = 0;
            bool validInput = false;
            var code = "";

            do
            {
                // Display a menu and ask for an option
                printMenu();


                do
                {

                // write a generic function to get an int from the user
                Console.WriteLine("Enter an option: ");
                input = Console.ReadLine();

                    //try/catch method
                    if (convertInt(input))
                    {
                        //set bool valid input to true
                        validInput = true;
                        choice = Convert.ToInt32(input);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid option: ");
                    }
                } while (!validInput);

                // Call appropriate function for the menu item
                switch (choice)
                {
                    case 1:
                        // Use a function
                        Console.WriteLine("Option 1");
                        Console.WriteLine("");
                        Console.WriteLine("Hit any key to continue");
                        Console.ReadKey();

                        for (int i = 1; i == 20; i++)
                        {
                            // Create a function to store postal codes
                            string[] arrayPC;
                            arrayPC = new string[20];
                            //char[] array = value.ToCharArray();


                            //prompt user to enter postal code
                            Console.WriteLine("Enter a postal code");
                            //store in array 
                            //check is its valid
                            valid();
                            arrayPC[i] = Console.ReadLine();

                            // That function will get, validate and store
                            // Use a separate function to validate

                            break;
                        }

                    case 2://display urban codes
                        displayUrbanCodes();
                        //get codes that have 0 as char 1
                        break;
                    case 3://display rural codes
                        displayRuralCodes();
                        break;
                    case 4://display all codes
                        displayAllCodes();
                        break;
                    case 5:
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect Option");
                        break;
                }
            } while (keepGoing);

            Console.WriteLine("The end");
            Console.ReadKey();
        }

        static void printMenu()
        {
            //write options on screen in menu format
            //title seprate from options
            Console.WriteLine("Menu");
            Console.WriteLine("*********");
            Console.WriteLine("");
            //display options
            Console.WriteLine("Chose an option");
            // hoice to enter a postal code
            Console.WriteLine("  1) Enter a postal code (ANA NAN)");
            //option to display the rural postal codes
            Console.WriteLine("  2) Display urban postal codes");
            //option to display rural postal codes
            Console.WriteLine("  3) Display rural postal codes");
            //option to display all postal codes
            Console.WriteLine("  4) Display all postal codes");
            Console.WriteLine("  5) Quit");
            Console.WriteLine("");
        }

        static void displayUrbanCodes()
        {
              var i = "";
            //write on screen 
            Console.WriteLine("Displaying Urban Codes...");
            Console.WriteLine("*************************");
            Console.WriteLine("");
            //get codes with char 1 != 0
             if (i.Contains("0"))
            {
                Console.WriteLine();
            }
            //prompt user to press key
            Console.WriteLine("Hit any key to continue");
            Console.ReadKey();
        }

        static void displayRuralCodes()
        {
            //display action on screen
            Console.WriteLine("Displaying Rural Codes...");
            Console.WriteLine("*************************");
            Console.WriteLine("");
            //get codes that char 1 == 0

            Console.WriteLine("Hit any key to continue");
            Console.ReadKey();
        }

        static void displayAllCodes()
        {
          
            Console.WriteLine("Displaying all Codes...");
            Console.WriteLine("*************************");
            Console.WriteLine("");
            //all input in arrayPC
           
            Console.WriteLine("Hit any key to continue");
            Console.ReadKey();
        }

        // Create more functions here
        private static bool convertInt(string s)
        {
            //try block
            try 
            {
                //convert input to int
                Convert.ToInt32 (s);
                //set bool to true
                return true;
            }
            catch(FormatException)
            {
                return false;
            }
        }
        static int CountChars(string value)
        {
            int result = 0;
            bool lastWasSpace = false;

            foreach (char c in value)
            {
                if (char.IsWhiteSpace(c))
                {
                    // A.
                    // Only count sequential spaces one time.
                    if (lastWasSpace == false)
                    {
                        result++;
                    }
                    lastWasSpace = true;
                }
                else
                {
                    // B.
                    // Count other characters every time.
                    result++;
                    lastWasSpace = false;
                }
            }
            return result;
        }

        //private static void pc()
        //{
        //    do
        //    {
        //        int[] arrayPC;
                
        //        for (int i = 1; i == 20; i++)
        //        {

        //        Console.WriteLine("Enter Postal Code " + arrayPC[i] + ": ");
        //        arrayPC = Console.ReadLine()[20];
        //        }

        //    }
        // }

        static void urban();
    {
        if 

    }
        private static bool valid(string s)
        {
            bool validInput = true;
        var i = "";

           if (i.Contains("d"))
           {
               //doesnt store in array 
               validInput = false;
               Console.WriteLine("Invalid Postal Code");
           }
           else if (i.Contains("I"))
           {
               //dont store
                validInput = false;
               Console.WriteLine("Invalid Postal Code");
           }
           else if (i.Contains("O"))
           {

            //dont store
                validInput = false;
               Console.WriteLine("Invalid Postal Code");
           }
           else if (i.Contains("Q"))
           {
               //dont store
                validInput = false;
               Console.WriteLine("Invalid Postal Code");
           }
           else if (i.Contains("F"))
           {
               //dont store
                validInput = false;
               Console.WriteLine("Invalid Postal Code");
           }
           else if //(char1||char3 = "W")
           {
               //invalid, cont store
                validInput = false;
               Console.WriteLine("Invalid Postal Code");
           }
           else if (s[1] = "Z")
           {
               //invalid, dont store
                validInput = false;
               Console.WriteLine("Invalid Postal Code");
           }
           else
           {
               //valid input, store
               validInput = true;
           }
            
        }

        //private static void rural()
        //{
        //    if  //(char2 == 0)
        //    { 
        //        code = "Rural";
        //    }
        //    else 
        //    {
        //        code = "Urban";
        //    }
        //}







    }







    //    static void Main2(string[] args)
    //    {
    //        string j = "";
    //        string k = "";
    //        string l = "";
    //        string m = "";
    //        string q = "";
    //        string input = "";
    //        int postal = 0;
    //        string postalCode = "";
    //        string[] arrayOfCode;
    //        do
    //        {
    //            if (postalCode[1] == "0")
    //            {
    //                postalCode = new string rural


    //            //prompt user to decide if they want to add a postal code
    //            Console.WriteLine("Do you want to add a postal code? Y/N");
    //            //set string j to user unpit
    //            j = Console.ReadLine();

    //            //if value of j is Y
    //            if (j == "Y")
    //            {
    //                //prompt user to enter a postal code
    //                Console.WriteLine("Enter postal code:");
    //                postalCode = Console.ReadLine();
    //                //check if valid ANA NAN
    //           if (isLetter(postalCode))
    //           {
    //               arrayOfCode[0] = Convert.ToString(postalCode);
    //           }
    //           if (isNumber(postalCode))
    //           {
    //                    arrayOfCode[1] = Convert.ToInt32(postal);
    //           }
    //           if (isLetter(postalCode))
    //           {
    //                    arrayOfCode[2] = Convert.ToString(postalCode);
    //           }
    //                if (isNumber(string))
    //                {
    //                    arrayOfCode[3] = Convert.ToInt32(postal);
    //                }
                   
    //                if (isNumber(postalCode))
    //                {
    //                    arrayOfCode[4] = Convert.ToInt32(postal);
    //                }
    //                 if (isLetter(postalCode))
    //                {
    //                    arrayOfCode[5] = Convert.ToString(postalCode);
    //                }
    //                if (isLetter(postalCode))
    //                {
    //                    arrayOfCode[6] = Convert.ToInt32(postal);
    //                }
    //            }
    //            //if value of j is n
    //            else if (j == "N")
    //            {
    //                //promt user to decide if want to get urban psotal codes
    //                Console.WriteLine("Do you want to get urban postal codes? Y/N");
    //                //set k to user input
    //                k = Console.ReadLine();
    //                //if k is y 
    //                if (k == "Y")
    //                {
    //                    //get urban postal codes
    //                }

    //                //if k is n
    //                else if (k == "N")
    //                {
    //                    //prompt user to decide if want to get rural postal codes
    //                    Console.WriteLine("Do you want to get rural postal codes? Y/N");
    //                    //set value of l to userinput  
    //                    l = Console.ReadLine();
    //                    //if user input is y
    //                    if (l == "Y")
    //                    {
    //                        //get rural postal codes
    //                    }
    //                    //is user input is n
    //                    else if (l == "N")
    //                    {
    //                        // prompt user to decide if want to get all postal codes
    //                        Console.WriteLine("Do you want to get all postal codes? Y/N");
    //                        //set m to user input
    //                        m = Console.ReadLine();
    //                        //if m is y
    //                        if (m == "Y")
    //                        {
    //                            //get all postal codes
    //                        }
    //                        //is m is n
    //                        else if (m == "N")
    //                        {
    //                            //prompt user if they want to quit
    //                            Console.WriteLine("Do you want to quit?Y/N");
    //                            //set value of q to user input
    //                            q = Console.ReadLine();
    //                            //if yes then break from loop
    //                            if (q == "Y")
    //                            {
    //                                break;
    //                            }
                                
    //                            private static bool isLetter (string s)
    //                            {
    //                                try
    //                                {
    //                                    Convert.ToString(s);
    //                                    return true;
    //                                }
    //                                catch (FormatException)
    //                                {
    //                                    return false;
    //                                }
    //                            }

    //                           private static bool isNumber (string w)
    //                            {
    //                                    try 
    //                                    {
    //                                        Convert.ToInt32(w);
    //                                        return true;
    //                                    }
    //                               catch (FormatException)
    //                               {
    //                                   return false;
    //                               }
    //                           }
        


    //                        }
    //                    }
    //                }
    //            }

    //        } while (q == "N");
    //    }
    //}
}

