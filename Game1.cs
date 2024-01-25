using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


public static class SpriteBatchExtensions
{
    public static void DrawCircle(this SpriteBatch spriteBatch, Vector2 center, float radius, float thickness, Color color, int segments = 32)
    {
        float angleIncrement = MathHelper.TwoPi / segments;

        for (int i = 0; i < segments; i++)
        {
            float angle1 = i * angleIncrement;
            float angle2 = (i + 1) * angleIncrement;

            Vector2 point1 = center + new Vector2((float)Math.Cos(angle1) * radius, (float)Math.Sin(angle1) * radius);
            Vector2 point2 = center + new Vector2((float)Math.Cos(angle2) * radius, (float)Math.Sin(angle2) * radius);

            spriteBatch.DrawLine(point1, point2, thickness, color);
        }
    }

    public static void DrawLine(this SpriteBatch spriteBatch, Vector2 start, Vector2 end, float thickness, Color color)
    {
        Vector2 direction = end - start;
        float angle = (float)Math.Atan2(direction.Y, direction.X);

        spriteBatch.Draw(Game1.Pixel, start, null, color, angle, Vector2.Zero, new Vector2(direction.Length(), thickness), SpriteEffects.None, 0);
    }
}

public class Game1 : Game
{
    public ScreenManager ScreenManager { get; private set; }
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private float lineThickness = 2f;

    public Texture2D CrossOut { get; set; }
    private SpriteFont font;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = 1280,
            PreferredBackBufferHeight = 720
        };
        graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        ScreenManager = new ScreenManager();
        ScreenManager.ChangeScreen(new MainGameScreen(this));
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        font = Content.Load<SpriteFont>("font");
        CrossOut = Content.Load<Texture2D>("crossout");
        Pixel = new Texture2D(GraphicsDevice, 1, 1);
        Pixel.SetData(new[] { Color.White });
        ScreenManager.LoadContent();
        base.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        ScreenManager.Update(gameTime);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        spriteBatch.Begin();
        ScreenManager.Draw(spriteBatch);
        spriteBatch.End();
        base.Draw(gameTime);
    }

    public static Texture2D Pixel { get; private set; }
    public static float AnimationDuration = 0.5f;
    public static float LineThickness = 2f;
}

