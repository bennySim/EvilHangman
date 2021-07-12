using EvilHangman.Input;
using EvilHangman.Output;

namespace EvilHangman
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