using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TSP_Group
{
    internal class BruteForce
    {
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

            return shortestPath;

        }
        private void CalculateShortestPath(List<int> currentPath, List<bool> visited, int currentLength)
        {
            Console.WriteLine("\tloading...\t");
            // calculate distance from last city to origin
            int originToLastCityDistance = cities[currentPath.Last()].DistanceTo(new City(0, 0, false));
            int totalDistance = currentLength = currentLength + originToLastCityDistance; ;

            // check if the total distance is shorter than the current shortest distance
            if (totalDistance < shortestDistance)
            {
                shortestDistance = totalDistance;
                shortestPath = new List<int>(currentPath);
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

                    // Backtrack
                    visited[i] = false;
                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
            return;
        }

    }
}
