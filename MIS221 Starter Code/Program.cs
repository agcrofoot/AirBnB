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
            if(menuChoice == 1)
            {
                AddListing();
            }
            else if(menuChoice == 2)
            {
                EditListing();
            }
            else if(menuChoice == 3)
            {
                DeleteListing();
            }
            else if(menuChoice == 4)
            {
                LeaseCondo();
            }
            else if(menuChoice == 5)
            {
                RunReport();
            }
            else if(menuChoice == 6)
            {
                GoToExit();
            }
        }

        public static int InputCheck(int menuChoice)
        {
            if(menuChoice < 1 || menuChoice > 6)
            {
                ErrorMessage();
                int newChoice = int.Parse(Console.ReadLine());
                return newChoice;
            }
            else
            {
                return menuChoice;
            }
        }

        public static void AddListing()
        {
            Console.Clear();
            //Instantiates new object
            Listing newListing = new Listing();

            //Prompts new listing ID
            Console.WriteLine("Enter the listing ID (A, B, C, etc.).");
            string listingID = Console.ReadLine();
            newListing.SetID(listingID);

            //Prompts new street address
            Console.WriteLine("Enter the address (ex. 123 Example St. (optional: Apt/Suite 13).");
            string addressStreet = Console.ReadLine();
            newListing.SetAddress(addressStreet);

            //Prompts new city
            Console.WriteLine("Enter the address city.");
            string addressCity = Console.ReadLine();
            newListing.SetCity(addressCity);

            //Prompts new state
            Console.WriteLine("Enter the address state.");
            string addressState = Console.ReadLine();
            newListing.SetState(addressState);

            //Prompts new end day
            Console.WriteLine("Enter the listing end date (mm/dd/yyyy).");
            string endDate = Console.ReadLine();
            newListing.SetDate(endDate);

            //Prompts new listing price
            Console.WriteLine("Enter the listing price.");
            double listPrice = double.Parse(Console.ReadLine());
            newListing.SetPrice(listPrice);

            //Prompt new listing's owner's email
            Console.WriteLine("Enter the listing's  owner's email.");
            string ownerEmail = Console.ReadLine();
            newListing.SetEmail(ownerEmail);

            //Presents status
            Console.WriteLine(newListing.ToString());
            Console.ReadKey();

            //Save to file
            ListingFile.SaveListing(newListing);
            Listing.IntCount();

            //Return to menu
            Menu();
        }

        public static void EditListing()
        {
            Console.Clear();
            Listing[] myListing = ListingFile.GetListings();
            Listing.SortListing(myListing);
            ListingFile.PrintListing(myListing);
            Console.WriteLine("Enter the ID of the listing you would like to edit.");
            string searchValue = Console.ReadLine();
            int foundIndex = Listing.BinarySearch(myListing, searchValue);
            if(foundIndex != -1)
            {
                int menuChoice = EditMenu();
                menuChoice = EditCheck(menuChoice);
                if(menuChoice == 1)
                {
                    Console.WriteLine("Enter new ID.");
                    myListing[foundIndex].SetID(Console.ReadLine());
                }
                else if(menuChoice == 2)
                {
                    Console.WriteLine("Enter new address.");
                    myListing[foundIndex].SetAddress(Console.ReadLine());
                }
                else if(menuChoice == 3)
                {
                    Console.WriteLine("Enter new city.");
                    myListing[foundIndex].SetCity(Console.ReadLine());
                }
                else if(menuChoice == 4)
                {
                    Console.WriteLine("Enter new state.");
                    myListing[foundIndex].SetState(Console.ReadLine());
                }
                else if(menuChoice == 5)
                {
                    Console.WriteLine("Enter new date (mm/dd/yyyy).");
                    myListing[foundIndex].SetDate(Console.ReadLine());
                }
                else if(menuChoice == 6)
                {
                    Console.WriteLine("Enter new price.");
                    myListing[foundIndex].SetPrice(double.Parse(Console.ReadLine()));
                }
                else if(menuChoice == 7)
                {
                    Console.WriteLine("Enter new email.");
                    myListing[foundIndex].SetEmail(Console.ReadLine());
                }
                else
                {
                    ErrorMessage();
                }
            }
            ListingFile.PrintListing(myListing);
            ListingFile.SaveEditedListing(myListing);

            Console.ReadKey();
            Menu();
        }

        public static void DeleteListing()
        {
            Console.Clear();
            Listing[] myListing = ListingFile.GetListings();
            Listing.SortListing(myListing);
            ListingFile.PrintListing(myListing);
            Console.WriteLine("Enter the ID of the listing you would like to delete.");
            string searchValue = Console.ReadLine();
            int foundIndex = Listing.BinarySearch(myListing, searchValue);
            if(foundIndex != -1)
            {

            }
        }

        public static void LeaseCondo()
        {

        }

        public static void RunReport()
        {

        }

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

        public static int EditCheck(int menuChoice)
        {
            if (menuChoice < 1 || menuChoice > 7)
            {
                ErrorMessage();
                int newChoice = int.Parse(Console.ReadLine());
                return newChoice;
            }
            else
            {
                return menuChoice;
            }
        }

        public static void ErrorMessage()
        {
            Console.WriteLine("Input invalid, please enter a valid input.");
        }

        public static void GoToExit()
        {
            Console.Clear();
            Console.WriteLine("Goodbye");
            Console.ReadKey();
            System.Environment.Exit(1);
        }

    }
}
