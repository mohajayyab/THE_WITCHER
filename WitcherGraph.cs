using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_WITCHER
{
    // creat a graph of cities in the Witcher world
    public class WitcherGraph
    {

        private Dictionary<string, int> cityIndices;
        private string[] cities;
        private bool[,] connections;

        public WitcherGraph(string[] cityNames)
        {
            cities = cityNames;
            cityIndices = new Dictionary<string, int>();

            for (int i = 0; i < cities.Length; i++)
            {
                cityIndices.Add(cities[i], i);
            }

            connections = new bool[cities.Length, cities.Length];
        }


        public void AddConnection(string city1, string city2)
        {
            int index1 = GetCityIndex(city1);
            int index2 = GetCityIndex(city2);
            connections[index1, index2] = true;
            connections[index2, index1] = true;
        }

        private int GetCityIndex(string cityName)
        {
            if (cityIndices.ContainsKey(cityName))
            {
                return cityIndices[cityName];
            }
            else
            {
                throw new ArgumentException("City name not found in graph ", nameof(cityName));
            }
        }


        public string GetCityName(int index)
        {
            return cities[index];
        }

        public bool AreConnected(string city1, string city2)
        {
            int index1 = GetCityIndex(city1);
            int index2 = GetCityIndex(city2);
            return connections[index1, index2];
        }
    }
}
