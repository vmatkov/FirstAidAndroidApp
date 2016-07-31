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

        private void FirstAidList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if(e.Position == 0)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(NegibnaOseba));
                StartActivity(intent);
            }
            else if (e.Position == 1)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(SrcnaKap));
                StartActivity(intent);
            }
            else if (e.Position == 2)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(MozganskaKap));
                StartActivity(intent);
            }
            else if (e.Position == 3)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(Dusenje));
                StartActivity(intent);
            }
            else if (e.Position == 4)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(HudeKrvavitve));
                StartActivity(intent);
            }
            else if (e.Position == 5)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(AmputiranPrst));
                StartActivity(intent);
            }
            else if (e.Position == 6)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(EpilepticniNapad));
                StartActivity(intent);
            }
            else if (e.Position == 7)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(OpeklinskeRane));
                StartActivity(intent);
            }
            else if (e.Position == 8)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(PoskodbaGlave));
                StartActivity(intent);
            }
            else if (e.Position == 9)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(PoskodbaHrbtenice));
                StartActivity(intent);
            }
            else if (e.Position == 10)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(Rane));
                StartActivity(intent);
            }
            else if (e.Position == 11)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(SladkornaBolezen));
                StartActivity(intent);
            }
            else if (e.Position == 12)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(Zastrupitev));
                StartActivity(intent);
            }
            else if (e.Position == 13)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(ZlomNoge));
                StartActivity(intent);
            }
            else if (e.Position == 14)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(ZlomRoke));
                StartActivity(intent);
            }
            else if (e.Position == 15)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(ZviniIzpahi));
                StartActivity(intent);
            }
            else if (e.Position == 16)
            {
                Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(NapadPanike));
                StartActivity(intent);
            }
        }
    }
}