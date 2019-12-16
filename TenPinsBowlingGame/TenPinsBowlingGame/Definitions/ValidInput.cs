namespace TenPinsBowlingGame.Definitions
{
    public class ValidInput
    {
        public static string ValidFirstOfTwoThrows => "123456789-";
        public static string ValidSecondOfTwoThrows => "123456789-/";
        public static string ValidFirstBonus => "123456789-x";
        public static string ValidSecondBonus => "123456789-/x";
        public static string StrikeFrame => "x";
        public static char Strike => 'x';
        public static char Spare => '/';
        public static char FrameSeparator => '|';
    }
}
