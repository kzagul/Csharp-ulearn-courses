using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Greedy.Architecture;
using Greedy.Architecture.Drawing;

namespace Greedy
{
    public class GreedyPathFinder : IPathFinder
    {
        public List<Point> FindPathToCompleteGoal(State state)
        {
            if (state.Chests.Count < state.Goal)
                return new List<Point>();
            var resultPath = new List<Point>();
            var position = state.Position;
            var chests = new HashSet<Point>(state.Chests);
            var pathFinder = new DijkstraPathFinder();
            for (int i = 0; i < state.Goal; i++)
            {
                if (chests.Contains(position))
                {
                    chests.Remove(position);
                    continue;
                }
                var path = pathFinder.GetPathsByDijkstra(state, position, chests).FirstOrDefault();
                if (path == null)
                    return new List<Point>();
                path.Path.RemoveAt(0);
                if (path.Path.Count == 0)
                    return new List<Point>();
                resultPath.AddRange(path.Path);
                position = resultPath[resultPath.Count - 1];
                chests.Remove(position);
            }
            if (resultPath.Count > state.InitialEnergy)
                return new List<Point>();
            return resultPath;
        }
    }
}