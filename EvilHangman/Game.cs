using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EvilHangman
{
    public class Game
    {
        public uint Score { get; } = 0;
        private readonly Dictionary<int, List<Word>> _words;
        private List<Word> _currentPossibleWords;
        private char[] _currentWord;

        public Game(string wordsFile)
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

        public char[] Start()
        {
            InitializePossibleWords(out var length);
            _currentWord = Enumerable.Repeat('_', length).ToArray();
            return _currentWord;
        }

        public char[] Guess(char c)
        {
            _currentPossibleWords = _currentPossibleWords
                .GroupBy(w => w.HashAccordingToChar(c))
                .OrderByDescending(g => g.Count())
                .First()
                .ToList();

            _currentPossibleWords
                .First()
                .GetIndicesOfChar(c)
                .ForEach(index => _currentWord[index] = c);

            return _currentWord;
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