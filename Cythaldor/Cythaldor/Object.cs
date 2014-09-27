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
        public int id, width, height;
        public Vector2 position;

        public Object(int id, int width, int height, Vector2 position)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resources.objects, new Vector2((position.X * width) - Camera.position.X, 
                (position.Y * height) - Camera.position.Y), GetSourceRectangle(id), Color.White);
        }

        public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (Resources.objects.Height / height);
            int tileX = tileIndex % (Resources.objects.Width / width);
            return new Rectangle(tileX * width, tileY * height, width, height);
        }

    }
}
