using NUnit.Framework;
using FluentAssertions;

using TenPinsBowlingGame.Validators;

namespace TenPinsBowlingGame.Tests
{
    public class FrameTenBonusValidatorFixture
    {
        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_Bonus_Found_For_Frame_Does_Not_Have_Bonus()
        {
            const string frame = "33";
            const string bonus = "3";
            
            var result = FrameTenBonusValidator.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_Two_Bonus_Found_For_Spare_Frame()
        {
            const string frame = "3/";
            const string bonus = "33";

            var result = FrameTenBonusValidator.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_Three_Bonus_Found_For_Strike_Frame()
        {
            const string frame = "x";
            const string bonus = "123";
            
            var result = FrameTenBonusValidator.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_Single_Bonus_Found_For_Strike_Frame()
        {
            const string frame = "x";
            const string bonus = "3";

            var result = FrameTenBonusValidator.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_First_Bonus_Contains_Invalid_Char()
        {
            const string frame = "8/";
            const string bonus = "/";

            var result = FrameTenBonusValidator.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_Second_Bonus_Contains_Invalid_Char()
        {
            const string frame = "x";
            const string bonus = "3s";

            var result = FrameTenBonusValidator.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Positive")]
        public void Should_Return_True_If_Single_Bonus_Found_For_Spare_Frame()
        {
            const string frame = "3/";
            const string bonus = "4";


            var result = FrameTenBonusValidator.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameTenBonusValidator: Positive")]
        public void Should_Return_True_If_Two_Bonus_Found_For_Strike_Frame()
        {
            const string frame = "x";
            const string bonus = "45";

            var result = FrameTenBonusValidator.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameTenBonusValidator: Positive")]
        public void Should_Return_True_If_Two_Bonus_Are_Both_Strike_For_Strike_Frame()
        {
            const string frame = "x";
            const string bonus = "xx";
            
            var result = FrameTenBonusValidator.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameTenBonusValidator: Positive")]
        public void Should_Return_True_If_Two_Bonus_Are_Spare_For_Strike_Frame()
        {
            const string frame = "x";
            const string bonus = "4/";

            var result = FrameTenBonusValidator.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeTrue();
        }
    }
}
