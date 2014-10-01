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

        public List<Button> buttons = new List<Button>();


        public GUI()
        {
            float woodRecWidth = ((Settings.Window.Width * 0.052f) * 2.0f);
            float woodRecHeight = ((Settings.Window.Height * 0.023f) * 2.0f);




            Rectangle woodRectangle = new Rectangle(15, 15, (int)woodRecWidth, (int)woodRecHeight);
            //MessageBox.Show((1280 * 0.052).ToString());
            //Rectangle woodRectangle = new Rectangle(15, 15, 100, 25);
            //WOOD BUTTON
            buttons.Add(new Button(0, woodRectangle));

            //ROCK BUTTON
        }

        public void Update(MouseState mouse, KeyboardState keyboard)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Button button in buttons)
            {
                spriteBatch.Draw(Resources.GUI, button.rectangle, GetSourceRectangle(button.id), Color.White);
            }
        }

        //GET THE SOURCE RECTANGLE FROM THE BUTTON'S TILESET
        public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (Resources.GUI.Height / 25);
            int tileX = tileIndex % (Resources.GUI.Width / 100);
            return new Rectangle(tileX * 100, tileY * 25, 100, 25);
        }



    }
}
