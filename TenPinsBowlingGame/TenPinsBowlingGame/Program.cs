using System;

namespace TenPinsBowlingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            const string bowlingGameStats = "X|X|21|--|--|--|--|--|--|--||";
            char input = '_';
            BowlingGameScoreBoard bowlingGameScoreBoard = new BowlingGameScoreBoard();

            while (input != 'x')
            {
                Console.WriteLine("Bowling Score Board");

                Console.WriteLine(bowlingGameStats);

                var totalScore = bowlingGameScoreBoard.ComputeTenPinsBowlingGameScores(bowlingGameStats);

                Console.WriteLine($"  |  |  |  |  |  |  |  |  |  ||  {totalScore}");

                input = char.ToLower(Console.ReadKey().KeyChar);
            }
        }
    }
}
