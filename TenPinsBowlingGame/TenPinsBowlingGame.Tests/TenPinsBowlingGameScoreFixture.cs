using System;
using NUnit.Framework;
using FluentAssertions;

using TenPinsBowlingGame;
using TenPinsBowlingGame.ExceptionHandlers;

namespace TenPinsBowlingGame.Tests
{
    public class TenPinsBowlingGameFixture
    {
        private BowlingGameScoreBoard sut = new BowlingGameScoreBoard();


        [Test]
        [Category("Invalid Game Info Format")]
        public void A_Bowling_Game_Should_Not_Have_More_Than_Ten_Frames()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("Invalid Game Info Format")]
        public void A_Bowling_Game_Should_Not_Have_Less_Than_Ten_Frames()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("Invalid Game Info Format")]
        public void A_Bowling_Game_Should_Have_Bonus_Balls_Indicator()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("Invalid Frame Info")]
        public void A_FRAME_In_A_Bowling_Game_Should_Have_At_Least_One_Proper_Input()
        {
            const string bowlingGameStats = "X|X|X|X|X|X||X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} without data for a frames.");
        }

        [Test]
        [Category("Invalid Frame Info")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_An_Incorrect_Input_D()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|D|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Frame Info")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_More_Than_Two_Input()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|234|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Frame Info")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Strike_And_Spare_In_The_Same_Frame()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X/|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Frame Info")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Spare_As_The_First_Input()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|/9|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Frame Info")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Two_Spares_As_Input()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|//|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Frame Info")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Two_Strikes_As_Input()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|XX|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Frame Info")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Strike_As_First_Input_Follow_By_Zero_Pins()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X-|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Frame Info")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Strike_As_First_Input_Follow_By_A_Digit()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X9|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Frame Info")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Two_Digits_Sums_Up_Over_Ten()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|68|X|X|X||XX";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Bonus Throw Info")]
        public void Should_Not_Have_Spare_As_First_Bonus_Ball()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X||/-";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Bonus Throw Info")]
        public void Should_Not_Have_Bonus_Balls_When_Frame_Ten_Is_Not_Spare_Or_Strike()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|55||55";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Bonus Throw Info")]
        public void Should_Not_Have_Two_Bonus_Balls_When_Frame_Ten_Is_Not_Strike()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|5/||55";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Bonus Throw Info")]
        public void Should_Not_Have_More_Than_Two_Bonus_Balls()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X||XX5";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Bonus Throw Info")]
        public void Should_Not_Have_Only_One_Bonus_Balls_When_Frame_Ten_Is_Strike()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X||5";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Bonus Throw Info")]
        public void Should_Not_Have_No_Bonus_Balls_When_Frame_Ten_Is_Strike()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X||";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Invalid Bonus Throw Info")]
        public void Should_Not_Have_No_Bonus_Balls_When_Frame_Ten_Is_Spare()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|5/||";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }


        [Test]
        [Category("Invalid Bonus Throw Info")]
        public void Should_Not_Have_Sum_Of_Two_Bonus_Balls_Greater_Than_Ten()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|5/||88";

            Action act = () => sut.ComputeTenPinsBowlingGameScores(bowlingGameStats);
            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats} with invalid data for a frames.");
        }

        [Test]
        [Category("Computing Game Score")]
        public void Should_Add_All_Numbers_From_Each_Frame()
        {
            const string bowlingGameStats = "11|22|33|44|11|22|33|44|11|22||";

            sut.ComputeTenPinsBowlingGameScores(bowlingGameStats).Should().Be(46);
        }

        [Test]
        [Category("Computing Game Score")]
        public void Should_Add_Next_Two_Balls_From_Next_Frame_For_Strike_Frame()
        {
            const string bowlingGameStats = "X|22|1-|--|--|--|--|--|--|--||";

            sut.ComputeTenPinsBowlingGameScores(bowlingGameStats).Should().Be(19);
        }

        [Test]
        [Category("Computing Game Score")]
        public void Should_Add_Next_Two_Balls_From_Next_Two_Frames_For_Strike_Frame()
        {
            const string bowlingGameStats = "X|X|21|--|--|--|--|--|--|--||";

            sut.ComputeTenPinsBowlingGameScores(bowlingGameStats).Should().Be(38);
        }

        [Test]
        [Category("Computing Game Score")]
        public void Should_Add_Next_Ball_For_Spare_Frame()
        {
            const string bowlingGameStats = "5/|21|--|--|--|--|--|--|--|--||";

            sut.ComputeTenPinsBowlingGameScores(bowlingGameStats).Should().Be(15);
        }

        [Test]
        [Category("Computing Game Score")]
        public void Should_Add_Next_Two_Bonus_Balls_For_Strike_On_Frame_Ten()
        {
            const string bowlingGameStats = "--|--|--|--|--|--|--|--|--|X||22";

            sut.ComputeTenPinsBowlingGameScores(bowlingGameStats).Should().Be(14);
        }

        [Test]
        [Category("Computing Game Score")]
        public void Should_Add_Next_Bonus_Ball_For_Spare_On_Frame_Ten()
        {
            const string bowlingGameStats = "--|--|--|--|--|--|--|--|--|8/||2";

            sut.ComputeTenPinsBowlingGameScores(bowlingGameStats).Should().Be(12);
        }

        [Test]
        [Category("Computing Game Score")]
        public void Should_Compute_Perfect_Game()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X||XX";

            sut.ComputeTenPinsBowlingGameScores(bowlingGameStats).Should().Be(300);
        }

        [Test]
        [Category("Computing Game Score")]
        public void Should_Compute_All_Spare_Game()
        {
            const string bowlingGameStats = "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5";

            sut.ComputeTenPinsBowlingGameScores(bowlingGameStats).Should().Be(150);
        }

        [Test]
        [Category("Computing Game Score")]
        public void Should_Compute_All_Nine_Pins_Game()
        {
            const string bowlingGameStats = "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||";

            sut.ComputeTenPinsBowlingGameScores(bowlingGameStats).Should().Be(90);
        }

        [Test]
        [Category("Computing Game Score")]
        public void Should_Compute_Radom_Game()
        {
            const string bowlingGameStats = "X|7/|9-|X|-8|8/|-6|X|X|X||81";

            sut.ComputeTenPinsBowlingGameScores(bowlingGameStats).Should().Be(167);
        }
    }
}