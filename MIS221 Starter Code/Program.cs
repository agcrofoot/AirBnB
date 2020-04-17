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

        //Routes input to correct area
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

       //Adds Listing
        public static void AddListing()
        {
            Console.Clear();

            Listing[] myListing = Listing.GetListing();

            //Presents status
            Console.Clear();
            ListingFile.PrintListing(myListing);

            //Save to file
            ListingFile.SaveNewListing(myListing);

            //Return to menu
            Console.WriteLine("Press any key to return to the Menu.");
            Console.ReadKey();
            Menu();
        }


        //Edits Listings
        public static void EditListing()
        {
            Console.Clear();

            //Retrieves current listings
            Listing[] myListing = ListingFile.GetListings();
            Check call = new Check();

            //Sorts them by listing ID
            Listing.SortListing(myListing);
            ListingFile.PrintListing(myListing);
            Console.WriteLine("Enter the ID of the listing to edit.");

            //Preforms a binary search for the listing ID
            string searchValue = Console.ReadLine();
            int indexFound = call.SearchListing(myListing, searchValue);

            //Presents menu of options to edit
            Console.Clear();
            int menuChoice = EditMenu();
            menuChoice = call.EditCheck(menuChoice);

            //Edits listing ID
            if (menuChoice == 1)
            {
                Console.Clear();
                Console.WriteLine("Enter new ID.");
                string listingID = Console.ReadLine();
                listingID = call.CheckInput(listingID);
                listingID = call.SearchID(myListing, listingID);
                myListing[indexFound].SetID(listingID);
            }
            //Edits street address
            else if (menuChoice == 2)
            {
                Console.Clear();
                Console.WriteLine("Enter new address.");
                string addressStreet = Console.ReadLine();
                addressStreet = call.CheckInput(addressStreet);
                myListing[indexFound].SetAddress(addressStreet);
            }
            //Edits city
            else if (menuChoice == 3)
            {
                Console.Clear();
                Console.WriteLine("Enter new city.");
                string addressCity = Console.ReadLine();
                addressCity = call.CheckInput(addressCity);
                myListing[indexFound].SetCity(addressCity);
            }
            //Edits state
            else if (menuChoice == 4)
            {
                Console.Clear();
                Console.WriteLine("Enter new state.");
                string addressState = Console.ReadLine().ToUpper();
                addressState = call.CheckState(addressState);
                myListing[indexFound].SetState(addressState);
            }
            //Edits end date
            else if (menuChoice == 5)
            {
                Console.Clear();
                Console.WriteLine("Enter new date (mm/dd/yyyy).");
                string endDate = Console.ReadLine();
                endDate = call.CheckDate(endDate);
                myListing[indexFound].SetDate(endDate);
            }
            //Edits listing price
            else if (menuChoice == 6)
            {
                Console.Clear();
                Console.WriteLine("Enter new price.");
                double listPrice = double.Parse(Console.ReadLine());
                listPrice = call.CheckPrice(listPrice);
                myListing[indexFound].SetPrice(listPrice);
            }
            //Edits owner email
            else if (menuChoice == 7)
            {
                Console.Clear();
                Console.WriteLine("Enter new email.");
                string ownerEmail = Console.ReadLine();
                ownerEmail = call.CheckEmail(ownerEmail);
                myListing[indexFound].SetEmail(ownerEmail);
            }
            //Prints out edited listings
            Console.Clear();
            ListingFile.PrintListing(myListing);

            //Saves edited listings
            ListingFile.SaveEditedListing(myListing, @"C:\Text\listings.txt");

            Console.WriteLine("Press any key to return to the Menu.");
            Console.ReadKey();
            Menu();
        }


        //Deletes listings
        public static void DeleteListing()
        {
            Console.Clear();
            Listing[] myListing = ListingFile.GetListings();
            Check call = new Check();
            Listing.SortListing(myListing);
            ListingFile.PrintListing(myListing);
            Console.WriteLine("Enter the ID of the listing to delete.");
            string searchValue = Console.ReadLine();
            int indexFound = call.SearchListing(myListing, searchValue);

            //Deletes listing found under specified listing ID
            Array.Clear(myListing, indexFound, 1);

            //Decreases count of listings in file
            Listing.ShiftListing(myListing, indexFound);
            Listing.DownCount();
            ListingFile.SaveEditedListing(myListing, @"C:\Text\listings.txt");
            Console.Clear();
            ListingFile.PrintListing(myListing);
            Console.WriteLine("Press any key to return to the Menu.");
            Console.ReadKey();
            Menu();
        }

        public static void LeaseCondo()
        {
            Console.Clear();
            Check call = new Check();
            Console.WriteLine("Enter '1' to lease condo.");
            Console.WriteLine("Enter '2' to edit lease.");
            Console.WriteLine("Enter '3' to delete leasing.");
            int inputChoice = int.Parse(Console.ReadLine());
            inputChoice = call.OptionCheck(inputChoice);

            //Adds rental
            if(inputChoice == 1)
            {
                Console.Clear();
                Renting[] myRentals = Renting.GetRental();

                //Displays rental summary
                Console.Clear();
                RentingFiles.PrintRentals(myRentals);
                RentingFiles.SaveRentals(myRentals, @"C:\Text\transactions.txt");

                Console.WriteLine("Press any key to return to the Menu.");
                Console.ReadKey();
                Menu();
            }
            //Edits rentals
            else if(inputChoice == 2)
            {
                Console.Clear();
                Renting[] myRentals = RentingFiles.GetRentals();
                Listing[] myListing = ListingFile.GetListings();

                Renting.SortRentals(myRentals);
                RentingFiles.PrintRentals(myRentals);
                Console.WriteLine("Enter the ID of the rental to edit.");

                string searchValue = Console.ReadLine();
                int indexFound = call.SearchRenting(myRentals, searchValue);

                Console.Clear();
                int menuChoice = RentingEditMenu();
                menuChoice = call.RentingEditCheck(menuChoice);
                if(menuChoice == 1)
                {
                    //Edits listing ID
                    Console.WriteLine("Edit the listing ID of the listing to be rented.");
                    string listingID = Console.ReadLine();
                    listingID = call.CheckInput(listingID);
                    myRentals[indexFound].SetID(listingID);
                }
                if(menuChoice == 2)
                {
                    //Edits name of person renting
                    Console.Clear();
                    Console.WriteLine("Edit the name of the person renting.");
                    string renterName = Console.ReadLine();
                    renterName = call.CheckInput(renterName);
                    myRentals[indexFound].SetName(renterName);
                }
                if (menuChoice == 3)
                {
                    //Edits renter's email
                    Console.Clear();
                    Console.WriteLine("Enter the renter's email.");
                    string renterEmail = Console.ReadLine();
                    renterEmail = call.CheckEmail(renterEmail);
                    myRentals[indexFound].SetRenterEmail(renterEmail);
                }
                if (menuChoice == 4)
                {
                    //Edits check-in date
                    Console.Clear();
                    Console.WriteLine("Enter the date of check-in.");
                    string rentalDate = Console.ReadLine();
                    string endDate = myListing[indexFound].GetDate();
                    rentalDate = call.CheckInDate(endDate, rentalDate);
                    myRentals[indexFound].SetRentalDate(rentalDate);
                }
                if (menuChoice == 5)
                {
                    //Edits check-out date
                    Console.Clear();
                    string checkInDate = myRentals[indexFound].GetRentalDate();
                    Console.WriteLine("Enter the date of check-out.");
                    string checkOutDate = Console.ReadLine();
                    checkOutDate = call.CheckOutDate(checkOutDate, checkInDate);
                    myRentals[indexFound].SetCheckOutDate(checkOutDate);
                }

                //Updates rental amount
                string searchItem = myRentals[indexFound].GetID();
                int foundPlace = call.SearchListing(myListing, searchItem);
                double listingPrice = myListing[foundPlace].GetPrice();
                myRentals[indexFound].SetAmount(listingPrice);

                //Updates owner email
                string searchInput = myRentals[indexFound].GetID();
                int foundAtIndex = call.SearchListing(myListing, searchInput);
                string ownerEmail = myListing[foundAtIndex].GetEmail();
                myRentals[indexFound].SetOwnerEmail(ownerEmail);

                //Updates total rental amount
                string checkOutDay = myRentals[indexFound].GetCheckOutDate();
                string rentDate = myRentals[indexFound].GetRentalDate();
                DateTime checkOut = DateTime.Parse(checkOutDay);
                DateTime checkIn = DateTime.Parse(rentDate);
                int daysDiff = ((TimeSpan)(checkOut - checkIn)).Days;
                double totalAmount = (daysDiff) * listingPrice;
                myRentals[indexFound].SetTotalAmount(totalAmount);

                Console.Clear();
                RentingFiles.PrintRentals(myRentals);

                //Saves edited rentals
                RentingFiles.SaveEditedRentals(myRentals, @"C:\Text\transactions.txt");

                Console.WriteLine("Press any key to return to the Menu.");
                Console.ReadKey();
                Menu();
            }
            //Deletes specified rental
            else
            {
                Console.Clear();
                Renting[] myRentals = RentingFiles.GetRentals();
                Renting.SortRentals(myRentals);
                RentingFiles.PrintRentals(myRentals);
                Console.WriteLine("Enter the ID of the rental to delete.");
                string searchValue = Console.ReadLine();
                int indexFound = call.SearchRenting(myRentals, searchValue);

                //Deletes rental found under specified listing ID
                Array.Clear(myRentals, indexFound, 1);

                //Decreases count of rentals in file
                Renting.ShiftRentals(myRentals, indexFound);
                Renting.DownCount();
                RentingFiles.SaveEditedRentals(myRentals, @"C:\Text\transactions.txt");
                Console.Clear();
                RentingFiles.PrintRentals(myRentals);
                Console.WriteLine("Press any key to return to the Menu.");
                Console.ReadKey();
                Menu();
            }

        }

        //Runs Reports
        public static void RunReport()
        {
            Console.Clear();
            Check call = new Check();
            Console.WriteLine("Enter '1' to go to Individual Customer Rentals.");
            Console.WriteLine("Enter '2' to go to Historic Customer Rentals.");
            Console.WriteLine("Enter '3' to go to Historic Revenue Report.");
            int inputChoice = int.Parse(Console.ReadLine());
            inputChoice = call.OptionCheck(inputChoice);

            //Goes to Individual Customer Rentals
            if (inputChoice == 1)
            {
                Console.Clear();
                Renting[] myRentals = RentingFiles.GetRentals();
                Renting.SortRentalEmail(myRentals);
                RentingFiles.PrintRentals(myRentals);
                Console.WriteLine("Enter the email address of the person you'd like to see an ICR report on.");
                string searchValue = Console.ReadLine();
                Console.Clear();
                Renting[] myICR = new Renting[100];
                int indexFound = call.SearchRentingEmail(myRentals, searchValue);
                int count = 0;

                //Searches for all instances of email
                while (indexFound != -1)
                {
                    myICR[count] = new Renting(myRentals[indexFound].GetID(), myRentals[indexFound].GetName(), myRentals[indexFound].GetRenterEmail(), myRentals[indexFound].GetRentalDate(), myRentals[indexFound].GetAmount(), myRentals[indexFound].GetCheckOutDate(), myRentals[indexFound].GetOwnerEmail(), myRentals[indexFound].GetTotalAmount());
                    myRentals[indexFound].SetRenterEmail("next");
                    Renting.SortRentalEmail(myRentals);
                    indexFound = Renting.BinaryEmailSearch(myRentals, searchValue);
                    count++;
                }

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(myICR[i].ToString());
                }

                //Reverts file back to original
                Renting.SortRentals(myRentals);
                indexFound = call.SearchRentingEmail(myRentals, "next");
                while (indexFound != -1)
                {
                    myRentals[indexFound].SetRenterEmail(searchValue);
                    RentingFiles.SaveEditedRentals(myRentals, @"C:\Text\transactions.txt");
                    indexFound = Renting.BinaryEmailSearch(myRentals, "next");
                }
                Renting.SortRentals(myRentals);
                RentingFiles.PrintRentals(myRentals);

                //Prompts to save to file or not
                Console.WriteLine("Would you like to save this report to a file?");
                Console.WriteLine("Enter '1' for Yes.");
                Console.WriteLine("Enter '2' for No.");
                int yesOrNo = int.Parse(Console.ReadLine());
                yesOrNo = call.YNCheck(yesOrNo);
                if (yesOrNo == 1)
                {
                    Console.Clear();
                    StreamWriter outFile = File.AppendText(@"C:\Text\icr.txt");

                    for (int i = 0; i < count; i++)
                    {
                        outFile.WriteLine(myICR[i].ToFile());
                    }
                    outFile.Close();
                    Console.WriteLine("The report has been saved.");
                    Console.WriteLine("Press any key to return to the Menu.");
                    Console.ReadKey();
                    Menu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Press any key to return to the Menu.");
                    Console.ReadKey();
                    Menu();
                }

            }
            else if (inputChoice == 2)
            {
                Console.Clear();
                Renting[] myRentals = RentingFiles.GetRentals();
                Renting.SortRenterName(myRentals);
                Renting.HCRReports(myRentals);

                //Prompts to save to file or not
                Console.WriteLine("Would you like to save this report to a file?");
                Console.WriteLine("Enter '1' for Yes.");
                Console.WriteLine("Enter '2' for No.");
                int yesOrNo = int.Parse(Console.ReadLine());
                yesOrNo = call.YNCheck(yesOrNo);
                if (yesOrNo == 1)
                {
                    Console.Clear();

                    Console.WriteLine("The report has been saved.");
                    Console.WriteLine("Press any key to return to the Menu.");
                    Console.ReadKey();
                    Menu();
                }
                else
                {
                    Console.Clear();
                    File.WriteAllText(@"C:\Text\hcr.txt", String.Empty);
                    Console.WriteLine("Press any key to return to the Menu.");
                    Console.ReadKey();
                    Menu();
                }



            }
            else
            {

            }
        }

        //Checks is initial input is valid for menu
        public static int InputCheck(int menuChoice)
        {
            string menuString = menuChoice.ToString();
            if (string.IsNullOrEmpty(menuString))
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

        public static int RentingEditMenu()
        {
            Console.WriteLine("Enter '1' to edit listing ID.");
            Console.WriteLine("Enter '2' to edit renter name.");
            Console.WriteLine("Enter '3' to edit renter email.");
            Console.WriteLine("Enter '4' to edit check-in date.");
            Console.WriteLine("Enter '5' to edit check-out date.");

            return int.Parse(Console.ReadLine());
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
