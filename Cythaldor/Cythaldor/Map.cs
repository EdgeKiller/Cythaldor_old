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
        public static int[,] TilesGround;
        public static List<Object> ObjectsTile = new List<Object>();


        public Map()
        {
            TilesGround = new int[Settings.Map.Width,Settings.Map.Height];
            //RandomMap();
            ObjectsTile.Add(new Tree(2, new Vector2(4,4)));
            ObjectsTile.Add(new Tree(2, new Vector2(5,4)));
            ObjectsTile.Add(new Tree(2, new Vector2(6, 4)));
            ObjectsTile.Add(new Tree(2, new Vector2(4, 5)));
            ObjectsTile.Add(new Tree(2, new Vector2(5, 5)));
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
                            y * Settings.Tile.Height - Camera.position.Y), GetSourceRectangle(TilesGround[x, y]), Color.White);
                    }
                }
            }

            foreach(Object _object in ObjectsTile)
            {
                _object.Draw(spriteBatch);
            }
        }

        public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (Resources.tileset.Width / Settings.Tile.Width);
            int tileX = tileIndex % (Resources.tileset.Width / Settings.Tile.Width);
            return new Rectangle(tileX * Settings.Tile.Width, tileY * Settings.Tile.Height, Settings.Tile.Width, Settings.Tile.Height);
        }

        public void RandomMap()
        {
            Random rand = new Random();
            for (int y = 0; y < TilesGround.GetLength(1); y++)
            {
                for (int x = 0; x < TilesGround.GetLength(0); x++)
                {
                    TilesGround[x, y] = rand.Next(0, 6);
                }
            }
        }

    }
}
