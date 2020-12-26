using System.Collections.Generic;

namespace MinecraftBlockColor
{
    public class Color 
    {
        public string name;
        public byte r, g, b;

        public Color(string _name, byte _r, byte _g, byte _b) {
            name = _name;
            r = _r;
            g = _g;
            b = _b;
        }
    }
}