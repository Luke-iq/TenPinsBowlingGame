using System;
using System.Collections;

using TenPinsBowlingGame.ExceptionHandlers;

namespace TenPinsBowlingGame
{
    public class BowlingGameScoreBoard
    {
        private const char Strike = 'x';
        private const char Spare = '/';
        private const int StrikeBonusCount = 2;
        private const int SpareBonusCount = 1;
        private const int totalNumberOfFrame = 10;
        private const int bonusFrame = 11;
        private const int frameTenIndex = 9;
        private const int firstBallOfAFrame = 0;
        private const int secondBallOfAFrame = 1;

        private int numberOfBonus = 0;
        private int totalScore = 0;

        private string[] ParseGameInfo(string gameInfo)
        {
            string[] gameScoreBoard = gameInfo.Split('|');
            if (gameScoreBoard.Length != 12)
            {
                return null;
            }

            for (int frame = 0; frame < 10; frame++)
            {
                if (gameScoreBoard[frame].Length == 0)
                    throw new InvalidGameInputException($"Invalid game input {gameInfo} without data for a frames.");
                if (gameScoreBoard[frame].Length > 2)
                    throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
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
                numberOfBonus--;
                bonusScore += currentPins;
            }

            return bonusScore;
        }

        public int ComputeTenPinsBowlingGameScores(string gameInfo)
        {
            Queue bonusBallRecords = new Queue();
            
            totalScore = 0;

            string[] gameScoreBoard = ParseGameInfo(gameInfo);
            if (gameScoreBoard == null)
            {
                throw new InvalidGameInputException($"Invalid game input {gameInfo}");
            }

            char frameTenDetail = '_';
            for(int currentFrame = 0; currentFrame < totalNumberOfFrame; currentFrame++)
            {
                char firstBall = char.ToLower(gameScoreBoard[currentFrame][firstBallOfAFrame]);
                if (!isValidFirstBall(firstBall))
                {
                    throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
                }

                var pinsDroppedForFirstBall = convertSingleScoreRecordToInt(firstBall);
                totalScore += pinsDroppedForFirstBall;
                totalScore += computeBonusScore(bonusBallRecords, pinsDroppedForFirstBall);

                if (firstBall == Strike)
                {
                    if (currentFrame == frameTenIndex)
                    {
                        frameTenDetail = Strike;
                    }
                    numberOfBonus += 2;
                    bonusBallRecords.Enqueue(new int[] { currentFrame, StrikeBonusCount });
                }

                if (gameScoreBoard[currentFrame].Length == 2)
                {
                    if(firstBall == Strike)
                    {
                        throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
                    }

                    char secondBall = char.ToLower(gameScoreBoard[currentFrame][secondBallOfAFrame]);
                    if (!isValidSecondBall(secondBall))
                    {
                        throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
                    }

                    int pinsDroppedForSecondBall = 0;
                    if (secondBall == Spare)
                    {
                        if (currentFrame == frameTenIndex)
                        {
                            frameTenDetail = Spare;
                        }
                        pinsDroppedForSecondBall = 10 - convertSingleScoreRecordToInt(firstBall);

                        totalScore += pinsDroppedForSecondBall;
                        totalScore += computeBonusScore(bonusBallRecords, pinsDroppedForSecondBall);

                        numberOfBonus++;
                        bonusBallRecords.Enqueue(new int[] {currentFrame, SpareBonusCount});
                    }
                    else
                    {
                        pinsDroppedForSecondBall = convertSingleScoreRecordToInt(secondBall);

                        if (pinsDroppedForFirstBall + pinsDroppedForSecondBall > 10)
                        {
                            throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
                        }

                        totalScore += pinsDroppedForSecondBall;
                        totalScore += computeBonusScore(bonusBallRecords, pinsDroppedForSecondBall);
                    }
                }
            }


            if (frameTenDetail == Strike && gameScoreBoard[bonusFrame].Length != 2)
            {
                throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
            }

            if (frameTenDetail == Spare && gameScoreBoard[bonusFrame].Length != 1)
            {
                throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
            }


            if (frameTenDetail != Strike && frameTenDetail != Spare && gameScoreBoard[bonusFrame].Length != 0)
            {
                throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
            }


            if (bonusBallRecords.Count > 0)
            {
                //if (numberOfBonus != gameScoreBoard[bonusFrame].Length)
                //{
                //    throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
                //}

                char firstBall = char.ToLower(gameScoreBoard[bonusFrame][firstBallOfAFrame]);
                if (!isValidFirstBall(firstBall))
                {
                    throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
                }

                var pinsDroppedForFirstBall = convertSingleScoreRecordToInt(firstBall);

                totalScore += computeBonusScore(bonusBallRecords, pinsDroppedForFirstBall);

                if (gameScoreBoard[bonusFrame].Length == 2)
                {
                    char secondBall = char.ToLower(gameScoreBoard[bonusFrame][secondBallOfAFrame]);
                    if (!isValidSecondBonusBall(secondBall))
                    {
                        throw new InvalidGameInputException($"Invalid game input {gameInfo} with invalid data for a frames.");
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
