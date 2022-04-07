using System;
using System.Collections.Generic;
using System.Drawing;
using Greedy.Architecture;
using Greedy.Architecture.Drawing;
using System.Linq;

namespace Greedy
{
    public class NotGreedyPathFinder : IPathFinder
    {
        public List<Point> FindPathToCompleteGoal(State state)
        {
            FindPath(state, new HashSet<Point>(state.Chests), state.Position, 0, new List<Point>(), 0);
            return bestPath.ToList();
        }
        IEnumerable<Point> bestPath = new List<Point>();
        int chestsFound = -1;

        public void FindPath(State state, IEnumerable<Point> chests,
            Point position, int energySpent, IEnumerable<Point> currentPath, int chestIndex)
        {
            if (chestsFound == state.Chests.Count)
                return;
            else if (chestIndex > chestsFound) //|| chestIndex == chestsFound)//&& energySpent < int.MaxValue)
            {
                bestPath = currentPath;
                chestsFound = chestIndex;
            }
            foreach (var chest in chests)
                ProcessChest(state, chests, position, energySpent, currentPath, chestIndex, chest);
        }

        private void ProcessChest(State state, IEnumerable<Point> chests, 
            Point position, int energySpent, IEnumerable<Point> currentPath, int chestIndex, Point chest)
        {
            var path = new DijkstraPathFinder().GetPathsByDijkstra
                                (state, position, new List<Point> { chest }).FirstOrDefault();
            if (energySpent + path.Cost <= state.Energy)
            {
                var notVisitedChests = new HashSet<Point>(chests);
                notVisitedChests.Remove(chest);
                path.Path.RemoveAt(0);
                FindPath(state, notVisitedChests, chest, energySpent + path.Cost,
                    currentPath.Concat(path.Path), chestIndex + 1);
            }
        }
    }
}