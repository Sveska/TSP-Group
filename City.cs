using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_Group
{
    internal class City
    {
        public int x { get; set; }
        public int y { get; set; }

        string name = "";


        public City(string name, int x, int y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }

        // distance between two cities formula
        public int DistanceTo(City c)
        {
            return (int)Math.Sqrt(Math.Pow((c.x - this.x), 2) + Math.Pow((c.y - this.y), 2));
        }

        public override string ToString()
        {
            string info = string.Empty;

            info += name;

            return info;
        }

    }
}
