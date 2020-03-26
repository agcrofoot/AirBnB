using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class Listing
    {
        private string listingID;
        private int addressNum;
        private string addressStreet;
        private string endMonth;
        private int endDate;
        private int endYear;
        private double listPrice;
        private string ownerEmail;
        private static int count;

        //Method constructor no att
        public Listing()
        {

        }

        //Method constuctor
        public Listing(string listingID, int addressNum, string addressStreet, string endMonth, int endDate,
            int endYear, double listPrice, string ownerEmail)
        {
            this.listingID = listingID;
            this.addressNum = addressNum;
            this.addressStreet = addressStreet;
            this.endMonth = endMonth;
            this.endDate = endDate;
            this.endYear = endYear;
            this.listPrice = listPrice;
            this.ownerEmail = ownerEmail;
        }

        //Gets listing ID
        public string GetID()
        {
            return listingID;
        }

        //Gets address number
        public int GetNumber()
        {
            return this.addressNum;
        }

        //Gets address street
        public string GetStreet()
        {
            return this.addressStreet;
        }

        //Gets listing end month
        public string GetMonth()
        {
            return this.endMonth;
        }

        //Gets listing end day
        public int GetDate()
        {
            return this.endDate;
        }

        //Gets listing end year
        public int GetYear()
        {
            return this.endYear;
        }

        //Gets list price
        public double GetPrice()
        {
            return this.listPrice;
        }

        //Gets owner email
        public string GetEmail()
        {
            return this.ownerEmail;
        }

        //Gets count
        public static int GetCount()
        {
            return count;
        }

        //Sets listing ID
        public void SetID(string listingID)
        {
            this.listingID = listingID;
        }

        //Sets street number
        public void SetNum(int addressNum)
        {
            this.addressNum = addressNum;
        }

        //Sets street name
        public void SetStreet(string addressStreet)
        {
            this.addressStreet = addressStreet;
        }

        //Sets listing end month
        public void SetMonth(string endMonth)
        {
            this.endMonth = endMonth;
        }

        //Sets listing end date
        public void SetDate(int endDate)
        {
            this.endDate = endDate;
        }

        //Sets listing end year
        public void SetYear(int endYear)
        {
            this.endYear = endYear;
        }

        //Sets list price
        public void SetPrice(double listPrice)
        {
            this.listPrice = listPrice;
        }

        //Sets owner email
        public void SetEmail(string ownerEmail)
        {
            this.ownerEmail = ownerEmail;
        }

        //Sets count
        public static void SetCount(int count)
        {
            Listing.count = count;
        }

        //Increases count
        public static void IntCount()
        {
            count++;
        }

        //Converts to string
        public string ToString()
        {
            return "The ID is " + listingID + " at " + addressNum + " " + addressStreet + ". The end date is "
                + endMonth + " " + endDate + ", " + endYear + ". It is priced at " + listPrice + " and the owner's email is " + ownerEmail + ".";
        }

        public static void SortListing(Listing[] myListing)
        {
            for(int outer = 0; outer < count - 1; outer++)
            {
                int min = outer;
                for(int inner = outer + 1; inner < count; inner++)
                {
                    if(myListing[inner].GetID().CompareTo(myListing[outer].GetID()) < 0)
                    {
                        min = inner;
                    }
                }
                if(min != outer)
                {
                    Swap(myListing, min, outer);
                }
            }
        }

        public static void Swap(Listing[] myListing, int x, int y)
        {
            Listing temp = myListing[x];
            myListing[x] = myListing[y];
            myListing[y] = temp;
        }



        public static int BinarySearch(Listing[] myListing, string searchValue)
        {
            int indexFound = -1;
            bool notFound = true;
            int first = 0;
            int last = Listing.GetCount() - 1;

            while(notFound && first <= last)
            {
                int middle = (first + last) / 2;

                if(searchValue == myListing[middle].GetID())
                {
                    notFound = false;
                    indexFound = middle;
                }
                else if(searchValue.CompareTo(myListing[middle].GetID()) > 0)
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

    }
}
