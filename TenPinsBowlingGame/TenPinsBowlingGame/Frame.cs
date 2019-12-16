using System.Collections.Generic;
using System.Linq;

using TenPinsBowlingGame.Definitions;

namespace TenPinsBowlingGame
{
    public class Frame
    {
        public List<int> PinsDroppedOfAThrow { get; set; }
        public List<int> PinsDroppedOfABonusBall { get; set; }
        public FrameBonus NumberOfBonusAcquired { get; set; }
        public Frame()
        {
            PinsDroppedOfAThrow = new List<int>();
            PinsDroppedOfABonusBall = new List<int>();
            NumberOfBonusAcquired = 0;
        }
        public void AddThrow(int pinsDropped)
        {
            PinsDroppedOfAThrow.Add(pinsDropped);
        }
        public void AddBonus(int pinsDropped)
        {
            PinsDroppedOfABonusBall.Add(pinsDropped);
        }
        public ScoreResult CurrentFrameScore()
        {
            var result = new ScoreResult
            {
                ScoreType = CurrentScoreStatus() ? ScoreStatus.Final : ScoreStatus.Temporary,
                Score = PinsDroppedOfAThrow.Sum() + PinsDroppedOfABonusBall.Sum()
            };

            return result;
        }

        private bool CurrentScoreStatus()
        {
            return IsStrikeAndHasAllBonus() || IsSpareAndHasBonus() || HasRemainingPinsWithoutBonus();
        }

        private bool IsStrikeAndHasAllBonus()
        {
            return (PinsDroppedOfAThrow.Count == 1) && (NumberOfBonusAcquired == FrameBonus.Strike)  && (PinsDroppedOfABonusBall.Count == (int) FrameBonus.Strike);
        }

        private bool IsSpareAndHasBonus()
        {
            return (PinsDroppedOfAThrow.Count == 2) && (NumberOfBonusAcquired == FrameBonus.Spare) && (PinsDroppedOfABonusBall.Count == (int) FrameBonus.Spare);
        }

        private bool HasRemainingPinsWithoutBonus()
        {
            var result = (PinsDroppedOfAThrow.Count == 2) && (NumberOfBonusAcquired == FrameBonus.NoBonus) && (PinsDroppedOfABonusBall.Count == (int) FrameBonus.NoBonus);
            return result;
        }
    }
}
