﻿/*******************************************************************************************
*
*   raylib [core] example - Basic window
*
*   Welcome to raylib!
*
*   To test examples, just press F6 and execute raylib_compile_execute script
*   Note that compiled executable is placed in the same folder as .c file
*
*   You can find all basic examples on C:\raylib\raylib\examples folder or
*   raylib official webpage: www.raylib.com
*
*   Enjoy using raylib. :)
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2013-2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

using Raylib_cs;

// Initialization
//--------------------------------------------------------------------------------------


Board board = new (Board.StandardBoard);
BoardRenderer boardRenderer = new ();

int screenWidth = board.Columns * BoardRenderer.CellSize;
int screenHeight = board.Rows * BoardRenderer.CellSize;

Raylib.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");
Raylib.SetWindowMonitor(1);
Raylib.SetWindowSize(screenWidth, screenHeight);
Raylib.SetTargetFPS(60);

int ticks = 0;

SpriteSheet sheet = SpriteSheet.Load("assets/sprites/capman.png", 1, 3);
AnimatedSprite capmanSprite = new AnimatedSprite(sheet, [(0, 0), (0, 1), (0, 2), (0, 1)]);
CapMan capMan = new CapMan();
capMan.Y = 23 * BoardRenderer.CellSize;
capMan.X = 14 * BoardRenderer.CellSize;

// Main game loop
while (!Raylib.WindowShouldClose())
{
    HandleInput();
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);
    boardRenderer.Render(board, 0, 0);
    DoThing();
    Raylib.EndDrawing();
    ticks++;
}

Raylib.CloseWindow();

void DoThing()
{
    capMan.Update(Raylib.GetFrameTime());
    capmanSprite.Draw((int)capMan.X, (int)capMan.Y);
}

void HandleInput()
{
    if (Raylib.IsKeyDown(KeyboardKey.W))
    {
        capMan.CurrentDirection = Direction.Up;
    }
    if (Raylib.IsKeyDown(KeyboardKey.D))
    {
        capMan.CurrentDirection = Direction.Right;
    }
    if (Raylib.IsKeyDown(KeyboardKey.A))
    {
        capMan.CurrentDirection = Direction.Left;
    }
    if (Raylib.IsKeyDown(KeyboardKey.S))
    {
        capMan.CurrentDirection = Direction.Down;
    }
}

