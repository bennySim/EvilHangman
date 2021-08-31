using System.Collections.Generic;
using System.Linq;

namespace EvilHangman
{
    public class GameLogic
    {
        public uint Score { get; private set; } = 5;
        private List<Word> _currentPossibleWords;
        public char[] CurrentWord { get; }
        public bool IsGameOver { get; private set; } = false;
        public List<char> UsedLetters { get; } = new();

        public GameLogic(List<Word> possibleWords, int length)
        {
            _currentPossibleWords = possibleWords;
            CurrentWord = Enumerable.Repeat('_', length).ToArray();
        }

        public bool Guess(char c, out char[] currentWord)
        {
            UsedLetters.Add(c);
            _currentPossibleWords = _currentPossibleWords
                .GroupBy(w => w.HashAccordingToChar(c))
                .OrderByDescending(g => g.Count())
                .First()
                .ToList();

            var numOfFilledChars = FillUncoveredChars(c);

            UpdateScore(numOfFilledChars);

            currentWord = CurrentWord;

            return numOfFilledChars > 0;
        }

        public string GetGuessedWord() => !IsGameOver ? null : _currentPossibleWords.First().Name;

        private int FillUncoveredChars(char c)
        {
            var indices = _currentPossibleWords
                .First()
                .GetIndicesOfChar(c);
            indices.ForEach(index => CurrentWord[index] = c);
            return indices.Count;
        }

        private void UpdateScore(int numOfFilledChars)
        {
            if (numOfFilledChars == 0)
            {
                Score--;
            }

            if (Score == 0)
            {
                IsGameOver = true;
            }
        }
    }
}