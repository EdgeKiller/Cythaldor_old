﻿using System;
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
        public static int seed;
        public static Random rand = new Random();


        public Map()
        {
            seed = rand.Next(0, 5000000);
            TilesGround = new int[Settings.Map.Width, Settings.Map.Height];
            TilesObject = new Object[Settings.Map.Width, Settings.Map.Height];
            InitObjectTile();
            GenerateMap(seed);
            //TilesObject[4, 4] = new Object(1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = (int)Math.Floor(Camera.position.Y / Settings.Tile.Height);
                y < (int)Math.Floor(Camera.position.Y / Settings.Tile.Height) + 
                (int)Math.Floor((float)Settings.Window.Height / Settings.Tile.Height) + Settings.Tile.Height && y < TilesGround.GetLength(1); y++)
            {
                for (int x = (int)Math.Floor(Camera.position.X / Settings.Tile.Width);
                    x < (int)Math.Floor(Camera.position.X / Settings.Tile.Width) +
                    (int)Math.Floor((float)Settings.Window.Width / Settings.Tile.Width) + Settings.Tile.Width && x < TilesGround.GetLength(0); x++)
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

        //GENERATE MAP WITH PERLIN NOISE'S ALGORITHM
        public void GenerateMap(int seed)
        {
            int _seed;
            _seed = seed;
            for (int x = 0; x < Settings.Map.Height; x++)
            {
                for (int y = 0; y < Settings.Map.Width; y++)
                {
                    /* BASE VALUES
                    float octave1 = PerlinSimplexNoise.noise((x * 16 + seed) * 0.0001f, (y * 16 + seed) * 0.0001f);
                    float octave2 = PerlinSimplexNoise.noise((x * 16 + seed) * 0.0005f, (y * 16 + seed) * 0.0005f);
                    float octave3 = PerlinSimplexNoise.noise((x * 16 + seed) * 0.005f, (y * 16 + seed) * 0.005f);
                    float octave4 = PerlinSimplexNoise.noise((x * 16 + seed) * 0.01f, (y * 16 + seed) * 0.01f) * 20f;
                    float octave5 = PerlinSimplexNoise.noise((x * 16 + seed) * 0.03f, (y * 16 + seed) * 0.03f) * 5f;
                    */
                    float octave1 = PerlinSimplexNoise.noise((x * 9 + seed) * 0.0001f, (y * 9 + seed) * 0.0001f);
                    float octave2 = PerlinSimplexNoise.noise((x * 9 + seed) * 0.0005f, (y * 9 + seed) * 0.0005f);
                    float octave3 = PerlinSimplexNoise.noise((x * 9 + seed) * 0.005f, (y * 9 + seed) * 0.005f);
                    float octave4 = PerlinSimplexNoise.noise((x * 9 + seed) * 0.005f, (y * 9 + seed) * 0.005f) * 20f;
                    float octave5 = PerlinSimplexNoise.noise((x * 9 + seed) * 0.003f, (y * 9 + seed) * 0.003f) * 5f;
                    float finalNumber = octave1 + octave2 + octave3 + octave4 + octave5 + octave1;

                    if (finalNumber <= 30 && finalNumber >= 20) // final number 30 - 20
                    {
                        TilesGround[x, y] = 6;
                    }
                    else if (finalNumber < 20 && finalNumber > 18) // 19 - 16
                    {
                        TilesGround[x, y] = 5;
                    }
                    else if (finalNumber <= 13 && finalNumber >= 8) // 15 - 9
                    {
                        TilesObject[x, y] = new Object(0);
                        TilesGround[x, y] = 0;
                    }
                    else if (finalNumber <= 8 && finalNumber >= 0) // 8 - 0
                    {
                        TilesObject[x, y] = new Object(1);
                        TilesGround[x, y] = 0;
                    }
                    else
                    {
                        //TilesObject[x, y] = new Object(8);
                        TilesGround[x, y] = 0;
                    }
                }
            }
            BlendGrass(153);
        }


        public void BlendGrass(int seed)
        {
            Random rnd = new Random();
            rnd = new Random(seed);
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

                    if (TilesGround[x, y] == 0)
                    {
                        TilesGround[x,y] = finaltile;
                    }

                }
            }
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
