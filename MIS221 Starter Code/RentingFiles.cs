using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MIS221_Starter_Code
{
    class RentingFiles
    {
        public static Renting[] GetRentals()
        {
            Renting[] myRentals = new Renting[8];
            Renting.SetCount(0);
            StreamReader inFile = new StreamReader(@"C:\Text\transactions.txt");

            string rentals = inFile.ReadLine();

            while (rentals != null)
            {
                string[] tempArray = rentals.Split('#');

                myRentals[Renting.GetCount()] = new Renting(tempArray[0], tempArray[1], tempArray[2], tempArray[3], double.Parse(tempArray[4]), tempArray[5], tempArray[6], double.Parse(tempArray[7]));

                Renting.IntCount();
                rentals = inFile.ReadLine();
            }
            inFile.Close();
            return myRentals;
        }


        public static void PrintRentals(Renting[] myRentals)
        {
            for (int i = 0; i < Renting.GetCount(); i++)
            {
                Console.WriteLine(myRentals[i].ToString());
            }
        }

        public static void SaveRentals(Renting myRental)
        {
            StreamWriter outFile = File.AppendText(@"C:\Text\transactions.txt");
            outFile.WriteLine(myRental.GetID() + '#' + myRental.GetName() + '#' + myRental.GetRenterEmail() + '#' +
                myRental.GetRentalDate() + '#' + myRental.GetAmount() + '#' + myRental.GetCheckOutDate() + '#' + 
                myRental.GetOwnerEmail() + '#' + myRental.GetTotalAmount());
            outFile.Close();
        }

        public static void SaveEditedRentals(Renting[] myRentals)
        {
            StreamWriter outFile = new StreamWriter(@"C:\Text\transactions.txt");

            for (int i = 0; i < Renting.GetCount(); i++)
            {
                outFile.WriteLine(myRentals[i].GetID() + '#' + myRentals[i].GetName() + '#' + myRentals[i].GetRenterEmail() + '#' +
                myRentals[i].GetRentalDate() + '#' + myRentals[i].GetAmount() + '#' + myRentals[i].GetCheckOutDate() + '#' +
                myRentals[i].GetOwnerEmail() + '#' + myRentals[i].GetTotalAmount());
            }
            outFile.Close();
        }
    }
}
