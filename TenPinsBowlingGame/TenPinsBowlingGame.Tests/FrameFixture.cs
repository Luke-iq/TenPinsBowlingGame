using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;

using TenPinsBowlingGame.Definitions;
using TenPinsBowlingGame.Models;

namespace TenPinsBowlingGame.Tests
{
    public class FrameFixture
    {
        [Test]
        [Category("FrameFixture:")]
        public void Should_Be_Able_To_Compute_Partial_Score_For_Spare_Frame()
        {
            var sut = new Frame
            {
                NumberOfBonusAcquired = FrameBonus.Spare,
            };
            sut.AddThrow(5);
            sut.AddThrow(5);

            var result = sut.CurrentFrameScore();

            result.Score.Should().Be(10);
        }

        [Test]
        [Category("FrameFixture:")]
        public void Should_Be_Able_To_Identify_Score_Is_Not_Final_For_Spare_Frame()
        {
            var sut = new Frame {NumberOfBonusAcquired = FrameBonus.Spare};
            sut.AddThrow(5);
            sut.AddThrow(5);

            var result = sut.CurrentFrameScore();

            result.ScoreType.Should().BeEquivalentTo(ScoreStatus.Temporary);
        }

        [Test]
        [Category("FrameFixture:")]
        public void Should_Be_Able_To_Compute_Final_Score_For_Spare_Frame()
        {
            var sut = new Frame {NumberOfBonusAcquired = FrameBonus.Spare};
            sut.AddThrow(5);
            sut.AddThrow(5);
            sut.AddBonus(3);

            var result = sut.CurrentFrameScore();

            result.Score.Should().Be(13);
        }

        [Test]
        [Category("FrameFixture:")]
        public void Should_Be_Able_To_Identify_Score_Is_Final_For_Spare_Frame()
        {
            var sut = new Frame { NumberOfBonusAcquired = FrameBonus.Spare };
            sut.AddThrow(5);
            sut.AddThrow(5);
            sut.AddBonus(3);

            var result = sut.CurrentFrameScore();

            result.ScoreType.Should().BeEquivalentTo(ScoreStatus.Final);
        }

        [Test]
        [Category("FrameFixture:")]
        public void Should_Be_Able_To_Compute_Partial_Score_For_Strike_Frame()
        {
            var sut = new Frame { NumberOfBonusAcquired = FrameBonus.Strike };
            sut.AddThrow(10);
            sut.AddBonus(10);

            var result = sut.CurrentFrameScore();

            result.Score.Should().Be(20);
        }

        [Test]
        [Category("FrameFixture:")]
        public void Should_Be_Able_To_Identify_Score_Is_Not_Final_For_Strike_Frame()
        {
            var sut = new Frame { NumberOfBonusAcquired = FrameBonus.Strike };
            sut.AddThrow(10);
            sut.AddBonus(10);

            var result = sut.CurrentFrameScore();

            result.ScoreType.Should().BeEquivalentTo(ScoreStatus.Temporary);
        }

        [Test]
        [Category("FrameFixture:")]
        public void Should_Be_Able_To_Compute_Final_Score_For_Strike_Frame()
        {
            var sut = new Frame { NumberOfBonusAcquired = FrameBonus.Strike };
            sut.AddThrow(10);
            sut.AddBonus(3);
            sut.AddBonus(5);

            var result = sut.CurrentFrameScore();

            result.Score.Should().Be(18);
        }

        [Test]
        [Category("FrameFixture:")]
        public void Should_Be_Able_To_Identify_Score_Is_Final_For_Strike_Frame()
        {
            var sut = new Frame { NumberOfBonusAcquired = FrameBonus.Strike };
            sut.AddThrow(10);
            sut.AddBonus(3);
            sut.AddBonus(5);

            var result = sut.CurrentFrameScore();

            result.ScoreType.Should().BeEquivalentTo(ScoreStatus.Final);
        }

        [Test]
        [Category("FrameFixture:")]
        public void Should_Be_Able_To_Identify_Score_Is_Partial_For_Empty_Frame()
        {
            var sut = new Frame();

            var result = sut.CurrentFrameScore();

            result.ScoreType.Should().BeEquivalentTo(ScoreStatus.Temporary);
        }

        [Test]
        [Category("FrameFixture:")]
        public void Should_Be_Able_To_Compute_Partial_Score_For_Empty_Frame()
        {
            var sut = new Frame();

            var result = sut.CurrentFrameScore();

            result.Score.Should().Be(0);
        }
    }
}
