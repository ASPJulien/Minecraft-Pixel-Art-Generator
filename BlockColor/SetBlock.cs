using System.Collections.Generic;

namespace MinecraftBlockColor
{
    public class SetBlock
    {
        public string Name;
        public string Command;
        public int I;
        public int J;
        
        public SetBlock(string _name, int _i, int _j) {
            Name = _name;
            I = _i;
            J = _j;
            Command = "setblock " + "~" + I + " ~-100" + " ~" + J + " " + Name;
        }
    }
}