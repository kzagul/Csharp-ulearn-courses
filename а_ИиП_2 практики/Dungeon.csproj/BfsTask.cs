using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class BfsTask
    {
        public static IEnumerable<SinglyLinkedList<Point>> FindPaths(Map map, Point start, Point[] chests)
        {
            var hashChests = new HashSet<Point>(chests);
            var visited = new HashSet<Point>();
            var queue = new Queue<SinglyLinkedList<Point>>(); // очередь
            var pathToPoint = new SinglyLinkedList<Point>(start);

            queue.Enqueue(pathToPoint);
            while (queue.Count != 0)
            {
                var path = queue.Dequeue();
                if (visited.Contains(path.Value) || !map.InBounds(path.Value)
                    || map.Dungeon[path.Value.X, path.Value.Y] != MapCell.Empty)
                    continue;
                if (hashChests.Contains(path.Value))
                    yield return path;
                visited.Add(path.Value);

                for (var dy = -1; dy <= 1; dy++)
                    for (var dx = -1; dx <= 1; dx++)
                        if (dx != 0 && dy != 0) continue;
                        else queue.Enqueue(new SinglyLinkedList<Point>(new Point(path.Value.X + dx, path.Value.Y + dy), path));
            }
        }
    }
}