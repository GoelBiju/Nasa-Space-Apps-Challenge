using Xamarin.Forms.Maps;

namespace MapOverlay
{
    public class CustomCircle
    {
        public Position Position { get; set; }

        public double Radius { get; set; }

        public int ColorCode { get; set; }

        private int aqi;

        public string aqiMessage {get; set;}

        public string goodAQI = "Air quality is satisfactory and is not a risk.";
        public string moderateAQI = "Acceptable air quality, however pollutants may be a health concern " +
            "to those who are sensitive.";
        public string unhealthySensitiveAQI = "Members of sensitive groups may find it difficult during the day e.g. those with athsma";
        public string unhealthyAQI = "Take care! There may be health impacts to everyone in this region. Outdoor exertion, especially those with athsma, " +
            "should be avoided and everyone else (including children) should be limited to indoor exertion.";
        public string veryUnhealthyAQI = "Emergency Condition: This region and the majority of the population will be affected by extremely high levels of pollutants in the atmosphere.";
        public string hazardousAQI = "Health alert - Everyone may experience serious consequences as a result of the high pollutants, AVOID going outdoors.";

        public CustomCircle(int aqi, Position position)
        {
            // Set default radius.
            Radius = 1000;

            Position = position;

            // Maroon - 800000 (Hazardous)   
            // Purple - 4B0082 (Very unhealthy)
            // Red - FF0000 (Unhealthy)
            // Dark Orange - FF8C00 (Unhealthy for sensitive groups)
            // Yellow - FFCB00 (Moderate)
            // Green - 008744 (Good)
            if (aqi > 0 && aqi < 51)
            {
                ColorCode = 0x66008744;
                aqiMessage = goodAQI;
            }
            else if (aqi < 101)
            {
                ColorCode = 0x66FFCB00;
                aqiMessage = moderateAQI;
            }
            else if (aqi < 151)
            {
                ColorCode = 0x66FF8C00;
                aqiMessage = unhealthySensitiveAQI;
            }
            else if (aqi < 201)
            {
                ColorCode = 0x66FF0000;
                aqiMessage = unhealthyAQI;
            }
            else if (aqi < 300)
            {
                ColorCode = 0x664B0082;
                aqiMessage = veryUnhealthyAQI;
            }
            else if (aqi >= 300)
            {
                ColorCode = 0x66800000;
                aqiMessage = hazardousAQI;
            }
        }

        public string AQIMessage
        {
            get { return aqiMessage; }
        }
    }
}

