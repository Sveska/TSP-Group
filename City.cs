using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP_Group
{
    internal class City
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool visited { get; set; }


        public City(int x, int y, bool visited)
        {
            this.x = x;
            this.y = y;
            this.visited = visited;
        }

        // if TSP has been to city this method will be called
        internal void Visit()
        {
           visited = true;
        }
        internal void ResetVisit()
        {
            visited = false;
        }

        // distance between two cities formula
        public int DistanceTo(City c)
        {
            return (int)Math.Sqrt(Math.Pow((c.x - this.x), 2) + Math.Pow((c.y - this.y), 2));
        }

    }
}
