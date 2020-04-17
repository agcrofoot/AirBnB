using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class Check
    {

        //Checks if input was valid
        public int EditCheck(int menuChoice)
        {
            string menuString = menuChoice.ToString();
            if (string.IsNullOrEmpty(menuString))
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

        //If endDate passes
        public void DateStillValid(Listing[] myListing)
        {
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                DateTime date = DateTime.Parse(myListing[i].GetDate());
                DateTime today = DateTime.Today;
                if (date < today)
                {
                    Array.Clear(myListing, i, 1);

                    Listing.ShiftListing(myListing, i);
                    Listing.DownCount();
                }
            }
        }

        //
        public int RentingEditCheck(int menuChoice)
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
                if (menuChoice < 1 || menuChoice > 7)
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


        //
        public int YNCheck(int yesOrNo)
        {
            string yesOrNoString = yesOrNo.ToString();
            if (string.IsNullOrEmpty(yesOrNoString))
            {
                ErrorMessage();
                int input1 = int.Parse(Console.ReadLine());
                int input2 = YNCheck(input1);
                return input2;
            }
            else
            {
                if (yesOrNo < 1 || yesOrNo > 2)
                {
                    ErrorMessage();
                    int input1 = int.Parse(Console.ReadLine());
                    int input2 = YNCheck(input1);
                    return input2;
                }
                else
                {
                    return yesOrNo;
                }
            }
        }

        //Checks if input to add, edit or delete rental is valid
        public int OptionCheck(int inputChoice)
        {
            string inputString = inputChoice.ToString();
            if (string.IsNullOrEmpty(inputString))
            {
                ErrorMessage();
                int input1 = int.Parse(Console.ReadLine());
                int input2 = OptionCheck(input1);
                return input2;
            }
            else
            {
                if (inputChoice < 1 || inputChoice > 3)
                {
                    ErrorMessage();
                    int input1 = int.Parse(Console.ReadLine());
                    int input2 = OptionCheck(input1);
                    return input2;
                }
                else
                {
                    return inputChoice;
                }
            }
        }


        //Checks if string input was valid
        public string CheckInput(string input)
        {
            if (string.IsNullOrEmpty(input))
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
        public string CheckState(string addressState)
        {
            if (string.IsNullOrEmpty(addressState))
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
        public string CheckDate(string endDate)
        {
            if (string.IsNullOrEmpty(endDate))
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

        public string CheckInDate(string endDate, string rentalDate)
        {
            if (string.IsNullOrEmpty(rentalDate))
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = CheckInDate(endDate, input1);
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
                    string input2 = CheckInDate(endDate, input1);
                    return input2;
                }

            }
        }

        //Checks if check out date is after check in date
        public string CheckOutDate(string checkOutDate, string rentalDate)
        {
            if (string.IsNullOrEmpty(checkOutDate))
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = CheckOutDate(input1, rentalDate);
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
                    string input2 = CheckOutDate(input1, rentalDate);
                    return input2;
                }

            }
        }

        //Checks if price was valid
        public double CheckPrice(double listPrice)
        {
            string priceString = listPrice.ToString();
            if (string.IsNullOrEmpty(priceString))
            {
                ErrorMessage();
                double input1 = double.Parse(Console.ReadLine());
                double input2 = CheckPrice(input1);
                return input2;
            }
            else
            {
                if (listPrice < 0)
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
        public string CheckEmail(string ownerEmail)
        {
            if (string.IsNullOrEmpty(ownerEmail))
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
        public int SearchListing(Listing[] myListing, string searchValue)
        {
            int indexFound = Listing.BinarySearch(myListing, searchValue);
            if (indexFound != -1)
            {
                return indexFound;
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
        public string SearchID(Listing[] myListing, string searchValue)
        {
            int indexFound = Listing.BinarySearch(myListing, searchValue);
            if (indexFound != -1)
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                string input2 = SearchID(myListing, input1);
                return input2;
            }
            else
            {
                return searchValue;
            }
        }

        //Searches renting for specified ID
        public int SearchRenting(Renting[] myRentals, string searchValue)
        {
            int indexFound = Renting.BinaryIDSearch(myRentals, searchValue);
            if (indexFound != -1)
            {
                return indexFound;
            }
            else
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                int input2 = SearchRenting(myRentals, input1);
                return input2;
            }
        }

        //Searches Renting for specified email
        public int SearchRentingEmail(Renting[] myRentals, string searchValue)
        {
            int indexFound = Renting.BinaryEmailSearch(myRentals, searchValue);
            if (indexFound != -1)
            {
                return indexFound;
            }
            else
            {
                ErrorMessage();
                string input1 = Console.ReadLine();
                int input2 = SearchRentingEmail(myRentals, input1);
                return input2;
            }
        }


        //Displays error message
        public void ErrorMessage()
        {
            Console.WriteLine("Input invalid, please enter a valid input.");
        }

    }
}
