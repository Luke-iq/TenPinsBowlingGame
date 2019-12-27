using System.Collections.Generic;
using System.Linq;
using TenPinsBowlingGame.Models;

namespace TenPinsBowlingGame.Processors
{
    public class BonusHandler
    {
        private readonly Queue<Frame> _bonusTracker = new Queue<Frame>();

        public void AddFrame(Frame frame)
        {
            _bonusTracker.Enqueue(frame);
        }

        public bool ApplyBonuses(IEnumerable<int> bonusRecords)
        {
            var status = true;
            foreach (var bonus in bonusRecords)
            {
                status &= ApplyBonus(bonus);
            }
            return status;
        }

        private bool ApplyBonus(int pinsDropped)
        {
            if (_bonusTracker.Count == 0)
            {
                return false;
            }

            var originalBonusRecordsCount = _bonusTracker.Count;

            for (var frameIndex = 0; frameIndex < originalBonusRecordsCount; frameIndex++)
            {
                var currentFrame = _bonusTracker.Dequeue();
                currentFrame.AddBonus(pinsDropped);
                if ((int)currentFrame.NumberOfBonusAcquired != currentFrame.PinsDroppedOfABonusBall.Count())
                {
                    _bonusTracker.Enqueue(currentFrame);
                }
            }
            return true;
        }
    }
}
