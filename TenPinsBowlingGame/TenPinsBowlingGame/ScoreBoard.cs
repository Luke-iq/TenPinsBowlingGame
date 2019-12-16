using TenPinsBowlingGame.Definitions;

namespace TenPinsBowlingGame
{
    public class ScoreBoard : GameParser
    {
        public Frame[] Frames;

        public ScoreBoard(string gameInfo)
        {
            Frames = ParseGameInfo(gameInfo);
        }

        public ScoreResult GetCurrentScores()
        {
            var result = new ScoreResult();

            foreach (var frame in Frames)
            {
                var frameScore = frame.CurrentFrameScore();
                result.ScoreType = frameScore.ScoreType == ScoreStatus.Final ? ScoreStatus.Final : ScoreStatus.Temporary;
                result.Score += frameScore.Score;
            }

            return result;
        }
    }
}
