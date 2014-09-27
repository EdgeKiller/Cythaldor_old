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
        

        public GameMain()
        {
            map = new Map();
 
        }

        public void Update(KeyboardState keyboard, MouseState mouse, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            Camera.Update(keyboard);
            Cursor.Update(mouse, graphics);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            map.Draw(spriteBatch);

            Cursor.Draw(spriteBatch);


            spriteBatch.DrawString(Resources.font1, "X : " + Cursor.OverTileX, Vector2.Zero, Color.White);
            spriteBatch.DrawString(Resources.font1, "Y : " + Cursor.OverTileY, new Vector2(0, 15), Color.White);
            spriteBatch.End();

        }



    }
}
