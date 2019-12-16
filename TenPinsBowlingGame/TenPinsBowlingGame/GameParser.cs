using TenPinsBowlingGame.Definitions;
using TenPinsBowlingGame.ExceptionHandlers;
using TenPinsBowlingGame.Validators;

namespace TenPinsBowlingGame
{
    public class GameParser : ScoreBoardValidator
    {
        private string[] gameInfoArray;

        public GameParser(string gameInfo)
        {
            gameInfoArray = gameInfo.Split(ValidInput.FrameSeparator);

            if (!IsValidGame(gameInfoArray))
            {
                throw new InvalidGameInputException($"Invalid game input {gameInfo}");
            }
        }

        public ScoreBoard GenerateScoreBoard()
        {
            var frames = new Frame[InputIndex.NumberOfFramesInBowlingGame];
            var bonusTracker = new BonusHandler();

            for (var frameIndex = 0; frameIndex < InputIndex.NumberOfFramesInBowlingGame; frameIndex++)
            {
                var newFrame = StringToFrame(gameInfoArray[frameIndex]);

                bonusTracker.ApplyBonuses(newFrame.PinsDroppedOfAThrow);

                if (newFrame.NumberOfBonusAcquired != FrameBonus.NoBonus)
                {
                    bonusTracker.AddFrame(newFrame);
                }

                frames[frameIndex] = newFrame;
            }

            if (gameInfoArray[InputIndex.BonusFrame].Length != ValidInput.EmptyFrameLength)
            {
                var bonusFrame = StringToFrame(gameInfoArray[InputIndex.BonusFrame]);
                bonusTracker.ApplyBonuses(bonusFrame.PinsDroppedOfAThrow);
            }

            var scoreBoard = new ScoreBoard(frames);

            return scoreBoard;
        }

        //public Frame[] ParseGameInfo()
        //{
            //var gameInfoSplit = _gameInfo.Split(ValidInput.FrameSeparator);

            //if (!IsValidGame(gameInfoSplit))
            //{
            //    throw new InvalidGameInputException($"Invalid game input {_gameInfo}");
            //}

        //    var scoreBoard = new Frame[InputIndex.NumberOfFramesInBowlingGame];

        //    PopulateFrames(gameInfoSplit, scoreBoard);
            
        //    return scoreBoard;
        //}

        //private static void PopulateFrames(string[] gameInfo, Frame[] scoreBoard)
        //{
        //    var bonusTracker = new BonusHandler();
            
        //    for (var frameIndex = 0; frameIndex < InputIndex.NumberOfFramesInBowlingGame; frameIndex++)
        //    {
        //        var newFrame = StringToFrame(gameInfo[frameIndex]);

        //        bonusTracker.ApplyBonuses(newFrame.PinsDroppedOfAThrow);
                
        //        if (newFrame.NumberOfBonusAcquired != FrameBonus.NoBonus)
        //        {
        //            bonusTracker.AddFrame(newFrame);
        //        }

        //        scoreBoard[frameIndex] = newFrame;
        //    }

        //    if (gameInfo[InputIndex.BonusFrame].Length != ValidInput.EmptyFrameLength)
        //    {
        //        var bonusFrame = StringToFrame(gameInfo[InputIndex.BonusFrame]);
        //        bonusTracker.ApplyBonuses(bonusFrame.PinsDroppedOfAThrow);
        //    }
        //}

        private static Frame StringToFrame(string frameString)
        {
            var frame = new Frame();

            if (IsStrikeFrame(frameString))
            {
                frame.AddThrow(InputIndex.TotalNumberOfPins);
                frame.NumberOfBonusAcquired = FrameBonus.Strike;
                return frame;
            }

            var pinsDroppedOfFirst = ConvertCharInput.ToInt[frameString[InputIndex.FirstInput]];
            frame.AddThrow(pinsDroppedOfFirst);

            if (frameString.Length == ValidInput.NoneStrikeFrameLength)
            {
                int pinsDroppedOfSecond;
                if (frameString[InputIndex.SecondInput] == ValidInput.Spare)
                {
                    pinsDroppedOfSecond = InputIndex.TotalNumberOfPins - pinsDroppedOfFirst;
                    frame.NumberOfBonusAcquired = FrameBonus.Spare;
                }
                else
                {
                    pinsDroppedOfSecond = ConvertCharInput.ToInt[frameString[InputIndex.SecondInput]];
                    frame.NumberOfBonusAcquired = FrameBonus.NoBonus;
                }

                frame.AddThrow(pinsDroppedOfSecond);
            }
            return frame;
        }
    }
}
