using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace FirstAid
{
    [Activity(Label = "@string/menu_three")]
    public class AED : Activity, IOnMapReadyCallback
    {
        private GoogleMap mMap;

        public void SetAedMarkersOnMap(List<MarkerOptions> AedNaprave)
        {
            for (var i = 0; i < AedNaprave.Count; i++)
                mMap.AddMarker(AedNaprave[i]);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;

            LatLng NYC = new LatLng(40.776408, -73.970755);
            LatLng MS = new LatLng(46.65236510, 16.15691760);

            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(MS,10);
            mMap.MoveCamera(camera);

            MarkerOptions optionsNYC = new MarkerOptions()
            .SetPosition(NYC)
            .SetTitle("New York")
            .SetSnippet("AKA: The Big Apple.")
            .SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.aed_pin_small));

            MarkerOptions optionsMS = new MarkerOptions()
            .SetPosition(MS)
            .SetTitle("Murska Sobota")
            .SetSnippet("AKA: Lejpo mesto.")
            .SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.aed_pin_small));

            mMap.AddMarker(optionsNYC);
            mMap.AddMarker(optionsMS);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AED);
            SetUpMap();
        }

        private void SetUpMap()
        {
            if(mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }
    }
}