using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class Renting
    {
        private string listingID;
        private string renterName;
        private string renterEmail;
        private string rentalDate;
        private double rentalAmount;
        private string checkOutDate;
        private string ownerEmail;
        private double totalAmount;
        private static int count;

        public Renting()
        {

        }

        public Renting(string listingID, string renterName, string renterEmail, string rentalDate, double rentalAmount, string checkOutDate, string ownerEmail, double totalAmount)
        {
            this.listingID = listingID;
            this.renterName = renterName;
            this.renterEmail = renterEmail;
            this.rentalDate = rentalDate;
            this.rentalAmount = rentalAmount;
            this.checkOutDate = checkOutDate;
            this.ownerEmail = ownerEmail;
            this.totalAmount = totalAmount;
        }

        public string GetID()
        {
            return listingID;
        }

        public string GetName()
        {
            return renterName;
        }

        public string GetRenterEmail()
        {
            return renterEmail;
        }

        public string GetRentalDate()
        {
            return rentalDate;
        }

        public double GetAmount()
        {
            return rentalAmount;
        }

        public string GetCheckOutDate()
        {
            return checkOutDate;
        }

        public string GetOwnerEmail()
        {
            return ownerEmail;
        }

        public double GetTotalAmount()
        {
            return totalAmount;
        }

        public static int GetCount()
        {
            return count;
        }

        public void SetID(string listingID)
        {
            this.listingID = listingID;
        }

        public void SetName(string renterName)
        {
            this.renterName = renterName;
        }

        public void SetRenterEmail(string renterEmail)
        {
            this.renterEmail = renterEmail;
        }

        public void SetRentalDate(string rentalDate)
        {
            this.rentalDate = rentalDate;
        }

        public void SetAmount(double rentalAmount)
        {
            this.rentalAmount = rentalAmount;
        }

        public void SetCheckOutDate(string checkOutDate)
        {
            this.checkOutDate = checkOutDate;
        }

        public void SetOwnerEmail(string ownerEmail)
        {
            this.ownerEmail = ownerEmail;
        }

        public void SetTotalAmount(double totalAmount)
        {
            this.totalAmount = totalAmount;
        }

        //Sets count
        public static void SetCount(int count)
        {
            Renting.count = count;
        }

        //Increases count
        public static void IntCount()
        {
            count++;
        }

        public static void DownCount()
        {
            count--;
        }

        public string ToString()
        {
            return "Listing ID: " + listingID + " Renter Name: " + renterName + " Renter Email: " + renterEmail + " Check-In Date: "
                + rentalDate + " Cost per Night: " + string.Format("{0:C}", rentalAmount) + " Check-Out Date: " + checkOutDate + " Owner Email: " + ownerEmail + " Total Cost: " + string.Format("{0:C}", totalAmount);
        }

        public string ToFile()
        {
            return listingID + "#" + renterName + "#" + renterEmail + "#" + rentalDate + "#" + rentalAmount + "#" + checkOutDate + "#" + ownerEmail + "#" + totalAmount;
        }

        public static void SortRentals(Renting[] myRentals)
        {
            for (int outer = 0; outer < count - 1; outer++)
            {
                int min = outer;
                for (int inner = outer + 1; inner < count; inner++)
                {
                    if (myRentals[min].GetID().CompareTo(myRentals[inner].GetID()) > 0)
                    {
                        min = inner;
                    }
                }
                if (min != outer)
                {
                    Swap(myRentals, min, outer);
                }
            }
        }

        public static void SortRentalEmail(Renting[] myRentals)
        {
            for (int outer = 0; outer < count - 1; outer++)
            {
                int min = outer;
                for (int inner = outer + 1; inner < count; inner++)
                {
                    if (myRentals[min].GetRenterEmail().CompareTo(myRentals[inner].GetRenterEmail()) > 0)
                    {
                        min = inner;
                    }
                }
                if (min != outer)
                {
                    Swap(myRentals, min, outer);
                }
            }
        }

        public static void SortRenterName(Renting[] myRentals)
        {
            for (int outer = 0; outer < count - 1; outer++)
            {
                int min = outer;
                for (int inner = outer + 1; inner < count; inner++)
                {
                    if (myRentals[min].GetName().CompareTo(myRentals[inner].GetName()) > 0)
                    {
                        min = inner;
                    }
                }
                if (min != outer)
                {
                    Swap(myRentals, min, outer);
                }
            }
        }


        public static void Swap(Renting[] myRentals, int x, int y)
        {
            Renting temp = myRentals[x];
            myRentals[x] = myRentals[y];
            myRentals[y] = temp;
        }



        public static int BinaryIDSearch(Renting[] myRentals, string searchValue)
        {
            int indexFound = -1;
            bool notFound = true;
            int first = 0;
            int last = Renting.GetCount() - 1;

            while (notFound && first <= last)
            {
                int middle = (first + last) / 2;

                if (searchValue == myRentals[middle].GetID())
                {
                    notFound = false;
                    indexFound = middle;
                }
                else if (searchValue.CompareTo(myRentals[middle].GetID()) > 0)
                {
                    first = middle + 1;
                }
                else
                {
                    last = middle - 1;
                }
            }
            return indexFound;
        }

        public static int BinaryEmailSearch(Renting[] myRentals, string searchValue)
        {
            int indexFound = -1;
            bool notFound = true;
            int first = 0;
            int last = Renting.GetCount() - 1;

            while (notFound && first <= last)
            {
                int middle = (first + last) / 2;

                if (searchValue == myRentals[middle].GetRenterEmail())
                {
                    notFound = false;
                    indexFound = middle;
                }
                else if (searchValue.CompareTo(myRentals[middle].GetRenterEmail()) > 0)
                {
                    first = middle + 1;
                }
                else
                {
                    last = middle - 1;
                }
            }
            return indexFound;

        }

        public static void ShiftRentals(Renting[] myRentals, int indexFound)
        {
            for (int i = indexFound; i < Renting.GetCount(); i++)
            {
                myRentals[i] = myRentals[i + 1];
            }
        }


        public static void HCRReports(Renting[] myRentals)
        {
            int nameCount = 1;
            double sum = myRentals[0].GetTotalAmount();
            string current = myRentals[0].GetName();
            Console.WriteLine(myRentals[0].ToString());

            for(int i = 1; i < Renting.GetCount(); i++)
            {
                if(myRentals[i].GetName() == current)
                {
                    Console.WriteLine(myRentals[i].ToString());
                    nameCount++;
                    sum += myRentals[i].GetTotalAmount();
                }
                else
                {
                    Console.WriteLine("Current name: " + current + "\t" + " Total rentals : " + nameCount + "\t" + " Average rental amount: " + (sum / nameCount));
                    current = myRentals[i].GetName();
                    sum = myRentals[i].GetTotalAmount();
                    nameCount = 1;
                    Console.WriteLine(myRentals[i].ToString());

                }
                
            }

            Console.WriteLine("Current name: " + current + "\t" + " Total rentals : " + nameCount + "\t" + " Average rental amount: " + (sum / nameCount));

        }

    }
}
