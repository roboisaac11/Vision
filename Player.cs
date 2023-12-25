using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Vision
{
    internal class Player : Sprite
    {

        private KeyboardState _keyboard;
        private int speed = 5;
        private float[] pos = { 0, 0 };
        private Enemy collidedSprite = null;
        private List<Sprite> collisionGroup;

        public Player(Texture2D texture, Vector2 position, Color color, int width, int height, string name = "", int speed = 5) : base(texture, position, color, width, height, name)
        {
            this.speed = speed;
        }
        public Player(Texture2D texture, Vector2 position, Color color, int width, int height, List<Sprite> collisionGroup, string name = "", int speed = 5) : base(texture, position, color, width, height, name)
        {
            this.collisionGroup = collisionGroup;
            this.speed = speed;
        }

        public void Update(GameTime gameTime, List<Enemy> choppingBlock)
        {
            base.Update(gameTime);

            // Get keyboard state
            _keyboard = Keyboard.GetState();

            // Check if collided enemy moved away
            if (collidedSprite != null)
                if (pos[0] != position.X || pos[1] != position.Y && !collidedSprite.Rect.Intersects(Rect))
                {
                    collidedSprite = null;
                }

            // Store current position
            pos[0] = position.X;
            pos[1] = position.Y;

            // Calculate X movement based on input
            float changeX = 0;
            if (_keyboard.IsKeyDown(Keys.Right))
            {
                changeX += speed;
            }
            else if (_keyboard.IsKeyDown(Keys.Left))
            {
                changeX -= speed;
            }

            // Move X
            position.X += changeX;

            // Collision detection X
            if (collisionGroup != null)
            {
                foreach (var sprite in collisionGroup)
                {
                    if (sprite.Rect.Intersects(Rect))
                    {
                        position.X -= changeX;
                        collidedSprite = (Enemy)sprite;
                    }
                }
            }

            // Calculate Y movement
            float changeY = 0;
            if (_keyboard.IsKeyDown(Keys.Down))
            {
                changeY += speed;
            }
            else if (_keyboard.IsKeyDown(Keys.Up))
            {
                changeY -= speed;
            }

            // Move Y
            position.Y += changeY;

            // Collision detection Y
            if (collisionGroup != null)
            {
                foreach (var sprite in collisionGroup)
                {
                    if (sprite.Rect.Intersects(Rect))
                    {
                        position.Y -= changeY;
                        collidedSprite = (Enemy)sprite;
                    }
                }
            }

            // Attack collided enemy
            if (collidedSprite != null)
            {
                if (_keyboard.IsKeyDown(Keys.Enter))
                {
                    collidedSprite.Damage(choppingBlock);
                }
            }

        }
    }
}
