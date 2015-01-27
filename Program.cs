using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lönrivision2
{
    class Program
    {
        static void Main(string[] args)
        
        {
            
            int NumberOfSalaries;

            do
            {
                NumberOfSalaries = ReadInt("Ange antal löner att mata in: ");

                if (NumberOfSalaries <= 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDu måste mata in minst två löner för att kunna göra en beräkning!");
                    Console.ResetColor();
                }

                else
                {
                    ProcessSalaries(NumberOfSalaries);
                   
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nTryck ner valfri tangent för ny beräkning - ESC avslutar");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static void ProcessSalaries(int count)

        {
            
            int[] SalaryNumber = new int[count];
            //This for loop, take in the value of each salary.

                for (int i = 0; i < SalaryNumber.Length; i++)
                {
                    SalaryNumber[i] = ReadInt("Ange lön nummer " + (i + 1) + ": ");
                }

                int[] SortSalaries = new int[count];

                // Kopierar nuvarande array till ny array och sorterar den
                Array.Sort(SortSalaries);
                Array.Copy(SalaryNumber, SortSalaries, count); 

                double MedianSalary = 0;
                double MedelSalary = SortSalaries.Average();
                int LoneSpridning = SortSalaries.Max() - SortSalaries.Min();

                // Räknar ut medianlön vid udda
                if (SortSalaries.Length % 2 == 1) 
                {
                    MedianSalary = SortSalaries[SortSalaries.Length / 2];
                }

                    // Räknar ut medianlön vid jämna
                else 
                {
                    int Median1 = SortSalaries[SortSalaries.Length / 2];
                    int Median2 = SortSalaries[SortSalaries.Length / 2 - 1];
                    MedianSalary = (Median1 + Median2) / 2;
                }


                Console.WriteLine("------------------------------------------");
                Console.WriteLine("\n{0}     : {1,9 :C0}", "Median Salary", MedianSalary);
                Console.WriteLine("{0}      : {1,9 :C0}", "Medel Salary", MedelSalary);
                Console.WriteLine("{0}     : {1,9 :C0}\n", "Lönespridning", LoneSpridning);
                Console.WriteLine("------------------------------------------");

                int raknare = 0;
                //lönerna presenteras i den ordning de matats in om tre löner på varje rad
                foreach (int loop in SalaryNumber)
                {
                    if (raknare % 3 == 0)
                    {
                        Console.Write("\n{0,8}", loop);
                        raknare++;
                    }
                    else
                    {
                        Console.Write("{0,8}", loop);
                        raknare++;
                    }
                }
                Console.WriteLine();  
        }
        
        static int ReadInt(string prompt)
        {

          int number;

        while(true)
            try
            {
                Console.Write(prompt);
                number = int.Parse(Console.ReadLine());
                Console.WriteLine();
                return number;
            }
            catch(Exception)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Antal löner måste vara ett heltal!");
                Console.ResetColor();
            }
        }
    }
}
