using NUnit.Framework;
using FluentAssertions;

using TenPinsBowlingGame.Validators;
namespace TenPinsBowlingGame.Tests
{
    public class FrameValidatorFixture
    {
        [Test]
        [Category("FrameValidatorFixture: Negative")]
        public void Should_Return_False_With_Empty_Frame()
        {
            const string frame = "";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameValidatorFixture: Negative")]
        public void Should_Return_False_When_Frame_Has_More_Than_Two_Values()
        {
            const string frame = "333";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameValidatorFixture: Negative")]
        public void Should_Return_False_With_One_None_Strike_Value()
        {
            const string frame = "3";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameValidatorFixture: Negative")]
        public void Should_Return_False_When_Size_Two_Frame_Starts_With_Strike()
        {
            const string frame = "X3";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameValidatorFixture: Negative")]
        public void Should_Return_False_When_Size_Two_Frame_Starts_With_Spare()
        {
            const string frame = "/3";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameValidatorFixture: Negative")]
        public void Should_Return_False_When_Sum_Of_Frame_Greater_Than_Ten()
        {
            const string frame = "83";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameValidatorFixture: Positive")]
        public void Should_Return_True_For_Strike_Frame()
        {
            const string frame = "x";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameValidatorFixture: Positive")]
        public void Should_Return_True_For_Spare_Frame()
        {
            const string frame = "X";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameValidatorFixture: Positive")]
        public void Should_Return_True_For_Regular_Frame()
        {
            const string frame = "11";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameValidatorFixture: Positive")]
        public void Should_Return_True_For_Frame_With_First_Zero_Pin_Throw()
        {
            const string frame = "-8";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameValidatorFixture: Positive")]
        public void Should_Return_True_For_Frame_With_Second_Zero_Pin_Throw()
        {
            const string frame = "8-";
            var sut = new FrameValidator();

            var result = sut.IsValidFrame(frame);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_Bonus_Found_For_Frame_Does_Not_Have_Bonus()
        {
            const string frame = "33";
            const string bonus = "3";
            var sut = new FrameValidator();

            var result = sut.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_Two_Bonus_Found_For_Spare_Frame()
        {
            const string frame = "3/";
            const string bonus = "33";
            var sut = new FrameValidator();

            var result = sut.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_Three_Bonus_Found_For_Strike_Frame()
        {
            const string frame = "x";
            const string bonus = "123";
            var sut = new FrameValidator();

            var result = sut.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_Single_Bonus_Found_For_Strike_Frame()
        {
            const string frame = "x";
            const string bonus = "3";
            var sut = new FrameValidator();

            var result = sut.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_First_Bonus_Contains_Invalid_Char()
        {
            const string frame = "8/";
            const string bonus = "/";
            var sut = new FrameValidator();

            var result = sut.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Negative")]
        public void Should_Return_False_If_Second_Bonus_Contains_Invalid_Char()
        {
            const string frame = "x";
            const string bonus = "3s";
            var sut = new FrameValidator();

            var result = sut.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeFalse();
        }

        [Test]
        [Category("FrameTenBonusValidator: Positive")]
        public void Should_Return_True_If_Single_Bonus_Found_For_Spare_Frame()
        {
            const string frame = "3/";
            const string bonus = "4";
            var sut = new FrameValidator();

            var result = sut.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameTenBonusValidator: Positive")]
        public void Should_Return_True_If_Two_Bonus_Found_For_Strike_Frame()
        {
            const string frame = "x";
            const string bonus = "45";
            var sut = new FrameValidator();

            var result = sut.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameTenBonusValidator: Positive")]
        public void Should_Return_True_If_Two_Bonus_Are_Both_Strike_For_Strike_Frame()
        {
            const string frame = "x";
            const string bonus = "xx";
            var sut = new FrameValidator();

            var result = sut.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeTrue();
        }

        [Test]
        [Category("FrameTenBonusValidator: Positive")]
        public void Should_Return_True_If_Two_Bonus_Are_Spare_For_Strike_Frame()
        {
            const string frame = "x";
            const string bonus = "4/";
            var sut = new FrameValidator();

            var result = sut.IsValidFrameTenBonus(frame, bonus);

            result.Should().BeTrue();
        }

    }
}
