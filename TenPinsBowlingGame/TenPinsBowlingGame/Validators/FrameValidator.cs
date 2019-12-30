using System.Linq;
using TenPinsBowlingGame.Definitions;

namespace TenPinsBowlingGame.Validators
{
    public class FrameValidator
    {
        public bool IsValidFrame(string frame)
        {
            return IsStrikeFrame(frame) || IsSpareFrame(frame) || IsValidNoneSpareFrameWIthTwoThrows(frame);
        }

        public bool IsValidFrameTenBonus(string frameTen, string bonus)
        {
            char firstBonus;

            switch (bonus.Length)
            {
                case (int)FrameBonus.NoBonus:
                    return !IsSpareFrame(frameTen) && !IsStrikeFrame(frameTen);

                case (int)FrameBonus.Spare:
                    if (IsSpareFrame(frameTen))
                    {

                        firstBonus = char.ToLower(bonus[InputIndex.FirstInput]);
                        return ValidInput.ValidFirstBonus.Contains(firstBonus);
                    }
                    return false;

                case (int)FrameBonus.Strike:
                    if (IsStrikeFrame(frameTen))
                    {
                        firstBonus = char.ToLower(bonus[InputIndex.FirstInput]);
                        var secondBonus = char.ToLower(bonus[InputIndex.SecondInput]);
                        return ValidInput.ValidFirstBonus.Contains(firstBonus) && ValidInput.ValidSecondBonus.Contains(secondBonus);
                    }
                    return false;

                default:
                    return false;
            }
        }

        public bool IsStrikeFrame(string frame)
        {
            return ((frame.Length == ValidInput.StrikeFrameLength) && (frame.ToLower() == ValidInput.StrikeFrame));
        }

        public static bool IsSpareFrame(string frame)
        {
            if (frame.Length != ValidInput.NoneStrikeFrameLength)
            {
                return false;
            }
            var firstThrow = char.ToLower(frame[InputIndex.FirstInput]);
            var secondThrow = char.ToLower(frame[InputIndex.SecondInput]);

            return ValidInput.ValidFirstOfTwoThrows.Contains(firstThrow) && secondThrow == ValidInput.Spare;
        }

        private static bool IsValidNoneSpareFrameWIthTwoThrows(string frame)
        {
            if (frame.Length != ValidInput.NoneStrikeFrameLength)
            {
                return false;
            }
            var firstThrow = char.ToLower(frame[InputIndex.FirstInput]);
            var secondThrow = char.ToLower(frame[InputIndex.SecondInput]);

            var hasCorrectSum = IsSumLessOrEqualToTen(frame);

            return ValidInput.ValidFirstOfTwoThrows.Contains(firstThrow) && ValidInput.ValidSecondOfTwoThrows.Contains(secondThrow) && hasCorrectSum;
        }

        private static bool IsSumLessOrEqualToTen(string frame)
        {
            var sum = frame.Where(char.IsDigit).Sum(input => (int) char.GetNumericValue(input));

            return sum <= InputIndex.TotalNumberOfPins;
        }
    }
}
