using System;
using TenPinsBowlingGame.ExceptionHandlers;

namespace TenPinsBowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var bowlingGameStats = new[]
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

            BowlingGameScoreBoard bowlingGameScoreBoard = new BowlingGameScoreBoard();

            Console.WriteLine("Bowling Score Board");

            foreach (var gameInput in bowlingGameStats)
            {
                var totalScore = bowlingGameScoreBoard.ComputeTenPinsBowlingGameScores(gameInput);

                Console.WriteLine($"{gameInput}\n\t\t\t\t\t{totalScore}\n");
            }

            Console.WriteLine("Please Enter a string for bowling game or `q` to end program:");
            var input = Console.ReadLine();

            while (input != "q")
            {

                try
                {
                    var totalScore = bowlingGameScoreBoard.ComputeTenPinsBowlingGameScores(input);

                    Console.WriteLine($"\t\t\t\t\t{totalScore}\n");

                }
                catch (InvalidGameInputException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Please Enter a string for bowling game or 'q' to end program:");
                input = Console.ReadLine();
            }
        }
    }
}
