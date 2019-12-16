using NUnit.Framework;
using FluentAssertions;

using TenPinsBowlingGame.Validators;

namespace TenPinsBowlingGame.Tests
{
    public class ScoreBoardValidatorFixture
    {
        [Test]
        [Category("ScoreBoardValidatorFixture: Negative")]
        public void Should_Return_False_When_Less_Than_Ten_Frame()
        {
            var gameDetail = new string[] {"X","X","X","X","X","X","X","X","X","XX"};
            var sut = new ScoreBoardValidator();

            var result = sut.IsValidGame(gameDetail);

            result.Should().BeFalse();
        }

        [Test]
        [Category("ScoreBoardValidatorFixture: Negative")]
        public void Should_Return_False_When_More_Than_Ten_Frame()
        {
            var gameDetail = new string[] { "X", "X", "X", "X", "X", "X", "X", "X", "X", "x", "x", "", "XX" };
            var sut = new ScoreBoardValidator();

            var result = sut.IsValidGame(gameDetail);

            result.Should().BeFalse();
        }

        [Test]
        [Category("ScoreBoardValidatorFixture: Negative")]
        public void Should_Return_False_When_Missing_Bonus_Indicator()
        {
            var gameDetail = new string[] { "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "x" };
            var sut = new ScoreBoardValidator();

            var result = sut.IsValidGame(gameDetail);

            result.Should().BeFalse();
        }

        [Test]
        [Category("ScoreBoardValidatorFixture: Positive")]
        public void Should_Return_True_For_Game_With_One_Bonus()
        {
            var gameDetail = new string[] { "X", "X", "X", "X", "X", "X", "X", "X", "X", "4/", "", "x" };
            var sut = new ScoreBoardValidator();

            var result = sut.IsValidGame(gameDetail);

            result.Should().BeTrue();
        }

        [Test]
        [Category("ScoreBoardValidatorFixture: Positive")]
        public void Should_Return_True_For_Game_With_Two_Bonus()
        {
            var gameDetail = new string[] { "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "", "33" };
            var sut = new ScoreBoardValidator();

            var result = sut.IsValidGame(gameDetail);

            result.Should().BeTrue();
        }

        [Test]
        [Category("ScoreBoardValidatorFixture: Positive")]
        public void Should_Return_True_For_Game_Without_Bonus()
        {
            var gameDetail = new string[] { "X", "X", "X", "X", "X", "X", "X", "X", "X", "33", "", "" };
            var sut = new ScoreBoardValidator();

            var result = sut.IsValidGame(gameDetail);

            result.Should().BeTrue();
        }
    }
}
