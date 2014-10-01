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

        public static int OverTileX, OverTileY;
        public static MouseState _mouse;
        public static Rectangle hitbox;
        public static Object OverObject;

        public static void Update(MouseState mouse, GraphicsDeviceManager graphics)
        {
            _mouse = mouse;
            if (mouse.X >= 0 && mouse.X <= graphics.PreferredBackBufferWidth 
                && mouse.Y >= 0 && mouse.Y <= graphics.PreferredBackBufferHeight
                && (int)Math.Floor((mouse.X + Camera.position.X) / Settings.Tile.Width) < Settings.Map.Width
                && (int)Math.Floor((mouse.Y + Camera.position.Y) / Settings.Tile.Height) < Settings.Map.Height)
            {
                OverTileY = (int)Math.Floor(((float)mouse.Y + Camera.position.Y) / Settings.Tile.Height);
                OverTileX = (int)Math.Floor(((float)mouse.X + Camera.position.X) / Settings.Tile.Width);
                hitbox = new Rectangle((int)OverTileX * Settings.Tile.Width, (int)OverTileY * Settings.Tile.Height, Settings.Tile.Width, Settings.Tile.Height);
                OverObject = Map.TableObject[(int)OverTileX, (int)OverTileY];

                if (mouse.RightButton == ButtonState.Pressed)
                {
                    Map.TableObject[(int)OverTileX, (int)OverTileY] = new Object(1);
                }

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    Map.TableObject[(int)OverTileX, (int)OverTileY].life -= 1;
                    if (Map.TableObject[(int)OverTileX, (int)OverTileY].life <= 0 && Map.TableObject[(int)OverTileX, (int)OverTileY].id != 64)
                    {
                        Map.TableObject[(int)OverTileX, (int)OverTileY] = new Object(64);
                    }
                }

            }
            else
            {
                OverTileY = -1;
                OverTileX = -1;
                OverObject = null;
            }



        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (OverTileX != -1 && OverTileY != -1)
            {
                spriteBatch.Draw(Resources.select, new Vector2(((float)OverTileX * Settings.Tile.Width) - Camera.position.X,
                    ((float)OverTileY * Settings.Tile.Height) - Camera.position.Y),
                    Color.White);
                
            }
            spriteBatch.Draw(Resources.cursor, new Vector2(_mouse.X, _mouse.Y), Settings.Cursor.color);
        }
    }
}
