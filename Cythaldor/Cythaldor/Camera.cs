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
    public static class Camera
    {

        public static Vector2 position = Vector2.Zero;

        public static void Update(KeyboardState keyboard)
        {
            if(keyboard.IsKeyDown(Settings.Key.CameraUp))
            {
                position.Y -= Settings.Camera.Speed;
            }
            if (keyboard.IsKeyDown(Settings.Key.CameraDown))
            {
                position.Y += Settings.Camera.Speed;
            }
            if (keyboard.IsKeyDown(Settings.Key.CameraLeft))
            {
                position.X -= Settings.Camera.Speed;
            }
            if (keyboard.IsKeyDown(Settings.Key.CameraRight))
            {
                position.X += Settings.Camera.Speed;
            }

            if (position.X < 0)
                position.X += Settings.Camera.Speed;
            if (position.Y < 0)
                position.Y += Settings.Camera.Speed;

            
            if((int)Math.Floor((position.X + Settings.Window.Width) / Settings.Tile.Width) >= Map.TilesGround.GetLength(0))
            {
                if(Settings.Window.Width <= Map.TilesGround.GetLength(0) * Settings.Tile.Width)
                    position.X -= Settings.Camera.Speed;
                else
                    position.X = 0;
                    
            }
            
            if ((int)Math.Floor((position.Y + Settings.Window.Height) / Settings.Tile.Height) >= Map.TilesGround.GetLength(1))
            {
                if (Settings.Window.Height <= Map.TilesGround.GetLength(1) * Settings.Tile.Height)
                    position.Y -= Settings.Camera.Speed;
                else
                    position.Y = 0;
            }


        }

    }
}
