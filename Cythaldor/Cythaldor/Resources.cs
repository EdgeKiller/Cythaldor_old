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
        //TILESETS
        public static Texture2D tileset, select, objects;

        //FONTS
        public static SpriteFont font1, font2;

        //GUI
        public static Texture2D cursor, GUI;

        public static void LoadContent(ContentManager content)
        {
            //TILESETS
            tileset = content.Load<Texture2D>(@"Textures\tileset");
            select = content.Load<Texture2D>(@"Textures\select");
            objects = content.Load<Texture2D>(@"Textures\object");

            //FONTS
            font1 = content.Load<SpriteFont>(@"SpriteFont1");
            font2 = content.Load<SpriteFont>(@"SpriteFont2");

            //GUI
            cursor = content.Load<Texture2D>(@"Textures\GUI\cursor");
            GUI = content.Load<Texture2D>(@"Textures\GUI\gui");

        }




    }
}
