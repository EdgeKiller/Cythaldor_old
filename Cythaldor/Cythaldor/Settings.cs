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


        //CAMERA


        //TILE
        public static int TileHeight = 32;
        public static int TileWidth = 32;

        //WINDOWS GAME
        public static bool MouseVisible = true;
        public static bool FullScreen = false;
        //public static int WindowHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        //public static int WindowWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static int WindowHeight = 600;
        public static int WindowWidth = 800;
        public static string GameVersion = "inDev 0.0.1";
        public static string GameCreator = "EdgeKiller";
        public static string GameName = "Cythaldor";

    }
}
