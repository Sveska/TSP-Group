using System.Collections.Generic;
using System.Numerics;

namespace TSP_Group
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>
            {
                new City("0", 0, 0),
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


            /*BruteForce bf = new BruteForce(cities);
            List<int> shortestPath = bf.SolveBF();
            Console.WriteLine("Shortest Distance: " + bf.shortestDistance);
            Console.WriteLine("Shortest Path: " + string.Join(" -> ", shortestPath.Select(cityIndex => cities[cityIndex].ToString())));*/

            /*ParallelBruteForce pbf = new ParallelBruteForce(cities);
            pbf.SolveParallelBF();*/

            TspApproximator approx = new TspApproximator(cities);
            approx.ApproximateTspTour();
        }
    }
}