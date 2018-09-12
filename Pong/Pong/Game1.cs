using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        DrawString playerOneString;
        DrawString playerTwoString;
        DrawString winnerString;

        Texture2D backTexture;
        //Players
        private Bat playerOne;
        private Bat playerTwo;
        //Game Ball
        private Ball ball;
        // Collision Manager
        private CollisionManger collisionManager;

        //Players Variables
        private Texture2D playerText;
        private Vector2 playerOnePosition;
        private Vector2 playerTwoPosition;

        //Game Ball variables
        private Texture2D gameBallText;
        private Vector2 ballPosition;
        private Vector2 ballSpeed;

        private Vector2 stage;

        //Score Variables
        private int MAX_SCORE = 2;
        private int playerOneScore;
        private int playerTwoScore;
        private string winner = "";

        public int PlayerOneScore
        {
            get { return playerOneScore; }
            set { playerOneScore = value; }
        }
        public int PlayerTwoScore
        {
            get { return playerTwoScore; }
            set { playerTwoScore = value; }
        }
        public string Winner
        {
            get { return winner; }
            set { winner = value; }
        }




        //Texture2D namesFont;
        SpriteFont nameFont;
        SpriteFont textFont;
       
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textFont = Content.Load<SpriteFont>("font/textFont");

            backTexture = Content.Load<Texture2D>("backround/pongTable");
            nameFont = Content.Load<SpriteFont>("font/nameFont");

            

            stage = new Vector2(graphics.PreferredBackBufferWidth,graphics.PreferredBackBufferHeight);

            playerText = Content.Load<Texture2D>("images/Bat");
            playerOnePosition = new Vector2(0, (stage.Y / 2) - (playerText.Height / 2));
            playerTwoPosition = new Vector2(stage.X - playerText.Width, (stage.Y / 2) - (playerText.Height / 2));

            gameBallText = Content.Load<Texture2D>("images/ball");
            ballPosition = new Vector2((stage.X / 2) - (gameBallText.Width / 2), (stage.Y / 2) - (gameBallText.Height / 2));
            ballSpeed = randomSpeed();
            //Loading Game Objects
            playerOne = new Bat(this,
                spriteBatch,
                playerText,
                playerOnePosition,
                stage);
            playerTwo = new Bat(this,
                spriteBatch,
                playerText,
                playerTwoPosition,
                stage);
            ball = new Ball(this,
                spriteBatch,
                gameBallText,
                ballPosition,
                stage);
            collisionManager = new CollisionManger(this, ball, playerOne, playerTwo);
            playerOneString = new DrawString(this, spriteBatch, textFont, new Vector2(170, 50));
            playerTwoString = new DrawString(this, spriteBatch, textFont, new Vector2(575, 50));
            winnerString = new DrawString(this, spriteBatch, textFont, new Vector2(stage.X/3, stage.Y / 2));


            // TODO: use this.Content to load your game content here
            Components.Add(playerOne);
            Components.Add(playerTwo);
            Components.Add(ball);
            Components.Add(collisionManager);
            Components.Add(playerOneString);
            Components.Add(playerTwoString);
            Components.Add(winnerString);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerOneString.PlayerDetails = "Alex " + "\n" + playerOneScore;
            playerTwoString.PlayerDetails = "Birju " + "\n" + playerTwoScore;

            // TODO: Add your update logic here
            KeyboardState ks = Keyboard.GetState();
            playerOne.moveUp(Keys.A);
            playerOne.moveDown(Keys.Z);
            playerTwo.moveUp(Keys.Up);
            playerTwo.moveDown(Keys.Down);

            //ball.Speed = randomSpeed();

            if(playerOneScore == MAX_SCORE)
            {
                winnerString.PlayerDetails = "Alex Wins!";
                if(ks.IsKeyDown(Keys.Space))
                {
                    restartGame();
                }
            }
            else if (playerTwoScore == MAX_SCORE)
            {
                winnerString.PlayerDetails = "Birju Wins!";
                if (ks.IsKeyDown(Keys.Space))
                {
                    restartGame();
                }
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);


            spriteBatch.Begin();
            spriteBatch.Draw(backTexture, new Rectangle(0, 0, 800, 480), Color.White);

            //spriteBatch.DrawString(nameFont, "Alex", new Vector2(170, 50), Color.Black);
            //spriteBatch.DrawString(nameFont, Ball.playerOneScore.ToString(), new Vector2(185, 150), Color.Black);
            //spriteBatch.DrawString(nameFont, "Birju", new Vector2(575, 50), Color.Black);
            //spriteBatch.DrawString(nameFont, Ball.playerTwoScore.ToString(), new Vector2(590, 150), Color.Black);
            spriteBatch.End();



            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public Vector2 randomSpeed()
        {
            Vector2 speed = Vector2.Zero;
            Random rs = new Random();
            int speedX = rs.Next(3, 10);
            int speedY = rs.Next(3, 10);
            int direction = rs.Next(0, 2);

            if (direction < 1)
            {
                speed.X = -speedX;
            }

            direction = rs.Next(0, 2);
            if(direction < 1)
            {
                speed.Y = -speedY;
            }
            return new Vector2(speedX, speedY);
        }

        public  void restartGame()
        {
            playerOneScore = 0;
            PlayerTwoScore = 0;
            ball.Position = new Vector2((stage.X / 2) - (gameBallText.Width / 2), (stage.Y / 2) - (gameBallText.Height / 2));
            playerOne.Position = new Vector2(0, (stage.Y / 2) - (playerText.Height / 2));
            playerTwo.Position = new Vector2(stage.X - playerText.Width, (stage.Y / 2) - (playerText.Height / 2));

            winnerString.PlayerDetails = "";
        }
    }
}
