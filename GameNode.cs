

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class GameNode
{
    private Color borderColor;

    public Vector2 Position { get; set; }
    public float Radius { get; set; }
    public Color Color { get; set; }
    public string Label { get; set; }
    public bool IsClicked { get; set; }

    public bool isHovered { get; set; }
    private bool hasBeenClicked { get; set; }
    public float AnimationProgress { get; set; }
    public Texture2D CrossOut { get; set; }
    public Game1 parentGame { get; }

    public GameNode(Vector2 position, float radius, Color color, string label, Texture2D image, Game1 game)
    {
        Position = position;
        Radius = radius;
        Color = color;
        Label = label;
        IsClicked = false;
        isHovered = false;
        hasBeenClicked = false;
        AnimationProgress = 0f;
        CrossOut = image;
        parentGame = game;

    }

    public GameNode(System.Numerics.Vector2 position, float radius, Color borderColor, string label)
    {
        Position = position;
        Radius = radius;
        this.borderColor = borderColor;
        Label = label;
    }

    public void Update(GameTime gameTime, MouseState mouseState)
    {
        isHovered = Vector2.Distance(mouseState.Position.ToVector2(), Position) < Radius;
        // Check for click and proximity
        if (mouseState.LeftButton == ButtonState.Pressed && isHovered)
        {
            IsClicked = true;
            hasBeenClicked = true;


            parentGame.ScreenManager.ChangeScreen(new DetailScreen(parentGame));
        }

        if (isHovered && !hasBeenClicked)
        {
            AnimationProgress += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (AnimationProgress >= Game1.AnimationDuration)
            {
                AnimationProgress = 0f;
                // Trigger any specific action for this GameNode
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch, SpriteFont font)
    {


        float scale = isHovered && !hasBeenClicked ? 1.0f + 0.1f * (float)Math.Sin(MathHelper.Pi * AnimationProgress / Game1.AnimationDuration) : 1.0f;
        float animatedRadius = Radius * scale;

        spriteBatch.DrawCircle(Position, animatedRadius, Game1.LineThickness, Color); // Assuming the DrawCircle extension method
        spriteBatch.DrawString(font, Label, Position - font.MeasureString(Label) / 2, Color.Black); // Center the label

        // Draw the image if the node has been clicked and animation is completed
        if (hasBeenClicked)
        {
            spriteBatch.Draw(CrossOut, new Rectangle((int)(Position.X - 50), (int)Position.Y - 39, 100, 78), Color.White);
        }

    }
}
