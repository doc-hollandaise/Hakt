using System;
using System.Collections.Generic;
using System.Net.Mime;
using Controls;
using HaktComponent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DetailScreen : GameScreen
{


    private Texture2D starAtlas;
    public int Rows { get; set; }
    public int Columns { get; set; }
    private int imageWidth;
    private int imageHeight;
    private List<Component> _gameComponents;

    //  Goals
    //  show 4 items
    //  have items be different colors
    //  have 1 items be a different shape
    //  on user tap
    //      - determine if shape does not fit
    //      - if it does not, user wins, go back 1 screen
    //      - if it does, shape will shake and user must pick again

    //  setup interface or function to return drawn object rectangle
    //  setup gameShape to take proper arguments and opilate constructor
    //  setup gamershape to allow tapping

    //  Setup methods to draw Gameshapes

    public DetailScreen(Game1 game, GraphicsDeviceManager graphics) : base(game, graphics)
    {


    }

    public override void Initialize()
    {
        // Update logic for DetailScreen
        Console.WriteLine("DETAIL INIT");
    }

    public override void LoadContent()
    {
        // Draw logic for DetailScreen
        starAtlas = game.Content.Load<Texture2D>("stars");
        imageWidth = starAtlas.Width / 2;
        imageHeight = starAtlas.Height / 2;

        var backButton = new Button(game.Content.Load<Texture2D>("Button"), game.Content.Load<SpriteFont>("Font"))
        {
            Position = new Vector2(10, 50),
            Text = "Random",
        };
        backButton.Click += BackButton_Click;

        _gameComponents = new List<Component>()
      {
        backButton,
      };
    }

    public override void Update(GameTime gameTime)
    {
        // Update logic for DetailScreen
        foreach (var component in _gameComponents)
            component.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {


        // Draw logic for DetailScreen
        Rectangle topLeft = new Rectangle(0, 0, imageWidth, imageHeight);
        Rectangle topRight = new Rectangle(imageWidth, 0, imageWidth, imageHeight);
        Rectangle bottomLeft = new Rectangle(0, imageHeight, imageWidth, imageHeight);
        Rectangle bottomRight = new Rectangle(imageWidth, imageHeight, imageWidth, imageHeight);
        Vector2 start = new Vector2(centerX, centerY);

        foreach (var component in _gameComponents)
            component.Draw(spriteBatch);

        spriteBatch.Draw(starAtlas, start, topLeft, Color.White);
        spriteBatch.Draw(starAtlas, new Vector2(imageWidth, 0), topRight, Color.White);
        spriteBatch.Draw(starAtlas, new Vector2(0, imageHeight), bottomLeft, Color.White);
        spriteBatch.Draw(starAtlas, new Vector2(imageWidth, imageHeight), bottomRight, Color.White);
    }

    private void BackButton_Click(object sender, EventArgs e)
    {

    }
}





