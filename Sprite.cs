using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Vision{
    public class Sprite
    {
        public string name;
        public Texture2D texture;
        public List<Texture2D[]> texture_frames;
        public Vector2 position;
        public int anim_index = 0;
        public Color color;
        public int width;
        public int height;
        private int counter = 0;
        private int frame_index = 0;
        public bool hflip = false;

        public Rectangle Rect {
            get {
                return new Rectangle((int)position.X,(int)position.Y, width, height);
            }
        }

        public Texture2D[] Animation {
            get {
                if(texture_frames != null){
                    return texture_frames[anim_index];
                }
                else{
                    return null;
                }
            }
            set {
                frame_index = 0;
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

        public Sprite(List<Texture2D[]> texture_frames, Vector2 position, Color color, int width = 112, int height = 200, string name = null){
            this.name = name;
            this.texture_frames = texture_frames;
            this.position = position;
            this.color = color;
            this.width = width;
            this.height = height;
        }

        public void ChangeAnimation(int index){
            anim_index = index;
            if(frame_index >= Animation.Length)
                frame_index = 0;
        }

        public virtual void Update(GameTime gameTime) {
            if(texture_frames != null){
                if(counter >= 2){
                    if(frame_index < Animation.Length - 1){
                        frame_index++;
                    }
                    else{
                        frame_index = 0;
                    }
                    counter = 0;
                }
                else{
                    counter++;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch){
            if(texture_frames == null){
                spriteBatch.Draw(texture, Rect, color);
            }
            else{
                if(!hflip)
                    spriteBatch.Draw(Animation[frame_index], Rect, color);
                else
                    spriteBatch.Draw(Animation[frame_index], Rect, null, color, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
            }
        }
    }
}