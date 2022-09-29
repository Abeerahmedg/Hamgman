using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static string[] wordBank = { "home", "school", "house", "apartment", "office"};
        static void Main(string[] args)
        {
            string response = "";
            do
            {
                Console.WriteLine("Welcom to my game hangman :)");
                Console.WriteLine("-----------------------------\n");
                Console.Write("Write the number you want:\n 1. play by word\n 2. Play by letter\n 3. Exit\n -:  ");
                response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        PlayByWord();
                        break;
                    case "2":
                        PlayByLetter();
                        break;
                    case "3":
                        break;

                }
            } while (response != "3");



        }
        static void PlayByWord()
        {
            Random random = new Random();
            string wordToGuess = wordBank[random.Next(0, wordBank.Length)];
            char[] word = new char[wordToGuess.Length];
            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for(int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');
            int lives = 10;
            bool won = false;
            string input;
            ;

            while (!won && lives > 0)
            {
                Console.WriteLine($"Guess the word I am thinking of , it has : {wordToGuess.Length} letters");

                input = Console.ReadLine().ToLower();
                if (input == wordToGuess) { 
                    Console.WriteLine("You gussed the word correct:) ");
                Console.WriteLine("Good job You won!"); }

                  else
                {
                    Console.WriteLine("Nope! that was not the word, try again");
                    lives--;
                }

                Console.WriteLine(displayToPlayer.ToString());
                Console.WriteLine($"The word you gussed: {input}");
                Console.WriteLine($"Attempts left for you: {lives}");
                if (input == wordToGuess)
                    won = true;
            if (won)
                {
                    Console.WriteLine("\nPress any key to quit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (!won && lives ==0)
                {
                 Console.WriteLine($"You lost! It was '{wordToGuess}' \n\n\n");
                }



        
                


            }

        }

        static void PlayByLetter()
        {
            Random random = new Random();


            string wordToGuess = wordBank[random.Next(0, wordBank.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();
            char[] word = new char[wordToGuess.Length];
            
            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 10;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;

            while (!won && lives > 0)
            {
                Console.WriteLine($"Guess the word I am thinking of by letter it has {wordToGuess.Length} letters: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine($"You've already tried '{guess}', and it was correct!");
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine($"You've already tried '{guess}', and it was wrong!");
                    continue;
                }

                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuessUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == wordToGuess.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);

                    Console.WriteLine($"Nope, there's no '{guess}' in it!");
                    lives--;
                }

                Console.WriteLine(displayToPlayer.ToString());
                Console.WriteLine($"The letter you gussed: {input}");
                Console.WriteLine($"Attempts left for you: {lives}");

            }


            if (won)
                Console.WriteLine("You won!");
            else
                Console.WriteLine($"You lost! It was '{wordToGuess}'");

            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }
        }
    }