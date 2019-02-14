using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapOverlay
{
    public class DataModel
    {
        public class Attribution
        {
            public string url { get; set; }
            public string name { get; set; }
        }

        public class City
        {
            public List<double> geo { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Co
        {
            public double v { get; set; }
        }

        public class H
        {
            public double v { get; set; }
        }

        public class No2
        {
            public double v { get; set; }
        }

        public class O3
        {
            public double v { get; set; }
        }

        public class P
        {
            public double v { get; set; }
        }

        public class Pm10
        {
            public int v { get; set; }
        }

        public class Pm25
        {
            public int v { get; set; }
        }

        public class R
        {
            public double v { get; set; }
        }

        public class So2
        {
            public double v { get; set; }
        }

        public class T
        {
            public double v { get; set; }
        }

        public class Iaqi
        {
            public Co co { get; set; }
            public H h { get; set; }
            public No2 no2 { get; set; }
            public O3 o3 { get; set; }
            public P p { get; set; }
            public Pm10 pm10 { get; set; }
            public Pm25 pm25 { get; set; }
            public R r { get; set; }
            public So2 so2 { get; set; }
            public T t { get; set; }
        }

        public class Time
        {
            public string s { get; set; }
            public string tz { get; set; }
            public int v { get; set; }
        }

        public class Debug
        {
            public DateTime sync { get; set; }
        }

        public class Data
        {
            public int aqi { get; set; }
            public int idx { get; set; }
            public List<Attribution> attributions { get; set; }
            public City city { get; set; }
            public string dominentpol { get; set; }
            public Iaqi iaqi { get; set; }
            public Time time { get; set; }
            public Debug debug { get; set; }

            public void NextSample()
            {
                iaqi.pm25.v = iaqi.pm25.v + 4;
            }
        }

        public class RootObject
        {
            public string status { get; set; }
            public Data data { get; set; }
        }

        public class StationTime
        {
            public string tz { get; set; }
            public string stime { get; set; }
            public int vtime { get; set; }
        }

        public class Station
        {
            public string name { get; set; }
            public List<double> geo { get; set; }
            public string url { get; set; }
        }

        public class Datum
        {
            public double lat { get; set; }
            public double lon { get; set; }
            public int uid { get; set; }
            public string aqi { get; set; }

            public StationTime time { get; set; }

            public Station station { get; set; }
        }

        public class StationRootObject
        {
            public string status { get; set; }
            public List<Datum> data { get; set; }
        }
    }
}
