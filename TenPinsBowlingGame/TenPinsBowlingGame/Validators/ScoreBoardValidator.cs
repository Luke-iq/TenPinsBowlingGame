using TenPinsBowlingGame.Definitions;

namespace TenPinsBowlingGame.Validators
{
    public class ScoreBoardValidator
    {
        public string[] ScoreBoardArray { get; }
        public ScoreBoardValidator(string[] newScoreBoardArray)
        {
            ScoreBoardArray = newScoreBoardArray;
        }
        public bool IsValidGame()
        {
            return HasCorrectNumberOfFrames() && HasBonusIndicator() && (HasCorrectFrames() && HasCorrectFrameTenBonus());
        }

        private bool HasCorrectNumberOfFrames()
        {
            return ScoreBoardArray.Length == InputIndex.TotalNumberOfFramesFromStringInput;
        }

        private bool HasCorrectFrames()
        {
            var hasCorrectFrames = true;
 
            for (var frameIndex = 0; frameIndex < InputIndex.NumberOfFramesInBowlingGame; frameIndex++)
            {
                var frameValidator = new FrameValidator(ScoreBoardArray[frameIndex]);
                hasCorrectFrames = hasCorrectFrames && frameValidator.IsValidFrame();
            }

            return hasCorrectFrames;
        }
        private bool HasBonusIndicator()
        {
            return ScoreBoardArray[InputIndex.BonusIndicatorIndex] == ValidInput.EmptyFrame;
        }
        private bool HasCorrectFrameTenBonus()
        {
            var frameTen = new FrameValidator(ScoreBoardArray[InputIndex.FrameTen]);
            return frameTen.IsValidFrameTenBonus(ScoreBoardArray[InputIndex.BonusFrame]);
        }
    }
}
