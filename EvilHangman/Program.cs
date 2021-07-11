using System;
using System.Linq;

namespace EvilHangman
{
    class Program
    {
        private const string FileWithWords = "words.txt";

        static void Main(string[] args)
        {
            new GameCLI().Start(FileWithWords);
        }

    }
}