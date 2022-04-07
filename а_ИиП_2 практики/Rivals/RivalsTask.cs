using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Rivals
{
    public class RivalsTask
    {
        public static IEnumerable<OwnedLocation> AssignOwners(Map map)
        {
            var visited = new List<Point>();
            var queue = new Queue<OwnedLocation>();
            int i = 0;
            foreach (var player in map.Players)
            {
                queue.Enqueue(new OwnedLocation(i, player, 0));
                i++;
            }

            while (queue.Count > 0)
            {
                var player = queue.Dequeue();
                var playerPos = player.Location;
                if (visited.Contains(playerPos) 
                    || !map.InBounds(playerPos)
                    || map.Maze[playerPos.X, playerPos.Y] != MapCell.Empty) continue;

                visited.Add(playerPos);
                yield return player;
                for (var dy = -1; dy <= 1; dy++)
                    for (var dx = -1; dx <= 1; dx++)
                        if (dx != 0 && dy != 0) continue;
                        else queue.Enqueue(new OwnedLocation
                            (player.Owner,
                            new Point { X = playerPos.X + dx, Y = playerPos.Y + dy },
                            player.Distance + 1));
            }
        }
    }
}
