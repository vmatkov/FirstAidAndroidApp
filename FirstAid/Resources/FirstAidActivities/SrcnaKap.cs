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

namespace FirstAid.Resources.FirstAidActivities
{
    [Activity(Label = "Srèni infarkt")]
    public class SrcnaKap : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.SrcniInfarkt);

            NujnaPomoc.loadImage(this, Resource.Id.srcniInfarkt, Resource.Drawable.srcniInfarkt);

            ActionBar actionBar = ActionBar;
            actionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnBackPressed()
        {
            NujnaPomoc.unloadImage(this, Resource.Id.srcniInfarkt);
            Finish();
            base.OnBackPressed();
        }
    }
}