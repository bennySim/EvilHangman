using System;
using System.Collections.Generic;

namespace EvilHangman.Input
{
    public class ConsoleInput : IInput
    {
        public char GetChar()
        {
            var c = (char) Console.Read();
            Console.ReadLine();
            return c;
        }

        public bool GetAnswerPlayAgain()
        {
            var yesAnswers = new List<string> {"yes", "y", "yeah", ""};
            var noAnswers = new List<string> {"no", "n", "hell, no"};

            Console.WriteLine("Do you want to play again? [default: yes]");
            while (true)
            {
                var consoleInput = Console.ReadLine();
                if (yesAnswers.Contains(consoleInput))
                {
                    return true;
                }

                if (noAnswers.Contains(consoleInput))
                {
                    return false;
                }
                
                Console.WriteLine("Invalid answer, try again 'yes' or 'no'.");
            }
        }
    }
}