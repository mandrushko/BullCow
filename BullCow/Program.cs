namespace BullCow
{
    using System;
    using System.ComponentModel.Design;
    using System.Runtime.CompilerServices;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, You are in the Game Bull&Cow! \nLet's start \nNow it's my turn. I'm thinking the 4-digit number and you should guess it. \nHere is the rules: \nif you guess digit and it is on its place - I answer \"Bull\" \nif you guess digit, but it is on another place - I answer \"Cow\"");
            //Console.WriteLine("Input the number. I will use it only in final comparing");
            Random random = new Random();
            var myNumber = random.Next(1000, 10000).ToString();
            Console.WriteLine("Got it. The number is ready. You may start. Please enter your suggestion.");
            Console.WriteLine(myNumber);
            string inputNumber = Console.ReadLine();
            WhatMyNumber whatMyNumber = new WhatMyNumber();
            whatMyNumber.WhatNumber(inputNumber, myNumber);
        }
    }

    public class WhatMyNumber
    {
        public void WhatNumber(string inputNumber, string myNumber)
        {
            int bull = 0;
            int cow = 0;
            int[] myNumberArray = myNumber.Select(c => int.Parse(c.ToString())).ToArray();
            int[] inputNumberArray = inputNumber.Select(c => int.Parse(c.ToString())).ToArray();

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
    }
}
