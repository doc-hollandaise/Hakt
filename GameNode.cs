

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
    public Texture2D NodeBG { get; set; }
    private Rectangle DestinationRectangle { get; set; }
    public Game1 ParentGame { get; set; }

    public GameNode(Vector2 position, float radius, Color color, string label, Texture2D image)
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

    }

    public GameNode(System.Numerics.Vector2 position, float radius, Color borderColor, string label)
    {
        Position = position;
        Radius = radius;
        this.borderColor = borderColor;
        Label = label;
    }

    public void LoadContent(Game1 game)
    {
        ParentGame = game;
        NodeBG = game.Content.Load<Texture2D>("node");
        DestinationRectangle = new Rectangle((int)Position.X - 75, (int)Position.Y - 75, 150, 150);
    }

    public void Update(GameTime gameTime, MouseState mouseState)
    {
        isHovered = Vector2.Distance(mouseState.Position.ToVector2(), Position) < Radius;
        // Check for click and proximity
        if (mouseState.LeftButton == ButtonState.Pressed && isHovered)
        {
            IsClicked = true;
            hasBeenClicked = true;


            ParentGame.ScreenManager.ChangeScreen(new DetailScreen(ParentGame));
        }

        if (isHovered && !hasBeenClicked)
        {
            AnimationProgress += (float)gameTime.ElapsedGameTime.TotalSeconds;
            float baseScale = 1.0f;
            float scaleRange = 0.2f;
            float scale = baseScale + (float)Math.Sin(AnimationProgress * 2 * Math.PI / 1) * scaleRange; // Complete a cycle every 1 second

            // Adjust the position and size based on the scale
            int scaledWidth = (int)(150 * scale);
            int scaledHeight = (int)(150 * scale);
            int offsetX = (scaledWidth - 150) / 2; // Ensure the growth is centered
            int offsetY = (scaledHeight - 150) / 2;

            DestinationRectangle = new Rectangle((int)Position.X - 75 - offsetX, (int)Position.Y - 75 - offsetY, scaledWidth, scaledHeight);
            if (AnimationProgress >= Game1.AnimationDuration)
            {
                AnimationProgress = 0f;
                DestinationRectangle = new Rectangle((int)Position.X - 75, (int)Position.Y - 75, 150, 150);

                // Trigger any specific action for this GameNode
            }
        }

        if (!isHovered && AnimationProgress >= Game1.AnimationDuration)
        {
            AnimationProgress = 0f;

            // Trigger any specific action for this GameNode
        }
    }

    public void Draw(SpriteBatch spriteBatch, SpriteFont font)
    {


        spriteBatch.Draw(NodeBG, DestinationRectangle, Color.White);

        // spriteBatch.DrawCircle(Position, animatedRadius, Game1.LineThickness, Color); // Assuming the DrawCircle extension method
        // spriteBatch.DrawString(font, Label, Position - font.MeasureString(Label) / 2, Color.Black); // Center the label

        // Draw the image if the node has been clicked and animation is completed
        if (hasBeenClicked)
        {
            spriteBatch.Draw(CrossOut, new Rectangle((int)(Position.X - 50), (int)Position.Y - 39, 100, 78), Color.White);
        }

    }
}
