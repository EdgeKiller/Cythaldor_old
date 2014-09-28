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
    public class Object
    {
        public int id;
        public int life;

        public Object(int id)
        {
            this.id = id;
            switch(this.id)
            {
                case 0: //TREE
                    this.life = 50;
                    break;
                case 1: //ROCK
                    this.life = 200;
                    break;
            };
                
            
        }

    }
}
