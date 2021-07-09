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
            Console.WriteLine(string.Join(" ", word));
            while (word.Any(c => c == '_'))
            {
                char c = (char) Console.Read();
                word = game.Guess(c);
                Console.WriteLine(string.Join(" ", word));
            }
        }
    }
}