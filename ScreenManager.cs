using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ScreenManager
{
    private GameScreen currentScreen;

    public void ChangeScreen(GameScreen screen)
    {
        currentScreen = screen;
    }

    public void Update(GameTime gameTime)
    {
        currentScreen?.Update(gameTime);
    }

    public void LoadContent()
    {
        currentScreen?.LoadContent();
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        currentScreen?.Draw(spriteBatch);
    }
}
