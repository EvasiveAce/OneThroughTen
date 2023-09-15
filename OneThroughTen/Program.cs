//inclusive 1-10 integers
//same guess 3 times in a row = exit
//no answer 5 attempts - end and retry
//right - correct and retry

//Problems with two of these: with my program the computer will never guess the same answer 3 times? Maybe I programmed the core system wrong or it's just a 
//requirement that is meant to throw me off like you said. same with the no answer 5 attempts, i do not think this will ever happen with the way I have it set up

namespace Program
{
    public class MainCLass
    {

        public static void Main(string[] args)
        {
            Game game = new Game();
            game.startGame();
            Console.ResetColor();
        }
    }

    public class Game
    {
        int computerGuess = 0;
        Random random = new Random();
        int numberToGuess = 0;
        bool toPlay = true;
        int currentRangeHigh = 11;
        int currentRangeLow = 1;

        public void startGame()
        {
            numberToGuess = random.Next(1, 11);
            while (toPlay)
            {
                computerGuess = random.Next(currentRangeLow, currentRangeHigh);
                string checkAnswer = CheckAnswer();
                Range(computerGuess, checkAnswer);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The computer guess: " + computerGuess);
                if (checkAnswer == "Correct")
                {
                    Console.ResetColor();
                    Console.WriteLine(computerGuess +" is the " + checkAnswer + " Answer!");
                    Console.WriteLine("Do you want to play again? (Y/N)");
                    char userInput = Console.ReadKey().KeyChar;
                    if(userInput == 'Y' || userInput == 'y')
                    {
                        Console.Clear();
                        Game game = new Game();
                        game.startGame();
                    } 
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Thanks for playing!");
                    }

                    //There is a case for a more invested program to actually have a while loop to catch Y and N and to repeat until a real case
                    //but with what I have right now, if they press y it's a repeat, if anything else it's taken as a N, which works for me
                    //else if(userInput == 'N')
                    //{
                    //    Console.Clear();
                    //    Console.WriteLine("Thanks for playing!");
                    //}


                }
                else
                {
                    //Color if else, doesnt need to be here but it looks cool for hotter/colder
                    if (checkAnswer == "Higher")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You need to be: " + checkAnswer);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("You need to be: " + checkAnswer);
                    }
                    
                }
                
            }

        }
        public void Range(int x, string higherLower)
        {
            if (higherLower == "Higher")
            {
                currentRangeLow = x + 1;
            }
            else if (higherLower == "Lower")
            {
                currentRangeHigh = x - 1;
            }
            else if (higherLower == "Correct")
            {
                toPlay = false;
            }
        }

        public string CheckAnswer()
        {
            if (computerGuess < numberToGuess)
            {
                return "Higher";
            }
            else if (computerGuess > numberToGuess)
            {
                return "Lower";
            }
            return "Correct";
        }
    }
}
