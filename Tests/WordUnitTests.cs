using EvilHangman;
using Xunit;

namespace Tests
{
    public class WordUnitTests
    {
        [Fact]
        public void HashFunctionTestNoChar()
        {
            var word = new Word("alhambra");
            Assert.Equal(0, word.HashAccordingToChar('c'));
            Assert.Equal(0, word.HashAccordingToChar('z'));
            Assert.Equal(0, word.HashAccordingToChar('x'));
        }

        [Fact]
        public void HashFunctionTestContainsOneOccurence()
        {
            var word = new Word("alhambra");
            Assert.Equal(2, word.HashAccordingToChar('l'));
            Assert.Equal(3, word.HashAccordingToChar('h'));
            Assert.Equal(6, word.HashAccordingToChar('b'));
            Assert.Equal(5, word.HashAccordingToChar('m'));
        }

        [Fact]
        public void HashFunctionTestContainsTwiceOccurence()
        {
            var word = new Word("tenet");
            Assert.Equal(11, word.HashAccordingToChar('t'));
            Assert.Equal(11, word.HashAccordingToChar('e'));

            var word2 = new Word("alla");
            Assert.Equal(9, word2.HashAccordingToChar('a'));
            Assert.Equal(9, word2.HashAccordingToChar('l'));
        }
    }
}