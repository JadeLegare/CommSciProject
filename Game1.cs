//Jade Legare
//april 5, 2017
//pop art moodlight 

/*
- start 
- state your varibles for the font, rectangles, picture, text string and vectors as well as the colour intensities and bools 
- set the screen dimensions that you want 
- initalize the rectangles in the multidimensional arrays, set the different values using the screen width and height to section it into four areas 
- declare and load the picture of the dog 
- when user presses the back button the program exits 
- declare the text for the multidimensional text array 
- create float values to measure the length and height of each word 
- set your textvectors to the screen width divided by two and either add or subtact quarter the width of the screen and then subtract half the width of the word
- set hte vector height by doing half the screen subtract the word height 
- set your red, green and values to make the bool false if the intensity reaches 225 and true if the intensity reaches 0
- if the bool it true then the colour intsneity will increase, else the intensity will decrease 
- declare thepicture values for each section of the array by setting the array to the red, green and blue intensities adding or subtracting different values to make each section change a differetn colour 
- draw the picture on the screen with the rectangle and colour 
- also draw the fonts on the screen using the font loaded, the text array, the etxt vector for that specific section of the screen and set the words colour 
- clear the colours on the screen so they can change each time 
- end

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

namespace PopArtMoodlight
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        
        SpriteFont font;
        Rectangle[,] picrec = new Rectangle [2,2];
        Texture2D puppypic;

        string[,] text = new string[2, 2];
        Vector2[,] txtvector = new Vector2 [2, 2];

        //conrols colour values 
        byte redIntensity = 100;
        byte greenIntensity = 30;
        byte blueIntensity = 60;

        Color[] piccolour = new Color[4];

        bool redCountingUp = true;
        bool greenCountingUp = true;
        bool blueCountingUp = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;
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
            //do .25 of the window size to set window size
            picrec[0, 0] = new Rectangle(0, 0, GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2);
            picrec[0, 1] = new Rectangle(GraphicsDevice.Viewport.Width/2, 0, GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2);
            picrec[1, 0] = new Rectangle(0, GraphicsDevice.Viewport.Height/2, GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2);
            picrec[1, 1] = new Rectangle(GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2, GraphicsDevice.Viewport.Width/2, GraphicsDevice.Viewport.Height/2);


            puppypic = this.Content.Load<Texture2D>("puppy");

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
            font = Content.Load<SpriteFont>("SpriteFont1");

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

               
           //text array      
            text[0, 0] = "puppies";
            text[0, 1] = "are";
            text[1, 0] = "super";
            text[1, 1] = "cute";

            //float array to measure size of each word
            float[] wordwidth = new float[5];
            float[] wordheight = new float[5];
            wordwidth[0] = font.MeasureString("puppies").X;
            wordheight[0] = font.MeasureString("puppies").Y;

            wordwidth[1] = font.MeasureString("are").X;
            wordheight[1] = font.MeasureString("are").Y;

            wordwidth[2] = font.MeasureString("super").X;
            wordheight[2] = font.MeasureString("super").Y;

            wordwidth[3] = font.MeasureString("cute").X;
            wordheight[3] = font.MeasureString("cute").Y;

            //set text vector to centre the word by taking half the screen width or height and subtracting the word length
            txtvector[0, 0] = new Vector2(GraphicsDevice.Viewport.Width/2 - GraphicsDevice.Viewport.Width/4 - wordwidth[0]/2, GraphicsDevice.Viewport.Height/2  - wordheight[0]);
            txtvector[0, 1] = new Vector2(GraphicsDevice.Viewport.Width/2 + GraphicsDevice.Viewport.Width/4 - wordwidth[1]/2, GraphicsDevice.Viewport.Height/2  - wordheight[1]);
            txtvector[1, 0] = new Vector2(GraphicsDevice.Viewport.Width / 2 - GraphicsDevice.Viewport.Width/4 - wordwidth[2]/2, GraphicsDevice.Viewport.Height  - wordheight[2]);
            txtvector[1, 1] = new Vector2(GraphicsDevice.Viewport.Width / 2 + GraphicsDevice.Viewport.Width/4 - wordwidth[3]/2, GraphicsDevice.Viewport.Height - wordheight[3]);

            //once hit 255 gently decrease
            //usses bools to go up and down by changin true and false values

            if (redIntensity == 225)
                //make bool false so can decrease
                redCountingUp = false;
            if (redIntensity == 0)
                //set bool to true to start increaseing again
                redCountingUp = true;

            if (redCountingUp)
                //inscrease insity(== 0)
                redIntensity++;
            else
                //decrease inswisity for colour
                redIntensity--;


            //control blue value to increase or decrease depending on colour tone from 0 - 225

            if (blueIntensity == 225)
                blueCountingUp = false;
            if (blueIntensity == 0)
                blueCountingUp = true;

            if (blueCountingUp)
                blueIntensity++;
            else
                blueIntensity--;

            //control green value to increase or decrease depending on colour tone from 0 - 225
            if (greenIntensity == 225)
                greenCountingUp = false;
            if (greenIntensity == 0)
                greenCountingUp = true;

            if (greenCountingUp)
                greenIntensity++;
            else
                greenIntensity--;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
           // GraphicsDevice.Clear(Color.CornflowerBlue);
            
            //set each array ofr the picture to a differetnt colour value that changes
            piccolour[0] = new Color(redIntensity -100, greenIntensity, blueIntensity -50);
            piccolour[1] = new Color(redIntensity + 100, greenIntensity, blueIntensity);
            piccolour[2] = new Color(redIntensity , greenIntensity + 100, blueIntensity );
            piccolour[3] = new Color(redIntensity, greenIntensity, blueIntensity + 100);

            spriteBatch.Begin();
            //draws puppy picture on screen in array rec position with piccolour 
            spriteBatch.Draw(puppypic, picrec[0, 0], piccolour[0]);
            spriteBatch.Draw(puppypic, picrec[0, 1], piccolour[1]);
            spriteBatch.Draw(puppypic, picrec[1, 0], piccolour[2]);
            spriteBatch.Draw(puppypic, picrec[1, 1], piccolour[3]);

            //drws the text on screen using the right font and which text and txtvector in each array, text colour is white
            spriteBatch.DrawString(font, text[0, 0], txtvector[0, 0], Color.White);
            spriteBatch.DrawString(font, text[0, 1], txtvector[0, 1], Color.White);
            spriteBatch.DrawString(font, text[1, 0], txtvector[1, 0], Color.White);
            spriteBatch.DrawString(font, text[1, 1], txtvector[1, 1], Color.White);

            //clear colour on screen to add new colour
            GraphicsDevice.Clear(piccolour[0]);
            GraphicsDevice.Clear(piccolour[1]);
            GraphicsDevice.Clear(piccolour[2]);
            GraphicsDevice.Clear(piccolour[3]);
            spriteBatch.End();
        

            base.Draw(gameTime);
        }
    }
}
