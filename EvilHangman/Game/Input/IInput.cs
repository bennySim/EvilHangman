namespace EvilHangman.Input
{
    public interface IInput
    {
        public char GetChar();

        public bool GetAnswerPlayAgain();
    }
}