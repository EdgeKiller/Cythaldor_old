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
using System.IO;

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
            public static bool MouseVisible = false;
            public static bool FullScreen = false;
            //public static int Height = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //public static int Width = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            public static int Height = 600;
            public static int Width = 800;
            public static string GameVersion = "inDev 0.0.1";
            public static string GameCreator = "EdgeKiller";
            public static string GameName = "Cythaldor";
        }
       
        //KEYS FROM CONFIG FILE
        public static class Key
        {
            public static Dictionary<string, Keys> KeysDic = new Dictionary<string, Keys>()
            {
                {"KEY_UP", Keys.Up}, {"KEY_DOWN", Keys.Down}, {"KEY_LEFT", Keys.Left}, {"KEY_RIGHT", Keys.Right},
                {"KEY_A", Keys.A}, {"KEY_B", Keys.B}, {"KEY_C", Keys.C}, {"KEY_D", Keys.D}, {"KEY_E", Keys.E},
                {"KEY_F", Keys.F}, {"KEY_G", Keys.G}, {"KEY_H", Keys.H}, {"KEY_I", Keys.I}, {"KEY_J", Keys.J}, 
                {"KEY_K", Keys.K}, {"KEY_L", Keys.L}, {"KEY_M", Keys.M}, {"KEY_N", Keys.N}, {"KEY_O", Keys.O}, 
                {"KEY_P", Keys.P}, {"KEY_Q", Keys.Q}, {"KEY_R", Keys.R}, {"KEY_S", Keys.S}, {"KEY_T", Keys.T}, 
                {"KEY_U", Keys.U}, {"KEY_V", Keys.V}, {"KEY_W", Keys.W}, {"KEY_X", Keys.X}, {"KEY_Y", Keys.Y}, 
                {"KEY_Z", Keys.Z}
            };
            
            //CAMERA KEYS
            public static Keys CameraUp = KeysDic[ReadFromConfig("CAMERA_KEY_UP")];
            public static Keys CameraDown = KeysDic[ReadFromConfig("CAMERA_KEY_DOWN")];
            public static Keys CameraLeft = KeysDic[ReadFromConfig("CAMERA_KEY_LEFT")];
            public static Keys CameraRight = KeysDic[ReadFromConfig("CAMERA_KEY_RIGHT")];
            
            
            
        }

        //READ SOMETHING FROM CONFIG FILE : "config.cfg"
        static public string ReadFromConfig(string Param)
        {
            StreamReader sr = new StreamReader("config.cfg");
            string line;
            string result = "";
            while((line = sr.ReadLine()) != null)
            {
                if(line.StartsWith(Param))
                {
                    result = line.Split('=')[1];
                }
            }
            return result;
        }



    }
}
