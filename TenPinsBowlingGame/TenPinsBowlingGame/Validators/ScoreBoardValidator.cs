using TenPinsBowlingGame.Definitions;

namespace TenPinsBowlingGame.Validators
{
    public class ScoreBoardValidator : FrameTenBonusValidator
    {
        public bool IsValidGame(string[] gameScoreBoard)
        {
            return HasCorrectNumberOfFrames(gameScoreBoard) && HasBonusIndicator(gameScoreBoard) && (HasCorrectFrames(gameScoreBoard) && HasCorrectFrameTenBonus(gameScoreBoard));
        }

        private static bool HasCorrectNumberOfFrames(string[] gameScoreBoard)
        {
            return gameScoreBoard.Length == InputIndex.TotalNumberOfFramesFromStringInput;
        }

        private static bool HasCorrectFrames(string[] gameScoreBoard)
        {
            var hasCorrectFrames = true;
            var frameValidator = new FrameValidator();

            for (int frameIndex = 0; frameIndex < InputIndex.NumberOfFramesInBowlingGame; frameIndex++)
            {
                hasCorrectFrames = hasCorrectFrames && frameValidator.IsValidFrame(gameScoreBoard[frameIndex]);
            }

            return hasCorrectFrames;
        }
        private static bool HasBonusIndicator(string[] gameScoreBoard)
        {
            return gameScoreBoard[InputIndex.BonusIndicatorIndex] == "";
        }
        private static bool HasCorrectFrameTenBonus(string[] gameScoreBoard)
        {
            return IsValidFrameTenBonus(gameScoreBoard[InputIndex.FrameTen], gameScoreBoard[InputIndex.BonusFrame]);
        }
    }
}
