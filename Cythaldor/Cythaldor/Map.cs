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

        public static int[,] TableGround; //THE MAP TABLE (GRASS/SAND...)
        public static Object[,] TableObject; //THE OBJECT TABLE (TREE/ROCK...)
        public static int seed; //SEED OF THE MAP
        public static Random rand = new Random();


        public Map()
        {
            seed = rand.Next(0, 5000000);
            TableGround = new int[Settings.Map.Width, Settings.Map.Height];
            TableObject = new Object[Settings.Map.Width, Settings.Map.Height];
            InitObjectTile();
            GenerateMap(seed);
        }

        //DRAW THE MAP (GROUND + OBJECT)
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = (int)Math.Floor(Camera.position.Y / Settings.Tile.Height);
                y < (int)Math.Floor(Camera.position.Y / Settings.Tile.Height) + 
                (int)Math.Floor((float)Settings.Window.Height / Settings.Tile.Height) + Settings.Tile.Height && y < TableGround.GetLength(1); y++)
            {
                for (int x = (int)Math.Floor(Camera.position.X / Settings.Tile.Width);
                    x < (int)Math.Floor(Camera.position.X / Settings.Tile.Width) +
                    (int)Math.Floor((float)Settings.Window.Width / Settings.Tile.Width) + Settings.Tile.Width && x < TableGround.GetLength(0); x++)
                {
                    spriteBatch.Draw(Resources.tileset, new Vector2(x * Settings.Tile.Width - Camera.position.X,
                        y * Settings.Tile.Height - Camera.position.Y), GetSourceRectangle(TableGround[x, y]), Color.White);

                    if (TableObject[x, y].id != 64)
                        spriteBatch.Draw(Resources.objects, new Vector2(x * Settings.Tile.Width - Camera.position.X,
                           y * Settings.Tile.Height - Camera.position.Y), GetSourceRectangle(TableObject[x, y].id), Color.White);
                }
            }
        }

        //GET THE SOURCE RECTANGLE FROM THE TILESET TEXTURE
        public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (Resources.tileset.Height / Settings.Tile.Height);
            int tileX = tileIndex % (Resources.tileset.Width / Settings.Tile.Width);
            return new Rectangle(tileX * Settings.Tile.Width, tileY * Settings.Tile.Height, Settings.Tile.Width, Settings.Tile.Height);
        }

        //GENERATE MAP WITH PERLIN NOISE'S ALGORITHM
        public void GenerateMap(int seed)
        {
            int _seed;
            _seed = seed;
            for (int x = 0; x < Settings.Map.Height; x++)
            {
                for (int y = 0; y < Settings.Map.Width; y++)
                {
                    float octave1 = PerlinSimplexNoise.noise((x * 9 + seed) * 0.0001f, (y * 9 + seed) * 0.0001f);
                    float octave2 = PerlinSimplexNoise.noise((x * 9 + seed) * 0.0005f, (y * 9 + seed) * 0.0005f);
                    float octave3 = PerlinSimplexNoise.noise((x * 9 + seed) * 0.005f, (y * 9 + seed) * 0.005f);
                    float octave4 = PerlinSimplexNoise.noise((x * 9 + seed) * 0.005f, (y * 9 + seed) * 0.005f) * 20f;
                    float octave5 = PerlinSimplexNoise.noise((x * 9 + seed) * 0.003f, (y * 9 + seed) * 0.003f) * 5f;
                    float finalNumber = octave1 + octave2 + octave3 + octave4 + octave5 + octave1;
                    if (finalNumber <= 30 && finalNumber >= 20) // final number 30 - 20
                    {
                        TableGround[x, y] = 6;
                    }
                    else if (finalNumber < 20 && finalNumber > 18) // 19 - 16
                    {
                        TableGround[x, y] = 5;
                    }
                    else if (finalNumber <= 13 && finalNumber >= 8) // 15 - 9
                    {
                        TableObject[x, y] = new Object(0);
                        TableGround[x, y] = 0;
                    }
                    else if (finalNumber <= 8 && finalNumber >= 0) // 8 - 0
                    {
                        TableObject[x, y] = new Object(1);
                        TableGround[x, y] = 0;
                    }
                    else
                    {
                        //TilesObject[x, y] = new Object(8);
                        TableGround[x, y] = 0;
                    }
                }
            }
            BlendGrass();
        }

        //BLEND GRASS TILE
        public void BlendGrass()
        {
            Random rnd = new Random();
            for (int x = 0; x < Settings.Map.Height; x++)
            {
                for (int y = 0; y < Settings.Map.Width; y++)
                {
                    int ActuTile = rnd.Next(0, 9);
                    int finaltile = 1;
                    if (ActuTile == 0 || ActuTile == 1 || ActuTile == 2 || ActuTile == 3 || ActuTile == 7 || ActuTile == 8)
                        finaltile = 0;
                    if (ActuTile == 4 || ActuTile == 5)
                        finaltile = 1;
                    if (ActuTile == 6)
                        finaltile = 1;
                    if (TableGround[x, y] == 0)
                        TableGround[x,y] = finaltile;
                }
            }
        }

        //SET ALL OBJECT'S ID TO 64
        public void InitObjectTile()
        {
            for (int y = 0; y < TableObject.GetLength(1); y++)
                for (int x = 0; x < TableObject.GetLength(0); x++)
                    TableObject[x, y] = new Object(64);
        }



    }
}
