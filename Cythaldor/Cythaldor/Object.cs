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
    public abstract class Object
    {
        public int id;
        public Vector2 position;

        public Object(int id, Vector2 position)
        {
            this.id = id;
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resources.objects, new Vector2((position.X * Settings.Tile.Width) - Camera.position.X,
                (position.Y * Settings.Tile.Height) - Camera.position.Y), GetSourceRectangle(id), Color.White);
        }

        public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (Resources.objects.Height / Settings.Tile.Height);
            int tileX = tileIndex % (Resources.objects.Width / Settings.Tile.Width);
            return new Rectangle(tileX * Settings.Tile.Width, tileY * Settings.Tile.Height, Settings.Tile.Width, Settings.Tile.Height);
        }

    }
}
