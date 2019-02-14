using Xamarin.Forms;
using Xamarin.Forms.Maps;

using Plugin.Geolocator;
using System.Threading.Tasks;
using System;


namespace MapOverlay
{
	public class MapPageCS : ContentPage
	{
        CustomMap customMap;

        Label resultsLabel;
        SearchBar searchBar;

        AirQualityAPI api;

        double userLat;
        double userLong;

		public MapPageCS ()
		{
            api = new AirQualityAPI();

            customMap = new CustomMap {
                MapType = MapType.Street,
                WidthRequest = App.ScreenWidth,
                HeightRequest = 400,
                VerticalOptions = LayoutOptions.FillAndExpand
			};

            resultsLabel = new Label
            {
                Text = "",
                VerticalOptions = LayoutOptions.FillAndExpand,
                FontSize = 20
            };

            searchBar = new SearchBar
            {
                Placeholder = "Search for location",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                SearchCommand = new Command(() => { resultsLabel.Text = "Result: " + searchBar.Text + " is what you asked for\n Here is a new piece of data!"; })
            };

            // Get user's current location.
            Task.Run(async () => { await GetUserPositionAsync(); });
            while (userLat == 0.0 || userLong == 0.0)
            {
            }

            // Gets the nearest air quality station.
            //Console.WriteLine(string.Format("LAT:{0}, LONG: {1}", userLat, userLong));
            var geoResult = api.GeolocalisedFeed(userLat, userLong);
            Position stationPosition = new Position(51.5074, 0.1278);
            //Position position = new Position(50.3792423, -4.1401285);\\
            var closestStationPin = new Pin
            {
                Type = PinType.Place,
                Position = stationPosition,
                Label = "London Centre",
                Address = string.Format("Touch me to view Health Alert", 45)
            };

            // Create the heatmap for the station and give it the air quality index to 
            // evaluate the colour to show.
            customMap.Circle = new CustomCircle(45, stationPosition);

            //var londonCentreMessage = customMap.Circle.AQIMessage;


            // Get the pin clicked event and information.
            closestStationPin.Clicked += (sender, e) =>
            {
                DisplayAlert(string.Format("{0} - Health Alert", "London"), string.Format("Air Quality Index is {0}\n\n", "45"), "OK");
            };

            //var position = new Position (37.79752, -122.40183);
            //customMap.Circle = new CustomCircle {
            //	Position = position,
            //	Radius = 1000
            //};

            // Position newPosition = new Position(51.500134, 0.0351029);
            //Position position = new Position(50.3792423, -4.1401285);
            //var newStationPin = new Pin
            //{
            //    Type = PinType.Place,
            //   Position = newPosition,
            //    Label = "London AQI",
            //    Address = string.Format("Touch me to view Health Alert", 55)
            //};

            //// Create the heatmap for the station and give it the air quality index to 
            //// evaluate the colour to show.
            //customMap.Circle = new CustomCircle(55, newPosition);

            //var londonMessage = customMap.Circle.AQIMessage;

            //// Get the pin clicked event and information.
            //newStationPin.Clicked += (sender, e) =>
            //{
            //    DisplayAlert(string.Format("{0} - Health Alert", "London AQI"), string.Format("Air Quality Index is {0}\n\n" + londonMessage, "55"), "OK");
            //};

            ////var position = new Position (37.79752, -122.40183);
            ////customMap.Circle = new CustomCircle {
            ////	Position = position,
            ////	Radius = 1000
            ////};

            customMap.Pins.Add(closestStationPin);
            //customMap.Pins.Add(newStationPin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(stationPosition, Distance.FromMiles(1.0)));

            //Content = customMap;
            Content = new StackLayout {
                Spacing = 0,
                Children =
                {
                    searchBar,
                    new ScrollView
                    {
                        Content = resultsLabel,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    },
                    customMap
                }
            };
        }


        private async Task GetUserPositionAsync()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;

            var location = await locator.GetPositionAsync(TimeSpan.FromTicks(10000));
            Console.WriteLine("MY LOCATION: {0}, {1}", location.Latitude, location.Longitude);
            Position position = new Position(location.Latitude, location.Longitude);
            userLat = location.Latitude;
            userLong = location.Longitude;

            var userPin = new Pin
            {
                Type = PinType.SavedPin,
                Position = position,
                Label = "You",
                Address = string.Format("(Latitude: {0:0.00}, Longitude: {1:0.00})", userLat, userLong)
            };

            customMap.Pins.Add(userPin);

            // Only move after all the required actions have been performed.
            //customMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.5)));
        }
    }
}
