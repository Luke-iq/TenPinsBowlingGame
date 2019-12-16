using System.Collections.Generic;

namespace TenPinsBowlingGame.Definitions
{
    public static class ConvertCharInput
    {
        public static readonly Dictionary<char, int> ToInt = new Dictionary<char, int>()
        {
            {'-', 0 },
            {'1', 1 },
            {'2', 2 },
            {'3', 3 },
            {'4', 4 },
            {'5', 5 },
            {'6', 6 },
            {'7', 7 },
            {'8', 8 },
            {'9', 9 },
            {'x', 10 },
            {'X', 10 }
        };
    }
}
