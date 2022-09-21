using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;

namespace sample;
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;
    Texture2D myTexture;
    Texture2D cloudTexture;
    Vector2[] scaleCloud;
    Vector2[] Cloudsama;
    Vector2 spritePosition = Vector2.Zero;
    int frame = 3;
    int[] speed;
    Random r = new Random();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        spriteBatch = new SpriteBatch(GraphicsDevice);
        myTexture = Content.Load<Texture2D>("NatureSprite");
        cloudTexture = Content.Load<Texture2D>("Cloud_sprite");
        speed = new int[4];
        Cloudsama = new Vector2[4];
        scaleCloud = new Vector2[4];
        for (int i = 0; i < 4; i++)
        {
            Cloudsama[i].Y = r.Next(0, GraphicsDevice.Viewport.Height - 112);
            scaleCloud[i].X = r.Next(1, 5);
            scaleCloud[i].Y = scaleCloud[i].X;
            speed[i] = r.Next(3, 7);
        }

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        for (int i = 0; i < 4; i++)
        {
            Cloudsama[i].X = Cloudsama[i].X + speed[i];

            scaleCloud[i].Y = scaleCloud[i].X;
            if (Cloudsama[i].X > GraphicsDevice.Viewport.Width)
            {
                Cloudsama[i].X = 0;
                Cloudsama[i].Y = r.Next(0, GraphicsDevice.Viewport.Height - 112);
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        GraphicsDevice.Clear(new Color(85, 133, 50));
        spriteBatch.Begin();
        spriteBatch.Draw(myTexture, new Vector2(1, 1), new Rectangle(64 * 4, 64 * 2, 64 * 4, 64 * 4), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(320, 64), new Rectangle(64, 0, 64, 64), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(320, 128), new Rectangle(64, 0, 64, 64), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(320, 192), new Rectangle(64, 0, 64, 64), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(320, 250), new Rectangle(64, 0, 64, 64), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(256, 250), new Rectangle(64, 0, 64, 64), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(512, 160), new Rectangle(64 * 2, 0, 64, 64), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(416, 282), new Rectangle(64 * 2, 0, 64, 64), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(128, 320), new Rectangle(0, 64 * 3, 64 * 2, 64 * 2), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(384, 64), new Rectangle(0, 0, 64, 64), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(608, 266), new Rectangle(0, 0, 64, 64), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(512, 330), new Rectangle(0, 64, 64, 64), Color.White);
        spriteBatch.Draw(myTexture, new Vector2(608, 96), new Rectangle(64 * 2, 64 * 4, 64 * 2, 64 * 2), Color.White);
        for (int i = 0; i < 4; i++)
        {
            spriteBatch.Draw(cloudTexture, Cloudsama[i], null, Color.White, 0, Vector2.Zero, scaleCloud[i], 0, 0);

        }
        spriteBatch.End();
        base.Draw(gameTime);
    }
}
