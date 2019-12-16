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
    }
}
