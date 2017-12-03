//jade legare
//health bar
//march 1st

/*
-	start 
-	declare variables for the child pictures and rectangle and chosen pic 
-	declare the bottle rectangle list and bottle pic 
-	declare bools for each health bar section 
-	initialize all the rectangles 
-	load all the photos and set to each of the variables
-	declare the gamepad and keyboard state
-	check to see if the child intersects with any of the bottles in the list 
-	if they intersect with one, remove that bottle from the screen, add a new bottle and set one of the healthy bool to true
-	check if the child intersects with all three of the bottles 
-	if keyboard key up is pressed or the thumbstick on the controller is moves up, set the chosenpic variable to the picture of the child walking upward and decrease the y value so the rectangle moves on the screen
-	if keyboard key down is pressed or the thumbstick on the controller is moves down, set the chosenpic variable to the picture of the child walking downward and insceases the y value so the rectangle moves on the screen
-	if keyboard key left is pressed or the thumbstick on the controller is moves left, set the chosenpic variable to the picture of the child walking lef and decrease the x value so the rectangle moves on the screen
-	if keyboard key right is pressed or the thumbstick on the controller is moves right, set the chosenpic variable to the picture of the child walking right and increase the x value so the rectangle moves on the screen
-	if none of these are pressed set a default picture of the child for the chosen pic value
-	draw the bottles and child on the screen 
-	depending on which healthy bool is true, add a red section to the health bar
-	end

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

namespace Health_Bar
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //medacine bottle array
        
        List <Rectangle> bottlerec;


        Texture2D bottlepic;
        Texture2D hospitalpic;
        Rectangle rechospital;

        Rectangle childrec;
        Texture2D[] childpic = new Texture2D[5];
        Texture2D chosenpic;

        List <Rectangle> health;
        Texture2D red;
       

        bool healthy = false;
        bool healthy2 = false;
        bool healthy3 = false;

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
            bottlerec = new List<Rectangle>();

            //retcangle for each array value
            bottlerec.Add(new Rectangle(600, 400, 50, 50)); 
            bottlerec.Add( new Rectangle(350, 400, 50, 50));
            bottlerec.Add( new Rectangle(400, 100, 50, 50));
            bottlerec.Add(new Rectangle(600, 200, 50, 50));

            //initialize health rectangle 
            health = new List<Rectangle>();
            //draw on screen 
            health.Add(new Rectangle(575, 0, 25, 10));
            health.Add(new Rectangle(600, 0, 25, 10));
            health.Add(new Rectangle(625, 0, 25, 10));
            health.Add(new Rectangle(650, 0, 25, 10));
            health.Add(new Rectangle(680, 0, 25, 10));
            //rectangle to hold picture of kid
            childrec = new Rectangle(600, 400, 70, 70);
            rechospital = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
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

            red = this.Content.Load<Texture2D>("red");
            //hospital pics for background 
            hospitalpic = this.Content.Load < Texture2D>("Hospital Parking Lot" );
            //medacine bottle pic
            bottlepic = this.Content.Load<Texture2D>("Medicine Bottle");
           

            //picture of little kid
            childpic[4] = Content.Load<Texture2D>("Raul 1Up");
            childpic[1] = Content.Load<Texture2D>("Raul Down");
            childpic[2] = Content.Load<Texture2D>("Raul Left");
            childpic[3] = Content.Load<Texture2D>("Raul Right");
            
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
            // if the user presses the back button the game ends
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            



            GamePadState pad1 = GamePad.GetState(PlayerIndex.One);
            KeyboardState KB = Keyboard.GetState();

            
            //check if inersects with any of the 3 bottles
            if (childrec.Intersects(bottlerec[1])) 
                {
                //removes the bottle
                bottlerec.RemoveAt(1);
                //adds a new bottle so numbers dont change
                bottlerec.Add(new Rectangle(600, 600, 50, 50));
                //set bool to true
                healthy = true;
                 }
            if (childrec.Intersects(bottlerec[2]))
            {
                //removes the bottle 
                bottlerec.RemoveAt(2);
                //adds a bottle so list numbers dont change
                bottlerec.Add(new Rectangle(600, 600, 50, 50));
                //set bool to true
                healthy2 = true;
            }
            if (childrec.Intersects(bottlerec[3]))
            {
                bottlerec.RemoveAt(3);
                health.Add(new Rectangle(650, 0, 50, 10));
                bottlerec.Add(new Rectangle(600, 600, 50, 50));
                healthy3 = true;
            }






            //depending on which key on kyeborad is pressed or thumpad moved on eh controller the child will move up, down, left or right
            if (KB.IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == 1.0f)
            {
                chosenpic = childpic[4];
                childrec.Y--;
            }

           else  if (KB.IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == -1.0f)
            {
                chosenpic = childpic[1];
                childrec.Y++;
            }

            else if (KB.IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == -1.0f)
            {
                chosenpic = childpic[2];
                childrec.X--;
            }

           else  if (KB.IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == 1.0f)
            {
                chosenpic = childpic[3];
                childrec.X++;
            }
            //setdefaly to pic chosenpic is set to the child going up
            else
            {
                chosenpic = childpic[4];
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
            //draws hoapital as background on school
            spriteBatch.Draw(hospitalpic, rechospital, Color.White);
            //pruint ech bottle on the screen

            spriteBatch.Draw(bottlepic, bottlerec[1], Color.White);
            spriteBatch.Draw(bottlepic, bottlerec[2], Color.White);
            spriteBatch.Draw(bottlepic, bottlerec[3], Color.White);


            //draws the kid on the screen
            spriteBatch.Draw(chosenpic, childrec, Color.White);

            //draw health bar 
            spriteBatch.Draw(red, health[0], Color.White);

            if (healthy == true)
            {
                spriteBatch.Draw(red, health[1], Color.White);
            }
            if (healthy2 == true)
            {
                spriteBatch.Draw(red, health[2], Color.White);
            }
            if (healthy3 == true)
            {
                spriteBatch.Draw(red, health[3], Color.White);
            }



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
