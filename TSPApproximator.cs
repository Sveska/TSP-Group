﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TSP_Group
{
    internal class TspApproximator
    {
        private readonly List<City> cities;
        public double TotalDistance { get; private set; }

        public TspApproximator(List<City> cities)
        {
            this.cities = cities;
            TotalDistance = 0;
        }

        public List<City> ApproximateTspTour()
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
            var nearestDistances = new Dictionary<City, int>();

            priorityQueue.Enqueue(root, 0);
            nearestDistances[root] = 0;

            while (priorityQueue.Count > 0)
            {
                var currentCity = priorityQueue.Dequeue();

                if (added[currentCity])
                    continue;

                added[currentCity] = true;
                mst.Add(currentCity);

                // Update and display TotalDistance when a city is added
                TotalDistance += nearestDistances[currentCity];
                Console.WriteLine($"City {currentCity} added to MST. Distance traveled: {TotalDistance}");

                foreach (var neighbor in cities)
                {
                    if (!added[neighbor])
                    {
                        var distance = currentCity.DistanceTo(neighbor);
                        if (!nearestDistances.ContainsKey(neighbor) || distance < nearestDistances[neighbor])
                        {
                            nearestDistances[neighbor] = distance;
                            priorityQueue.Enqueue(neighbor, distance);
                        }
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
}