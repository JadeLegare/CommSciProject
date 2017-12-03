using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Neverland_2._0
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Rectangle playerrec;
        Texture2D PeterPan;

        CharacterGameItem player = new CharacterGameItem(5, 0, 100, 100);

        Rectangle enemyrec;
        Rectangle magicrec;

        Texture2D[] flyingitemtex = new Texture2D[5];
        Texture2D healthbartex;
        Rectangle[] healthbarrec = new Rectangle[6];

        Rectangle flyingItemRec;
        GameSpriteStruct[] flyingitem;
        GameSpriteStruct pan;
        GameSpriteStruct magic;
        int numofitems = 20;

        int score = 0;
        int health = 5;
        int level = 0;
        int numposition;
        bool noItems = true;
        Random rand = new Random();

        //background and screen info
        Texture2D chosenBGpic;
    
        Rectangle BGrec;
        Texture2D chosenFOpic;
        Texture2D[] backgroundPic = new Texture2D[5];

        //sprite values
        float displayWidth;
        float displayHeight;
        float mindisplayX;
        float mindisplayY;
        float maxdisplayX;
        float maxdisplayY;
        float overScanPercentage = 10.0f;
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
            CharacterGameItem player = new CharacterGameItem(5, 0, playerrec.Y, playerrec.X);
            //set to size of the screen 
            //dont have to keep typing code over and over
            displayHeight = GraphicsDevice.Viewport.Height;
            displayWidth = GraphicsDevice.Viewport.Width;
            pan.spriteRectangle = new Rectangle(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 50, 50);
            magic.spriteRectangle = new Rectangle(0, 200, 50, 50);

            healthbarrec[5] = new Rectangle(GraphicsDevice.Viewport.Width - 200, GraphicsDevice.Viewport.Height/10, 200, 20);
            healthbarrec[4] = new Rectangle(GraphicsDevice.Viewport.Width - 200, GraphicsDevice.Viewport.Height/10, 150, 20);
            healthbarrec[3] = new Rectangle(GraphicsDevice.Viewport.Width - 200, GraphicsDevice.Viewport.Height/10, 100, 20);
            healthbarrec[2] = new Rectangle(GraphicsDevice.Viewport.Width - 200, GraphicsDevice.Viewport.Height/10, 50, 20);
            healthbarrec[1] = new Rectangle(GraphicsDevice.Viewport.Width - 200, GraphicsDevice.Viewport.Height/10, 25, 20);

            BGrec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

          //  Background = new BackgroundClass();
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

            healthbartex = this.Content.Load<Texture2D>("images/red");

            //set image to one of peter pan flying
            pan.spriteTexture = this.Content.Load<Texture2D>("images/peterflying");

            magic.spriteTexture = this.Content.Load<Texture2D>("images/magictink");

            flyingitemtex[0] = this.Content.Load<Texture2D>("images/clock");
            flyingitemtex[1] = this.Content.Load<Texture2D>("images/smeed");
            flyingitemtex[2] = this.Content.Load<Texture2D>("images/mermaid");
            flyingitemtex[3] = this.Content.Load<Texture2D>("images/hook");
            flyingitemtex[4] = this.Content.Load<Texture2D>("images/smeed");

            declareSprites();
           // flyingitemtex[0] = this.Content.Load<Texture2D>("smeed");
           // flyingitemtex[1] = this.Content.Load<Texture2D>("clock");
           // flyingitemtex[2] = this.Content.Load<Texture2D>("mermaid");

            backgroundPic[0] = this.Content.Load<Texture2D>("images/london");
            backgroundPic[1] = this.Content.Load<Texture2D>("images/neverland");
            backgroundPic[2] = this.Content.Load<Texture2D>("images/mermaidlagoon");
            backgroundPic[3] = this.Content.Load<Texture2D>("images/hookship");
            backgroundPic[4] = this.Content.Load<Texture2D>("images/powwow");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

          //  Background.SetRectangle(new Rectangle(0, 0, displayWidth, displayHeight));

            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);
            KeyboardState KB = Keyboard.GetState();
            chosenBGpic = backgroundPic[0];
            chosenFOpic = flyingitemtex[0];
            numposition = rand.Next(GraphicsDevice.Viewport.Height - 50);

            /*// Move the bread
            bread.X = bread.X + (bread.XSpeed * gamePad1.ThumbSticks.Left.X);
            bread.Y = bread.Y - (bread.YSpeed * gamePad1.ThumbSticks.Left.Y);
            bread.SpriteRectangle.X = (int)bread.X;
            bread.SpriteRectangle.Y = (int)bread.Y;
            */
            {
                //if press thumbstick up then players y value increases
                if (KB.IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y == 1.0f)
                {
                    //move up on screen
                    pan.spriteRectangle.Y--;
                }

                //if presses thumbstick down then players y value decreases
                if (KB.IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y == -1.0f)
                {
                    //move down screen
                    pan.spriteRectangle.Y++;

                }


                if (flyingitem[level].Visible)
                {
                    noItems = false;
                }

                //
                if (pan.spriteRectangle.Intersects(flyingitem[level].spriteRectangle))
                {
                    if (health > 0)
                    {
                        health--;
                    }

                    flyingitem[level].Visible = false;

                    setupSprite(ref flyingitem[level], 0.05f, 1000, 0, numposition, true);

                  //  noItems = true;
                    // ENEMY COLLIDE 
                }

                if (pan.spriteRectangle.Intersects(magic.spriteRectangle))
                {
                    score++;
                    magic.Visible = false;
                    setupSprite(ref magic, 0.05f, 100.0f, 0, numposition + 10, true);

                    // MAGIC COLLIDE 
                }


                if (noItems)
                {
                    //resetItems;
                    //changes y position so flying objects arent coming out of same spot each time 
                    flyingitem[level].spriteRectangle.Y = (int)flyingitem[level].Ypos + numposition;
                    //moving the objects
                    flyingitem[level].Xpos = flyingitem[level].Xpos + flyingitem[level].Xspeed;
                    flyingitem[level].spriteRectangle.X = (int)(flyingitem[level].Xpos + 0.5f);

                    flyingitem[level].Visible = true;

                }
                if(flyingitem[level].Xpos + flyingitem[level].spriteRectangle.Width >= GraphicsDevice.Viewport.Width)
                {
                  
                    setupSprite(ref flyingitem[level], 0.05f, 1000, 0, numposition, true);

                  //  flyingitem[level].spriteRectangle.X = (int)flyingitem[level].Xpos;
                   // flyingitem[level].spriteRectangle.Y = (int)flyingitem[level].Ypos;
                }

                if (magic.Xpos + magic.spriteRectangle.Width >= GraphicsDevice.Viewport.Width)
                {
                    setupSprite(ref magic, 0.05f, 100.0f, 0, numposition, true);

                }
            }


            if (health <= 0)
            {
                return;
            }

            //moving the objects
            flyingitem[level].Xpos = flyingitem[level].Xpos + flyingitem[level].Xspeed;
            flyingitem[level].spriteRectangle.X = (int)(flyingitem[level].Xpos + 0.5f);

            //moving the magic fairy across the screen
            magic.Xpos = magic.Xpos + magic.Xspeed;
            magic.spriteRectangle.X = (int)(magic.Xpos + 0.5f);



            if (score >= 10)
                {
                level = 1;
                
                chosenBGpic = backgroundPic[level];
                chosenFOpic = flyingitemtex[level];
                 }
          
           else if (score >= 20)
            {
                level = 2;

                chosenBGpic = backgroundPic[level];
                chosenFOpic = flyingitemtex[level];
            }
            else if (score >= 30)
            {
                level = 3;

                chosenBGpic = backgroundPic[level];
                chosenFOpic = flyingitemtex[level];
            }
            else if (score >= 40)
            {
                level = 4;

                chosenBGpic = backgroundPic[level];
                chosenFOpic = flyingitemtex[level];
            }
            else if (score >= 50)
            {
                level = 0;

                chosenBGpic = backgroundPic[level];
                chosenFOpic = flyingitemtex[level];
            }
            if (level >4)
            {
                level = 0;
            }

            base.Update(gameTime);
        }


        //METHODS
        
         public void TitleScreen(Game1 game)
        {
        //    if (game.GamePad1.Buttons.A == ButtonState.Pressed)
            {
         //       game.StartGame();
            }
        }
      

        //method to draw text on screen 
        public void drawText(string text, Color textcolor, float x, float y)
        {

            int layer;
            Vector2 textVector = new Vector2(x, y);
            //sloid part of character text 
            Color backColor = new Color(90, 190, 190);
            for (layer = 0; layer > 10; layer++)
            {
                // spriteBatch.DrawString(font, text, textVector, backColor);
                textVector.X++;
                textVector.Y++;
            }
        }

        //sprite values
        public struct GameSpriteStruct
        {
            public Texture2D spriteTexture;
            public Rectangle spriteRectangle;
            public float Xpos;
            public float Ypos;
            public float Xspeed;
            public float Yspeed;
            public float widthfactor;
            public float ticksToCrossScreen;
            public bool Visible;

        }

        //reuse this code when declaring and setting up sprites
        public void setupSprite(ref GameSpriteStruct sprite, float widthfactor, float ticksToCrossScreen, float initialX, float initialY, bool initialVisibility)
        {
            sprite.widthfactor = widthfactor;
            sprite.ticksToCrossScreen = ticksToCrossScreen;
            sprite.spriteRectangle.Width = (int)((displayWidth * widthfactor) + 0.5f);
          //  float aspectRatio = (float)sprite.spriteTexture.Width / sprite.spriteTexture.Height;
            sprite.spriteRectangle.Height = (int)((sprite.spriteRectangle.Width) + 0.5f);
            sprite.Xpos = initialX;
            sprite.Ypos = initialY;
            sprite.Xspeed = displayWidth / ticksToCrossScreen;
            sprite.Yspeed = sprite.Xspeed;
            sprite.Visible = initialVisibility;

        }

        public void declareSprites()
        {
            setupSprite(ref pan, 0.05f, 200.0f, displayWidth / 2, displayHeight / 2, true);
            setupSprite(ref magic, 0.05f, 100.0f, 50, numposition, true);

            flyingitem = new GameSpriteStruct[numofitems];

            
                flyingitem[level].spriteTexture = flyingitemtex[level];
                setupSprite(ref flyingitem[level], 0.05f, 1000, 0, 400, true);

                flyingitem[level].spriteRectangle.X = (int)flyingitem[level].Xpos;
                flyingitem[level].spriteRectangle.Y = (int)flyingitem[level].Ypos;
            
        }



        //couple the player and enemy
        // public bool checkCollision(flyingitem[i].spriteRctangle)

        //     return spriteRectangle.Intercests(flyingitem);
        public void resetItems()
        {
            //make flying item visible 
            flyingitem[level].Visible = true;
            //changes y position so flying objects arent coming out of same spot each time 
            //  flyingitem[level].Ypos = flyingitem[level].Ypos + numposition;
            //flyingitem[level].spriteRectangle.X = (int)flyingitem[level].Xpos;
            flyingitem[level].spriteRectangle.Y = (int)flyingitem[level].Ypos + numposition;
        }




        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(chosenBGpic, BGrec, Color.White);
            spriteBatch.Draw(pan.spriteTexture, pan.spriteRectangle, Color.White);
           
            //draws flying item on screen, picture shown changes depending on the level number
            spriteBatch.Draw(flyingitemtex[level], flyingitem[0].spriteRectangle, Color.White);
            
            //draws the magic fairy on screen 
            spriteBatch.Draw(magic.spriteTexture, magic.spriteRectangle, Color.White);
            
            //draw health bar on screen depending on how much helath the player has determines the length of the health bar
            spriteBatch.Draw(healthbartex, healthbarrec[health], Color.White);

            drawText("Score:" + score.ToString() , Color.White, 100,400);
         
            // +"Lives: " + health.ToString()
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
