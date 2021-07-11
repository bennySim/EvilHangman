using System;
using System.Linq;

namespace EvilHangman
{
    public class GameCLI
    {
        public void Start(string wordsFileName)
        {
            var game = new GameLogic(wordsFileName);
            var word = game.Init();
            var isGameOver = false;
            while (word.Any(c => c == '_') && !isGameOver)
            {
                PrintWord(word);
                GuessLetter(game, out word);
                CheckGameOver(game, out isGameOver);
            }

            if (!isGameOver)
            {
                Console.WriteLine("Congrats, you won!");
            }
        }


        private static void PrintWord(char[] word)
        {
            Console.WriteLine(string.Join(" ", word));
        }

        private static void CheckGameOver(GameLogic gameLogic, out bool isGameOver)
        {
            if (gameLogic.IsGameOver)
            {
                Console.WriteLine("You failed! Game over.");
                isGameOver = true;
            }
            else
            {
                isGameOver = false;
            }
        }

        private static void GuessLetter(GameLogic gameLogic, out char[] word)
        {
            var c = GetChar();
            var isGoodGuess = gameLogic.Guess(c, out word);
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