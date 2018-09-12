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
    public class Bat : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        private Texture2D playerText;
        private Vector2 position;
        private Vector2 stage;
        int speed;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Texture2D Texture
        {
            get { return playerText; }
        }





        public Bat(Game game, SpriteBatch spriteBatch, Texture2D playerText, Vector2 position,Vector2 stage)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.playerText = playerText;            
            this.position = position;
            this.stage = stage;
            speed = 3;
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
            // TODO: Add your update code here
            KeyboardState ks = Keyboard.GetState();


            //if (ks.IsKeyDown(Keys.Escape))
            //{
            //    Game.Exit();
            //}
            //if (ks.IsKeyDown(Keys.Z))
            //{
            //    if(playerOne.Y <= (stage.Y - myTexture.Height))
            //        playerOne.Y += speed;
            //}
            //if (ks.IsKeyDown(Keys.A))
            //{
            //    if (playerOne.Y >= 0)
            //        playerOne.Y -= speed;
            //}
            //if (ks.IsKeyDown(Keys.Down))
            //{
            //    if (playerTwo.Y <= (stage.Y - myTexture.Height))
            //        playerTwo.Y += speed;
            //}
            //if (ks.IsKeyDown(Keys.Up))
            //{
            //    if (playerTwo.Y >= 0)
            //        playerTwo.Y -= speed;
            //}
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your draw code here
            spriteBatch.Begin();
            spriteBatch.Draw(playerText, position, Color.White);
            //spriteBatch.Draw(myTexture, playerTwo, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void moveUp(Keys key)
        {
            KeyboardState ks = Keyboard.GetState();
            if(ks.IsKeyDown(key))
            {
                if (position.Y >= 0)
                    position.Y -= speed;
            }
        }

        public void moveDown(Keys key)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(key))
            {
                if (position.Y <= (stage.Y - playerText.Height))
                    position.Y += speed;
            }
        }
    }
}
