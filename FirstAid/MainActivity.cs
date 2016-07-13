using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace FirstAid
{
    [Activity(Label = "Prva pomoč")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

        }
    }
}

