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

    private int atlasXOffset;
    private int atlasYOffset;

    private int gridSpacing = 10;
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
        atlasXOffset = imageWidth;
        atlasYOffset = imageHeight;

        var backButton = new Button(game.Content.Load<Texture2D>("Button"), game.Content.Load<SpriteFont>("Font"))
        {
            Position = new Vector2(centerX - 63, 100),
            Text = "BACK",
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

        Vector2 startTopLeft = new Vector2(centerX - atlasXOffset - gridSpacing / 2, centerY - atlasYOffset);
        Vector2 startTopRight = new Vector2(centerX + gridSpacing / 2, centerY - atlasYOffset);
        Vector2 startBottomLeft = new Vector2(centerX - atlasXOffset - gridSpacing / 2, centerY + gridSpacing);
        Vector2 startBottomRight = new Vector2(centerX + gridSpacing / 2, centerY + gridSpacing);

        foreach (var component in _gameComponents)
            component.Draw(spriteBatch);

        spriteBatch.Draw(starAtlas, startTopLeft, topLeft, Color.White);
        spriteBatch.Draw(starAtlas, startTopRight, topRight, Color.White);
        spriteBatch.Draw(starAtlas, startBottomLeft, bottomLeft, Color.White);
        spriteBatch.Draw(starAtlas, startBottomRight, bottomRight, Color.White);

        // spriteBatch.DrawLine(new Vector2(centerX, 0), new Vector2(centerX, 700), 1.0f, Color.Black);
    }

    private void BackButton_Click(object sender, EventArgs e)
    {
        game.ScreenManager.ChangeScreen(ScreenManager.ScreenType.MainGameScreen);
    }
}





