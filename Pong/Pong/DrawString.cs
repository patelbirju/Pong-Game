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
    public class DrawString : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont textFont;

        private string playerDetails;


        private Vector2 position;

        public string PlayerDetails
        {
            get { return playerDetails; }
            set { playerDetails = value; }
        }
        


        public DrawString(Game game,SpriteBatch spriteBatch, SpriteFont textFont,Vector2 position)
        : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.textFont = textFont;
            this.playerDetails = string.Empty;
            this.position = position;
            
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

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your update code here
            spriteBatch.Begin();


            //spriteBatch.DrawString(textFont, "Alex", new Vector2(170, 50), Color.Black);
            //spriteBatch.DrawString(textFont, playerOneScore.ToString(), new Vector2(185, 150), Color.Black);
            //spriteBatch.DrawString(textFont, "Birju", new Vector2(575, 50), Color.Black);
            //spriteBatch.DrawString(textFont, playerTwoScore.ToString(), new Vector2(590, 150), Color.Black);
            //spriteBatch.DrawString(textFont, winner, new Vector2(300, 150), Color.Black);
            spriteBatch.DrawString(textFont, playerDetails, position, Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }


    }

    



}
