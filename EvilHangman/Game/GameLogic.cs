using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EvilHangman
{
    public class GameLogic
    {
        private uint Score { get; set; } = 5;
        private readonly Dictionary<int, List<Word>> _words;
        private List<Word> _currentPossibleWords;
        private char[] _currentWord;
        public bool IsGameOver { get; private set; } = false;

        public GameLogic(string wordsFile)
        {
            _words = ProcessFileIntoWords(wordsFile);
        }

        private static Dictionary<int, List<Word>> ProcessFileIntoWords(string file)
        {
            return File
                .ReadAllLines(file)
                .Select(w => w.ToLower())
                .GroupBy(w => w.Length)
                .Where(g => g.Key > 3)
                .ToDictionary(g => g.Key,
                    g => g.Select(w => new Word(w)).ToList());
        }

        public char[] Init()
        {
            InitializePossibleWords(out var length);
            _currentWord = Enumerable.Repeat('_', length).ToArray();
            return _currentWord;
        }

        public bool Guess(char c, out char[] currentWord)
        {
            _currentPossibleWords = _currentPossibleWords
                .GroupBy(w => w.HashAccordingToChar(c))
                .OrderByDescending(g => g.Count())
                .First()
                .ToList();

            var numOfFilledChars = FillUncoveredChars(c);

            UpdateScore(numOfFilledChars);

            currentWord = _currentWord;

            return numOfFilledChars > 0;
        }

        public string GetGuessedWord() => !IsGameOver ? null : _currentPossibleWords.First().Name;

        private int FillUncoveredChars(char c)
        {
            var indices = _currentPossibleWords
                .First()
                .GetIndicesOfChar(c);
            indices.ForEach(index => _currentWord[index] = c);
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

        private void InitializePossibleWords(out int length)
        {
            var lengths = _words.Keys.ToList();
            var randomLengthIndex = new Random().Next(0, lengths.Count);
            length = lengths[randomLengthIndex];
            _currentPossibleWords = _words[length];
        }
    }
}