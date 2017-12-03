//buttonBach

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

namespace MoveSpeed
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //initalize and load font for the BIG CLOCK application
       font ***
       //bool to count how many times the button is pressed
       int[] acount = new int[4];
       int[] bcount = new int [4];
       int[] xcount = new int [4];
       int[] ycount = new int [4];
       //hold game pad states
       //holds state of gamepad during call of update 
       GamePadState pad1;
       //holds values from the previous call of Update
       GamepadState oldpad1;

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

            ambulance = new List<Texture2D>() ;                    


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
            pad1 = GamePad.GetState(PlayerIndex.One);
            pad2 = GamePad.GetState(PlayerIndex.Two);
            pad3 = GamePad.GetState(PlayerIndex.Three);
            pad4 = GamePad.GetState(PlayerIndex.Four);

            //chekc if button on keyboard has been pressed
            KeyboardState KB = Keyboard.GetState();

           if (pad1.Buttons.Start == ButtonState.Pressed)
           {
               presscounter[0,1,2,3] = 0;

           }
           //figure out if button is down or up and only count after it been released and it up
            if ( pad1.Buttons.B = ButtonState.Pressed)
            {  
                oldpad1 = pad1;
                //display number on screen of how many times its been pressed
            }
     
           //add one to counter when button is pressed
            if (oldpad1.Buttons.B == ButtonState.released && pad1.Buttons.Start == ButtonState.Pressed)
            {
                bcount[0] ++;
            }
            if (oldpad1.Buttons.A == ButtonState.released && pad1.Buttons.Start == ButtonState.Pressed)
            {
                acount[0] ++;
            }
            if (oldpad1.Buttons.X == ButtonState.released && pad1.Buttons.Start == ButtonState.Pressed)
            {
                xcount[0] ++;
            }
            if (oldpad1.Buttons.Y == ButtonState.released && pad1.Buttons.Start == ButtonState.Pressed)
            {
                ycount[0] ++;
            }

            if (pad1.Triggers.Right > 0|| KB.IsKeyDown(Keys.NumPad1))
            {
                lightspeed = (byte)(2 * pad1.Triggers.Right);
            }
             if (pad1.Triggers.Left > 0|| KB.IsKeyDown(Keys.NumPad2))
            {
                lightspeed = (byte)(-2 * pad1.Triggers.Left);
            }


           //holds previous state of GamePad, tests for change nad uses the and operator, if previous button state was up and the current state is down the the counter with increase
           //edge dector and detects a change from one state to another 
            oldpad1 = pad1;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
         DateTime nowDateTime = DateTime.Now;
         string nowstring = nowDateTime.ToLongTimeString();
         Vector2 timeVector = new Vector2(0,0); 

         string countstring = presscounter[0].ToString();
         Vector2 countVector = new Vector2(50,400);

            spriteBatch.Begin();
         
        SpriteBatch.DrawString(font, nowString, timeVector, Color.Red);
        spriteBatch.DrawString(font, countstring, countVector, Color.Red);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
