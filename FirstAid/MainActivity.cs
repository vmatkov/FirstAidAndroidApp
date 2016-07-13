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

            var Item1 = FindViewById<ImageView>(Resource.Id.MaterialItem1);
            var Item2 = FindViewById<ImageView>(Resource.Id.MaterialItem2);
            var Item3 = FindViewById<ImageView>(Resource.Id.MaterialItem2);
            var Item4 = FindViewById<ImageView>(Resource.Id.MaterialItem3);

            Item1.Click += Item1_Click;
            Item2.Click += Item2_Click;
            Item3.Click += Item3_Click;
            Item4.Click += Item4_Click;

        }

        private void Item1_Click(object sender, EventArgs e)
        {
            // Nujna medicinska pomoč
        }

        private void Item2_Click(object sender, EventArgs e)
        {
            // Koliko vem o nudenju prve pomoči?
        }

        private void Item3_Click(object sender, EventArgs e)
        {
            // Zemljevid AED naprav po Sloveniji
        }

        private void Item4_Click(object sender, EventArgs e)
        {
            // Klic 112
        }
    }
}

