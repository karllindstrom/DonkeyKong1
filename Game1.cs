using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

using System.IO;

namespace DonkeyKong1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Tile[,] tileArray;
        public static int tileSize = 40; //Game1.tileSize

        Vector2 pos;

        Mario mario;
        DK dk;
        Pauline pauline;
        List<Enemy> enemyList = new List<Enemy>();
        Enemy enemy;
        public float speed;
        
        public  static int lives = 3;

        public bool invincible;
        public float cooldown = 3f;
        public enum GameState
        {
            MainMenu,
            InGame,
            GameOver,
            Win
        }

        public GameState currentState;

    

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            currentState = GameState.MainMenu;
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.PreferredBackBufferWidth = 900;

            _graphics.ApplyChanges();

            TextureHandler.LoadTextures(Content);


            CreateLevel("map.txt");




        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyboardState = Keyboard.GetState();

            switch (currentState)
            {
                case GameState.MainMenu:

                    if (keyboardState.IsKeyDown(Keys.Enter))
                    {
                        currentState = GameState.InGame;
                        
                    }
                    

                    break;
                case GameState.InGame:

                    Window.Title = $"{lives}";

                    if (invincible)
                    {
                        cooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                        if(cooldown <= 0)
                        {
                            invincible = false;
                            cooldown = 3f;
                        }
                    }

                    foreach (var enemy in enemyList)
                    {
                        enemy.Update(gameTime);
                        if (mario.GetBounds().Intersects(enemy.GetBounds()) && !invincible)
                        {

                            lives--;
                            invincible = true;
                        }
                    }
                    
                    if(lives == 0)
                    {
                        currentState = GameState.GameOver;
                    }


                    mario.Update(gameTime);

                    if (mario.GetBounds().Intersects(dk.GetBounds()) && !invincible)
                    {
                        currentState = GameState.GameOver;
                    }

                    if (mario.GetBounds().Intersects(pauline.GetBounds()))
                    {
                        currentState = GameState.Win;
                    }

                    break;
                case GameState.GameOver:

                   
                    if (keyboardState.IsKeyDown(Keys.Enter))
                    {
                        currentState = GameState.InGame;
                        enemyList.Clear();
                        CreateLevel("map.txt");
                        lives = 3;
                        cooldown = 3f;
                        invincible = false;

                    }

                    break;
                case GameState.Win:

                    if (keyboardState.IsKeyDown(Keys.Enter))
                    {
                        currentState = GameState.InGame;
                        enemyList.Clear();
                        CreateLevel("map.txt");
                        lives = 3;
                        cooldown = 3f;
                        invincible = false;

                    }

                    break;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            switch (currentState)
            {
                case GameState.MainMenu:

                    _spriteBatch.Draw(TextureHandler.texStart, Vector2.Zero, Color.White);

                    break;
                case GameState.InGame:

                    foreach (Tile t in tileArray)
                    {
                        t.Draw(_spriteBatch);
                    }
                    dk.Draw(_spriteBatch);


                    pauline.Draw(_spriteBatch);
                    foreach (Enemy enemy in enemyList)
                    {
                        enemy.Draw(_spriteBatch);
                    }

                    mario.Draw(_spriteBatch);

                    break;
                case GameState.GameOver:

                    _spriteBatch.Draw(TextureHandler.texLoose, Vector2.Zero, Color.White);

                    break;
                case GameState.Win:

                    _spriteBatch.Draw(TextureHandler.texWin, Vector2.Zero, Color.White);

                    break;

            }

            //foreach (Tile t in tileArray)
            //{
            //    t.Draw(_spriteBatch);
            //}
            //dk.Draw(_spriteBatch);
            
            
            //pauline.Draw(_spriteBatch);
            //foreach (Enemy enemy in enemyList)
            //{
            //    enemy.Draw(_spriteBatch);
            //}

            //mario.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        public List<string> ReadFromFile(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            List<string> result = new List<string>();

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                result.Add(line);
                System.Diagnostics.Debug.WriteLine(line);
            }
            streamReader.Close();
            return result;
        }

        public void CreateLevel(string fileName)
        {
            List<string> list = ReadFromFile("map.txt");

            tileArray = new Tile[list[0].Length, list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[0].Length; j++)
                {
                    if (list[i][j] == 'b')
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureHandler.texBridge, false);
                    }
                    else if (list[i][j] == 'l')
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureHandler.texLadder, true);
                    }
                    else if (list[i][j] == 't')
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureHandler.texBridgeLadder, true);
                    }
                    else if (list[i][j] == 'e')
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureHandler.texEmpty, false);
                    }
                    else if (list[i][j] == 'w')
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureHandler.texEmpty, true);
                    }

                    if (list[i][j] == 'm')
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureHandler.texEmpty, true);
                        mario = new Mario(new Vector2(j * tileSize, i * tileSize));
                    }
                    if (list[i][j] == 'p')
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureHandler.texEmpty, true);
                        pauline = new Pauline(new Vector2(j * tileSize, i * tileSize));
                    }
                    if (list[i][j] == 'd')
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureHandler.texEmpty, false);
                        dk = new DK(new Vector2(j * tileSize, i * tileSize));
                    }
                    if (list[i][j] == 'E')
                    {
                        tileArray[j, i] = new Tile(new Vector2(j * tileSize, i * tileSize), TextureHandler.texEmpty, true);
                        enemyList.Add(new Enemy(new Vector2(j * tileSize, i * tileSize), 2f, 3f));
                    }


                }

            }
        }

        public static bool GetTileAtPosition(Vector2 pos)
        {
            return tileArray[(int)pos.X / tileSize, (int)pos.Y / tileSize].walkable;
        }
    }
}