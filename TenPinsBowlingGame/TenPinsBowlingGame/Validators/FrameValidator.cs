using System.Linq;
using TenPinsBowlingGame.Definitions;

namespace TenPinsBowlingGame.Validators
{
    public class FrameValidator
    {
        public string FrameString { get; }

        public FrameValidator(string newFrame)
        {
            FrameString = newFrame;
        }

        public bool IsValidFrame()
        {
            return IsStrikeFrame() || IsSpareFrame() || IsValidNoneSpareFrameWIthTwoThrows();
        }

        public bool IsValidFrameTenBonus(string bonus)
        {
            char firstBonus;

            switch (bonus.Length)
            {
                case (int)FrameBonus.NoBonus:
                    return !IsSpareFrame() && !IsStrikeFrame();

                case (int)FrameBonus.Spare:
                    if (IsSpareFrame())
                    {

                        firstBonus = char.ToLower(bonus[InputIndex.FirstInput]);
                        return ValidInput.ValidFirstBonus.Contains(firstBonus);
                    }
                    return false;

                case (int)FrameBonus.Strike:
                    if (IsStrikeFrame())
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

        public bool IsStrikeFrame()
        {
            return ((FrameString.Length == ValidInput.StrikeFrameLength) && (FrameString.ToLower() == ValidInput.StrikeFrame));
        }

        public bool IsSpareFrame()
        {
            if (FrameString.Length != ValidInput.NoneStrikeFrameLength)
            {
                return false;
            }
            var firstThrow = char.ToLower(FrameString[InputIndex.FirstInput]);
            var secondThrow = char.ToLower(FrameString[InputIndex.SecondInput]);

            return ValidInput.ValidFirstOfTwoThrows.Contains(firstThrow) && secondThrow == ValidInput.Spare;
        }

        private bool IsValidNoneSpareFrameWIthTwoThrows()
        {
            if (FrameString.Length != ValidInput.NoneStrikeFrameLength)
            {
                return false;
            }
            var firstThrow = char.ToLower(FrameString[InputIndex.FirstInput]);
            var secondThrow = char.ToLower(FrameString[InputIndex.SecondInput]);

            var hasCorrectSum = IsSumLessOrEqualToTen();

            return ValidInput.ValidFirstOfTwoThrows.Contains(firstThrow) && ValidInput.ValidSecondOfTwoThrows.Contains(secondThrow) && hasCorrectSum;
        }

        private bool IsSumLessOrEqualToTen()
        {
            var sum = FrameString.Where(char.IsDigit).Sum(input => (int) char.GetNumericValue(input));

            return sum <= InputIndex.TotalNumberOfPins;
        }
    }
}
