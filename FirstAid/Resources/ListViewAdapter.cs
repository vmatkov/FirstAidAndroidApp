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
using Java.Lang;

namespace FirstAid.Resources
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtQuestion { set; get; }
        public TextView txtAnswer1 { set; get; }
        public TextView txtAnswer2 { set; get; }
        public TextView txtAnswer3 { set; get; }
        public TextView txtAnswer4 { set; get; }
    }

    public class ListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Question> listQuestion;

        public ListViewAdapter(Activity activity, List<Question> listQuestion)
        {
            this.activity = activity;
            this.listQuestion = listQuestion;
        }

        public override int Count
        {
            get
            {
                return listQuestion.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return listQuestion[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View v = null;
            return v;
            //var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout)
        }
    }
}