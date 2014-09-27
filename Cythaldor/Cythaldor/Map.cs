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
    public class Map
    {
        static public int[,] TilesGround;


        public Map()
        {
           TilesGround = new int[Settings.Map.Width,Settings.Map.Height];
           RandomMap();
        }


        public void RandomMap()
        {
            Random rand = new Random();
            for (int y = 0; y < TilesGround.GetLength(1); y++)
            {
                for (int x = 0; x < TilesGround.GetLength(0); x++)
                {
                    TilesGround[x, y] = rand.Next(0, 3);
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < TilesGround.GetLength(1); y++)
            {
                for (int x = 0; x < TilesGround.GetLength(0); x++)
                {
                    if ((x * Settings.Tile.Width - Camera.position.X) < Settings.Window.Width &&
                        (y * Settings.Tile.Height - Camera.position.Y) < Settings.Window.Height)
                    {
                        spriteBatch.Draw(Resources.tileset, new Vector2(x * Settings.Tile.Width - Camera.position.X, 
                            y * Settings.Tile.Height - Camera.position.Y),
                        new Rectangle(TilesGround[y, x] * Settings.Tile.Width, 0, Settings.Tile.Width, Settings.Tile.Height), Color.White);
                    }

                    
                }
            }
                
        }

    }
}
