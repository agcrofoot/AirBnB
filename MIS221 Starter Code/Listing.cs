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
        private string addressStreet;
        private string addressCity;
        private string addressState;
        private string endDate;
        private double listPrice;
        private string ownerEmail;
        private static int count;

        //Method constructor no att
        public Listing()
        {

        }

        //Method constuctor
        public Listing(string listingID, string addressStreet, string addressCity, string addressState, string endDate, double listPrice, string ownerEmail)
        {
            this.listingID = listingID;
            this.addressStreet = addressStreet;
            this.addressCity = addressCity;
            this.addressState = addressState;
            this.endDate = endDate;
            this.listPrice = listPrice;
            this.ownerEmail = ownerEmail;
        }

        //Gets listing ID
        public string GetID()
        {
            return listingID;
        }

        //Gets street address
        public string GetAddress()
        {
            return this.addressState;
        }

        //Gets city
        public string GetCity()
        {
            return this.addressCity;
        }

        //Gets state
        public string GetState()
        {
            return this.addressState;
        }
        //Gets listing end day
        public string GetDate()
        {
            return this.endDate;
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
        public void SetAddress(string addressStreet)
        {
            this.addressStreet = addressStreet;
        }

        //Sets list city
        public void SetCity(string addressCity)
        {
            this.addressCity = addressCity;
        }

        //Sets list state
        public void SetState(string addressState)
        {
            this.addressState = addressState;
        }

        //Sets listing end date
        public void SetDate(string endDate)
        {
            this.endDate = endDate;
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

        //Decreases count
        public static void DownCount()
        {
            count--;
        }

        //Converts to string
        public string ToString()
        {
            return "Listing ID: " + listingID + " Address: " + addressState + " " + addressCity + ", " + addressState + 
                " End Date: " + endDate + " Cost: " + string.Format("{0:C}", listPrice) + 
                " Owner Email: " + ownerEmail;
        }

        //Preps listing for file
        public string ToFile()
        {
            return listingID + "#" + addressStreet + "#" + addressCity + "#" + addressState +
                "#" + endDate + "#" + listPrice + "#" + ownerEmail;
        }

        


        //Sorts by listing ID
        public static void SortListing(Listing[] myListing)
        {
            for(int outer = 0; outer < count - 1; outer++)
            {
                int min = outer;
                for(int inner = outer + 1; inner < count; inner++)
                {
                    if(myListing[inner].GetID().CompareTo(myListing[min].GetID()) < 0)
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

        //Swaps the listings
        public static void Swap(Listing[] myListing, int x, int y)
        {
            Listing temp = myListing[x];
            myListing[x] = myListing[y];
            myListing[y] = temp;
        }

        //Preforms a binary search for the listing ID
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

        //Shifts the listings to eliminate null space
        public static void ShiftListing(Listing[] myListing, int indexFound)
        {
            for(int i = indexFound; i < Listing.GetCount(); i++)
            {
                myListing[i] = myListing[i + 1];
            }
        }
    }
}
