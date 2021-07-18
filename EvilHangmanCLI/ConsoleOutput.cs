using System;
using EvilHangman.IO;

namespace EvilHangmanCLI.IO
{
    public class ConsoleOutput : IOutput
    {
        public void PrintWinMessage()
        {
            Console.WriteLine("Congrats, you won!");
        }

        public void PrintGameOverMessage(string word)
        {
            Console.WriteLine($"You failed! Game over. Word is {word}");
        }

        public void PrintGoodGuessMessage(char c)
        {
            Console.WriteLine($"Perfect! Letter '{c}' is in the word!");
        }

        public void PrintBadGuessMessage(char c)
        {
            Console.WriteLine($"Letter '{c}' is not in the word!");
        }

        public void PrintWord(char[] word)
        {
            Console.WriteLine(string.Join(" ", word));
        }

     

        public void PrintGameEnd(bool isWin, string word)
        {
            if (isWin)
            {
                PrintWinMessage();
            }
            else
            {
                PrintGameOverMessage(word);
            }
        }

        public void PrintResultOfGuess(bool isGoodGuess, char c)
        {
            if (!isGoodGuess)
            {
                PrintBadGuessMessage(c);
            }
            else
            {
                PrintGoodGuessMessage(c);
            }
        }
    }
}