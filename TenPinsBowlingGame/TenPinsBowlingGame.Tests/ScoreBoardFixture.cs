using NUnit.Framework;
using FluentAssertions;

namespace TenPinsBowlingGame.Tests
{
    public class ScoreBoardFixture
    {
        [Test]
        [Category("ScoreBoardFixture: Positive")]
        public void Should_Add_All_Numbers_From_Each_Frame()
        {
            const string bowlingGameStats = "11|22|33|44|11|22|33|44|11|22||";

            var sut = new ScoreBoard(bowlingGameStats);

            sut.GetCurrentScores().Score.Should().Be(46);
        }

        [Test]
        [Category("ScoreBoardFixture: Positive")]
        public void Should_Add_Next_Two_Balls_From_Next_Frame_For_Strike_Frame()
        {
            const string bowlingGameStats = "X|22|1-|--|--|--|--|--|--|--||";

            var sut = new ScoreBoard(bowlingGameStats);

            sut.GetCurrentScores().Score.Should().Be(19);
        }

        [Test]
        [Category("ScoreBoardFixture: Positive")]
        public void Should_Add_Next_Two_Balls_From_Next_Two_Frames_For_Strike_Frame()
        {
            const string bowlingGameStats = "X|X|21|--|--|--|--|--|--|--||";

            var sut = new ScoreBoard(bowlingGameStats);

            sut.GetCurrentScores().Score.Should().Be(38);
        }

        [Test]
        [Category("ScoreBoardFixture: Positive")]
        public void Should_Add_Next_Ball_For_Spare_Frame()
        {
            const string bowlingGameStats = "5/|21|--|--|--|--|--|--|--|--||";

            var sut = new ScoreBoard(bowlingGameStats);

            sut.GetCurrentScores().Score.Should().Be(15);
        }

        [Test]
        [Category("ScoreBoardFixture: Positive")]
        public void Should_Add_Next_Two_Bonus_Balls_For_Strike_On_Frame_Ten()
        {
            const string bowlingGameStats = "--|--|--|--|--|--|--|--|--|X||22";

            var sut = new ScoreBoard(bowlingGameStats);

            sut.GetCurrentScores().Score.Should().Be(14);
        }

        [Test]
        [Category("ScoreBoardFixture: Positive")]
        public void Should_Add_Next_Bonus_Ball_For_Spare_On_Frame_Ten()
        {
            const string bowlingGameStats = "--|--|--|--|--|--|--|--|--|8/||2";

            var sut = new ScoreBoard(bowlingGameStats);

            sut.GetCurrentScores().Score.Should().Be(12);
        }

        [Test]
        [Category("ScoreBoardFixture: Positive")]
        public void Should_Compute_Perfect_Game()
        {
            const string bowlingGameStats = "X|X|X|X|X|X|X|X|X|X||XX";

            var sut = new ScoreBoard(bowlingGameStats);

            sut.GetCurrentScores().Score.Should().Be(300);
        }

        [Test]
        [Category("ScoreBoardFixture: Positive")]
        public void Should_Compute_All_Spare_Game()
        {
            const string bowlingGameStats = "5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5";

            var sut = new ScoreBoard(bowlingGameStats);

            sut.GetCurrentScores().Score.Should().Be(150);
        }

        [Test]
        [Category("ScoreBoardFixture: Positive")]
        public void Should_Compute_All_Nine_Pins_Game()
        {
            const string bowlingGameStats = "9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||";

            var sut = new ScoreBoard(bowlingGameStats);

            sut.GetCurrentScores().Score.Should().Be(90);
        }

        [Test]
        [Category("ScoreBoardFixture: Positive")]
        public void Should_Compute_Random_Game()
        {
            const string bowlingGameStats = "X|7/|9-|X|-8|8/|-6|X|X|X||81";

            var sut = new ScoreBoard(bowlingGameStats);

            sut.GetCurrentScores().Score.Should().Be(167);
        }
    }
}