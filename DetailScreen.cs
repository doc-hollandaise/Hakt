using System;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class DetailScreen : GameScreen
{


    private Texture2D starAtlas;
    public int Rows { get; set; }
    public int Columns { get; set; }
    private int imageWidth;
    private int imageHeight;


    public DetailScreen(Game1 game) : base(game)
    {


    }

    public override void Initialize()
    {
        // Update logic for DetailScreen
        Console.WriteLine("DETAIL INIT");
    }

    public override void LoadContent()
    {
        Console.WriteLine("LOAD CONTENT");
        // Draw logic for DetailScreen
        starAtlas = game.Content.Load<Texture2D>("stars");
        imageWidth = starAtlas.Width / 2;
        imageHeight = starAtlas.Height / 2;
        Console.WriteLine("HeightWidth: " + imageHeight);
    }

    public override void Update(GameTime gameTime)
    {
        // Update logic for DetailScreen
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        // Draw logic for DetailScreen
        Rectangle sourceRectangle = new Rectangle(imageWidth, 0, imageWidth, imageHeight); // For top-right image
        Vector2 start = new Vector2(0, 0);
        spriteBatch.Draw(starAtlas, start, sourceRectangle, Color.White); // 'position' is where you want to draw the image
    }


}


//  shape matching puzzle
//  show 4 shapes; choose which doesnt belong