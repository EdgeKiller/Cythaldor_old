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
    public class Box
    {
        public Rectangle rectangle;
        public int id;

        public Box(int id, Rectangle rectangle)
        {
            this.rectangle = rectangle;
            this.id = id;
        }

    }
}
