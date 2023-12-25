using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Vision
{
    internal class Enemy : Sprite{
        private Player player;

        public Enemy(Texture2D texture, Vector2 position, Color color, int width, int height, Player player, string name = "") : base(texture, position, color, width, height, name){ this.player = player; }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Damage(List<Enemy> choppingBlock)
        {
            choppingBlock.Add(this);
        }
    }
}
