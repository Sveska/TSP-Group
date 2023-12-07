using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP_Group
{
    internal class TspApproximator
    {
        public List<City> ApproximateTspTour(List<City> cities)
        {
            City root = cities[0];
            var mst = ComputeMst(cities, root);
            var visited = new HashSet<City>();
            var preorderWalk = new List<City>();
            PreorderWalk(root, mst, visited, preorderWalk);

            // Adding root to the end to complete the cycle
            preorderWalk.Add(root);
            return preorderWalk;
        }

        private List<City> ComputeMst(List<City> cities, City root)
        {
            var mst = new List<City>();
            var priorityQueue = new PriorityQueue<City, int>();
            var added = cities.ToDictionary(city => city, city => false);

            // Initialize with root city
            priorityQueue.Enqueue(root, 0);

            while (priorityQueue.Count > 0)
            {
                // Dequeue the next city
                var currentCity = priorityQueue.Dequeue();

                if (added[currentCity])
                    continue;

                added[currentCity] = true;
                mst.Add(currentCity);

                foreach (var neighbor in cities)
                {
                    if (!added[neighbor])
                    {
                        var distance = currentCity.DistanceTo(neighbor);
                        priorityQueue.Enqueue(neighbor, distance);
                    }
                }
            }

            return mst;
        }

        private void PreorderWalk(City city, List<City> mst, HashSet<City> visited, List<City> walk)
        {
            visited.Add(city);
            walk.Add(city);

            foreach (var neighbor in mst)
            {
                if (!visited.Contains(neighbor))
                {
                    PreorderWalk(neighbor, mst, visited, walk);
                }
            }
        }
    }