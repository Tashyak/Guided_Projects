using System;

const int width = 30;
const int height = 12;
const int targetFood = 5;

Random random = new Random();
int playerX = width / 2;
int playerY = height / 2;
int foodX = 0;
int foodY = 0;
int score = 0;
int dx = 1;
int dy = 0;
bool isGameOver = false;

Console.CursorVisible = false;
PlaceFood();

while (!isGameOver)
{
	if (Console.KeyAvailable)
	{
		ConsoleKeyInfo key = Console.ReadKey(true);

		if (key.Key == ConsoleKey.UpArrow && dy != 1)
		{
			dx = 0;
			dy = -1;
		}
		else if (key.Key == ConsoleKey.DownArrow && dy != -1)
		{
			dx = 0;
			dy = 1;
		}
		else if (key.Key == ConsoleKey.LeftArrow && dx != 1)
		{
			dx = -1;
			dy = 0;
		}
		else if (key.Key == ConsoleKey.RightArrow && dx != -1)
		{
			dx = 1;
			dy = 0;
		}
		else if (key.Key == ConsoleKey.Escape)
		{
			isGameOver = true;
		}
	}

	playerX += dx;
	playerY += dy;

	if (playerX <= 0 || playerX >= width - 1 || playerY <= 0 || playerY >= height - 1)
	{
		isGameOver = true;
	}

	if (!isGameOver && playerX == foodX && playerY == foodY)
	{
		score++;

		if (score >= targetFood)
		{
			isGameOver = true;
		}
		else
		{
			PlaceFood();
		}
	}

	Render();
	Thread.Sleep(140);
}

Console.SetCursorPosition(0, height + 2);
Console.WriteLine(score >= targetFood
	? $"You won! You ate {score} food items."
	: $"Game over. Final score: {score}");

void PlaceFood()
{
	do
	{
		foodX = random.Next(1, width - 1);
		foodY = random.Next(1, height - 1);
	}
	while (foodX == playerX && foodY == playerY);
}

void Render()
{
	Console.SetCursorPosition(0, 0);

	for (int y = 0; y < height; y++)
	{
		for (int x = 0; x < width; x++)
		{
			if (x == playerX && y == playerY)
			{
				Console.Write('@');
			}
			else if (x == foodX && y == foodY)
			{
				Console.Write('*');
			}
			else if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
			{
				Console.Write('#');
			}
			else
			{
				Console.Write(' ');
			}
		}

		Console.WriteLine();
	}

	Console.WriteLine($"Score: {score}/{targetFood}   Arrow keys move. Esc quits.");
}
