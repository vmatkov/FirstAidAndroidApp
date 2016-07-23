using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Threading.Tasks;
using Android;
using Android.Support.V4.Content;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Plugin.Geolocator;
using System;
using Android.Content.PM;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Support.V4.App;

namespace FirstAid
{
    [Activity(Label = "@string/menu_two")]
    public class KolikoVem : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.KolikoVem);
        }

        //TextView textLocation;
        //Button buttonGetLocation;
        //View layout;
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //    SetContentView(Resource.Layout.KolikoVem);

        //    layout = FindViewById<LinearLayout>(Resource.Id.main_layout);
        //    textLocation = FindViewById<TextView>(Resource.Id.label);

        //    buttonGetLocation = FindViewById<Button>(Resource.Id.myButton);

        //    buttonGetLocation.Click += async (sender, e) => await TryGetLocationAsync();
        //}


    }
}