using System.Collections.Generic;
using TenPinsBowlingGame.Definitions;
using TenPinsBowlingGame.Processors;

namespace TenPinsBowlingGame.Models
{
    public class ScoreBoard
    {
        private readonly Frame[] _frames;

        public IEnumerable<Frame> Frames => _frames;

        public ScoreBoard() => _frames = new Frame[InputIndex.NumberOfFramesInBowlingGame];
        public ScoreBoard(string gameInfo, GameParser gameParser)
        {
            _frames = gameParser.GenerateScoreBoard(gameInfo);
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
