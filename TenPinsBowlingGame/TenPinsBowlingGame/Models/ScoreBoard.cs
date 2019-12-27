using System.Collections.Generic;
using TenPinsBowlingGame.Definitions;
using TenPinsBowlingGame.Processors;

namespace TenPinsBowlingGame.Models
{
    public class ScoreBoard
    {
        private readonly Frame[] _frames;

        public IEnumerable<Frame> Frames => _frames;

        public ScoreBoard(string gameInfo)
        {
            var gameParser = new GameParser();
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
