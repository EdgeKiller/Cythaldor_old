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
        public static Rectangle hitbox;
        public static Object OverObject;

        public static void Update(MouseState mouse, GraphicsDeviceManager graphics)
        {
            _mouse = mouse;
            if (mouse.X >= 0 && mouse.X <= graphics.PreferredBackBufferWidth && mouse.Y >= 0 && mouse.Y <= graphics.PreferredBackBufferHeight)
            {
                OverTileY = (int)Math.Floor(((float)mouse.Y + Camera.position.Y) / Settings.Tile.Height);
                OverTileX = (int)Math.Floor(((float)mouse.X + Camera.position.X) / Settings.Tile.Width);
                hitbox = new Rectangle((int)OverTileX * Settings.Tile.Width, (int)OverTileY * Settings.Tile.Height, Settings.Tile.Width, Settings.Tile.Height);
            }
            else
            {
                OverTileY = null;
                OverTileX = null;
            }

            foreach(Object _object in Map.ObjectsTile)
            {
                Rectangle objectRec = new Rectangle((int)_object.position.X * Settings.Tile.Width, (int)_object.position.Y * Settings.Tile.Height,
                    Settings.Tile.Width, Settings.Tile.Height);
                if (hitbox.Intersects(objectRec))
                {
                    OverObject = _object;
                    break;
                }
                else
                    OverObject = null;
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
