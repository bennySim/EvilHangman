using System;
using System.Linq;

namespace EvilHangman
{
    class Program
    {
        private const string FileWithWords = "words.txt";

        static void Main(string[] args)
        {
            var game = new Game(FileWithWords);
            var word = game.Start();
            PrintWord(word);
            var isGameOver = false;
            while (word.Any(c => c == '_') && !isGameOver)
            {
                GuessLetter(game, out word);
                CheckGameOver(game, out isGameOver);
                PrintWord(word);
            }
            Console.WriteLine("Congrats, you won!");
        }

        private static void PrintWord(char[] word)
        {
            Console.WriteLine(string.Join(" ", word));
        }

        private static void CheckGameOver(Game game, out bool isGameOver)
        {
            if (game.IsGameOver)
            {
                Console.WriteLine("You failed! Game over.");
                isGameOver = true;
            }

            isGameOver = false;
        }

        private static void GuessLetter(Game game, out char[] word)
        {
            var c = GetChar();
            var isGoodGuess = game.Guess(c, out word);
            if (!isGoodGuess)
            {
                Console.WriteLine($"Letter '{c}' is not in the word!");
            }
            else
            {
                Console.WriteLine($"Perfect! Letter '{c}' is in the word!");
            }
        }

        private static char GetChar()
        {
            var c = (char) Console.Read();
            Console.ReadLine();
            return c;
        }
    }
}