﻿using System;
using NUnit.Framework;
using FluentAssertions;
using TenPinsBowlingGame.ExceptionHandlers;

namespace TenPinsBowlingGame.Tests
{
    public class GameParserFixture
    {
        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_Bowling_Game_Should_Not_Have_More_Than_Ten_Frames()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_Bowling_Game_Should_Not_Have_Less_Than_Ten_Frames()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X||";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_Bowling_Game_Should_Have_Bonus_Balls_Indicator()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_FRAME_In_A_Bowling_Game_Should_Have_At_Least_One_Proper_Input()
        {
            const string bowlingGameStats = "X|X|X|X|X|X||X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_An_Incorrect_Input_D()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|D|X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_More_Than_Two_Input()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|234|X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Strike_And_Spare_In_The_Same_Frame()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X/|X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Spare_As_The_First_Input()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|/9|X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Two_Spares_As_Input()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|//|X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Two_Strikes_As_Input()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|XX|X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Strike_As_First_Input_Follow_By_Zero_Pins()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X-|X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Strike_As_First_Input_Follow_By_A_Digit()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X9|X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void A_FRAME_In_A_Bowling_Game_Should_Not_Have_Two_Digits_Sums_Up_Over_Ten()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|68|X|X|X||XX";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void Should_Not_Have_Spare_As_First_Bonus_Ball()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X||/-";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void Should_Not_Have_Bonus_Balls_When_Frame_Ten_Is_Not_Spare_Or_Strike()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|55||55";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void Should_Not_Have_Two_Bonus_Balls_When_Frame_Ten_Is_Not_Strike()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|5/||55";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void Should_Not_Have_More_Than_Two_Bonus_Balls()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X||XX5";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void Should_Not_Have_Only_One_Bonus_Balls_When_Frame_Ten_Is_Strike()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X||5";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void Should_Not_Have_No_Bonus_Balls_When_Frame_Ten_Is_Strike()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X||";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void Should_Not_Have_No_Bonus_Balls_When_Frame_Ten_Is_Spare()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|5/||";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }

        [Test]
        [Category("GameParserFixture: Negative")]
        public void Should_Not_Have_Sum_Of_Two_Bonus_Balls_Greater_Than_Ten()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|5/||88";
            var sut = new GameParser();

            Action act = () =>
            {
                sut.GenerateScoreBoard(bowlingGameStats);
            };

            act.Should().Throw<InvalidGameInputException>()
                .WithMessage($"Invalid game input {bowlingGameStats}");
        }
    }
}
