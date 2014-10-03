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
        public static bool CollideBox = false;

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

            bool collideBox = false;
            foreach (Box box in GUI.buttons)
            {
                if(new Rectangle(_mouse.X, _mouse.Y, 1, 1).Intersects(box.rectangle))
                {
                    collideBox = true;
                    CollideBox = true;
                    break;
                }
                else
                {
                    collideBox = false;
                    CollideBox = false;
                }
            }


        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(Resources.cursor, new Vector2(_mouse.X, _mouse.Y), Settings.Cursor.color);
        }
    }
}
