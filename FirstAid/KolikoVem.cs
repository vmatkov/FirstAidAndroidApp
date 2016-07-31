using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Collections.Generic;
using FirstAid.Resources.Model;
using Android.Views;

namespace FirstAid
{
    [Activity(Label = "@string/menu_two")]
    public class KolikoVem : Activity
    {
        private TextView questionTextView;
        private ListView listView;
        private Button Confirm;
        private List<Question> listSource = new List<Question>();
        private static List<string> selectedItems = new List<string>();
        private List<int> correctAnswers = new List<int>();
        private int id = 0;
        private int pointScore = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.KolikoVem);

            ActionBar actionBar = ActionBar;
            actionBar.SetDisplayHomeAsUpEnabled(true);

            questionTextView = FindViewById<TextView>(Resource.Id.textQuestion);
            listView = FindViewById<ListView>(Resource.Id.answersList);
            Confirm = FindViewById<Button>(Resource.Id.confirm);
            
            listView.ChoiceMode = ChoiceMode.Multiple;

            listSource = MainActivity.Questions;

            questionTextView.SetText(listSource[id].question, TextView.BufferType.Normal);

            QuestionsListViewAdapter adapter = new QuestionsListViewAdapter(this, listSource[id].answers);
            listView.Adapter = adapter;

            correctAnswers = listSource[id].correct;

            Confirm.Click += Confirm_Click;
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

        public static void CheckAnswer_Click(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            if (selectedItems.Contains(cb.Text))
                selectedItems.Remove(cb.Text);
            else
                selectedItems.Add(cb.Text);
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (id < 11)
            {
                List<int> selected = new List<int>();
                for (var i = 0; i < selectedItems.Count; i++)
                {
                    var m = listSource[id].answers.IndexOf(selectedItems[i]);
                    selected.Add(m);
                }

                if(new HashSet<int>(selected).SetEquals(correctAnswers))//if (selected == correctAnswers)
                {
                    pointScore++;
                    Toast.MakeText(this, "Pravilno", ToastLength.Short).Show();
                }
                else Toast.MakeText(this, "Žal napaèno", ToastLength.Short).Show();

                id++;
                selectedItems.Clear();
                selected.Clear();

                if (id < 11)
                {
                    questionTextView.SetText(listSource[id].question, TextView.BufferType.Normal);

                    QuestionsListViewAdapter adapter = new QuestionsListViewAdapter(this, listSource[id].answers);
                    listView.Adapter = adapter;

                    correctAnswers = listSource[id].correct;
                }
                else
                {
                    var procent = Math.Round((pointScore / 11.0 * 100), 1);
                    questionTextView.SetText("Kviz ste zakljuèili, dosegli ste: " + procent + "%.", TextView.BufferType.Normal);
                    listView.Adapter = null;
                    Confirm.SetText("Konèaj", TextView.BufferType.Normal);
                }
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }
}