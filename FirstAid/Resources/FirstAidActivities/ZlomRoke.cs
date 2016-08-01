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
    [Activity(Label = "Zlom roke")]
    public class ZlomRoke : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ZlomRoke);

            NujnaPomoc.loadImage(this, Resource.Id.zlomRoke, Resource.Drawable.zlomRoke);

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
            NujnaPomoc.unloadImage(this, Resource.Id.zlomRoke);
            Finish();
            base.OnBackPressed();
        }
    }
}