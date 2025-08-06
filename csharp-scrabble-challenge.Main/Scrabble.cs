using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {

        private Dictionary<char, int> charScore = new Dictionary<char, int>();
        private Dictionary<char, char> bracketPair = new Dictionary<char, char> { { '{', '}' }, { '[', ']'} };
        private List<char> legalBrackets = new List<char> { '{', '}', '[', ']' };
        private string _word;
        private int _mulitplier = 1;

        public Scrabble(string word)
        {
            //TODO: do something with the word variable
            addAlphabetToDict();
            word = word.ToUpper();
            _word = word;
        }

        public int score()
        {
            //TODO: score calculation code goes here
            int finalScore = 0;
            string subString = _word;
            int _wordMultiplier = 1;

            char currentOpenBracket = ' ';

            if (_word.Length == 0) { return finalScore; }
            if (checkLegalWord(_word))
            {
                if (_word[0] == '{' && _word[_word.Length - 1] == '}')
                {
                    subString = _word.Substring(1, _word.Length - 2);

                    if (subString[1] == '}') 
                    {
                        _wordMultiplier = 1;
                        _mulitplier = 2;
                        currentOpenBracket = '{';
                    }
                    else { _wordMultiplier = 2; }
                }
                else if (_word[0] == '[' && _word[_word.Length - 1] == ']')
                    {
                        subString = _word.Substring(1, _word.Length - 2);
                    if (subString[1] == ']')
                    {
                        _wordMultiplier = 1;
                        _mulitplier = 3;
                        currentOpenBracket = '[';
                    }
                    else { _wordMultiplier = 3; }   
                }

                foreach (char ch in subString)
                {
                    //if (ch == '{') { _mulitplier += 1; open++; }
                    //else if(ch == '}') { if (_mulitplier > 1) { _mulitplier -= 1; } close++; }
                    //else if (ch == '[') { _mulitplier += 2; open++; }
                    //else if (ch == ']') { if (_mulitplier > 2) { _mulitplier -= 2; } close++; }

                    if (ch == '{')
                    {
                        if (currentOpenBracket == ' ') { _mulitplier += 1; currentOpenBracket = '{'; }
                        else { return 0; }
                    }
                    else if (ch == '}')
                    {
                        if (currentOpenBracket == '{') { _mulitplier -= 1; currentOpenBracket = ' '; }
                        else { return 0; }
                    }
                    else if (ch == '[')
                    {
                        if (currentOpenBracket == ' ') { _mulitplier += 2; currentOpenBracket = '['; }
                        else { return 0; }
                    }
                    else if (ch == ']')
                    {
                        if (currentOpenBracket == ']') { _mulitplier -= 2; currentOpenBracket = ' '; }
                        else { return 0; }

                    }
                    finalScore += charScore[ch] * _mulitplier;
                }
            }

            return finalScore * _wordMultiplier;

        }



        private bool checkLegalWord(string word)
        {
            foreach (char ch in word)
            {
                if (!charScore.ContainsKey(ch))
                {
                    return false;
                }
            }
            return true;
        }
        private void addAlphabetToDict()
        {
            charScore.Add('A', 1);
            charScore.Add('E', 1);
            charScore.Add('I', 1);
            charScore.Add('O', 1);
            charScore.Add('U', 1);
            charScore.Add('L', 1);
            charScore.Add('N', 1);
            charScore.Add('R', 1);
            charScore.Add('S', 1);
            charScore.Add('T', 1);
            charScore.Add('D', 2);
            charScore.Add('G', 2);
            charScore.Add('B', 3);
            charScore.Add('C', 3);
            charScore.Add('M', 3);
            charScore.Add('P', 3);
            charScore.Add('F', 4);
            charScore.Add('H', 4);
            charScore.Add('V', 4);
            charScore.Add('W', 4);
            charScore.Add('Y', 4);
            charScore.Add('K', 5);
            charScore.Add('J', 8);
            charScore.Add('X', 8);
            charScore.Add('Q', 10);
            charScore.Add('Z', 10);
            charScore.Add('{', 0);
            charScore.Add('}', 0);
            charScore.Add('[', 0);
            charScore.Add(']', 0);
        }     


        
    }
}
