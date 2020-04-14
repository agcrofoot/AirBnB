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
            Console.Clear();
            Console.WriteLine("Enter the listing ID.");
            string listingID = Console.ReadLine();
            listingID = CheckInput(listingID);
            newListing.SetID(listingID);

            //Prompts new street address
            Console.Clear();
            Console.WriteLine("Enter the address (ex. 123 Example St. (optional: Apt/Suite 13).");
            string addressStreet = Console.ReadLine();
            addressStreet = CheckInput(addressStreet);
            newListing.SetAddress(addressStreet);

            //Prompts new city
            Console.Clear();
            Console.WriteLine("Enter the address city.");
            string addressCity = Console.ReadLine();
            addressCity = CheckInput(addressCity);
            newListing.SetCity(addressCity);

            //Prompts new state
            Console.Clear();
            Console.WriteLine("Enter the address state abbriviation.");
            string addressState = Console.ReadLine().ToUpper();
            addressState = CheckState(addressState);
            newListing.SetState(addressState);

            //Prompts new end day
            Console.Clear();
            Console.WriteLine("Enter the listing end date (mm/dd/yyyy).");
            string endDate = Console.ReadLine();
            endDate = CheckDate(endDate);
            newListing.SetDate(endDate);

            //Prompts new listing price
            Console.Clear();
            Console.WriteLine("Enter the listing price.");
            double listPrice = double.Parse(Console.ReadLine());
            listPrice = CheckPrice(listPrice);
            newListing.SetPrice(listPrice);

            //Prompt new listing's owner's email
            Console.Clear();
            Console.WriteLine("Enter the listing's  owner's email.");
            string ownerEmail = Console.ReadLine();
            ownerEmail = CheckEmail(ownerEmail);
            newListing.SetEmail(ownerEmail);

            //Presents status
            Console.Clear();
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
            int foundIndex = SearchListing(myListing, searchValue);

            //Presents menu of options to edit
            Console.Clear();
            int menuChoice = EditMenu();
            menuChoice = EditCheck(menuChoice);

            //Edits listing ID
            if (menuChoice == 1)
            {
                Console.Clear();
                Console.WriteLine("Enter new ID.");
                string listingID = Console.ReadLine();
                listingID = CheckInput(listingID);
                listingID = SearchID(myListing, listingID);
                myListing[foundIndex].SetID(listingID);
            }
            //Edits street address
            else if (menuChoice == 2)
            {
                Console.Clear();
                Console.WriteLine("Enter new address.");
                string addressStreet = Console.ReadLine();
                addressStreet = CheckInput(addressStreet);
                myListing[foundIndex].SetAddress(addressStreet);
            }
            //Edits city
            else if (menuChoice == 3)
            {
                Console.Clear();
                Console.WriteLine("Enter new city.");
                string addressCity = Console.ReadLine();
                addressCity = CheckInput(addressCity);
                myListing[foundIndex].SetCity(addressCity);
            }
            //Edits state
            else if (menuChoice == 4)
            {
                Console.Clear();
                Console.WriteLine("Enter new state.");
                string addressState = Console.ReadLine().ToUpper();
                addressState = CheckState(addressState);
                myListing[foundIndex].SetState(addressState);
            }
            //Edits end date
            else if (menuChoice == 5)
            {
                Console.Clear();
                Console.WriteLine("Enter new date (mm/dd/yyyy).");
                string endDate = Console.ReadLine();
                endDate = CheckDate(endDate);
                myListing[foundIndex].SetDate(endDate);
            }
            //Edits listing price
            else if (menuChoice == 6)
            {
                Console.Clear();
                Console.WriteLine("Enter new price.");
                double listPrice = double.Parse(Console.ReadLine());
                listPrice = CheckPrice(listPrice);
                myListing[foundIndex].SetPrice(listPrice);
            }
            //Edits owner email
            else if (menuChoice == 7)
            {
                Console.Clear();
                Console.WriteLine("Enter new email.");
                string ownerEmail = Console.ReadLine();
                ownerEmail = CheckEmail(ownerEmail);
                myListing[foundIndex].SetEmail(ownerEmail);
            }
            //Prints out edited listings
            Console.Clear();
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
            int foundIndex = SearchListing(myListing, searchValue);

            //Deletes listing found under specified listing ID
            Array.Clear(myListing, foundIndex, 6);

            //Decreases count of listings in file
            Listing.DownCount();
            ListingFile.SaveEditedListing(myListing);
            Console.Clear();
            ListingFile.PrintListing(myListing);
            Console.ReadKey();
            Menu();
        }

        public static void LeaseCondo()
        {
            Console.Clear();
            Console.WriteLine("Press '1' to lease condo.");
            Console.WriteLine("Press '2' to edit lease.");
            int inputChoice = int.Parse(Console.ReadLine());
            if(inputChoice == 1)
            {
                Console.Clear();
                Listing[] myListing = ListingFile.GetListings();
                Listing.SortListing(myListing);
                ListingFile.PrintListing(myListing);

                //Instantiated new object
                Renting myRental = new Renting();

                //Sets listing ID
                Console.WriteLine("Enter the listing ID of the listing to be rented.");
                string listingID = Console.ReadLine();
                listingID = CheckInput(listingID);
                myRental.SetID(listingID);

                //Sets name of person renting
                Console.Clear();
                Console.WriteLine("Enter the name of the person renting.");
                string renterName = Console.ReadLine();
                renterName = CheckInput(renterName);
                myRental.SetName(renterName);

                //Sets renter's email
                Console.Clear();
                Console.WriteLine("Enter the renter's email.");
                string renterEmail = Console.ReadLine();
                renterEmail = CheckEmail(renterEmail);
                myRental.SetRenterEmail(renterEmail);

                //Sets check-in date
                Console.Clear();
                Console.WriteLine("Enter the date of check-in.");
                string rentalDate = Console.ReadLine();
                rentalDate = CheckDate(rentalDate);
                myRental.SetRentalDate(rentalDate);

                //Sets rental amount
                string searchValue = listingID;
                int foundIndex = SearchListing(myListing, searchValue);
                double listingPrice = myListing[foundIndex].GetPrice();
                myRental.SetAmount(listingPrice);

                //Sets check-out date
                Console.Clear();
                Console.WriteLine("Enter the date of check-out.");
                string checkOutDate = Console.ReadLine();
                checkOutDate = CheckOutDate(checkOutDate, rentalDate);
                myRental.SetCheckOutDate(checkOutDate);

                //Sets owner email;
                string ownerEmail = myListing[foundIndex].GetEmail();
                myRental.SetOwnerEmail(ownerEmail);

                //Sets total rental amount
                DateTime checkOut = DateTime.Parse(checkOutDate);
                DateTime checkIn = DateTime.Parse(rentalDate);
                int daysDiff = ((TimeSpan)(checkOut - checkIn)).Days;
                double totalAmount = (daysDiff + 1) * listingPrice;
                myRental.SetTotalAmount(totalAmount);

                Array.Clear(myListing, foundIndex, 6);

                //Decreases count of listings in file
                Listing.DownCount();
                ListingFile.SaveEditedListing(myListing);

                //Displays rental summary
                Console.Clear();
                Console.WriteLine(myRental.ToString());
                Console.ReadKey();

                RentingFiles.SaveRentals(myRental);

                Renting.IntCount();
                Menu();
            }
            else
            {
                Console.Clear();
                Renting[] myRentals = RentingFiles.GetRentals();
                Listing[] myListing = ListingFile.GetListings();

                Renting.SortRentals(myRentals);
                RentingFiles.PrintRentals(myRentals);
                Console.WriteLine("Enter the ID of the rental to edit.");

                string searchValue = Console.ReadLine();
                int foundIndex = SearchRenting(myRentals, searchValue);

                Console.Clear();
                int menuChoice = RentingEditMenu();
                menuChoice = RentingEditCheck(menuChoice);
                if(menuChoice == 1)
                {
                    //Edits listing ID
                    Console.WriteLine("Edit the listing ID of the listing to be rented.");
                    string listingID = Console.ReadLine();
                    listingID = CheckInput(listingID);
                    myRentals[foundIndex].SetID(listingID);
                }
                if(menuChoice == 2)
                {
                    //Edits name of person renting
                    Console.Clear();
                    Console.WriteLine("Edit the name of the person renting.");
                    string renterName = Console.ReadLine();
                    renterName = CheckInput(renterName);
                    myRentals[foundIndex].SetName(renterName);
                }
                if (menuChoice == 3)
                {
                    //Edits renter's email
                    Console.Clear();
                    Console.WriteLine("Enter the renter's email.");
                    string renterEmail = Console.ReadLine();
                    renterEmail = CheckEmail(renterEmail);
                    myRentals[foundIndex].SetRenterEmail(renterEmail);
                }
                if (menuChoice == 4)
                {
                    //Edits check-in date
                    Console.Clear();
                    Console.WriteLine("Enter the date of check-in.");
                    string rentalDate = Console.ReadLine();
                    string endDate = myListing[foundIndex].GetDate();
                    rentalDate = CheckInDate(endDate, rentalDate);
                    myRentals[foundIndex].SetRentalDate(rentalDate);
                }
                if (menuChoice == 5)
                {
                    //Edits check-out date
                    Console.Clear();
                    string checkInDate = myRentals[foundIndex].GetRentalDate();
                    Console.WriteLine("Enter the date of check-out.");
                    string checkOutDate = Console.ReadLine();
                    checkOutDate = CheckOutDate(checkOutDate, checkInDate);
                    myRentals[foundIndex].SetCheckOutDate(checkOutDate);
                }

                //Updates rental amount
                string searchItem = myRentals[foundIndex].GetID();
                int foundPlace = SearchListing(myListing, searchItem);
                double listingPrice = myListing[foundPlace].GetPrice();
                myRentals[foundIndex].SetAmount(listingPrice);

                //Updates owner email
                string searchInput = myRentals[foundIndex].GetID();
                int indexFound = SearchListing(myListing, searchInput);
                string ownerEmail = myListing[indexFound].GetEmail();
                myRentals[foundIndex].SetOwnerEmail(ownerEmail);

                //Updates total rental amount
                string checkOutDay = myRentals[foundIndex].GetCheckOutDate();
                string rentDate = myRentals[foundIndex].GetRentalDate();
                DateTime checkOut = DateTime.Parse(checkOutDay);
                DateTime checkIn = DateTime.Parse(rentDate);
                int daysDiff = ((TimeSpan)(checkOut - checkIn)).Days;
                double totalAmount = (daysDiff + 1) * listingPrice;
                myRentals[foundIndex].SetTotalAmount(totalAmount);

                Console.Clear();
                RentingFiles.PrintRentals(myRentals);

                //Saves edited rentals
                RentingFiles.SaveEditedRentals(myRentals);

                Console.ReadKey();
                Menu();
            }

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

        public static int RentingEditMenu()
        {
            Console.WriteLine("Enter '1' to edit listing ID.");
            Console.WriteLine("Enter '2' to edit renter name.");
            Console.WriteLine("Enter '3' to edit renter email.");
            Console.WriteLine("Enter '4' to edit check-in date.");
            Console.WriteLine("Enter '5' to edit check-out date.");

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

        public static int RentingEditCheck(int menuChoice)
        {
            string menuString = menuChoice.ToString();
            if (string.IsNullOrEmpty(menuString))
            {
                ErrorMessage();
                int input1 = int.Parse(Console.ReadLine());
                int input2 = RentingEditCheck(input1);
                return input2;
            }
            else
            {
                if (menuChoice < 1 || menuChoice > 5)
                {
                    ErrorMessage();
                    int input1 = int.Parse(Console.ReadLine());
                    int input2 = RentingEditCheck(input1);
                    return input2;
                }
                else
                {
                    return menuChoice;
                }
            }
        }

        //Checks if id was valid
        public static string CheckInput(string input)
        {
            if(string.IsNullOrEmpty(input))
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = CheckInput(input1);
                return input2;
            }
            else
            {
                return input;
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
                if (dDate >= today)
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

        public static string CheckInDate(string endDate, string rentalDate)
        {
            if (string.IsNullOrEmpty(rentalDate))
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = CheckDate(input1);
                return input2;
            }
            else
            {
                DateTime dDate = DateTime.Parse(endDate);
                DateTime checkInDate = DateTime.Parse(rentalDate);
                if (dDate >= checkInDate)
                {
                    return string.Format("{0:MM/dd/yyyy}", checkInDate);
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

        //Checks if check out date is after check in date
        public static string CheckOutDate(string checkOutDate, string rentalDate)
        {
            if (string.IsNullOrEmpty(checkOutDate))
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = CheckDate(input1);
                return input2;
            }
            else
            {
                DateTime checkOut = DateTime.Parse(checkOutDate);
                DateTime checkIn = DateTime.Parse(rentalDate);
                if (checkOut >= checkIn)
                {
                    return string.Format("{0:MM/dd/yyyy}", checkOut);
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
        public static int SearchListing(Listing[] myListing, string searchValue)
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
                int input2 = SearchListing(myListing, input1);
                return input2;
            }
        }

        //Checks if listing ID already exists
        public static string SearchID(Listing[] myListing, string searchValue)
        {
            int foundIndex = Listing.BinarySearch(myListing, searchValue);
            if (foundIndex != -1)
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                int input2 = SearchListing(myListing, input1);
                return input1;
            }
            else
            {
                return searchValue;
            }
        }


        //Searches renting 
        public static int SearchRenting(Renting[] myRentals, string searchValue)
        {
            int foundIndex = Renting.BinarySearch(myRentals, searchValue);
            if (foundIndex != -1)
            {
                return foundIndex;
            }
            else
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                int input2 = SearchRenting(myRentals, input1);
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
