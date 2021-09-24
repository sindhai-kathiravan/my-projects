using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPhoneSystem
{
    static public class Constants
    {
        static public class Forms
        {
            public const string MainForm = "MainForm";
            public const string HomeForm = "HomeForm";
            public const string DirectoryForm = "DirectoryForm";
            public const string PinForm = "PinForm";
            public const string DirectionForm = "DirectionForm";
            public const string ScanForm = "ScanForm";
            public const string CallForm = "CallForm";
            public const string HelpForm = "HelpForm";
        }

        static public class Controls
        {
            public const string lblNextForm = "lblNextForm";
            public const string pnlTop = "pnlTop";
            
        }
        static public class Weather
        {
            public const string Thunderstorm = "Thunderstorm";
            public const string Drizzle = "Drizzle";
            public const string Rain = "Rain";
            public const string Snow = "Snow";
            public const string Clear = "Clear";
            public const string Clouds = "Clouds";
            public const string Sunny = "Sunny";


        }

        static public class AspectRatio
        {
            public const double FROM_WIDTH_TO_HEIGHT = 1.77777777778;//16
            public const double FROM_HEIGHT_TO_WIDTH = 0.5625;//9

            public const double HEIGHT = 1920;
            public const double WIDTH = 1080;
        }
    }

    
}
