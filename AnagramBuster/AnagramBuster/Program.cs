using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnagramBuster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Anagram Buster\nPlease Enter the Anagram:");
            
            string anagram = Console.ReadLine();
            
            List<string> wordsInAnagram = new List<string>();
            
            char[] letters = anagram.ToCharArray();
            
            CheckForWords(wordsInAnagram, letters);

            wordsInAnagram = SortByLength(wordsInAnagram);

            Console.WriteLine("The following words were found in the anagram");

            foreach (var word in wordsInAnagram)
            {
                Console.WriteLine(word);
            }
        }

        private static void CheckForWords(List<string> wordsInAnagram, char[] letters)
        {
            using (var sr = new StreamReader("C:/Users/jonathanwilliamson/source/repos/AnagramBuster/AnagramBuster/AnagramBuster/wordlist.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    string word = sr.ReadLine();
                    char[] wordLetters = word.ToCharArray();
                    if (WordInAnagram(letters, wordLetters))
                    {
                        wordsInAnagram.Add(word);
                    }
                }
            }
        }

        private static bool WordInAnagram(char[] anagram, char [] word)
        {
            if(word.Length == 1)
            {
                return false;
            }

            List<char> anagramLetters = anagram.ToList();
            foreach (var letter in word)
            {
                if (!anagramLetters.Contains(letter))
                {
                    return false;
                }
                else
                {
                    anagramLetters.Remove(letter);
                }
            }
            return true;
        }

        private static List<string> SortByLength(List<string> words)
        {
            List<string> sortedWords = (from s in words orderby s.Length ascending select s).ToList();
            return sortedWords;
        }
    }
}
