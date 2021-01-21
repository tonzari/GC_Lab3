using System;

namespace Lab3DecisionMaker
{
    // GC Lab 3 - Decision Maker
    // Antonio Manzari

    // The application prompts to the user to enter an integer between 1 and 100, and displays the associated result based on the integer range entered.
    class Program
    {
        static string userName = String.Empty;
        static string userNumInput = String.Empty;
        static int userNumber = 0;
        static int minNumber = 1;
        static int maxNumber = 100;

        static void Main(string[] args)
        {
            GetUserName();

            do
            {
                UpdateUserNumber();
            } while (CheckUserWantsToContinue());

            ExitApp();
        }

        public static string GetUserName()
        {
            Console.Write("Hi! Please enter your name: ");
            userName = Console.ReadLine();
            Console.WriteLine($"Thanks, {userName}. Let's get started!");
            Console.WriteLine(Environment.NewLine);

            return userName;
        }

        public static void UpdateUserNumber()
        {
            Console.Write($"Enter a number between {minNumber} and {maxNumber}: ");
            userNumInput = Console.ReadLine();

            if (Int32.TryParse(userNumInput, out userNumber) && CheckUserNumWithinRange(userNumber))
            {
                Console.WriteLine($"Output: {GetResult(userNumber)}");
            }
            else
            {
                Console.WriteLine($"{userName}, what have you done?? Please enter a valid number! PLEASE!");
            }
        }

        public static string GetResult(int userNumber)
        {
            string result = string.Empty;
            if (userNumber % 2 == 0)
            {
                if (userNumber < 25)
                {
                    result = "Even and less than 25.";
                }
                else if (userNumber >= 26 && userNumber <= 60)
                {
                    result = "Even.";
                }
                else
                {
                    result = $"{userNumber} and even.";
                }
            }
            else
            {
                result = $"{userNumber} and odd.";
            }

            return result;
        }

        public static bool CheckUserNumWithinRange(int userNumber)
        {
            return userNumber >= minNumber && userNumber <= maxNumber;
        }

        public static bool CheckUserWantsToContinue()
        {
            Console.WriteLine($"{userName}, would you like to continue? (y/n) ");
            char userInput = Char.ToLower(Console.ReadKey().KeyChar);

            if (userInput.Equals('y'))
            {
                Console.WriteLine(Environment.NewLine);
                return true;
            }
            else if (userInput.Equals('n'))
            {
                
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Goodbye, {userName}!");
                return false;
            }
            else
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"That's not a y, nor is it an n. Please follow the directions, {userName}.");
                return CheckUserWantsToContinue();
            }
        }
        public static void ExitApp()
        {
            Console.WriteLine("Exiting application...");
            Environment.Exit(0);
        }
    }
}
