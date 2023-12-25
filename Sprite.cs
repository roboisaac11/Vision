using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Vision{
    public class Sprite
    {
        public string name;
        public Texture2D texture;
        public Texture2D[] texture_frames;
        public Vector2 position;
        public Color color;
        public int width;
        public int height;

        public Rectangle Rect {
            get {
                return new Rectangle((int)position.X,(int)position.Y, width, height);
            }
        }

        public Sprite(Texture2D texture, Vector2 position, Color color, int width = 112, int height = 200, string name = null){
            this.name = name;
            this.texture = texture;
            this.position = position;
            this.color = color;
            this.width = width;
            this.height = height;
        }

        public Sprite(Texture2D[] texture_frames, Vector2 position, Color color, int width = 112, int height = 200, string name = null){
            this.name = name;
            this.texture_frames = texture_frames;
            this.position = position;
            this.color = color;
            this.width = width;
            this.height = height;
        }

        public virtual void Update(GameTime gameTime) {

        }

        public virtual void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture, Rect, color);
        }
    }
}