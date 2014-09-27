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
    public static class Resources
    {
        public static Texture2D tileset, select, cursor;
        public static SpriteFont font1;

        public static void LoadContent(ContentManager content)
        {
            tileset = content.Load<Texture2D>(@"Textures\tileset");
            select = content.Load<Texture2D>(@"Textures\select");
            font1 = content.Load<SpriteFont>(@"SpriteFont1");
            cursor = content.Load<Texture2D>(@"Textures\cursor");
        }




    }
}
