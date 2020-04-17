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
            Renting[] myRentals = new Renting[100];
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



        public static void SaveRentals(Renting[] myRentals, string path)
        {
            StreamWriter outFile = File.AppendText(path);

            for (int i = 0; i < Renting.GetCount(); i++)
            {
                outFile.WriteLine(myRentals[i].ToFile());
            }
            outFile.Close();
        }

        public static void SaveEditedRentals(Renting[] myRentals, string path)
        {
            StreamWriter outFile = new StreamWriter(path);

            for (int i = 0; i < Renting.GetCount(); i++)
            {
                outFile.WriteLine(myRentals[i].ToFile());
            }
            outFile.Close();
        }

    }
}
