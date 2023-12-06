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
        public int SolveTSP()
        {
            shortestPath = new List<int>();
            List<int> currentPath = new List<int>();
            List<>
        }


    }
}
