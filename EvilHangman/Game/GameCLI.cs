using System.Linq;
using EvilHangman.Input;
using EvilHangman.Output;

namespace EvilHangman
{
    public class GameCLI
    {
        private IOutput _output;
        private IInput _input;
        private GameLogic _game;

        public void Start(string wordsFileName, IOutput output, IInput input)
        {
            _output = output;
            _input = input;
            _game = new GameLogic(wordsFileName);
            var word = _game.Init();

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
       
    }
}