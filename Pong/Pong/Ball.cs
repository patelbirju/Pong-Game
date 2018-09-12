using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Pong
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Ball : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Game1 pong;

        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Vector2 position;
        private Vector2 stage;
        private Vector2 speed;
        bool gameStart = false;

        int MAX_SCORE = 2;
        
            
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Texture2D Texture
        {
            get { return texture; }
        }
        public Vector2 Speed
        {
            get { return speed; }
            set { speed = value; }
        }




        public Ball(Game game, SpriteBatch spriteBatch,
            Texture2D texture,
            Vector2 position,
            Vector2 stage)
            : base(game)
        {
            this.pong = (Game1)game;
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.position = position;
            this.stage = stage;
            

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();


            if (gameStart == false)
            {
                if (ks.IsKeyDown(Keys.Enter))
                {
                    gameStart = true;
                  
                }
            }
            else
            {
                if (pong.PlayerOneScore != MAX_SCORE && pong.PlayerTwoScore != MAX_SCORE)
                {
                    position.Y += speed.Y;
                    if (position.Y < 0)
                    {
                        speed.Y = Math.Abs(speed.Y);

                    }
                    if (position.Y >
                        (stage.Y - texture.Height))
                        speed.Y = -Math.Abs(speed.Y);

                    position.X += speed.X;

                    if (position.X + texture.Width >= stage.X)
                    {
                        position = new Vector2((stage.X / 2) - (texture.Width / 2), (stage.Y / 2) - (texture.Height / 2));
                        speed = new Vector2(0, 0);
                        pong.PlayerOneScore++;
                    }
                    else if (position.X < 0)
                    {
                        position = new Vector2((stage.X / 2) - (texture.Width / 2), (stage.Y / 2) - (texture.Height / 2));
                        speed = new Vector2(0, 0);
                        pong.PlayerTwoScore++;
                    }
                    else if (ks.IsKeyDown(Keys.Enter))
                    {
                        speed = new Vector2(5, -5);
                    }
                }

            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
