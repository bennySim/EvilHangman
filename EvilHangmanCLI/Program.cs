using EvilHangman;
using EvilHangmanCLI.IO;

namespace EvilHangmanCLI
{
    class Program
    {
        private const string FileWithWords = "words.txt";

        static void Main(string[] args)
        {
            new GameCLI(FileWithWords, new ConsoleOutput(), new ConsoleInput()).Start();
        }
    }
}