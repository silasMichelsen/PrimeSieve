using System;
using System.Threading;

namespace PrimeSieve
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set size of sample to find primes in
            int size = 12;

            // Print headline
            Console.WriteLine("Sieve of Erastosthenes");
            Console.WriteLine("Finds all prime numbers below {0}", size*10);
            Console.WriteLine();

            // Print grid of numbers
            for (int i = 0; i < size; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    int num = (i * 10) + j;
                    string writeNum = Convert.ToString(num).PadLeft(3, ' ');
                    Console.Write(writeNum);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to start Sieve");
            Console.ReadKey();

            // create array of booleans to store evaluated numbers
            bool[] numbers = new bool[size * 10];
            numbers[0] = true;

            // Start sieve from first prime = 2
            Console.SetCursorPosition(0, 0);
            int currentPrime = 2;
            int basePrime = 0;

            // Checks that all numbers have been tested, loops through grid and colors acordingly
            while (Array.Exists(numbers, item => item == false))
            {
                ConsoleColor currentColor;
                switch (basePrime)
                {
                    case 0: currentColor = ConsoleColor.DarkRed; break;
                    case 1: currentColor = ConsoleColor.DarkGreen; break;
                    case 2: currentColor = ConsoleColor.DarkBlue; break;
                    case 3: currentColor = ConsoleColor.DarkYellow; break;
                    case 4: currentColor = ConsoleColor.DarkCyan; break;
                    case 5: currentColor = ConsoleColor.DarkGray; break;
                    default: currentColor = ConsoleColor.DarkMagenta; break;
                }

                for (int i = 0; i < size; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        string writeNum;
                        int num = (i * 10) + j;
                        int r = (j - 1) * 4; //Sets coordinates for overwriting existing numbers grid
                        int d = i + 3;

                        // Checks if any number is divisible by current prime or is current prime
                        // If the number is a prime aply BGcolor, if number is a factor of current prime aply FGcolor
                        if (num % currentPrime == 0)
                        {
                            Thread.Sleep(50);
                            Console.SetCursorPosition(r, d);
                            if (num == currentPrime)
                            { Console.BackgroundColor = currentColor; }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = currentColor;
                            }

                            if (numbers[num - 1] == false)
                            {
                                writeNum = Convert.ToString(num).PadLeft(3, ' ');
                                Console.Write(writeNum);
                                Console.Write(" ");
                            }
                            numbers[num - 1] = true;
                        }
                    }
                    Console.WriteLine();
                }

                // Writes the currently found prime to console
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                Console.WriteLine("We have found the prime number {0}", currentPrime);
                
                if (currentPrime < Math.Sqrt(size * 10))
                {
                    Console.WriteLine("We have highligted all of the factors of this prime");
                }
                else
                {
                    Console.WriteLine("This prime has no factors within our search range");
                    basePrime += 100;
                }

                // Sets the current prime to the next available prime
                currentPrime = Array.FindIndex(numbers, item => item == false) + 1;
                basePrime += 1;
                Thread.Sleep(250);
            }
            Console.WriteLine();
            Console.WriteLine("All of the numbers highligted with a colored background are prime numbers");
            Console.WriteLine("All of the numbers in colored type are factors of a prime");
            Console.WriteLine("End of program");
            Console.ReadKey();
        } // end main
    } // end program
} // end PrimeSieve
