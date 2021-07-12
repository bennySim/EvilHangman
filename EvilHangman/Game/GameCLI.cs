using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EvilHangman.Input;
using EvilHangman.Output;

namespace EvilHangman
{
    public class GameCLI
    {
        private readonly IOutput _output;
        private readonly IInput _input;
        private GameLogic _game;
        private readonly Dictionary<int, List<Word>> _words;

        public GameCLI(string wordsFileName, IOutput output, IInput input)
        {
            _output = output;
            _input = input;
            _words = ProcessFileIntoWords(wordsFileName);
        }

        public void Start()
        {
            do
            {
                GuessOneWord();
            } while (_input.GetAnswerPlayAgain());
        }

        private void GuessOneWord()
        {
            var possibleWords = InitializePossibleWords(out var length);
            _game = new GameLogic(possibleWords, length);
            var word = _game.CurrentWord;

            while (word.Any(c => c == '_') && !_game.IsGameOver)
            {
                _output.PrintWord(word);
                GuessLetter(out word);
            }

            _output.PrintGameEnd(!_game.IsGameOver, _game.GetGuessedWord());
        }

        private void GuessLetter(out char[] word)
        {
            var c = _input.GetChar();
            var isGoodGuess = _game.Guess(c, out word);
            _output.PrintResultOfGuess(isGoodGuess, c);
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

        private List<Word> InitializePossibleWords(out int length)
        {
            var lengths = _words.Keys.ToList();
            var randomLengthIndex = new Random().Next(0, lengths.Count);
            length = lengths[randomLengthIndex];
            return _words[length];
        }
    }
}