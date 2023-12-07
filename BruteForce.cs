using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TSP_Group
{
    internal class BruteForce
    {
        int counter = 0;
        Random random = new Random();

        private int totalCities;

        private List<City> cities { get; set; }

        private List<int> shortestPath;

        private int shortestDistance = int.MaxValue;



        public BruteForce(List<City> cities)
        {
            this.cities = cities;
            totalCities = cities.Count;

        }

        public List<int> SolveBF()
        {
            shortestPath = new List<int>();
            List<int> currentPath = new List<int>();
            List<bool> visited = Enumerable.Repeat(false, totalCities).ToList();

            // start from the origin (0,0)
            currentPath.Add(0);
            visited[0] = true;

            CalculateShortestPath(currentPath, visited, 0);

            foreach (var index in shortestPath)
            {
                Console.WriteLine($"City visited: {cities[index].x},{cities[index].y}");
            }

            return shortestPath;

        }
        private void CalculateShortestPath(List<int> currentPath, List<bool> visited, int currentLength)
        {
            if (currentPath.Count == totalCities)
            {
                // Calculate distance from last city to origin
                int originToLastCityDistance = cities[currentPath.Last()].DistanceTo(cities[0]);
                int totalDistance = currentLength + originToLastCityDistance;

                if (totalDistance < shortestDistance)
                {
                    shortestDistance = totalDistance;
                    shortestPath = new List<int>(currentPath);
                }
                return;
            }

            for (int i = 0; i < totalCities; i++)
            {
                if (!visited[i])
                {
                    int lastCityIndex = currentPath.Last();
                    int distanceToNextCity = cities[lastCityIndex].DistanceTo(cities[i]);

                    visited[i] = true;
                    currentPath.Add(i);

                    CalculateShortestPath(currentPath, visited, currentLength + distanceToNextCity);

                    visited[i] = false;
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
        }
    }
}
