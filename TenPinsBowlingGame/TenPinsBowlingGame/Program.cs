using System;

using TenPinsBowlingGame.ExceptionHandlers;
using TenPinsBowlingGame.Models;
using TenPinsBowlingGame.Processors;
using TenPinsBowlingGame.Validators;

namespace TenPinsBowlingGame
{
    public class Program
    {
        public static void PrintScore(string s)
        {
            try
            {
                var gameParser = new GameParser(new ScoreBoardValidator());
                var bowlingGameScoreBoard = new ScoreBoard(s, gameParser);
                var currentResult = bowlingGameScoreBoard.GetCurrentScores();

                Console.WriteLine($"\t\t\t\t{currentResult.ScoreType} Score: {currentResult.Score}\n");
            }
            catch (InvalidGameInputException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void Main(string[] args)
        {
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
            string input;

            Console.WriteLine("Bowling Score Board");

            foreach (var gameInput in bowlingGameStats)
            {
                Console.WriteLine($"{gameInput}");
                PrintScore(gameInput);
            }

            do
            {
                Console.WriteLine("Please Enter a string for bowling game or 'q' to end program:");
                input = Console.ReadLine();
                PrintScore(input);
            } while (input != "q");
        }
    }
}
