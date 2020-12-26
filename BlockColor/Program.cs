﻿using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using BlockColor;
using System.Windows;
using System;
using System.Threading.Tasks;

namespace MinecraftBlockColor
{
    static class Program
    {
        internal static void GeneratePixelArt(string imagePath, string dataPackPath)
        {
            try
            {
                Bitmap img = new Bitmap(Bitmap.FromFile(@imagePath));
                for (int i = 0; i < img.Width; i++)
                {
                    for (int j = 0; j < img.Height; j++)
                    {
                        System.Drawing.Color pixel = img.GetPixel(i,j);
                        commands.Add(new SetBlock(Block(pixel.R,pixel.G,pixel.B), i, j).Command);
                    }
                }
                System.IO.File.WriteAllLines(@dataPackPath + "\\file.mcfunction", commands);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                throw;
            }
        }

        public static string Block(byte _r, byte _g, byte _b)
        {
            string lowestColorName = "nothing";
            int lowestColorDistance = int.MaxValue;
            int actualColorDistance;
            
            Color myColor = new Color("", _r, _g, _b);
            for (int i = 0; i != colors.Count; i++)
            {
                actualColorDistance = Distance(myColor, colors[i]);
                if (actualColorDistance < lowestColorDistance)
                {
                    lowestColorDistance = actualColorDistance;
                    lowestColorName = colors[i].name;
                }
            }
            return lowestColorName;
        }
        
        public static int Distance(Color current, Color possible)
        {
            int difR = Math.Abs(possible.r - current.r);
            int difG = Math.Abs(possible.g - current.g);
            int difB = Math.Abs(possible.b - current.b);
            return difR + difG + difB;
        }

        private static List<string> commands = new List<string>();
        private static List<Color> colors = new List<Color>()
        {
            new Color("white_concrete", 209, 215, 216),
            new Color("orange_concrete", 224, 96, 0),
            new Color("magenta_concrete", 170, 45, 160),
            new Color("light_blue_concrete", 31, 139, 201),
            new Color("yellow_concrete", 240, 175, 13),
            new Color("lime_concrete", 93, 169, 16),
            new Color("pink_concrete", 214, 100, 143),
            new Color("gray_concrete", 52, 56, 60),
            new Color("light_gray_concrete", 125, 125, 125),
            new Color("cyan_concrete", 13, 119, 136),
            new Color("purple_concrete", 101, 26, 156),
            new Color("blue_concrete", 41, 43, 145),
            new Color("brown_concrete", 95, 57, 25),
            new Color("green_concrete", 72, 91, 31),
            new Color("red_concrete", 144, 29, 29),
            new Color("black_concrete", 21, 24, 28)
        };
    }
}
