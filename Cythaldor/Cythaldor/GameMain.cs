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
    class GameMain
    {

        Map map;
        public static int? CursorOverTileX, CursorOverTileY;

        public GameMain()
        {
            map = new Map();
 
        }

        public void Update(KeyboardState keyboard, MouseState mouse, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            Camera.Update(keyboard);
            if (mouse.X >= 0 && mouse.X <= graphics.PreferredBackBufferWidth && mouse.Y >= 0 && mouse.Y <= graphics.PreferredBackBufferHeight)
            {
                CursorOverTileY = (int)Math.Floor(((float)mouse.Y + Camera.position.Y) / Settings.Tile.Height);
                CursorOverTileX = (int)Math.Floor(((float)mouse.X + Camera.position.X) / Settings.Tile.Width);
            }
            else
            {
                CursorOverTileY = null;
                CursorOverTileX = null;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            map.Draw(spriteBatch);

            if(CursorOverTileX != null && CursorOverTileY != null)
            {
                spriteBatch.Draw(Resources.select, new Vector2(((float)CursorOverTileX * Settings.Tile.Width) - Camera.position.X,
                    ((float)CursorOverTileY * Settings.Tile.Height) - Camera.position.Y),
                    Color.White);
            }


            spriteBatch.DrawString(Resources.font1, "X : " + CursorOverTileX, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Resources.font1, "Y : " + CursorOverTileY, new Vector2(0, 15), Color.White);
            spriteBatch.End();

        }



    }
}
