using System.Collections.Generic;
using System.Linq;

using TenPinsBowlingGame.Definitions;
using TenPinsBowlingGame.ExceptionHandlers;

namespace TenPinsBowlingGame.Models
{
    public class Frame
    {
        private readonly List<int> _pinsDroppedOfAThrow;
        private readonly List<int> _pinsDroppedOfABonusBall;
        public IEnumerable<int> PinsDroppedOfAThrow => _pinsDroppedOfAThrow;
        public IEnumerable<int> PinsDroppedOfABonusBall => _pinsDroppedOfABonusBall;
        public FrameBonus NumberOfBonusAcquired { get; set; }
        public Frame()
        {
            _pinsDroppedOfAThrow = new List<int>();
            _pinsDroppedOfABonusBall = new List<int>();
            NumberOfBonusAcquired = 0;
        }
        public void AddThrow(int pinsDropped)
        {
            if(_pinsDroppedOfAThrow.Count < ValidInput.NoneStrikeFrameLength)
            {
                _pinsDroppedOfAThrow.Add(pinsDropped);
                if(_pinsDroppedOfAThrow.Count == ValidInput.StrikeFrameLength && pinsDropped == InputIndex.TotalNumberOfPins)
                {
                    
                }
            }
            throw new InvalidGameInputException($"Invalid frame input {pinsDropped} for a completed Frame");  
        }
        public void AddBonus(int pinsDropped)
        {
            if(_pinsDroppedOfABonusBall.Count < (int) NumberOfBonusAcquired)
            {
                _pinsDroppedOfABonusBall.Add(pinsDropped);
            }
            throw new InvalidGameInputException($"Invalid bouns input {pinsDropped} for a completed Frame");  
        }
        public ScoreResult CurrentFrameScore()
        {
            var result = new ScoreResult
            {
                ScoreType = IsFinalScore() ? ScoreStatus.Final : ScoreStatus.Temporary,
                Score = PinsDroppedOfAThrow.Sum() + PinsDroppedOfABonusBall.Sum()
            };

            return result;
        }

        public bool HasAllKnockedDownPinsInfo() => _pinsDroppedOfAThrow.Count == ValidInput.NoneStrikeFrameLength || _pinsDroppedOfAThrow[0] == InputIndex.TotalNumberOfPins;

        private bool IsFinalScore()
        {
            return IsStrikeAndHasAllBonus() || IsSpareAndHasBonus() || HasRemainingPinsWithoutBonus();
        }
        private bool IsStrikeAndHasAllBonus()
        {
            return (PinsDroppedOfAThrow.Count() == ValidInput.StrikeFrameLength) && (NumberOfBonusAcquired == FrameBonus.Strike)  && (PinsDroppedOfABonusBall.Count() == (int) FrameBonus.Strike);
        }
        private bool IsSpareAndHasBonus()
        {
            return (PinsDroppedOfAThrow.Count() == ValidInput.NoneStrikeFrameLength) && (NumberOfBonusAcquired == FrameBonus.Spare) && (PinsDroppedOfABonusBall.Count() == (int) FrameBonus.Spare);
        }
        private bool HasRemainingPinsWithoutBonus()
        {
            var result = (PinsDroppedOfAThrow.Count() == ValidInput.NoneStrikeFrameLength) && (NumberOfBonusAcquired == FrameBonus.NoBonus) && (PinsDroppedOfABonusBall.Count() == (int) FrameBonus.NoBonus);
            return result;
        }
    }
}
