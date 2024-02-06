using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class GameScreen
{

    protected Game1 game;
    protected int centerX;
    protected int centerY;

    public GameScreen(Game1 game, GraphicsDeviceManager graphics)
    {
        this.game = game;
        centerX = graphics.PreferredBackBufferWidth / 2;
        centerY = graphics.PreferredBackBufferHeight / 2;
    }

    public abstract void Initialize();

    public abstract void LoadContent();
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);
}
