using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            //Starter Code
            //Menu
            Menu();

        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Add Listing '1'");
            Console.WriteLine("Edit Listing '2'");
            Console.WriteLine("Delete Listing '3'");
            Console.WriteLine("Lease Condo '4'");
            Console.WriteLine("Run Report '5'");
            Console.WriteLine("Exit '6'");

            int menuChoice = int.Parse(Console.ReadLine());
            menuChoice = InputCheck(menuChoice);
            Route(menuChoice);
        }

        public static void Route(int menuChoice)
        {
            if (menuChoice == 1)
            {
                AddListing();
            }
            else if (menuChoice == 2)
            {
                EditListing();
            }
            else if (menuChoice == 3)
            {
                DeleteListing();
            }
            else if (menuChoice == 4)
            {
                LeaseCondo();
            }
            else if (menuChoice == 5)
            {
                RunReport();
            }
            else if (menuChoice == 6)
            {
                GoToExit();
            }
        }

        public static int InputCheck(int menuChoice)
        {
            string menuString = menuChoice.ToString();
            if(string.IsNullOrEmpty(menuString))
            {
                ErrorMessage();
                int input1 = int.Parse(Console.ReadLine());
                int input2 = InputCheck(input1);
                return input2;
            }
            else
            {
                if (menuChoice < 1 || menuChoice > 6)
                {
                    ErrorMessage();
                    int input1 = int.Parse(Console.ReadLine());
                    int input2 = InputCheck(input1);
                    return input2;
                }
                else
                {
                    return menuChoice;
                }
            }
        }

        public static void AddListing()
        {
            Console.Clear();
            //Instantiates new object
            Listing newListing = new Listing();

            //Prompts new listing ID
            Console.WriteLine("Enter the listing ID.");
            string listingID = Console.ReadLine();
            listingID = CheckID(listingID);
            newListing.SetID(listingID);

            //Prompts new street address
            Console.WriteLine("Enter the address (ex. 123 Example St. (optional: Apt/Suite 13).");
            string addressStreet = Console.ReadLine();
            addressStreet = CheckAddress(addressStreet);
            newListing.SetAddress(addressStreet);

            //Prompts new city
            Console.WriteLine("Enter the address city.");
            string addressCity = Console.ReadLine();
            addressCity = CheckAddress(addressCity);
            newListing.SetCity(addressCity);

            //Prompts new state
            Console.WriteLine("Enter the address state abbriviation.");
            string addressState = Console.ReadLine().ToUpper();
            addressState = CheckState(addressState);
            newListing.SetState(addressState);

            //Prompts new end day
            Console.WriteLine("Enter the listing end date (mm/dd/yyyy).");
            string endDate = Console.ReadLine();
            endDate = CheckDate(endDate);
            newListing.SetDate(endDate);

            //Prompts new listing price
            Console.WriteLine("Enter the listing price.");
            double listPrice = double.Parse(Console.ReadLine());
            listPrice = CheckPrice(listPrice);
            newListing.SetPrice(listPrice);

            //Prompt new listing's owner's email
            Console.WriteLine("Enter the listing's  owner's email.");
            string ownerEmail = Console.ReadLine();
            ownerEmail = CheckEmail(ownerEmail);
            newListing.SetEmail(ownerEmail);

            //Presents status
            Console.WriteLine(newListing.ToString());
            Console.ReadKey();

            //Save to file
            ListingFile.SaveListing(newListing);

            //Increases count of listings in file
            Listing.IntCount();

            //Return to menu
            Menu();
        }


        //Edits Listings
        public static void EditListing()
        {
            Console.Clear();

            //Retrieves current listings
            Listing[] myListing = ListingFile.GetListings();

            //Sorts them by listing ID
            Listing.SortListing(myListing);
            ListingFile.PrintListing(myListing);
            Console.WriteLine("Enter the ID of the listing to edit.");

            //Preforms a binary search for the listing ID
            string searchValue = Console.ReadLine();
            int foundIndex = Search(myListing, searchValue);

            //Presents menu of options to edit
            int menuChoice = EditMenu();
            menuChoice = EditCheck(menuChoice);

            //Edits listing ID
            if (menuChoice == 1)
            {
                Console.WriteLine("Enter new ID.");
                string listingID = Console.ReadLine();
                listingID = CheckID(listingID);
                myListing[foundIndex].SetID(listingID);
            }
            //Edits street address
            else if (menuChoice == 2)
            {
                Console.WriteLine("Enter new address.");
                string addressStreet = Console.ReadLine();
                addressStreet = CheckAddress(addressStreet);
                myListing[foundIndex].SetAddress(addressStreet);
            }
            //Edits city
            else if (menuChoice == 3)
            {
                Console.WriteLine("Enter new city.");
                string addressCity = Console.ReadLine();
                addressCity = CheckAddress(addressCity);
                myListing[foundIndex].SetCity(addressCity);
            }
            //Edits state
            else if (menuChoice == 4)
            {
                Console.WriteLine("Enter new state.");
                string addressState = Console.ReadLine().ToUpper();
                addressState = CheckState(addressState);
                myListing[foundIndex].SetState(addressState);
            }
            //Edits end date
            else if (menuChoice == 5)
            {
                Console.WriteLine("Enter new date (mm/dd/yyyy).");
                string endDate = Console.ReadLine();
                endDate = CheckDate(endDate);
                myListing[foundIndex].SetDate(endDate);
            }
            //Edits listing price
            else if (menuChoice == 6)
            {
                Console.WriteLine("Enter new price.");
                double listPrice = double.Parse(Console.ReadLine());
                listPrice = CheckPrice(listPrice);
                myListing[foundIndex].SetPrice(listPrice);
            }
            //Edits owner email
            else if (menuChoice == 7)
            {
                Console.WriteLine("Enter new email.");
                string ownerEmail = Console.ReadLine();
                ownerEmail = CheckEmail(ownerEmail);
                myListing[foundIndex].SetEmail(ownerEmail);
            }
            //Prints out edited listings
            ListingFile.PrintListing(myListing);

            //Saves edited listings
            ListingFile.SaveEditedListing(myListing);

            Console.ReadKey();
            Menu();
        }


        //Deletes listings
        public static void DeleteListing()
        {
            Console.Clear();
            Listing[] myListing = ListingFile.GetListings();
            Listing.SortListing(myListing);
            ListingFile.PrintListing(myListing);
            Console.WriteLine("Enter the ID of the listing to delete.");
            string searchValue = Console.ReadLine();
            int foundIndex = Search(myListing, searchValue);

            //Deletes listing found under specified listing ID
            Array.Clear(myListing, foundIndex, 6);

            //Decreases count of listings in file
            Listing.DownCount();
            ListingFile.SaveEditedListing(myListing);
            ListingFile.PrintListing(myListing);
            Console.ReadKey();
            Menu();
        }

        public static void LeaseCondo()
        {

        }

        public static void RunReport()
        {

        }

        //Presents menu of editable options
        public static int EditMenu()
        {
            Console.WriteLine("Enter '1' to edit listing ID.");
            Console.WriteLine("Enter '2' to edit street addess.");
            Console.WriteLine("Enter '3' to edit city.");
            Console.WriteLine("Enter '4' to edit state.");
            Console.WriteLine("Enter '5' to edit listing end date.");
            Console.WriteLine("Enter '6' to edit listing price.");
            Console.WriteLine("Enter '7' to edit listing owner email.");

            return int.Parse(Console.ReadLine());
        }

        //Checks if input was valid
        public static int EditCheck(int menuChoice)
        {
            string menuString = menuChoice.ToString();
            if(string.IsNullOrEmpty(menuString))
            {
                ErrorMessage();
                int input1 = int.Parse(Console.ReadLine());
                int input2 = EditCheck(input1);
                return input2;
            }
            else
            {
                if (menuChoice < 1 || menuChoice > 7)
                {
                    ErrorMessage();
                    int input1 = int.Parse(Console.ReadLine());
                    int input2 = EditCheck(input1);
                    return input2;
                }
                else
                {
                    return menuChoice;
                }
            }
        }
        

        //Checks if id was valid
        public static string CheckID(string listingID)
        {
            if(string.IsNullOrEmpty(listingID))
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = CheckID(input1);
                return input2;
            }
            else
            {
                return listingID;
            }
        }

        //Checks if address and city were valid
        public static string CheckAddress(string addressStreet)
        {
            if(string.IsNullOrEmpty(addressStreet))
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = CheckAddress(input1);
                return input2;
            }
            else
            {
                return addressStreet;   
            }
        }
        
        //Checks if state was valid
        public static string CheckState(string addressState)
        {
            if(string.IsNullOrEmpty(addressState))
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = CheckState(input1);
                return input2;
            }
            else
            {
                char[] stateAbbrv = addressState.ToArray();
                if (stateAbbrv.Length < 2)
                {
                    ErrorMessage();
                    string input1 = Console.ReadLine();
                    string input2 = CheckState(input1);
                    return input2;
                }
                else
                {
                    return addressState;
                }
            }
        }

        //Checks if date was valid
        public static string CheckDate(string endDate)
        {
            if(string.IsNullOrEmpty(endDate))
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = CheckDate(input1);
                return input2;
            }
            else
            {
                DateTime dDate = DateTime.Parse(endDate);
                DateTime today = DateTime.Today;
                if (dDate > today)
                {
                    return string.Format("{0:MM/dd/yyyy}", dDate);
                }
                else
                {
                    ErrorMessage();
                    string input1 = Console.ReadLine();
                    string input2 = CheckDate(input1);
                    return input2;
                }
                
            }
        }


        //Checks if price was valid
        public static double CheckPrice(double listPrice)
        {
            string priceString = listPrice.ToString();
            if(string.IsNullOrEmpty(priceString))
            {
                ErrorMessage();
                double input1 = double.Parse(Console.ReadLine());
                double input2 = CheckPrice(input1);
                return input2;
            }
            else
            {
                if(listPrice < 0)
                {
                    ErrorMessage();
                    double input1 = double.Parse(Console.ReadLine());
                    double input2 = CheckPrice(input1);
                    return input2;
                }
                else
                {
                    return listPrice;
                }
            }
        }

        //Checks if email was valid
        public static string CheckEmail(string ownerEmail)
        {
            if(string.IsNullOrEmpty(ownerEmail))
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = CheckEmail(input1);
                return input2;
            }
            else
            {
                if (ownerEmail.Contains("@") && ownerEmail.Contains("."))
                {
                    return ownerEmail;
                }
                else
                {
                    ErrorMessage();
                    string input1 = Console.ReadLine();
                    string input2 = CheckEmail(input1);
                    return input2;
                }
            }

        }

        //Checks if search value was valid
        public static int Search(Listing[] myListing, string searchValue)
        {
            int foundIndex = Listing.BinarySearch(myListing, searchValue);
            if(foundIndex != -1)
            {
                return foundIndex;
            }
            else
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                int input2 = Search(myListing, input1);
                return input2;
            }
        }

        //Displays error message
        public static void ErrorMessage()
        {
            Console.WriteLine("Input invalid, please enter a valid input.");
        }

        //Exits program
        public static void GoToExit()
        {
            Console.Clear();
            Console.WriteLine("Goodbye");
            Console.ReadKey();
            System.Environment.Exit(1);
        }

    }
}
