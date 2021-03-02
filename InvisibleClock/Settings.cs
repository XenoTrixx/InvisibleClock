using System;
using System.Collections.Generic;
using System.Text;

namespace InvisibleClock.ApplicationSettings
{
    public class Window
    {
        public bool TransparentBackground { get; set; }
        public string BackgroundColor { get; set; }
        public bool IsForeGround { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

    }

    public class Position
    {
        public bool Standard { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }

    }

    public class Font
    {
        public string Color { get; set; }
        public int Size { get; set; }
        public string Family { get; set; }

    }

    public class Time
    {
        public int Interval { get; set; }
        public string Format { get; set; }
    }

    public class Settings
    {
        public Window Window { get; set; }
        public Position Position { get; set; }
        public Font Font { get; set; }
        public Time Time { get; set; }

    }
}
