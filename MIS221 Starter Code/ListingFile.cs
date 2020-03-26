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

                myListing[Listing.GetCount()] = new Listing(tempArray[0], int.Parse(tempArray[1]), tempArray[2], tempArray[3], int.Parse(tempArray[4]), int.Parse(tempArray[5]), double.Parse(tempArray[6]), tempArray[7]);

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
            outFile.WriteLine(newListing.GetID() + '#' + newListing.GetNumber() + '#' + 
                newListing.GetStreet() + '#' + newListing.GetMonth() + '#' + newListing.GetDate() + 
                '#' + newListing.GetYear() + '#' + newListing.GetPrice() + '#' + newListing.GetEmail());
            outFile.Close();
        }

        public static void SaveEditedListing(Listing[] myListing)
        {
            StreamWriter outFile = new StreamWriter(@"C:\Text\listings.txt");
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                outFile.WriteLine(myListing[i].GetID() + '#' + myListing[i].GetNumber() + '#' +
                myListing[i].GetStreet() + '#' + myListing[i].GetMonth() + '#' + myListing[i].GetDate() +
                '#' + myListing[i].GetYear() + '#' + myListing[i].GetPrice() + '#' + myListing[i].GetEmail());
            }
            outFile.Close();
        }

    }
}
