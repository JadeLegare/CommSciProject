//Jade Legare
//march 8, 2017
//speedy ambulance

/* 
- start 
- declare all variables for the photos and rectangles
- set ambulnace to an array to hold all the photos of the ambulance 
- initialze rectangles by settign the X, Y values and height adn width 
- hospital photo to background 
- load all the photos for the ambulance and hospital 
- check that controller is attached as player one 
- check if any buttons on the keybowrd have been pressed
- is the keyboard key up, or the thumbpad on the controller is moved up then it 
sets the current pic to a picture of the ambulance moving up 
- also changes the value of the rectangle moving to decrease the y vlaue so it moves up on the screen 
- if keyboard key down or thumbpad is down then sets current pic to ambulance moving down 
- also increases the value on y on the rectangle to move it down the screen 
- if keyboard key left or thumbpad is left then sets current pic to ambulance moving left 
- also decreases the value on x on the rectangle to move it left on the screen 
- if keyboard key right or thumbpad is right then sets current pic to ambulance moving right 
- also increases the value on x on the rectangle to move it right on the screen 
- if the right trigger is pressed it sets the value ligthspeed to 10 times the vlaue of the left thumbstick x




*/




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

namespace speedyAmbulance
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D hospital;
        Texture2D currentpic;

        List<Texture2D> ambulance;
        //declare the rectangles for each direction of the albumalnce and the hospital
        Rectangle moving;
        //backrec;
        // Rectangle frontrec;
        //Rectangle leftrec;
        //Rectangle rightrec;
        Rectangle hospitalrec;

        //controls speed
        byte lightspeed;
        //declare game controller pad
        GamePadState pad1;

        //  byte movement;


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
            //set size and position of all the rectangles for the different truck photos
            /*  backrec = new Rectangle(400, 300, 100, 100);
              frontrec = new Rectangle(400, 300, 100, 100);
              rightrec = new Rectangle(400, 300, 100, 100);
              leftrec = new Rectangle(400, 300, 100, 100);
             */

            ambulance = new List<Texture2D>();


            //declare new rectangle
            moving = new Rectangle(400, 300, 100, 100);

            //set rectangle to size of whole screen 
            hospitalrec = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

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
            /*
          //set ambulance back to photo of the backward ambulance 
          ambulanceBack = this.Content.Load<Texture2D>("AmbulanceBackward");
          //set ambulance forward to photo of the forward ambulance 
          ambulanceForward = this.Content.Load<Texture2D>("AmbulanceForward");
          //set ambulance leeft to photo of the left ambulance
          ambulanceLeft = this.Content.Load<Texture2D>("AmbulanceLeft");
          //set ambulance right to photo of the right ambulance
          ambulanceRight = this.Content.Load<Texture2D>("AmbulanceRight");
          //set hospital to photo of the hospital background
          */
            hospital = this.Content.Load<Texture2D>("Hospital Parking Lot");
            ambulance.Add(Content.Load<Texture2D>("AmbulanceRight"));
            ambulance.Add(Content.Load<Texture2D>("AmbulanceBackward"));
            ambulance.Add(Content.Load<Texture2D>("AmbulanceForward"));
            ambulance.Add(Content.Load<Texture2D>("AmbulanceLeft"));


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //set pad1 to check for the controller
            pad1 = GamePad.GetState(PlayerIndex.One);
            

            //chekc if button on keyboard has been pressed
            KeyboardState KB = Keyboard.GetState();

            //set current pic to defalt of the ambulance going forward
            currentpic = ambulance[1];
            
            //if the up key on the keyboard has been pressed
            if (KB.IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == 1.0f)
            {
                //sets the picture to the picture of the ambulance going up
                currentpic = ambulance[2];
                //change the value of y on the rectangle to move the picture around the screen
                moving.Y--;

            }
            else if (KB.IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == -1.0f)
            {
                //sets the picture to the picture of the ambulance going down
                currentpic = ambulance[1];
                //change y value of rectangle to move down the screen
                moving.Y++;


            }
            else if (KB.IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == -1.0f)
            {
                //sets the picture to the picture of the ambulance going left
                currentpic = ambulance[3];
                //change x value so it moves left on the screen
                moving.X--;

            }
            else if (KB.IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == 1.0f)
            {
                //sets the picture to the picture of the ambulance going right
                currentpic = ambulance[0];
                //change x value so the image moves right on the screen
                moving.X++;
            }


          
         
            //if right trigger has a value larger than zero 
            if (pad1.Triggers.Right > 0 || KB.IsKeyDown(Keys.A))
            {
                //change lightspeed to two times the value of the pressed trigger
                lightspeed = (byte)(2);
                //increase x value of rectangle by light speed value
                moving.X += lightspeed;
            }
            else if(pad1.Triggers.Left > 0 || KB.IsKeyDown(Keys.B))
            {
                //change lightspeed to two times the value of the pressed trigger
                lightspeed = (byte)(2);
                //decrease x value of rectangle by light speed value
                moving.X -= lightspeed;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();
            //draws hospiral photo and rectangle on screeen
            spriteBatch.Draw(hospital, hospitalrec, Color.White);
            //draws photo of the back ambulance and rectangel on screen 
            spriteBatch.Draw(currentpic, moving, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
