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

namespace FirstAid.Resources.Model
{
    class FirstAidListViewAdapter : BaseAdapter<string>
    {
        private List<string> mItems;
        private Context mContext;

        public FirstAidListViewAdapter(Context context, List<string> items)
        {
            mItems = items;
            mContext = context;
        }

        public override string this[int position]
        {
            get
            {
                return mItems[position];
            }
        }

        public override int Count
        {
            get
            {
                return mItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.firstaidRow, null, false);
            }

            TextView firstAidItem = row.FindViewById<TextView>(Resource.Id.firstaidItem);
            firstAidItem.Text = mItems[position];

            return row;
        }
    }
}