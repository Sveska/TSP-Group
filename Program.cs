using System.Collections.Generic;
using System.Numerics;

namespace TSP_Group
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();

            City city1 = new City(-3138, -2512, false);
            City city2 = new City(6804, -1072, false);
            City city3 = new City(-193, 8782, false);
            City city4 = new City(-5168, 2636, false);
            City city5 = new City(-8022, -3864, false);
            City city6 = new City(-9955, -2923, false);
            City city7 = new City(-7005, 2118, false);
            City city8 = new City(7775, -8002, false);
            City city9 = new City(4244, -1339, false);
            City city10 = new City(9478, -1973, false);
            City city11 = new City(-7795, -5000, false);
            City city12 = new City(-4521, 1266, false);
            City city13 = new City(-192, 3337, false);
            City city14 = new City(-9860, 1311, false);

            cities.Add(city1);
            cities.Add(city2);
            cities.Add(city3);
            cities.Add(city4);
            cities.Add(city5);
            cities.Add(city6);
            cities.Add(city7);
            cities.Add(city8);
            cities.Add(city9);
            cities.Add(city10);
            cities.Add(city11);
            cities.Add(city12);
            cities.Add(city13);
            cities.Add(city14);


            List<int> distances = new List<int>();
            BigInteger num = 87_178_291_200;
            for (BigInteger i = 0; i < num; i++)
            {
                BruteForce bf = new BruteForce(cities);
                distances.Add(bf.bruteForceAlgo());
            }
            distances.Sort();
            Console.WriteLine(distances[0]);









        }
    }
}