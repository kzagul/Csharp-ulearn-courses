using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greedy.Architecture;
using System.Drawing;

namespace Greedy
{
    class DijkstraData
    {
        public Point? Previous { get; set; }
        public int Price { get; set; }
        public DijkstraData(int price, Point? previous = null)
        {
            Price = price;
            Previous = previous;
        }
    }

    public class DijkstraPathFinder
    {
        public IEnumerable<PathWithCost> GetPathsByDijkstra(State state, Point start, IEnumerable<Point> targets)
        {
            HashSet<Point> chests = new HashSet<Point>(targets);
            HashSet<Point> visited = new HashSet<Point>();

            Dictionary<Point, DijkstraData> track = new Dictionary<Point, DijkstraData>();
            track.Add(start,new DijkstraData(0));

            while (chests.Count > 0)
            {
                var toOpen = new Point(-1, -1);
                var bestPrice = double.PositiveInfinity;
                foreach (var pointAndData in track
                    .Where(pointAndData => 
                        !visited.Contains(pointAndData.Key) 
                        && pointAndData.Value.Price < bestPrice))
                {
                    bestPrice = pointAndData.Value.Price;
                    toOpen = pointAndData.Key;
                }

                if (toOpen == new Point(-1, -1)) yield break;

                if (chests.Contains(toOpen))
                {
                    yield return GetPathWithCost(toOpen, track);
                    chests.Remove(toOpen);
                }
                CheckIncidentNodes(toOpen, state, track);
                visited.Add(toOpen);
            }
        }

        private void CheckIncidentNodes(Point toOpen, State state, Dictionary<Point, DijkstraData> track)
        {
            for (var dy = -1; dy <= 1; dy++)
                for (var dx = -1; dx <= 1; dx++)
                {
                    if (dx != 0 && dy != 0) continue;
                    else
                    {
                        var newPoint = new Point(toOpen.X + dx, toOpen.Y + dy);
                        if (state.InsideMap(newPoint) && !state.IsWallAt(newPoint))
                        {
                            var price = track[toOpen].Price + state.CellCost[newPoint.X, newPoint.Y];
                            if (!track.ContainsKey(newPoint) || track[newPoint].Price > price)
                                track[newPoint] = new DijkstraData(price, toOpen);
                        }
                    }
                }
        }

        private PathWithCost GetPathWithCost(Point toOpen, Dictionary<Point, DijkstraData> track)
        {
            var result = new List<Point>();
            Point? pointer = toOpen;
            while (pointer != null)
            {
                result.Add((Point)pointer);
                pointer = track[(Point)pointer].Previous;
            }
            result.Reverse();
            return new PathWithCost(track[toOpen].Price, result.ToArray());
        }
    }
}
