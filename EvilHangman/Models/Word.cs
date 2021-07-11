using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace EvilHangman
{
    public class Word
    {
        public string Name { get; }
        public Dictionary<char, List<int>> CharIndices { get; }

        public Word(string name)
        {
            Name = name;
            CharIndices = TransformToMap(name);
        }

        private static Dictionary<char, List<int>> TransformToMap(string word)
        {
            var dict = new Dictionary<char, List<int>>();
            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (dict.ContainsKey(c))
                {
                    var indices = dict[c];
                    indices.Add(i);
                    dict[c] = indices;
                }
                else
                {
                    dict[c] = new List<int> {i};
                }
            }

            return dict;
        }

        public int HashAccordingToChar(char c)
        {
            if (!CharIndices.ContainsKey(c))
            {
                return 0;
            }

            var charIndices = CharIndices[c];
            return Enumerable.Range(0, charIndices.Count)
                .Select(n => n * Name.Length)
                .Zip(charIndices, (n, index) => n + index + 1)
                .Sum();
        }

        public List<int> GetIndicesOfChar(char c) => CharIndices.ContainsKey(c) ? CharIndices[c] : new List<int>();
    }
}