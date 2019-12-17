using System;
using TenPinsBowlingGame.ExceptionHandlers;

namespace TenPinsBowlingGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ScoreBoard bowlingGameScoreBoard;

            var bowlingGameStats = new []
            {
                "11|22|33|44|11|22|33|44|11|22||",
                "X|X|21|--|--|--|--|--|--|--||",
                "5/|21|--|--|--|--|--|--|--|--||",
                "--|--|--|--|--|--|--|--|--|X||22",
                "--|--|--|--|--|--|--|--|--|8/||2",
                "X|X|X|X|X|X|X|X|X|X||XX",
                "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5",
                "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||",
                "X|7/|9-|X|-8|8/|-6|X|X|X||81"
            };

            Console.WriteLine("Bowling Score Board");

            foreach (var gameInput in bowlingGameStats)
            {
                bowlingGameScoreBoard = new ScoreBoard(gameInput);
                
                var currentResult = bowlingGameScoreBoard.GetCurrentScores();

                Console.WriteLine($"{gameInput}\n\t\t\t\t\t{currentResult.Score}\n");
            }

            Console.WriteLine("Please Enter a string for bowling game or `q` to end program:");
            var input = Console.ReadLine();
            while (input != "q")
            {
                try
                {
                    bowlingGameScoreBoard = new ScoreBoard(input);
                    var currentResult = bowlingGameScoreBoard.GetCurrentScores();

                    Console.WriteLine($"\t\t\t\t\t{currentResult.Score} {currentResult.ScoreType}\n");
                }
                catch (InvalidGameInputException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Please Enter a string for bowling game or x to end program:");
                input = Console.ReadLine();
            }
        }
    }
}
