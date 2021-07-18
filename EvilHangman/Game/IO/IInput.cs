namespace EvilHangman.IO
{
    public interface IInput
    {
        public char GetChar();

        public bool GetAnswerPlayAgain();
    }
}