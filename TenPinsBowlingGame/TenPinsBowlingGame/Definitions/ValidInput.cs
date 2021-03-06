﻿namespace TenPinsBowlingGame.Definitions
{
    public class ValidInput
    {
        public static string ValidFirstOfTwoThrows => "123456789-";
        public static string ValidSecondOfTwoThrows => "123456789-/";
        public static string ValidFirstBonus => "123456789-x";
        public static string ValidSecondBonus => "123456789-/x";
        public static string StrikeFrame => "x";
        public static string EmptyFrame => "";
        public static char Spare => '/';
        public static char FrameSeparator => '|';
        public static int StrikeFrameLength => 1;
        public static int NoneStrikeFrameLength => 2;
        public static int EmptyFrameLength => 0;
    }
}
