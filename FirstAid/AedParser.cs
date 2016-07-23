using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FirstAid
{
    public class AedLocation
    {
        public float Latitude { set; get; }
        public float Longitude { set; get; }
        public string Title { set; get; }

        public AedLocation() { }

        public AedLocation(float lat, float lon, string title)
        {
            Latitude = lat;
            Longitude = lon;
            Title = title;
        }

        ~AedLocation() { }
    }

    public class AedParser
    {
        private static List<AedLocation> ParseJsonData(string json)
        {
            var AedNaprave = new List<AedLocation>();

            JArray JsonArray = JArray.Parse(json);

            foreach (var item in JsonArray.Children())
            {
                var itemProperties = item.Children<JProperty>(); //bValidated szDescription

                var bValidated = itemProperties.FirstOrDefault(x => x.Name == "bValidated");
                if ((int)bValidated.Value == 1)
                {
                    var rLatitude = itemProperties.FirstOrDefault(x => x.Name == "rLatitude");
                    var rLatitudeValue = rLatitude.Value;

                    var rLongitude = itemProperties.FirstOrDefault(x => x.Name == "rLongitude");
                    var rLongitudeValue = rLongitude.Value;

                    var szDescription = itemProperties.FirstOrDefault(x => x.Name == "szDescription");
                    var szDescriptionValue = szDescription.Value;

                    AedNaprave.Add(new AedLocation((float)rLatitudeValue, (float)rLongitudeValue,(string)szDescriptionValue));
                }
            }

            return AedNaprave;
        }

        public static List<MarkerOptions> GetAedLocations(string json)
        {
            List<MarkerOptions> mList = new List<MarkerOptions>();

            // pridobivanje AED naprav in JSON-a

            var data = ParseJsonData(json);

            for(var i = 0; i < data.Count; i++)
            {
                mList.Add(
                    new MarkerOptions()
                    .SetPosition(new LatLng(data[i].Latitude, data[i].Longitude))
                    .SetTitle(data[i].Title)
                );
            }

            return mList;
        }
    }
}