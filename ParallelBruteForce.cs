         /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                     //
       // Project: TSP Group Project                                                                          //
      // File Name: ParallelBruteForce                                                                       //
     // Course: CSCI 3230 – Algorithms                                                                      //
    // Authors: Scotty Snyder, Zachary Sveska, Andrew Garcia, Chris Cleveland, Matthew Beeler              //
   // Created: Wednesday, December 6, 2023                                                                //
  // Copyright: Scotty Snyder, Zachary Sveska, Andrew Garcia, Chris Cleveland, Matthew Beeler, 2023      //
 //                                                                                                     //
/////////////////////////////////////////////////////////////////////////////////////////////////////////
// usees Task Parallel Library in .NET to parallelize the computation
// recursion with path calculation
// program uses a lock lockObj to ensure thread safety when updating shortest DIstance and shortestPath
// recursive calls make new instances of the path newPAth and visited list newVisited for each recursive call
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSP_Group
{
    internal class ParallelBruteForce
    {
        private int totalCities;
        private List<City> cities;
        private List<int> shortestPath;
        private int shortestDistance = int.MaxValue;
        private object lockObj = new object();

        public ParallelBruteForce(List<City> cities)
        {
            this.cities = cities;
            totalCities = cities.Count;
            shortestPath = new List<int>();
        }
        /// <summary>
        /// uses parallelization to bruteforce the TSP problem
        /// </summary>
        /// <returns>the shortest path determined by the algorithm</returns>
        public List<int> SolveParallelBF()
        {
            List<int> initialPath = new List<int> { 0 };
            List<bool> visited = Enumerable.Repeat(false, totalCities).ToList();
            visited[0] = true;

            Parallel.ForEach(Enumerable.Range(1, totalCities - 1), (i) =>
            {
                List<int> newPath = new List<int>(initialPath);
                List<bool> newVisited = new List<bool>(visited);
                newPath.Add(i);
                newVisited[i] = true;
                CalculateShortestPath(newPath, newVisited, 0);
            });
            foreach (var index in shortestPath)
            {
                Console.WriteLine($"City visited: {cities[index].x},{cities[index].y}" + " " + index);
            }
            return shortestPath;
        }

        private void CalculateShortestPath(List<int> currentPath, List<bool> visited, int currentLength)
        {
            if (currentPath.Count == totalCities)
            {
                int originToLastCityDistance = cities[currentPath.Last()].DistanceTo(cities[0]);
                int totalDistance = currentLength + originToLastCityDistance;

                lock (lockObj)
                {
                    if (totalDistance < shortestDistance)
                    {
                        shortestDistance = totalDistance;
                        shortestPath = new List<int>(currentPath);
                    }
                }
                return;
            }

            for (int i = 1; i < totalCities; i++)
            {
                if (!visited[i])
                {
                    int lastCityIndex = currentPath.Last();
                    int distanceToNextCity = cities[lastCityIndex].DistanceTo(cities[i]);

                    List<int> newPath = new List<int>(currentPath) { i };
                    List<bool> newVisited = new List<bool>(visited);
                    newVisited[i] = true;

                    CalculateShortestPath(newPath, newVisited, currentLength + distanceToNextCity);
                }
            }
        }
    }
}
