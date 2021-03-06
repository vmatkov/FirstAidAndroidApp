﻿using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android.Content.PM;
using Android;
using Android.Gms.Maps.Model;
using System.Collections.Generic;
using Android.Content.Res;
using System.IO;
using FirstAid.Resources.Model;

namespace FirstAid
{
    [Activity(Label = "@string/ApplicationName")]
    public class MainActivity : Activity
    {
        public static List<MarkerOptions> AedMarkers;
        public static List<Question> Questions;

        static readonly int REQUEST_PHONE = 0;
        static readonly int REQUEST_LOCATION = 1;

        readonly string[] PermissionsLocation =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };

        protected override void OnCreate(Bundle bundle)
        {
            //RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //AED Markers from JSON
            string json;
            AssetManager assets = this.Assets;
            using (var streamReader = new StreamReader(assets.Open("AedJson.json")))
            {
                json = streamReader.ReadToEnd();
            }

            AedMarkers = AedParser.GetAedLocations(json);

            //Questions and answers from JSON
            string qJson;
            AssetManager qAssets = this.Assets;
            using (var streamReader = new StreamReader(qAssets.Open("Questions.json")))
            {
                qJson = streamReader.ReadToEnd();
            }

            Questions = QuestionParser.ParseJsonData(qJson);

            var Item1 = FindViewById<ImageView>(Resource.Id.MaterialItem1);
            var Item2 = FindViewById<ImageView>(Resource.Id.MaterialItem2);
            var Item3 = FindViewById<ImageView>(Resource.Id.MaterialItem3);
            var Item4 = FindViewById<ImageView>(Resource.Id.MaterialItem4);

            Item1.Click += Item1_Click;
            Item2.Click += Item2_Click;
            Item3.Click += Item3_Click;
            Item4.Click += Item4_Click;

        }

        private void Item1_Click(object sender, EventArgs e)
        {
            // Nujna medicinska pomoč
            Intent intent = new Intent(this, typeof(NujnaPomoc));
            StartActivity(intent);
        }

        private void Item2_Click(object sender, EventArgs e)
        {
            // Koliko vem o nudenju prve pomoči?
            Intent intent = new Intent(this, typeof(KolikoVem));
            StartActivity(intent);
        }

        private void Item3_Click(object sender, EventArgs e)
        {
            // Zemljevid AED naprav po Sloveniji

            var permissionCheckOne = ContextCompat.CheckSelfPermission(this, PermissionsLocation[0]);
            var permissionCheckTwo = ContextCompat.CheckSelfPermission(this, PermissionsLocation[1]);

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (permissionCheckOne == Permission.Granted && permissionCheckTwo == Permission.Granted)
                {
                    Intent intent = new Intent(this, typeof(AED));
                    StartActivity(intent);
                }
                else
                {
                    ActivityCompat.RequestPermissions(this, new string[] { PermissionsLocation[0] }, REQUEST_LOCATION);
                    ActivityCompat.RequestPermissions(this, new string[] { PermissionsLocation[1] }, REQUEST_LOCATION);
                }
            }
            else
            {
                Intent intent = new Intent(this, typeof(AED));
                StartActivity(intent);
            }
        }

        private void Item4_Click(object sender, EventArgs e)
        {
            // Klic 112

            // Pogledamo, če že imamo pravice za dostop.
            var permissionCheck = ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.CallPhone);

            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (permissionCheck != Android.Content.PM.Permission.Granted)
                {
                    ActivityCompat.RequestPermissions(this, new string[] { Android.Manifest.Permission.CallPhone }, REQUEST_PHONE);
                }
                else
                {
                    Intent callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse("tel:112"));
                    StartActivity(callIntent);
                }
            }
            else
            {
                Intent callIntent = new Intent(Intent.ActionCall);
                callIntent.SetData(Android.Net.Uri.Parse("tel:112"));
                StartActivity(callIntent);
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (requestCode == REQUEST_PHONE)
            {
                // If request is cancelled, the result arrays are empty.
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                {
                    Intent callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse("tel:112"));
                    StartActivity(callIntent);
                }
                else
                {
                    Toast.MakeText(this, "Za dostop je potrebno dovoljenje.", ToastLength.Long).Show();
                }
                return;
            }
            else if(requestCode == REQUEST_LOCATION)
            {
                // If request is cancelled, the result arrays are empty.
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                {
                    Intent intent = new Intent(this, typeof(AED));
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(this, "Za dostop je potrebno dovoljenje.", ToastLength.Long).Show();
                }
                return;
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
    }
}

