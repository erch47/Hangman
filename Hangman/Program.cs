using System.Diagnostics.Tracing;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Hangman
{
    internal class Program
    {

        public static int rightLetters = 0;
        static void Main(string[] args)
        {
            Random random = new Random();
            StringBuilder usedChars = new StringBuilder();
            List <string> secretWordList = new List<string> { "Egg", "Fish", "cookie", "Inconsequential", "Hypothetically", "Flabbergast" };
            int index = random.Next(secretWordList.Count);
            string secretWord = secretWordList[index].ToLower();

            List<char> lines = printLines(secretWord);
            int wrongGuesses = 0;                      


            while(wrongGuesses != 10 && rightLetters < secretWord.Length)
            {
                Console.Write("Guessed letters: ");
                Console.Write(usedChars);


                string guess = userGuess().ToLower();


                if (guess.Length == 1)
                {
                    if (usedChars.ToString().Contains(guess[0]))
                    {
                        Console.Write("\r\nYou already guessed this letter");
                        printHangMan(wrongGuesses);

                    } 
                    else
                    {
                        bool charInWord = checkGuess(guess, secretWord);
                        

                        if (charInWord)
                        {
                            printHangMan(wrongGuesses);
                            usedChars.Append(guess[0]);
                            lines = ReplaceLines(lines, secretWord, guess);


                            foreach(char c in lines)
                            {
                                Console.Write(c);
                            }   
                            Console.Write("\r\n");
                        }
                        else
                        {
                            wrongGuesses++;
                            usedChars.Append(guess[0]);
                            printHangMan(wrongGuesses);
                        }
                    }

                }
                else if (guess.Length > 1)
                {
                    if (guess == secretWord)
                    {
                        break;
                    }
                }
                
            }


            if (wrongGuesses == 10)
            {
                Console.WriteLine("Game over you lose!");
            }
            else
            {
                Console.WriteLine("You win!");
            }

        }


        private static void printHangMan(int guess)
        {
            //Print the hangman

            switch (guess)
            {
                case 0:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("   ===");
                    break;
                case 1:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 2:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 3:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 4:
                    Console.WriteLine("\n+---+");
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 5:
                    Console.WriteLine("\n+---+");
                    Console.WriteLine(" O  |");
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 6:
                    Console.WriteLine("\n+---+");
                    Console.WriteLine(" O  |");
                    Console.WriteLine(" |  |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 7:
                    Console.WriteLine("\n+---+");
                    Console.WriteLine(" O  |");
                    Console.WriteLine("/|  |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 8:
                    Console.WriteLine("\n+---+");
                    Console.WriteLine(" O  |");
                    Console.WriteLine("/|\\ |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                    break;
                case 9:
                    Console.WriteLine("\n+---+");
                    Console.WriteLine(" O  |");
                    Console.WriteLine("/|\\ |");
                    Console.WriteLine("/   |");
                    Console.WriteLine("   ===");
                    break;
                case 10:
                    Console.WriteLine("\n+---+");
                    Console.WriteLine(" O  |");
                    Console.WriteLine("/|\\ |");
                    Console.WriteLine("/ \\ |");
                    Console.WriteLine("   ===");
                    break;
            }
            
        }


        private static List<char> ReplaceLines(List<char> lines, string word, string guess)
        {
            //Replaces the dashes with the correct letter and counts number of correct letters

            for (int i = 0; i < lines.Count; i++)
            {
                if (word[i] == guess[0])
                {
                    lines.RemoveAt(i);
                    lines.Insert(i, guess[0]);
                    rightLetters++;
                }
            }
            return lines;
        }

        private static string userGuess()
        {
            //Get user guess

            Console.Write("\r\nGuess a letter or word: ");
            string? guess = Console.ReadLine();
            return guess;
        }

        private static bool checkGuess(string guess, string word)
        {
            //Returns true if the guess is correct

            bool correctGuess = false;
            for (int i = 0; i < word.Length; i++)
            {
                if (guess[0] == word[i])
                {
                    correctGuess = true;
                }
            }
            return correctGuess;
        }


        private static List <char> printLines(string word)
        {
            //Returns a character list with dashes 

            List<char> lines = new List<char>();
            for (int i = 0; i < word.Length; i++)
            {
                lines.Add('-');
            }
            return lines;
        }
    }//End of class
}