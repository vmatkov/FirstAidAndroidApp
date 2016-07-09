using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Media;
using Android.Graphics;

namespace PrvaPomoc
{
    [Activity(Label = "Prva pomoč")]
    public class MainActivity : Activity
    {
        private List<Image> clickableItems;
        //private List<string> clickableItems;
        private ListView mListView;

        protected override void OnCreate(Bundle bundle)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            mListView = FindViewById<ListView>(Resource.Id.menuList);

            //ArrayAdapter<Image> adapter = new ArrayAdapter<Image>(this, Android.Resource.Layout.SimpleListItem1, clickableItems);

            //clickableItems = new List<string>();
            //clickableItems.Add("PRVA POMOČ");
            //clickableItems.Add("Koliko vem o nudenju prve pomoči?");
            //clickableItems.Add("Zemljevid AED naprav");
            //clickableItems.Add("Pokliči 112");

            //clickableItems = new List<Image>();
            //clickableItems.Add(new Bitmap());
            //clickableItems.Add("Koliko vem o nudenju prve pomoči?");
            //clickableItems.Add("Zemljevid AED naprav");
            //clickableItems.Add("Pokliči 112");

            //ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, clickableItems);

            //mListView.Adapter = adapter;

        }
    }
}

