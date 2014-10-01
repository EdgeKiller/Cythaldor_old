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
        GUI gui;

        public GameMain()
        {
            map = new Map();
            gui = new GUI();
        }

        public void Update(KeyboardState keyboard, MouseState mouse, GameTime gameTime, GraphicsDeviceManager graphics)
        {
            Camera.Update(keyboard, gameTime);
            Cursor.Update(mouse, graphics);
            gui.Update(mouse, keyboard);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
            map.Draw(spriteBatch);
            gui.Draw(spriteBatch);


            Cursor.Draw(spriteBatch);

            if (Settings.Window.ShowGameInfos)
            {
                spriteBatch.DrawString(Resources.font1, "TILE X : " + Cursor.OverTileX, Vector2.Zero, Color.White);
                spriteBatch.DrawString(Resources.font1, "TILE Y : " + Cursor.OverTileY, new Vector2(0, 15), Color.White);
                if (Cursor.OverTileX != -1 && Cursor.OverTileY != -1)
                {
                    spriteBatch.DrawString(Resources.font1, "TERRAIN ID : " + Map.TableGround[(int)Cursor.OverTileX, (int)Cursor.OverTileY].ToString(), new Vector2(0, 30), Color.White);
                }
                if (Cursor.OverObject != null && Cursor.OverObject.id != 64)
                {
                    spriteBatch.DrawString(Resources.font1, "OBJ ID : " + Cursor.OverObject.id + " LIFE : " + Cursor.OverObject.life, new Vector2(0, 45), Color.White);
                }
                spriteBatch.DrawString(Resources.font1, "MOUSE X : " + Cursor._mouse.X, new Vector2(0, 60), Color.White);
                spriteBatch.DrawString(Resources.font1, "MOUSE Y : " + Cursor._mouse.Y, new Vector2(0, 75), Color.White);
                spriteBatch.DrawString(Resources.font1, "CAMERA X : " + Camera.position.X, new Vector2(0, 90), Color.White);
                spriteBatch.DrawString(Resources.font1, "CAMERA Y : " + Camera.position.Y, new Vector2(0, 105), Color.White);
                spriteBatch.DrawString(Resources.font1, "SEED : " + Map.seed.ToString(), new Vector2(0, 120), Color.White);
            }

            spriteBatch.End();

        }



    }
}
