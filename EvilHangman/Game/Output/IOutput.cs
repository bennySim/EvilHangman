namespace EvilHangman.Output
{
    public interface IOutput
    {
        public void PrintWinMessage();

        public void PrintGameOverMessage();

        public void PrintGoodGuessMessage(char c);

        public void PrintBadGuessMessage(char c);

        public void PrintWord(char[] word);



        public void PrintGameEnd(bool isWin);

        public void PrintResultOfGuess(bool isGoodGuess, char c);
    }
}