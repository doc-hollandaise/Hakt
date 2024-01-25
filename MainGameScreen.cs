using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


public class MainGameScreen : GameScreen
{
    private List<GameNode> nodes;
    private SpriteFont font;
    private Texture2D crossOut;
    private float lineThickness;

    public MainGameScreen(Game1 game) : base(game)
    {
        nodes = new List<GameNode>();
        lineThickness = 2f;
    }

    public override void LoadContent()
    {
        font = game.Content.Load<SpriteFont>("font");
        crossOut = game.Content.Load<Texture2D>("crossout");

        Console.WriteLine("LOADING");

        string jsonText = File.ReadAllText("nodeData.json");
        List<NodeData> nodeDatas = JsonConvert.DeserializeObject<List<NodeData>>(jsonText);

        foreach (var nodeData in nodeDatas)
        {
            Color borderColor = nodeData.GetColor();
            nodes.Add(new GameNode(nodeData.Position, nodeData.Radius, borderColor, nodeData.Label, crossOut, game));
        }

    }

    public override void Update(GameTime gameTime)
    {
        MouseState mouseState = Mouse.GetState();

        foreach (var node in nodes)
        {
            node.Update(gameTime, mouseState);
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        foreach (var node in nodes)
        {
            node.Draw(spriteBatch, font);
        }

        // Draw lines between nodes
        for (int i = 0; i < nodes.Count - 1; i++)
        {
            var startNode = nodes[i];
            var endNode = nodes[i + 1];

            Vector2 direction = Vector2.Normalize(endNode.Position - startNode.Position);
            Vector2 start = startNode.Position + direction * startNode.Radius;
            Vector2 end = endNode.Position - direction * endNode.Radius;

            spriteBatch.DrawLine(start, end, lineThickness, Color.Black);
        }
    }
}

