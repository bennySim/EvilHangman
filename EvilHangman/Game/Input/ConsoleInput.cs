using System;

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
    }
}