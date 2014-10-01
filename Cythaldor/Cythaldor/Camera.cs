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

        public static void Update(KeyboardState keyboard, GameTime gameTime)
        {
            int speed = Settings.Camera.Speed + (int)gameTime.ElapsedGameTime.TotalMilliseconds / 8;
            if (keyboard.IsKeyDown(Settings.Key.CameraUp))
            {
                position.Y -= speed;
            }
            if (keyboard.IsKeyDown(Settings.Key.CameraDown))
            {
                position.Y += speed;
            }
            if (keyboard.IsKeyDown(Settings.Key.CameraLeft))
            {
                position.X -= speed;
            }
            if (keyboard.IsKeyDown(Settings.Key.CameraRight))
            {
                position.X += speed;
            }

            if (position.X < 0)
                position.X += speed;
            if (position.Y < 0)
                position.Y += speed;


            
            if((int)Math.Floor((position.X + Settings.Window.Width) / Settings.Tile.Width) >= Map.TableGround.GetLength(0))
            {
                if(Settings.Window.Width <= Map.TableGround.GetLength(0) * Settings.Tile.Width)
                    position.X -= speed;
                else
                    position.X = 0;
                    
            }
            
            if ((int)Math.Floor((position.Y + Settings.Window.Height) / Settings.Tile.Height) >= Map.TableGround.GetLength(1))
            {
                if (Settings.Window.Height <= Map.TableGround.GetLength(1) * Settings.Tile.Height)
                    position.Y -= speed;
                else
                    position.Y = 0;
            }


        }

    }
}
