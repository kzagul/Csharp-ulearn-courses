using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
	public class DungeonTask
	{
		public static MoveDirection[] FindShortestPath(Map map)
		{
			var finishToStart = BfsTask.FindPaths
				(map, map.Exit, new[] { map.InitialPosition})
				.SelectMany(path => path);
			if (finishToStart.Count() == 0)
				return new MoveDirection[] { };
            foreach (var _ in map.Chests
				.Where(chest => finishToStart
					.Contains(chest))
				.Select(chest => new { }))
                return Convert(finishToStart);

            var paths = Concatenate(map);
			int lengthOfShortestPath;
			IEnumerable<Point> shortestPath;
            try
            {
				lengthOfShortestPath = paths.Min(path => path.Count);
				shortestPath = paths
					.Where(path => path.Count == lengthOfShortestPath)
					.SelectMany(path => path);
            }
			catch
            {
				return Convert(finishToStart);
            }
			return Convert(shortestPath);
		}
        private static MoveDirection[] Convert(IEnumerable<Point> path)
        {
			return path
				.Zip(path.Skip(1), (first, second) =>
					second.X - first.X > 0 ? MoveDirection.Right
					: second.X - first.X < 0 ? MoveDirection.Left
					: second.Y - first.Y > 0 ? MoveDirection.Down
					: MoveDirection.Up)
				.ToArray();
        }

		static IEnumerable<List<Point>> Concatenate(Map map)
        {
			var startToChests = BfsTask.FindPaths(map, map.InitialPosition, map.Chests);
			var finishToChests = BfsTask.FindPaths(map, map.Exit, map.Chests);
			return from startToChest in startToChests
				   join finishToChest in finishToChests
				   on startToChest.Value equals finishToChest.Value
				   select startToChest
						.Reverse()
						.Concat(finishToChest.Skip(1))
						.ToList();
		}
    }
}
