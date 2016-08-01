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
using FirstAid.Resources.Model;
using FirstAid.Resources.FirstAidActivities;
using Android.Gms.Maps.Model;

namespace FirstAid
{
    [Activity(Label = "@string/menu_one")]
    public class NujnaPomoc : Activity
    {
        private ListView firstAidList;
        private List<string> firstAidEvents;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NujnaPomoc);

            ActionBar actionBar = ActionBar;
            actionBar.SetDisplayHomeAsUpEnabled(true);

            firstAidList = FindViewById<ListView>(Resource.Id.firstAidListView);
            firstAidEvents = new List<string>
            {
                "NEGIBNA OSEBA", "SRÈNI INFARKT", "MOŽGANSKA KAP", "DUŠENJE", "HUDE KRVAVITVE", "AMPUTIRAN PRST", "EPILEPTIÈNI NAPAD",
                "OPEKLNISKE RANE", "POŠKODBE GLAVE", "POŠKODBE HRBTENICE", "RANE", "SLADKORNA BOLEZEN", "ZASTRUPITEV", "ZLOM NOGE", "ZLOM ROKE",
                "ZVINI IN IZPAHI", "NAPAD PANIKE"
            };

            FirstAidListViewAdapter adapter = new FirstAidListViewAdapter(this, firstAidEvents);
            firstAidList.Adapter = adapter;

            firstAidList.ItemClick += FirstAidList_ItemClick;

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

        public static void loadImage(Activity a, int id, int image)
        {
            ImageView imgView = a.FindViewById<ImageView>(id);
            imgView.SetImageResource(image);
        }

        public static void unloadImage(Activity a, int id)
        {
            ImageView imgView = a.FindViewById<ImageView>(id);
            imgView.SetImageResource(0);
        }

        private void FirstAidList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if(e.Position == 0)
            {
                Intent intent = new Intent(this, typeof(NegibnaOseba));
                StartActivity(intent);
            }
            else if (e.Position == 1)
            {
                Intent intent = new Intent(this, typeof(SrcnaKap));
                StartActivity(intent);
            }
            else if (e.Position == 2)
            {
                Intent intent = new Intent(this, typeof(MozganskaKap));
                StartActivity(intent);
            }
            else if (e.Position == 3)
            {
                Intent intent = new Intent(this, typeof(Dusenje));
                StartActivity(intent);
            }
            else if (e.Position == 4)
            {
                Intent intent = new Intent(this, typeof(HudeKrvavitve));
                StartActivity(intent);
            }
            else if (e.Position == 5)
            {
                Intent intent = new Intent(this, typeof(AmputiranPrst));
                StartActivity(intent);
            }
            else if (e.Position == 6)
            {
                Intent intent = new Intent(this, typeof(EpilepticniNapad));
                StartActivity(intent);
            }
            else if (e.Position == 7)
            {
                Intent intent = new Intent(this, typeof(OpeklinskeRane));
                StartActivity(intent);
            }
            else if (e.Position == 8)
            {
                Intent intent = new Intent(this, typeof(PoskodbaGlave));
                StartActivity(intent);
            }
            else if (e.Position == 9)
            {
                Intent intent = new Intent(this, typeof(PoskodbaHrbtenice));
                StartActivity(intent);
            }
            else if (e.Position == 10)
            {
                Intent intent = new Intent(this, typeof(Rane));
                StartActivity(intent);
            }
            else if (e.Position == 11)
            {
                Intent intent = new Intent(this, typeof(SladkornaBolezen));
                StartActivity(intent);
            }
            else if (e.Position == 12)
            {
                Intent intent = new Intent(this, typeof(Zastrupitev));
                StartActivity(intent);
            }
            else if (e.Position == 13)
            {
                Intent intent = new Intent(this, typeof(ZlomNoge));
                StartActivity(intent);
            }
            else if (e.Position == 14)
            {
                Intent intent = new Intent(this, typeof(ZlomRoke));
                StartActivity(intent);
            }
            else if (e.Position == 15)
            {
                Intent intent = new Intent(this, typeof(ZviniIzpahi));
                StartActivity(intent);
            }
            else if (e.Position == 16)
            {
                Intent intent = new Intent(this, typeof(NapadPanike));
                StartActivity(intent);
            }
        }
    }
}