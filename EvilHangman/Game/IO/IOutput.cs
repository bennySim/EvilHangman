using System.Collections.Generic;

namespace EvilHangman.IO
{
    public interface IOutput
    {
        public void PrintWinMessage();

        public void PrintGameOverMessage(string word);

        public void PrintGoodGuessMessage(char c);

        public void PrintBadGuessMessage(char c);

        public void PrintWord(char[] word);

        public void PrintGameEnd(bool isWin, string word);

        public void PrintResultOfGuess(bool isGoodGuess, char c);
        
        public void PrintNumOfLeftGuesses(uint numLeftGuesses);

        public void PrintUsedLetters(IEnumerable<char> guessedLetters);
    }
}