         /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                     //
       // Project: TSP Group Project                                                                          //
      // File Name: Main                                                                                     //
     // Course: CSCI 3230 – Algorithms                                                                      //
    // Authors: Scotty Snyder, Zachary Sveska, Andrew Garcia, Chris Cleveland, Matthew Beeler              //
   // Created: Wednesday, December 5, 2023                                                                //
  // Copyright: Scotty Snyder, Zachary Sveska, Andrew Garcia, Chris Cleveland, Matthew Beeler, 2023      //
 //                                                                                                     //
/////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace TSP_Group
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List of all the cities given in the spec were hardcoded into the program
            List<City> cities = new List<City>
            {
                new City("a", -3138, -2512),
                new City("b", 6804, -1072),
                new City("c", -193, 8782),
                new City("d", -5168, 2636),
                new City("e", -8022, -3864),
                new City("f", -9955, -2923),
                new City("g", -7005, 2118),
                new City("h", 7775, -8002),
                new City("i", 4244, -1339),
                new City("j", 9478, -1973),
                new City("k", -7795, -5000),
                new City("l", -4521, 1266),
                new City("m", -192, 3337),
                new City("n", -9860, 1311)
            };

            //I've added a video called TSP Bruteforce to the repository, this video demonstrates the maximum number of
            //cities (12) that can be visited within two minutes on my desktop
            Stopwatch sw = Stopwatch.StartNew();
            /*BruteForce bf = new BruteForce(cities);
            List<int> shortestPath = bf.SolveBF();
            Console.WriteLine("Shortest Distance: " + bf.shortestDistance);
            Console.WriteLine("Shortest Path: " + string.Join(" -> ", shortestPath.Select(cityIndex => cities[cityIndex].ToString())));
            sw.Stop();
            Console.WriteLine(sw);*/


            //I've added a video called TSP ParallelBruteforce to the repository, this video demonstrates the maximum number of
            //cities (13) that can be visited within two minutes on my desktop
            /*sw.Restart();
            sw.Start();
            ParallelBruteForce pbf = new ParallelBruteForce(cities);
            pbf.SolveParallelBF();
            sw.Stop();
            Console.WriteLine(sw);*/

            sw.Restart();
            sw.Start();
            TspApproximator approx = new TspApproximator(cities);
            approx.ApproximateTspTour();
            sw.Stop();
            Console.WriteLine(sw);
            StreamWriter output = new StreamWriter("Bruteforce output.txt");
        }
    }
}