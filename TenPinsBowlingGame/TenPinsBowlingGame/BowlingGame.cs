using System.Linq;

using TenPinsBowlingGame.Definitions;
using TenPinsBowlingGame.Models;
using TenPinsBowlingGame.Processors;
using TenPinsBowlingGame.ExceptionHandlers;

namespace TenPinsBowlingGame
{
    public class BowlingGame
    {
        private readonly Frame[] _scoreBoard;
        private Frame _tempFrame;
        private readonly int _currentFrame;
        private readonly BonusHandler _bonusHandler;

        public BowlingGame()
        {
            _scoreBoard = new Frame[InputIndex.NumberOfFramesInBowlingGame];
            _tempFrame = new Frame();
            _currentFrame = 0;
            _bonusHandler = new BonusHandler();
        }

        public int Bowl(int pinsKnockedDown)
        {
            int currentScore = 0;

            return currentScore;
        }

        private void AddPinsKnockedDownInfoToCurrentFrame(int pinsKnockedDown)
        {
            if(_currentFrame > InputIndex.FrameTen)
            {
                if(!_bonusHandler.BonusInfoRequired)
                {
                    throw new InvalidGameInputException($"Invalid game input {pinsKnockedDown} for a completed game"); 
                }
            }
            else
            {
                _scoreBoard[_currentFrame].AddThrow(pinsKnockedDown);
                if(_bonusHandler.BonusInfoRequired)
                {
                    _bonusHandler.ApplyBonus(pinsKnockedDown);
                }
                            
                if(_scoreBoard[_currentFrame].PinsDroppedOfAThrow.Sum() == InputIndex.TotalNumberOfPins)
                {
                    if(_scoreBoard[_currentFrame].PinsDroppedOfAThrow.Count() == 1)
                    {
                        _scoreBoard[_currentFrame].NumberOfBonusAcquired = FrameBonus.Strike;
                    }
                    if( _scoreBoard[_currentFrame].PinsDroppedOfAThrow.Count() == 2)
                    {
                        _scoreBoard[_currentFrame].NumberOfBonusAcquired = FrameBonus.Spare;
                    }
                    _bonusHandler.AddFrame(_scoreBoard[_currentFrame]);
                }

                
            }
        }

    }
}