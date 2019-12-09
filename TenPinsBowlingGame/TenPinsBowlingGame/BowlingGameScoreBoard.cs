using System;
using System.Collections;
using System.Collections.Generic;

using TenPinsBowlingGame.ExceptionHandlers;

namespace TenPinsBowlingGame
{
    public class BowlingGameScoreBoard
    {
        private const char Strike = 'x';
        private const char Spare = '/';
        private const int StrikeBonusCount = 2;
        private const int SpareBonusCount = 1;

        private int totalScore = 0;

        private string[] ParseGameInfo(string gameInfo)
        {
            string[] gameScoreBoard = gameInfo.Split('|');
            if (gameScoreBoard.Length != 12)
            {
                return null;
            }

            return gameScoreBoard;
        }

        private bool isValidFirstBall(char firstBall)
        {
            const string validFirstBall = "123456789-x";

            return validFirstBall.Contains(firstBall);
        }

        private bool isValidSecondBall(char secondBall)
        {
            const string validFirstBall = "123456789-/";

            return validFirstBall.Contains(secondBall);
        }

        private bool isValidSecondBonusBall(char secondBall)
        {
            const string validFirstBall = "123456789-/x";

            return validFirstBall.Contains(secondBall);
        }

        private int convertSingleScoreRecordToInt(char score)
        {
            switch (score)
            {
                case '-':
                    return 0;

                case 'x':
                    return 10;

                default:
                    return (int)Char.GetNumericValue(score);
            }
        }

        private int computeBonusScore(Queue bonusRecords, int currentPins)
        {
            int bonusScore = 0;
            int originalBonusRecordsCount = bonusRecords.Count;

            for (int bonus = 0; bonus < originalBonusRecordsCount; bonus++ )
            {
                var bonusDetail = (int[])bonusRecords.Dequeue();
                if (bonusDetail[1] == 2)
                {
                    bonusRecords.Enqueue(new int[] { bonusDetail[0], 1 });
                }

                bonusScore += currentPins;
            }

            return bonusScore;
        }

        public int ComputeTenPinsBowlingGameScores(string gameInfo)
        {
            const int totalNumberOfFrame = 10;
            const int bonusFeame = 11;
            const int firstBallOfAFrame = 0;
            const int secondBallOfAFrame = 1;

            Queue bonusBallRecords = new Queue();
        
            totalScore = 0;

            string[] gameScoreBoard = ParseGameInfo(gameInfo);
            if (gameScoreBoard == null)
            {
                throw new InvalidGameInputException($"Invalid game input {gameInfo}");
            }

            for(int currentFrame = 0; currentFrame < totalNumberOfFrame; currentFrame++)
            {
                char firstBall = char.ToLower(gameScoreBoard[currentFrame][firstBallOfAFrame]);
                if (!isValidFirstBall(firstBall))
                {
                    throw new InvalidGameInputException($"Invalid game input {gameInfo}");
                }

                var pinsDroppedForFirstBall = convertSingleScoreRecordToInt(firstBall);
                totalScore += pinsDroppedForFirstBall;
                totalScore += computeBonusScore(bonusBallRecords, pinsDroppedForFirstBall);

                if (firstBall == Strike)
                {
                    bonusBallRecords.Enqueue(new int[] { currentFrame, StrikeBonusCount });
                }

                if (gameScoreBoard[currentFrame].Length == 2)
                {
                    char secondBall = char.ToLower(gameScoreBoard[currentFrame][secondBallOfAFrame]);
                    if (!isValidSecondBall(secondBall))
                    {
                        throw new InvalidGameInputException($"Invalid game input {gameInfo}");
                    }

                    if (secondBall == Spare)
                    {
                        int sparePins = 10 - convertSingleScoreRecordToInt(firstBall);
                        totalScore += (sparePins);
                        totalScore += computeBonusScore(bonusBallRecords, sparePins);

                        bonusBallRecords.Enqueue(new int[] {currentFrame, SpareBonusCount});
                    }
                    else
                    {
                        int pinsDroppedForSecondBall = convertSingleScoreRecordToInt(secondBall);
                        totalScore += pinsDroppedForSecondBall;
                        totalScore += computeBonusScore(bonusBallRecords, pinsDroppedForSecondBall);
                    }
                }
            }

            if (gameScoreBoard[bonusFeame] != null && bonusBallRecords.Count > 0)
            {
                char firstBall = char.ToLower(gameScoreBoard[bonusFeame][firstBallOfAFrame]);
                if (!isValidFirstBall(firstBall))
                {
                    throw new InvalidGameInputException($"Invalid game input {gameInfo}");
                }

                var pinsDroppedForFirstBall = convertSingleScoreRecordToInt(firstBall);

                totalScore += computeBonusScore(bonusBallRecords, pinsDroppedForFirstBall);

                if (gameScoreBoard[bonusFeame].Length == 2)
                {
                    char secondBall = char.ToLower(gameScoreBoard[bonusFeame][secondBallOfAFrame]);
                    if (!isValidSecondBonusBall(secondBall))
                    {
                        throw new InvalidGameInputException($"Invalid game input {gameInfo}");
                    }

                    if (secondBall == Spare)
                    {
                        int sparePins = 10 - convertSingleScoreRecordToInt(firstBall);

                        totalScore += computeBonusScore(bonusBallRecords, sparePins);

                    }
                    else
                    {
                        int pinsDroppedForSecondBall = convertSingleScoreRecordToInt(secondBall);
                        
                        totalScore += computeBonusScore(bonusBallRecords, pinsDroppedForSecondBall);
                    }
                }

            }

            return totalScore;
        }
    }
}
