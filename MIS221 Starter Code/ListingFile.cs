using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class ListingFile
    {
        public static Listing[] GetListings()
        {
            Listing[] myListing = new Listing[8];
            Listing.SetCount(0);
            StreamReader inFile = new StreamReader(@"C:\Text\listings.txt");

            string listing = inFile.ReadLine();

            while (listing != null)
            {
                string[] tempArray = listing.Split('#');

                myListing[Listing.GetCount()] = new Listing(tempArray[0], tempArray[1], tempArray[2], tempArray[3], tempArray[4], double.Parse(tempArray[5]), tempArray[6]);

                Listing.IntCount();
                listing = inFile.ReadLine();
            }
            inFile.Close();
            return myListing;
        }

        public static void PrintListing(Listing[] myListing)
        {
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                Console.WriteLine(myListing[i].ToString());
            }
        }


        public static void SaveListing(Listing newListing)
        {
            StreamWriter outFile = File.AppendText(@"C:\Text\listings.txt");
            outFile.WriteLine(newListing.GetID() + '#' + newListing.GetAddress() + '#' + newListing.GetCity() + '#' +
                newListing.GetState() + '#' + newListing.GetDate() + '#' + newListing.GetPrice() + '#' + newListing.GetEmail());
            outFile.Close();
        }

        public static void SaveEditedListing(Listing[] myListing)
        {
            StreamWriter outFile = new StreamWriter(@"C:\Text\listings.txt");

            for (int i = 0; i < Listing.GetCount(); i++)
            {
                outFile.WriteLine(myListing[i].GetID() + '#' + myListing[i].GetAddress() + '#' + myListing[i].GetCity() + '#' +
                    myListing[i].GetState() + '#' + myListing[i].GetDate() + '#' + string.Format("{0:0.00}", myListing[i].GetPrice()) + '#' + myListing[i].GetEmail());
            }
            outFile.Close();
        }

        public static void SaveDeletedListing(Listing delListing)
        {
            StreamWriter outFile = new StreamWriter(@"C:\Text\listings.txt");

            for (int i = 0; i < Listing.GetCount(); i++)
            {
                outFile.WriteLine(delListing.GetID() + delListing.GetAddress() + delListing.GetCity() +
                    delListing.GetState() + delListing.GetDate() + delListing.GetPrice() + delListing.GetEmail());
            }
            outFile.Close();
        }

    }
}
