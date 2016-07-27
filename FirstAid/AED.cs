using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Gms.Location;
using Android;
using System;
using Android.Support.V4.App;
using Android.Locations;
using Android.Gms.Common.Apis;
using Android.Gms.Common;
using Android.Widget;

namespace FirstAid
{
    [Activity(Label = "@string/menu_three")]
    public class AED : Activity, IOnMapReadyCallback, Android.Gms.Location.ILocationListener, 
        GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        private GoogleMap mMap;
        protected Location mLocation;
        protected GoogleApiClient mGoogleApiClient;
        protected LocationRequest mLocationRequest;
        protected bool mRequestingLocationUpdates;
        private List<MarkerOptions> markers;

        const int RequestLocationId = 0;

        readonly string[] PermissionsLocation =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        public void SetAedMarkersOnMap(List<MarkerOptions> AedNaprave)
        {
            for (var i = 0; i < AedNaprave.Count; i++)
                mMap.AddMarker(AedNaprave[i]);
            for (var i = 0; i < AedNaprave.Count; i++)
            {
                if (mMap.Projection.VisibleRegion.LatLngBounds.Contains(AedNaprave[i].Position))
                {
                    mMap.AddMarker(AedNaprave[i]);
                }
            }
        }

        protected void buildGoogleApiClient()
        {
            Toast.MakeText(this, "Google Api Client se vzpostavlja.", ToastLength.Long).Show();
            mGoogleApiClient = new GoogleApiClient.Builder(this)
                    .AddConnectionCallbacks(this)
                    .AddOnConnectionFailedListener(this)
                    .AddApi(LocationServices.API)
                    .Build();
            CreateLocationRequest();
        }

        private void CreateLocationRequest()
        {
            mLocationRequest = new LocationRequest();

            mLocationRequest.SetInterval(10000);
            mLocationRequest.SetFastestInterval(5000);

            mLocationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);

        }

        public void OnMapReady(GoogleMap googleMap)
        {
            mMap = googleMap;
            mMap.MyLocationEnabled = true;
            
            if(mLocation != null)
            {
                CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(new LatLng(mLocation.Latitude,mLocation.Longitude), 13);
                mMap.MoveCamera(camera);
            }
            else
            {
                LatLng SLO = new LatLng(46.0661174, 14.5320991);

                CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(SLO, 10);
                mMap.MoveCamera(camera);
            }
        }

        private void UpdateUI()
        {
            Toast.MakeText(this, "Lon: " + mLocation.Longitude + " Lat: " + mLocation.Latitude, ToastLength.Long).Show();
            var closest = FindClosestMarker();
            for (var i = 0; i < markers.Count; i++)
            {
                if (markers[i] == closest)
                    markers[i].SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.aed_pin_red_small));
                else
                    markers[i].SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.aed_pin_small));
            }
            SetAedMarkersOnMap(markers);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AED);

            markers = MainActivity.AedMarkers;

            mRequestingLocationUpdates = false;
            buildGoogleApiClient();

            SetUpMap();
        }

        private void SetUpMap()
        {
            if(mMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            mGoogleApiClient.Connect();
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (mGoogleApiClient.IsConnected && mRequestingLocationUpdates)
            {
                startLocationUpdates();
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            if (mGoogleApiClient.IsConnected)
            {
                stopLocationUpdates();
            }
        }

        protected void startLocationUpdates()
        {
            LocationServices.FusedLocationApi.RequestLocationUpdates(mGoogleApiClient, mLocationRequest, this);
        }

        protected void stopLocationUpdates()
        {
            LocationServices.FusedLocationApi.RemoveLocationUpdates(mGoogleApiClient, this);
        }

        public void OnLocationChanged(Location location)
        {
            mLocation = location;
            Toast.MakeText(this, "Posodabljam lokacijo.", ToastLength.Short).Show();
        }

        protected double Rad(double x)
        {
            return x * Math.PI / 180;
        }

        public MarkerOptions FindClosestMarker()
        {
            var lat = mLocation.Latitude;
            var lng = mLocation.Longitude;
            var R = 6371; // radius of earth in km
            var distances = new List<double>();
            var closest = -1;
            for( var i = 0; i < markers.Count; i++ )
            {
                var mlat = markers[i].Position.Latitude;
                var mlng = markers[i].Position.Longitude;
                var dLat = Rad(mlat - lat);
                var dLong = Rad(mlng - lng);
                var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +  Math.Cos(Rad(lat)) * Math.Cos(Rad(lat)) * Math.Sin(dLong / 2) * Math.Sin(dLong / 2);
                var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                var d = R * c;
                distances.Add(d);
                if (closest == -1 || d < distances[closest])
                {
                    closest = i;
                }
            }

            return markers[closest];
        }

        public void OnConnected(Bundle connectionHint)
        {
            if (mLocation == null)
            {
                mLocation = LocationServices.FusedLocationApi.GetLastLocation(mGoogleApiClient);
                CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(new LatLng(mLocation.Latitude, mLocation.Longitude), 14);
                mMap.MoveCamera(camera);
                UpdateUI();
            }

            if (mRequestingLocationUpdates)
            {
                startLocationUpdates();
            }
        }

        public void OnConnectionSuspended(int cause)
        {
            Toast.MakeText(this, "Povezava prekinjena.", ToastLength.Long).Show();
            mGoogleApiClient.Connect();
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            Toast.MakeText(this, "Povezava ni uspela: ConnectionResult.getErrorCode() = " + result.ErrorCode.ToString(), ToastLength.Long).Show();
        }
    }
}
 