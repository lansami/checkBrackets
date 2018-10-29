using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBrackets
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputText = string.Empty;
                Console.WriteLine("Enter the text that will be checked:");
                inputText = Console.ReadLine();
                string errors = CheckBracketsOnString(inputText);
                if (string.IsNullOrWhiteSpace(errors)) { Console.WriteLine("All brackets are ok"); }
                else { Console.WriteLine($"Not all brackets were ok. Check errors: \n{errors}"); }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Exception occured:{exc.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Check if the brackets are ok on string
        /// </summary>
        /// <param name="inputText">Text to check</param>
        /// <returns>Return the list of errors occured</returns>
        public static string CheckBracketsOnString(string inputText)
        {
            string errors = string.Empty;
            // Brackets structure accepted
            Dictionary<char, char> acceptedBrackets = new Dictionary<char, char>()
            {
                { '(',')' },
                { '[',']' },
                { '{','}' },
            };
            // Stack of brackets that are not closed
            Stack<KeyValuePair<char,int>> brackets = new Stack<KeyValuePair<char,int>>();
            for(int i=0; i < inputText.Length; i++)
            {
                // If the bracket is an opening bracket add it to the stack of brackets that are not closed
                if (acceptedBrackets.Keys.Contains(inputText[i]))
                {
                    brackets.Push(new KeyValuePair<char, int>(inputText[i], i));
                }
                // Else if the bracket is a closing bracket check if the closing bracket is the expect bracket
                else if (acceptedBrackets.Values.Contains(inputText[i]))
                {
                    // If it exists an opened bracket then check if is the expected bracket
                    if (brackets.Any())
                    {    
                        if (inputText[i] == acceptedBrackets[brackets.First().Key])
                        {
                            brackets.Pop();
                        }
                        // If the checked bracket is not the expected bracket then get the string around the checked bracket
                        else
                        {
                            errors += GetSubString(inputText, i) + Environment.NewLine;
                        }
                    }
                    // If no opened bracket opened then get the string around the closed bracket without having the opening bracket
                    else
                    {
                        errors += GetSubString(inputText, i) + Environment.NewLine;
                    }
                }
                else
                {
                    continue;
                }
            }

            if (brackets.Count == 0 && string.IsNullOrWhiteSpace(errors))
            {
                return string.Empty;
            }
            else
            {
                // While brackets are still available then output the string around the found bracket
                while (brackets.Any())
                {
                    KeyValuePair<char, int> bracket = brackets.Pop();
                    errors += GetSubString(inputText, bracket.Value) + Environment.NewLine;
                }

                return errors;
            }

        }

        /// <summary>
        /// Get substring of string created as three left characters on left and three characters on right
        /// </summary>
        /// <param name="inputText">Text from where to extract the substring</param>
        /// <param name="checkIndex">Index where the substring should be</param>
        /// <returns>Returns the substring of the input text</returns>
        public static string GetSubString(string inputText, int checkIndex)
        {
            string substring = string.Empty;
            int noElementsLeft = 0;
            int noElementsRight = 0;
            // Get the number of elements on the left side of the checkIndex
            noElementsLeft = (checkIndex / 3 < 1 ? checkIndex % 3 : 3);
            // Get the number of elements on the right side of the checkIndex
            noElementsRight = (inputText.Length - 3 <= checkIndex ? inputText.Length - checkIndex - 1 : 3);
            substring += inputText.Substring(checkIndex - noElementsLeft, noElementsLeft);
            if (checkIndex + noElementsRight + 1 <= inputText.Length)
            {
                substring += inputText.Substring(checkIndex, noElementsRight + 1);
            }

            return substring.Replace(' ', '.'); ;
        }
    }
}
