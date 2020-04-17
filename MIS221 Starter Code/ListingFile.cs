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
        //Reads in listings.txt
        public static Listing[] GetListings()
        {
            Listing[] myListing = new Listing[100];
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

        //Prints out all listings
        public static void PrintListing(Listing[] myListing)
        {
            for (int i = 0; i < Listing.GetCount(); i++)
            {
                Console.WriteLine(myListing[i].ToString());
            }
        }

        //Saves listings to listings.txt
        public static void SaveNewListing(Listing[] myListing)
        {
            StreamWriter outFile = File.AppendText(@"C:\Text\listings.txt");

            for (int i = 0; i < Listing.GetCount(); i++)
            {
                outFile.WriteLine(myListing[i].ToFile());
            }
            outFile.Close();
        }

        public static void SaveEditedListing(Listing[] myListing, string path)
        {
            StreamWriter outFile = new StreamWriter(path);

            for (int i = 0; i < Listing.GetCount(); i++)
            {
                outFile.WriteLine(myListing[i].ToFile());
            }
            outFile.Close();
        }
    }
}
