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
        public static Object[,] TilesObject;

        public Map()
        {
            TilesGround = new int[Settings.Map.Width, Settings.Map.Height];
            TilesObject = new Object[Settings.Map.Width, Settings.Map.Height];
            InitObjectTile();
            RandomMap();
            //TilesObject[4, 4] = new Object(1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = (int)Math.Floor(Camera.position.Y / Settings.Tile.Height);
                y < (int)Math.Floor(Camera.position.Y / Settings.Tile.Height) + 
                (int)Math.Floor((float)Settings.Window.Height / Settings.Tile.Height) + Settings.Tile.Height * 5 && y < TilesGround.GetLength(1); y++)
            {
                for (int x = (int)Math.Floor(Camera.position.X / Settings.Tile.Width);
                    x < (int)Math.Floor(Camera.position.X / Settings.Tile.Width) +
                    (int)Math.Floor((float)Settings.Window.Width / Settings.Tile.Width) + Settings.Tile.Width * 5 && x < TilesGround.GetLength(0); x++)
                {
                    spriteBatch.Draw(Resources.tileset, new Vector2(x * Settings.Tile.Width - Camera.position.X,
                        y * Settings.Tile.Height - Camera.position.Y), GetSourceRectangle(TilesGround[x, y]), Color.White);

                    if (TilesObject[x, y].id != 64)
                    {
                        spriteBatch.Draw(Resources.objects, new Vector2(x * Settings.Tile.Width - Camera.position.X,
                           y * Settings.Tile.Height - Camera.position.Y), GetSourceRectangle(TilesObject[x, y].id), Color.White);
                    }
                }
            }
        }

        public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (Resources.tileset.Width / Settings.Tile.Width);
            int tileX = tileIndex % (Resources.tileset.Width / Settings.Tile.Width);
            return new Rectangle(tileX * Settings.Tile.Width, tileY * Settings.Tile.Height, Settings.Tile.Width, Settings.Tile.Height);
        }

        //CREATE A RANDOM MAP
        public void RandomMap()
        {
            Random rand = new Random();
            for (int y = 0; y < TilesGround.GetLength(1); y++)
                for (int x = 0; x < TilesGround.GetLength(0); x++)
                    TilesGround[x, y] = rand.Next(0, 6);
        }

        //SET ALL OBJECT'S ID TO 64
        public void InitObjectTile()
        {
            for (int y = 0; y < TilesObject.GetLength(1); y++)
                for (int x = 0; x < TilesObject.GetLength(0); x++)
                    TilesObject[x, y] = new Object(64);
        }



    }
}
