using TenPinsBowlingGame.Definitions;

namespace TenPinsBowlingGame.Validators
{
    public class FrameTenBonusValidator : FrameValidator
    {
        public static bool IsValidFrameTenBonus(string frameTen, string bonus)
        {
            char firstBonus;

            switch(frameTen.Length)
            {
                case 1:
                    if (IsStrikeFrame(frameTen) && bonus.Length == (int)FrameBonus.Strike)
                    {
                        firstBonus = char.ToLower(bonus[InputIndex.FirstInput]);
                        var secondBonus = char.ToLower(bonus[InputIndex.SecondInput]);
                        return ValidInput.ValidFirstBonus.Contains(firstBonus) && ValidInput.ValidSecondBonus.Contains(secondBonus);
                    }
                    return false;

                case 2:
                    if (!IsSpareFrame(frameTen))
                    {
                        return bonus.Length == (int)FrameBonus.NoBonus;
                    }

                    if (bonus.Length != (int)FrameBonus.Spare)
                    {
                        return false;
                    }

                    firstBonus = char.ToLower(bonus[InputIndex.FirstInput]);
                    return ValidInput.ValidFirstBonus.Contains(firstBonus) ;

                default:
                    return false;
            }
        }
    }
}
