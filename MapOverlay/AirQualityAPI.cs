using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOverlay
{
    public class AirQualityAPI
    {
        private RestClient client;
        private string apiToken;

        // API Documentation: https://aqicn.org/json-api/doc/
        private string api_Url = "https://api.waqi.info";

        // city and token
        private string api_CityFeedUrl = "https://api.waqi.info/feed/{0}/?token={1}";
        // lat, long and token
        private string api_GeolocalisedUrl = "https://api.waqi.info/feed/geo:{0};{1}/?token={2}";
        // token and keyword
        private string api_Search = "https://api.waqi.info/search/?token={0}&keyword={1}";


        public AirQualityAPI()
        {
            client = new RestClient(api_Url);

            // Store the token we need to use the waqi api with.
            apiToken = "454cac0b25995e1a4566c412dab345ddacbea0fa";
        }

        public DataModel.RootObject CityFeed(string city)
        {
            //var client = new RestClient(api_Url);

            var request = new RestRequest("feed/{city}/", Method.GET);
            request.AddUrlSegment("city", city);
            request.AddParameter("token", apiToken);
            Console.WriteLine(client.BuildUri(request));

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            
            var pollutionData = JsonConvert.DeserializeObject<DataModel.RootObject>(content);

            // Sample some more data.
            //pollutionData.data.NextSample();
            //pollutionData.data.NextSample();
            //pollutionData.data.NextSample();

            return pollutionData;
        }

        public DataModel.RootObject GeolocalisedFeed(double latitude, double longitude)
        {
            //var client = new RestClient(api_Url);

            var request = new RestRequest("feed/geo:{lat};{lng}/", Method.GET);

            request.AddUrlSegment("lat", latitude);
            request.AddUrlSegment("lng", longitude);
            request.AddParameter("token", apiToken);
            Console.WriteLine(client.BuildUri(request));

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var stationData = JsonConvert.DeserializeObject<DataModel.RootObject>(content);
            return stationData;
        }

        
        public DataModel.StationRootObject MapQuery(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            var request = new RestRequest("map/bounds/?latlng={lat1},{lng1},{lat2},{lng2}");

            request.AddUrlSegment("lat1", latitude1);
            request.AddUrlSegment("lng1", longitude1);
            request.AddUrlSegment("lat2", latitude2);
            request.AddUrlSegment("lng2", longitude2);
            request.AddParameter("token", apiToken);
            Console.WriteLine(client.BuildUri(request));

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var mapData = JsonConvert.DeserializeObject<DataModel.StationRootObject>(content);
            return mapData;
        }

        public DataModel.StationRootObject Search(string searchName)
        {
            //var client = new RestClient(api_Url);

            var request = new RestRequest("search/?keyword={search}", Method.GET);
            request.AddUrlSegment("search", searchName);
            request.AddParameter("token", apiToken);
            Console.WriteLine(client.BuildUri(request));

            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var searchData = JsonConvert.DeserializeObject<DataModel.StationRootObject>(content);
            return searchData;
        }
    }
}
