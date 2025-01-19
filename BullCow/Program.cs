namespace BullCow
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("Hello!!! \nYou are in the Game Bull&Cow! ");
            bool keepPlaying = true;
            do
            {                
                Console.WriteLine("Let's start \nI'm thinking the 4-digit number and you should guess it. \nHere is the rules: \nif you guess digit and it is on its place - I answer \"Bull\" \nif you guess digit, but it is on another place - I answer \"Cow\"");

                Random random = new Random();
                string myNumber;

                do
                {
                    var digits = Enumerable.Range(0, 10).OrderBy(_ => random.Next()).Take(4);
                    myNumber = string.Join("", digits);
                }
                while (myNumber.Length != 4);

                Console.WriteLine(myNumber);
                Console.Write("Got it. The number is ready. You may start. ");

                bool keepGuessNumber = true;

                while (keepGuessNumber)
                {
                    string inputNumber;
                    do
                    {
                        Console.WriteLine("Please enter your number:");
                        inputNumber = Console.ReadLine();
                        if (!inputNumber.All(char.IsDigit) || inputNumber.Length != 4)
                        {
                            Console.WriteLine("Invalid input. Make sure to enter exactly 4 digits.");
                        }
                    }
                    while (!inputNumber.All(char.IsDigit) || inputNumber.Length != 4);


                    GameLogic whatMyNumber = new GameLogic(inputNumber, myNumber);
                    keepGuessNumber = whatMyNumber.GamePlay();
                }

                Console.WriteLine("Do you want to play one more time? Y/N");

                string answer = String.Empty;
                do
                {
                    answer = Console.ReadLine();
                    switch (answer.ToLower())
                    {
                        case "y":
                            keepPlaying = true;
                            Console.Clear();
                            break;
                        case "n":
                            keepPlaying = false;
                            Console.WriteLine("Goodbye! Thanks for game!");
                            break;
                        default:
                            Console.WriteLine("I don't understand you. Please enter Y or N");
                            break;
                    }
                }
                while (answer.ToLower() != "y" && answer.ToLower() != "n");
            }
            while (keepPlaying);
        }
    }

    public class GameLogic(string inputNumber, string myNumber)
    {
        int bull = 0;
        int cow = 0;
        int[] myNumberArray = myNumber.Select(c => int.Parse(c.ToString())).ToArray();
        int[] inputNumberArray = inputNumber.Select(c => int.Parse(c.ToString())).ToArray();

        public bool GamePlay()
        {
            if (IfNumberGuessed(inputNumber, myNumber))
            {
                Console.WriteLine("C O N G R A T U L A T I O N!!! You GUESS the number!");
                return false;
            }
            else
            {
                CountBull(inputNumber, myNumber);
                CountCow(inputNumber, myNumber);
                return true;
            }
        }

        public bool IfNumberGuessed(string inputNumber, string myNumber)
        {
            if (inputNumber == myNumber)
                return true;

            return false;
        }

        public void CountBull(string inputNumber, string myNumber)
        {
            for (int i = 0; i < 4; i++)
            {
                if (myNumberArray[i] == inputNumberArray[i])
                    bull++;
            }

            switch (bull)
            {
                case 0:
                    Console.WriteLine("There is NO bull");
                    break;
                case 1:
                    Console.WriteLine($"There is {bull} bull");
                    break;
                case > 1:
                    Console.WriteLine($"There are {bull} bulls");
                    break;
            }
        }

        public void CountCow(string inputNumber, string myNumber)
        {
            for (int i = 0; i < 4; i++)
            {
                if (myNumberArray[i] != inputNumberArray[i])
                    for (int j = 0; j < 4; j++)
                    {
                        if (myNumberArray[i] == inputNumberArray[j])
                            cow++;
                    }
            }

            switch (cow)
            {
                case 0:
                    Console.WriteLine("There is NO cow");
                    break;
                case 1:
                    Console.WriteLine($"There is {cow} cow");
                    break;
                case > 1:
                    Console.WriteLine($"There are {cow} cows");
                    break;
            }
        }
    }
}
