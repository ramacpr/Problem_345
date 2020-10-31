using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_345
{
    class Program
    {
        static List<HashSet<string>> synSet = new List<HashSet<string>>();
      
        static void Main(string[] args)
        {
            Initialize(); 

            string sentence1 = "He wants to eat food.";
            string sentence2 = "He wants to consume food.";

            Console.WriteLine("Input 1: " + sentence1);
            Console.WriteLine("Input 2: " + sentence2);

            // remove . , ; and other special characters 
            sentence1 = sentence1.Replace(".", "");
            sentence2 = sentence2.Replace(".", "");

            // make to lower case 
            sentence1 = sentence1.ToLower();
            sentence2 = sentence2.ToLower();

            CheckEquivalence(sentence1.Trim(), sentence2.Trim());
            Console.ReadLine();
        }

        static void Initialize()
        {
            HashSet<string> theSet = new HashSet<string>();
            theSet.Add("eat");
            theSet.Add("consume");
            synSet.Add(theSet);

            theSet = new HashSet<string>();
            theSet.Add("put");
            theSet.Add("place");
            synSet.Add(theSet);

            theSet = new HashSet<string>();
            theSet.Add("adjust");
            theSet.Add("regulate");
            synSet.Add(theSet);
        }

        static bool CheckEquivalence(string sentence1, string sentence2)
        {
            if(GetWordCount(sentence1) != GetWordCount(sentence2))
            {
                Console.WriteLine("Not Equivalent");
                return false; 
            }

            string word1 = FindFirstWordOf(sentence1);
            string word2 = FindFirstWordOf(sentence2);
            if(word1 != word2)
            {
                if(!AreWordsSynonyms(word1, word2))
                    return false;
            }
            sentence1 = sentence1.Replace(word1, "").Trim();
            sentence2 = sentence2.Replace(word2, "").Trim();

            // we have checked all the words and they are equivalent
            if(string.IsNullOrEmpty(sentence1) && string.IsNullOrEmpty(sentence2))
            {
                Console.WriteLine("Equivalent");
                return true;
            }

            return CheckEquivalence(sentence1, sentence2);
        }

        static bool AreWordsSynonyms(string word1, string word2)
        {
            foreach(var set in synSet)
            {
                if (set.Contains(word1) && set.Contains(word2))
                    return true; 
            }            
            return true; 
        }

        static string FindFirstWordOf(string sentence)
        {
            string word = sentence.Trim();
            if (word.Length <= 0)
                return "";

            int index = word.IndexOf(" ");
            if (index <= 0)
                return word; // word has the last word of the sentence

            word = word.Substring(0, index);
            return word;
        }

        static int GetWordCount(string sentence)
        {
            string[] words = sentence.Split(' ');
            return words.Length;
        }
    }
}
