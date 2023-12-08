         /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                     //
       // Project: TSP Group Project                                                                          //
      // File Name: BruteForce                                                                               //
     // Course: CSCI 3230 – Algorithms                                                                      //
    // Authors: Scotty Snyder, Zachary Sveska, Andrew Garcia, Chris Cleveland, Matthew Beeler              //
   // Created: Wednesday, December 5, 2023                                                                //
  // Copyright: Scotty Snyder, Zachary Sveska, Andrew Garcia, Chris Cleveland, Matthew Beeler, 2023      //
 //                                                                                                     //
/////////////////////////////////////////////////////////////////////////////////////////////////////////

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
        private int totalCities;

        private List<City> cities { get; set; }

        public List<int> shortestPath;

        public int shortestDistance = int.MaxValue;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="cities">a list of cities for the brute force algorithm to process</param>
        public BruteForce(List<City> cities)
        {
            this.cities = cities;
            totalCities = cities.Count;
        }

        /// <summary>
        /// Uses the CalculateShortestPath method to find the shortest possible path with the algorithm provided
        /// </summary>
        /// <returns>a list containing the shortest path</returns>
        public List<int> SolveBF()
        {
            shortestPath = new List<int>();
            List<int> currentPath = new List<int>();
            List<bool> visited = Enumerable.Repeat(false, totalCities).ToList();

            // start from the origin (0,0)
            currentPath.Add(0);
            visited[0] = true;

            CalculateShortestPath(currentPath, visited, 0);

            foreach(var index in shortestPath)
            {
                Console.WriteLine($"City visited: {cities[index].x},{cities[index].y}");
            }

            return shortestPath;
        }

        /// <summary>
        /// Determines the shortest available path using as few optimization methods as possible
        /// </summary>
        /// <param name="currentPath"></param>
        /// <param name="visited">The list of every node currently traversed</param>
        /// <param name="currentLength"></param>
        private void CalculateShortestPath(List<int> currentPath, List<bool> visited, int currentLength)
        {
            if(currentPath.Count == totalCities)
            {
                // Calculate distance from last city to origin
                int originToLastCityDistance = cities[currentPath.Last()].DistanceTo(cities[0]);
                int totalDistance = currentLength + originToLastCityDistance;

                if(totalDistance < shortestDistance)
                {
                    shortestDistance = totalDistance;
                    shortestPath = new List<int>(currentPath);
                }
                return;
            }

            for(int i = 0; i < totalCities; i++)
            {
                if(!visited[i])
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
