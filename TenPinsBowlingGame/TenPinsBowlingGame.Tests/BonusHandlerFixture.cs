using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;

using TenPinsBowlingGame.Definitions;
using TenPinsBowlingGame.Models;
using TenPinsBowlingGame.Processors;

namespace TenPinsBowlingGame.Tests
{
    public class BonusHandlerFixture
    {
        [Test]
        [Category("BonusHandlerFixture: Positive")]
        public void Should_Be_Able_To_Update_Single_Bonus_Of_Given_Frame()
        {
            var aFrame = new Frame {NumberOfBonusAcquired = FrameBonus.Spare};
            var bonusValue = new List<int>() { 9 };
            var sut = new BonusHandler();
            sut.AddFrame(aFrame);

            sut.ApplyBonuses(bonusValue);

            aFrame.PinsDroppedOfABonusBall.Count.Should().Be((int)FrameBonus.Spare);
        }

        [Test]
        [Category("BonusHandlerFixture: Positive")]
        public void Should_Be_Able_To_Update_Two_Bonus_Of_Given_Frame()
        {
            var aFrame = new Frame {NumberOfBonusAcquired = FrameBonus.Strike};
            var bonusValue = new List<int>() { 1, 9 };
            BonusHandler sut = new BonusHandler();
            sut.AddFrame(aFrame);

            sut.ApplyBonuses(bonusValue);

            aFrame.PinsDroppedOfABonusBall.Count.Should().Be((int)FrameBonus.Strike);
        }

        [Test]
        [Category("BonusHandlerFixture: Positive")]
        public void Should_Return_True_When_Single_Bonus_Apply_Successfully()
        {
            var aFrame = new Frame {NumberOfBonusAcquired = FrameBonus.Spare};
            var bonusValue = new List<int>() { 9 };
            var sut = new BonusHandler();
            sut.AddFrame(aFrame);

            var result = sut.ApplyBonuses(bonusValue);

            result.Should().BeTrue();
        }


        [Test]
        [Category("BonusHandlerFixture: Positive")]
        public void Should_Return_True_When_Two_Bonus_Apply_Successfully()
        {
            var aFrame = new Frame {NumberOfBonusAcquired = FrameBonus.Strike};
            var bonusValue = new List<int>() { 9, 9 };
            var sut = new BonusHandler();
            sut.AddFrame(aFrame);

            var result = sut.ApplyBonuses(bonusValue);
            
            result.Should().BeTrue();
        }

        [Test]
        [Category("BonusHandlerFixture: Negative")]
        public void Should_Return_False_When_No_Frame_To_Apply_Bonus()
        {
            var bonusValue = new List<int>() { 9 };
            var sut = new BonusHandler();

            var result = sut.ApplyBonuses(bonusValue);

            result.Should().BeFalse();
        }

        [Test]
        [Category("BonusHandlerFixture: Negative")]
        public void Should_Return_False_When_Applying_Third_Bonus_To_A_Frame()
        {
            var aFrame = new Frame { NumberOfBonusAcquired = FrameBonus.Strike };
            var bonusValue = new List<int>() { 1, 9, 3 };
            BonusHandler sut = new BonusHandler();
            sut.AddFrame(aFrame);

            var result = sut.ApplyBonuses(bonusValue);

            result.Should().BeFalse();
        }
    }
}
