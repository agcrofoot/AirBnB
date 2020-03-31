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
        private string listAddress;
        private string listCity;
        private string listState;
        private string endDate;
        private double listPrice;
        private string ownerEmail;
        private static int count;

        //Method constructor no att
        public Listing()
        {

        }

        //Method constuctor
        public Listing(string listingID, string listAddress, string listCity, string listState, string endDate, double listPrice, string ownerEmail)
        {
            this.listingID = listingID;
            this.listAddress = listAddress;
            this.listCity = listCity;
            this.listState = listState;
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
            return this.listAddress;
        }

        //Gets city
        public string GetCity()
        {
            return this.listCity;
        }

        //Gets state
        public string GetState()
        {
            return this.listState;
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
        public void SetAddress(string listAddress)
        {
            this.listAddress = listAddress;
        }

        //Sets list city
        public void SetCity(string listCity)
        {
            this.listCity = listCity;
        }

        //Sets list state
        public void SetState(string listState)
        {
            this.listState = listState;
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

        public static void DownCount()
        {
            count--;
        }

        //Converts to string
        public string ToString()
        {
            return "The ID is " + listingID + " at " + listAddress + " " + listCity + ", " + listState + ". The end date is "
                + endDate + ". It is priced at " + string.Format("{0:C}", listPrice) + " and the owner's email is " + ownerEmail + ".";
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
