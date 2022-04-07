using System;
using System.Collections.Generic;
using System.Text;

namespace Graphes
{
	enum StateX
	{
		Empty,
		Wall,
		Visited
	};

	class PointX
	{
		public int X { get; set; }
		public int Y { get; set; }

	}

	public class ProgramX
	{
		static void Main()
		{
			var map = new State[labyrinth[0].Length, labyrinth.Length];

			for (int x = 0; x < map.GetLength(0); x++)
				for (int y = 0; y < map.GetLength(1); y++)
					map[x, y] = labyrinth[y][x] == ' ' ? State.Empty : State.Wall;

			var queue = new Queue<Point>();
			queue.Enqueue(new Point { X = 0, Y = 0 });
			while (queue.Count != 0)
			{
				var point = queue.Dequeue();
				if (point.X < 0 || point.X >= map.GetLength(0) || point.Y < 0 || point.Y >= map.GetLength(1)) continue;
				if (map[point.X, point.Y] != State.Empty) continue;
				map[point.X, point.Y] = State.Visited;
				Print(map);

				for (var dy = -1; dy <= 1; dy++)
					for (var dx = -1; dx <= 1; dx++)
						if (dx != 0 && dy != 0) continue;
						else queue.Enqueue(new Point { X = point.X + dx, Y = point.Y + dy });

			}
		}

		static string[] labyrinth = new string[]
		{
		" X   X    ",
		" X XXXXX X",
		"      X   ",
		"XXXX XXX X",
		"         X",
		" XXX XXXXX",
		" X        "
		};

		static void Print(State[,] map)
		{
			Console.CursorLeft = 0;
			Console.CursorTop = 0;
			for (int x = 0; x < map.GetLength(0) + 2; x++)
				Console.Write("X");
			Console.WriteLine();
			for (int y = 0; y < map.GetLength(1); y++)
			{
				Console.Write("X");
				for (int x = 0; x < map.GetLength(0); x++)
					switch (map[x, y])
					{
						case State.Wall: Console.Write("X"); break;
						case State.Empty: Console.Write(" "); break;
						case State.Visited: Console.Write("."); break;
					}
				Console.WriteLine("X");
			}
			for (int x = 0; x < map.GetLength(0) + 2; x++)
				Console.Write("X");
			Console.ReadKey();
		}

	}
}
