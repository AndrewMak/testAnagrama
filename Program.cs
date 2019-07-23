using System;
using System.Linq;

namespace testeanagrama
{
    class Program
    {
        public class Anagram
        {
            public Anagram()
            {
                Valid = true;
                Result = "Both string are anagram string.";
            }
            public string Result { get; set; }
            public bool Valid { get; set; }
            public Anagram areAnagram(string firstString, string secondString)
            {
                if (firstString.Trim().Length != secondString.Trim().Length)
                {
                    Valid = false;
                    Result = $"Both string are not anagram string.";
                    return this;
                }
                else
                {
                    //Convert string to character array  
                    var firstarray = firstString.ToLower().Trim().ToCharArray().ToList();
                    var secondarray = secondString.ToLower().Trim().ToCharArray().ToList();
                    //Sort array  
                    firstarray.Sort();
                    secondarray.Sort();

                    var listzip = firstarray.Zip(secondarray, (first, second) => new { first, second });
                    foreach (var item in listzip)
                    {
                        if (item.first != item.second)
                        {
                            Valid = false;
                            Result = $"Both string are not anagram string. : {item.first} and {item.second}";
                            return this;
                        }
                    }

                    return this;
                }
            }
        }
        static void Main(string[] args)
        {
            string firstString, secondString;
            Console.WriteLine("Enter first string");
            firstString = Console.ReadLine();
            Console.WriteLine("Enter second string");
            secondString = Console.ReadLine();
            Anagram anagram = new Anagram();
            //Check if words are anagram  
            if (anagram.areAnagram(firstString, secondString).Valid == true)
                Console.WriteLine(anagram.Result);
            else
                Console.WriteLine(anagram.Result);
            Console.ReadLine();
        }
    }

}
