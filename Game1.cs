using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Vision
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player player;

        List<Sprite> enemies;
        List<Enemy> choppingBlock;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            enemies = new List<Sprite>();
            choppingBlock = new List<Enemy>();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D playerTexture = Content.Load<Texture2D>("sprite-static");
            Texture2D enemyTexture = Content.Load<Texture2D>("sprite-static");

            int width = playerTexture.Width * 3;
            int height = playerTexture.Height * 3;

            player = new Player(playerTexture, new Vector2(0, 0), Color.White, width, height, enemies, "Player", 10);

            enemies.Add(new Enemy(enemyTexture, new Vector2(100, 100), Color.Red, width, height, player, "Bad Guy 1"));
            enemies.Add(new Enemy(enemyTexture, new Vector2(400, 300), Color.Red, width, height, player, "Bad Guy 2"));


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Enemy sprite in enemies){
                sprite.Update(gameTime);
            }

            foreach (Enemy sprite in choppingBlock){
                enemies.Remove(sprite);
            }

            player.Update(gameTime, choppingBlock);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(37,0,56));
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            player.Draw(_spriteBatch);

            foreach (Enemy sprite in enemies){
                sprite.Draw(_spriteBatch);
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
