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
                "NEGIBNA OSEBA", "SRÈNA KAP", "MOŽGANSKA KAP", "DUŠENJE", "HUDE KRVAVITVE", "ALERGIÈNI NAPAD", "AMPUTIRAN PRST", "EPILEPTIÈNI NAPAD",
                "OPEKLNISKE RANE", "POŠKODBE GLAVE", "POŠKODBE HRBTENICE", "RANE", "SLADKORNA BOLEZEN", "ZASTRUPITEV", "ZLOM NOGE", "ZLOM ROKE",
                "ZVINI IN IZPAHI"
            };

            FirstAidListViewAdapter adapter = new FirstAidListViewAdapter(this, firstAidEvents);
            firstAidList.Adapter = adapter;

            firstAidList.ItemClick += FirstAidList_ItemClick;

        }

        private void FirstAidList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, firstAidEvents[e.Position], ToastLength.Long).Show();
        }
    }
}