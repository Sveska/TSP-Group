using System.Collections.Generic;
using System.Numerics;

namespace TSP_Group
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();

            City city1 = new City("a", -3138, -2512);
            City city2 = new City("b", 6804, -1072);
            City city3 = new City("c", -193, 8782);
            City city4 = new City("d", -5168, 2636);
            City city5 = new City("e", -8022, -3864);
            City city6 = new City("f", -9955, -2923);
            City city7 = new City("g", -7005, 2118);
            City city8 = new City("h", 7775, -8002);
            City city9 = new City("i", 4244, -1339);
            //City city10 = new City("j", 9478, -1973);
            //City city11 = new City("k", -7795, -5000);
            //City city12 = new City("l", -4521, 1266);
            //City city13 = new City("m", -192, 3337);
            //City city14 = new City("n", -9860, 1311);

            cities.Add(city1);
            cities.Add(city2);
            cities.Add(city3);
            cities.Add(city4);
            cities.Add(city5);
            cities.Add(city6);
            cities.Add(city7);
            cities.Add(city8);
            cities.Add(city9);
            //cities.Add(city10);
            //cities.Add(city11);
            //cities.Add(city12);
            //cities.Add(city13);
            //cities.Add(city14);

            BruteForce bf = new BruteForce(cities);
            List<int> shortestPath = bf.SolveBF();
        }
    }
}