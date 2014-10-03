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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        GamePlay main;

        public enum GameState
        {
            GameStart,
            GameMenu,
            GamePlay
        }

        GameState gameState = new GameState();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = Settings.Window.Height;
            graphics.PreferredBackBufferWidth = Settings.Window.Width;
            graphics.IsFullScreen = Settings.Window.FullScreen;
            graphics.ApplyChanges();
            gameState = GameState.GamePlay;
            main = new GamePlay();
        }

        protected override void Initialize()
        {
            Window.Title = Settings.Window.GameName + " - " + Settings.Window.GameVersion + " - " +
                Settings.Window.GameCreator;
            IsMouseVisible = Settings.Window.MouseVisible;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Resources.LoadContent(Content);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if(gameState == GameState.GamePlay)
            {
                main.Update(Keyboard.GetState(), Mouse.GetState(), gameTime, graphics);
            }
            else if(gameState == GameState.GameStart)
            {

            }
            else if (gameState == GameState.GameMenu)
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            main.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
