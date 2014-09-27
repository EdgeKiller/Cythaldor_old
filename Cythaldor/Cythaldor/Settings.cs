using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Cythaldor
{
    public static class Settings
    {
        //MAP
        public static class Map
        {
            public static int Height = 1000;
            public static int Width = 1000;
        }
        
        //CAMERA
        public static class Camera
        {
            public static int Speed = 4;
        }

        //TILE
        public static class Tile
        {
            public static int Height = 32;
            public static int Width = 32;
        }
       
        //WINDOWS GAME
        public static class Window
        {
            public static bool MouseVisible = true;
            public static bool FullScreen = false;
            //public static int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //public static int Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            public static int Height = 600;
            public static int Width = 800;
            public static string GameVersion = "inDev 0.0.1";
            public static string GameCreator = "EdgeKiller";
            public static string GameName = "Cythaldor";
        }
        

    }
}
