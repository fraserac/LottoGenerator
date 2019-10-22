using System;
using System.IO;

namespace LottoNumApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean running = true;
            while (running)
            {
                Console.WriteLine("Would you like to try your luck?, hit y followed by return key for yes or any other key to exit: ");
                var KP = Console.ReadLine();
                if (KP.Equals("y"))
                {
                    Console.Clear();
                    LottoNumbers();
                    
                }
                else
                {
                    Environment.Exit(0);
                }

            }
            
        }


        public static void LottoNumbers()
        {


            int numOfNums = 3;
            int maxNumber = 2;
            int minNumber = 1;
            int[] inputNum = new int[numOfNums];
            int val;
            int checker = 0;
            Console.WriteLine("Insert a number between " + minNumber + " and "  + maxNumber +" for each of the " + inputNum.Length + " numbers in the lotto draw, followed by return key: ");


            for (int j = 0; j < inputNum.Length; j++)
            {
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out val))
                {
                    if (Int32.Parse(input) <= maxNumber & Int32.Parse(input) >= minNumber)
                    {
                        inputNum[j] = Int32.Parse(input);
                        Console.Clear();
                        Console.WriteLine("\n" + "You have inserted: ");

                        foreach (int number in inputNum)
                        {
                            if (number == 0)
                                continue;
                            
                                Console.Write(number + "   ");
                            
                        }
                        Console.WriteLine("\n To insert next number, type a whole number between " + minNumber + " and " + maxNumber + " and press return.");

                    }
                    else
                    {
                        Console.WriteLine("Please insert an integer between 1 and 3.");
                        j--;
                    }
                }
                else
                {
                    Console.WriteLine("Not an integer, please insert an integer between 1 and 3.");
                    j--;
                }
            }
            // Problem: Take user input and process it

            var randNum = new Random();

            int[] lotNums = new int[numOfNums];

            for (int i = 0; i < inputNum.Length; i++)
            {
                lotNums[i] = randNum.Next(minNumber, maxNumber +1);
            }

            Console.Clear();
            Console.WriteLine("\n" + "Lotto numbers: ");

            foreach (int num in lotNums)
                Console.Write(" " + num + " ");

            Console.WriteLine("\n" + "Your numbers: ");
            foreach (int numb in inputNum)
                Console.Write(" " + numb + " ");
            for (int k = 0; k < inputNum.Length; k++)
            {
                if (inputNum[k] == lotNums[k])
                {
                    checker++;
                }
            }

            if (checker == inputNum.Length)
            {
                Console.WriteLine("     CONGRATULATIONS, YOU WON!");
            }
            else
            {
                Console.WriteLine("     Sorry, you lose! Press any key to play again...  ");
            }

             Console.ReadKey();
            Console.Clear();
        }

    }
}
