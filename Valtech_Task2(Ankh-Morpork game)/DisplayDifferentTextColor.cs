using System;

namespace Valtech_Task2_Ankh_Morpork_game_.Service
{
    public static class DisplayDifferentTextColor
    {
        public static void DisplayRedColorText(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DisplayGreenColorText(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DisplayBlueColorText(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
