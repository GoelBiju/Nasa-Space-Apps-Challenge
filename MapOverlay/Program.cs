using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOverlay
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new AirQualityAPI();

            // Test City api.
            var cityResult = api.CityFeed("Plymouth");
            Console.WriteLine("AQI in Plymouth Centre: " + cityResult.data.aqi);
            Console.ReadLine();

            // Test Station api.
            var geoResult = api.GeolocalisedFeed(50.3790705, -4.141894);
            Console.WriteLine("Station Name: " + geoResult.data.city.name);
            Console.ReadLine();

            // Map api.
            var mapResult = api.MapQuery(50.16634316943975, -6.383056640625001, 51.27909868682927, 1.8896484375000002);
            Console.WriteLine("Map Data results: ");
            for (int i = 0; i < mapResult.data.Count; i++)
            {
                Console.WriteLine("ID of station: " + mapResult.data[i].uid);
            }
            Console.ReadLine();

            // Search api.
            var searchResult = api.Search("bangalore");
            Console.WriteLine("Search Data results: ");
            for (int i = 0; i < searchResult.data.Count; i++)
            {
                Console.WriteLine("Names of search stations: " + searchResult.data[i].station.name);
            }
            Console.ReadLine();
        }
    }
}
