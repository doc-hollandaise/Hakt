using Microsoft.Xna.Framework;

public class NodeData
{
    public System.Numerics.Vector2 Position { get; set; }
    public float Radius { get; set; }

    private Color _color;
    public string ColorString
    {
        get => _color.ToString();
        set => _color = ParseColor(value);
    }

    public string Label { get; set; }

    private Color ParseColor(string colorName)
    {
        System.Console.WriteLine("COLOR NAME: " + colorName);
        switch (colorName)
        {
            case "Red": return Color.Red;
            case "Blue": return Color.Blue;
            case "Green": return Color.Green;
            // Add more cases as needed
            default: return Color.White;
        }
    }

    public Color GetColor()
    {
        return _color;
    }
}
