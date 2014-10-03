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
using System.Windows.Forms;

namespace Cythaldor
{
    public class GUI
    {

        public static List<Box> buttons = new List<Box>();


        public GUI()
        {
            //WOOD BUTTON
            float woodRecWidth = (Settings.Window.Width * (100f / 1920f) * 2.0f);
            float woodRecHeight = (Settings.Window.Height * (25f / 1080f) * 2.0f);
            Rectangle woodRectangle = new Rectangle(15, 15, (int)woodRecWidth, (int)woodRecHeight);
            buttons.Add(new Box(0, woodRectangle));

            //ROCK BUTTON
            float rockRecWidth = (Settings.Window.Width * (100f / 1920f) * 2.0f);
            float rockRecHeight = (Settings.Window.Height * (25f / 1080f) * 2.0f);
            Rectangle rockRectangle = new Rectangle(30 + (int)woodRecWidth,  15, (int)rockRecWidth, (int)rockRecHeight);
            buttons.Add(new Box(1, rockRectangle));


        }

        public void Update(MouseState mouse, KeyboardState keyboard)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Box button in buttons)
            {
                spriteBatch.Draw(Resources.GUI, button.rectangle, GetSourceRectangle(button.id), Color.White);
            }
        }

        //GET THE SOURCE RECTANGLE FROM THE BUTTON'S TILESET
        public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (Resources.GUI.Height / 50);
            int tileX = tileIndex % (Resources.GUI.Width / 200);
            return new Rectangle(tileX * 200, tileY * 50, 200, 50);
        }



    }
}
