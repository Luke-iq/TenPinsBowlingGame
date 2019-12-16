using TenPinsBowlingGame.Definitions;

namespace TenPinsBowlingGame.Validators
{
    public class ScoreBoardValidator : FrameValidator
    {
        public bool IsValidGame(string[] gameScoreBoard)
        {
            return HasCorrectNumberOfFrames(gameScoreBoard) && HasBonusIndicator(gameScoreBoard) && (HasCorrectFrames(gameScoreBoard) && HasCorrectFrameTenBonus(gameScoreBoard));
        }

        private bool HasCorrectNumberOfFrames(string[] gameScoreBoard)
        {
            return gameScoreBoard.Length == InputIndex.TotalNumberOfFramesFromStringInput;
        }

        private bool HasCorrectFrames(string[] gameScoreBoard)
        {
            var hasCorrectFrames = true;
 
            for (int frameIndex = 0; frameIndex < InputIndex.NumberOfFramesInBowlingGame; frameIndex++)
            {
                hasCorrectFrames = hasCorrectFrames && IsValidFrame(gameScoreBoard[frameIndex]);
            }

            return hasCorrectFrames;
        }
        private bool HasBonusIndicator(string[] gameScoreBoard)
        {
            return gameScoreBoard[InputIndex.BonusIndicatorIndex] == ValidInput.EmptyFrame;
        }
        private bool HasCorrectFrameTenBonus(string[] gameScoreBoard)
        {
            return IsValidFrameTenBonus(gameScoreBoard[InputIndex.FrameTen], gameScoreBoard[InputIndex.BonusFrame]);
        }
    }
}
