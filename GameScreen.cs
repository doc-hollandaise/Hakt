using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class GameScreen
{
    protected Game1 game;

    public GameScreen(Game1 game)
    {
        this.game = game;
    }

    public abstract void Update(GameTime gameTime);

    public abstract void LoadContent();
    public abstract void Draw(SpriteBatch spriteBatch);
}
