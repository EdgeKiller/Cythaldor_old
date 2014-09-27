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
    public static class Cursor
    {

        public static int? OverTileX, OverTileY;
        public static MouseState _mouse;

        public static void Update(MouseState mouse, GraphicsDeviceManager graphics)
        {
            _mouse = mouse;
            if (mouse.X >= 0 && mouse.X <= graphics.PreferredBackBufferWidth && mouse.Y >= 0 && mouse.Y <= graphics.PreferredBackBufferHeight)
            {
                OverTileY = (int)Math.Floor(((float)mouse.Y + Camera.position.Y) / Settings.Tile.Height);
                OverTileX = (int)Math.Floor(((float)mouse.X + Camera.position.X) / Settings.Tile.Width);
            }
            else
            {
                OverTileY = null;
                OverTileX = null;
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (OverTileX != null && OverTileY != null)
            {
                spriteBatch.Draw(Resources.select, new Vector2(((float)OverTileX * Settings.Tile.Width) - Camera.position.X,
                    ((float)OverTileY * Settings.Tile.Height) - Camera.position.Y),
                    Color.White);
                spriteBatch.Draw(Resources.cursor, new Vector2(_mouse.X, _mouse.Y), Color.White);
            }
        }
    }
}
