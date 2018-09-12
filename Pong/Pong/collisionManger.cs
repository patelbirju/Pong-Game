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
    public class CollisionManger : Microsoft.Xna.Framework.GameComponent
    {
        private Ball ball;
        private Bat playerOne;
        private Bat playerTwo;
        public CollisionManger(Game game, Ball ball, Bat playerOne, Bat playerTwo)
            : base(game)
        {
            this.ball = ball;
            this.playerOne = playerOne;
            this.playerTwo = playerTwo;
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
            Rectangle playerOneRect = getFrames(playerOne.Position, playerOne.Texture);
            Rectangle playerTwoRect = getFrames(playerTwo.Position, playerTwo.Texture);
            Rectangle ballRect = getFrames(ball.Position, ball.Texture);

            // Check for collisions
            if(playerOneRect.Intersects(ballRect))
            {
                ball.Speed = new Vector2(Math.Abs(ball.Speed.X), ball.Speed.Y);
            }
            if(playerTwoRect.Intersects(ballRect))
            {
                ball.Speed = new Vector2(-Math.Abs(ball.Speed.X), ball.Speed.Y);
            }


            base.Update(gameTime);
        }

        public Rectangle getFrames(Vector2 position, Texture2D texture)
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
    }
}
