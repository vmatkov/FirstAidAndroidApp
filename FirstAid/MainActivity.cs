using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Android.Content.PM;

namespace FirstAid
{
    [Activity(Label = "@string/ApplicationName")]
    public class MainActivity : Activity
    {
        static readonly int REQUEST_PHONE = 0;

        protected override void OnCreate(Bundle bundle)
        {
            //RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

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
            Intent intent = new Intent(this, typeof(AED));
            StartActivity(intent);
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
                    ActivityCompat.RequestPermissions(this, new String[] { Android.Manifest.Permission.CallPhone }, REQUEST_PHONE);
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
                    Toast.MakeText(this, "Permission required", ToastLength.Long).Show();
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

