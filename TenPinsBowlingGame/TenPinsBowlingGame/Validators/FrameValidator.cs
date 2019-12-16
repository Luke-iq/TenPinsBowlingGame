using System.Linq;
using TenPinsBowlingGame.Definitions;

namespace TenPinsBowlingGame.Validators
{
    public class FrameValidator
    {
        public bool IsValidFrame(string frame)
        {
            switch (frame.Length)
            {
                case 1:
                    return IsStrikeFrame(frame);
                case 2:
                    return IsSpareFrame(frame) || IsValidFrameWIthTwoThrows(frame);
                default:
                    return false;
            }
        }

        public static bool IsStrikeFrame(string frame)
        {
            return ((frame.Length == 1) && (frame.ToLower() == ValidInput.StrikeFrame));
        }

        public static bool IsSpareFrame(string frame)
        {
            var firstThrow = char.ToLower(frame[InputIndex.FirstInput]);
            var secondThrow = char.ToLower(frame[InputIndex.SecondInput]);

            return ValidInput.ValidFirstOfTwoThrows.Contains(firstThrow) && secondThrow == ValidInput.Spare;
        }

        private static bool IsValidFrameWIthTwoThrows(string frame)
        {

            var firstThrow = char.ToLower(frame[InputIndex.FirstInput]);
            var secondThrow = char.ToLower(frame[InputIndex.SecondInput]);

            var hasCorrectSum = IsSumLessOrEqualToTen(frame);

            return ValidInput.ValidFirstOfTwoThrows.Contains(firstThrow) && ValidInput.ValidSecondOfTwoThrows.Contains(secondThrow) && hasCorrectSum;
        }

        private static bool IsSumLessOrEqualToTen(string frame)
        {
            const int maximumTotalForTwoThrows = 10;

            var sum = frame.Where(char.IsDigit).Sum(input => (int) char.GetNumericValue(input));

            return sum <= maximumTotalForTwoThrows;
        }
    }
}
