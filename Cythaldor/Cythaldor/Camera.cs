﻿using System;
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
            if(keyboard.IsKeyDown(Keys.Z))
            {
                position.Y -= Settings.Camera.Speed;
            }
            if (keyboard.IsKeyDown(Keys.S))
            {
                position.Y += Settings.Camera.Speed;
            }
            if (keyboard.IsKeyDown(Keys.Q))
            {
                position.X -= Settings.Camera.Speed;
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                position.X += Settings.Camera.Speed;
            }

            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;

        }

    }
}
