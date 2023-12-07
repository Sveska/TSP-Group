         /////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                                                                                                     //
       // Project: TSP Group Project                                                                          //
      // File Name: City                                                                                     //
     // Course: CSCI 3230 – Algorithms                                                                      //
    // Authors: Scotty Snyder, Zachary Sveska, Andrew Garcia, Chris Cleveland, Matthew Beeler              //
   // Created: Wednesday, December 5, 2023                                                                //
  // Copyright: Scotty Snyder, Zachary Sveska, Andrew Garcia, Chris Cleveland, Matthew Beeler, 2023      //
 //                                                                                                     //
/////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        /// <summary>
        /// defauly constructor for a city
        /// </summary>
        /// <param name="name">the name that is used to identify a city</param>
        /// <param name="x">the x-coordinate of a city</param>
        /// <param name="y">the y-coordinate of a city</param>
        public City(string name, int x, int y)
        {
            this.name = name;
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// method used to determine the distance between two cities
        /// </summary>
        /// <param name="c">the city you wish to determine the distance to</param>
        /// <returns>the distance from one city to another</returns>
        public int DistanceTo(City c)
        {
            return (int)Math.Sqrt(Math.Pow((c.x - x), 2) + Math.Pow((c.y - y), 2));
        }

        /// <summary>
        /// ToString so each city other methods and display a name for each city
        /// </summary>
        /// <returns>the name of a city</returns>
        public override string ToString()
        {
            string info = string.Empty;

            info += name;

            return info;
        }

    }
}
