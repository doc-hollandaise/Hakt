using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ScreenManager
{
    private GameScreen currentScreen;
    private Game1 Game { get; }
    private GraphicsDeviceManager Graphics { get; }

    public ScreenManager(Game1 game1, GraphicsDeviceManager graphics)
    {
        Game = game1;
        Graphics = graphics;
    }



    public enum ScreenType
    {
        MainGameScreen,
        DetailScreen,
    }

    public void ChangeScreen(ScreenType screen)
    {
        switch (screen)
        {
            case ScreenType.MainGameScreen:
                currentScreen = new MainGameScreen(Game, Graphics);
                break;
            case ScreenType.DetailScreen:
                currentScreen = new DetailScreen(Game, Graphics);
                break;
            default:
                throw new System.ArgumentException("Invalid screen type");
        }

        currentScreen.Initialize();
        currentScreen?.LoadContent();


    }

    public void Initialize()
    {
        currentScreen?.Initialize();
    }

    public void LoadContent()
    {
        currentScreen?.LoadContent();
    }
    public void Update(GameTime gameTime)
    {
        currentScreen?.Update(gameTime);
    }


    public void Draw(SpriteBatch spriteBatch)
    {
        currentScreen?.Draw(spriteBatch);
    }
}
