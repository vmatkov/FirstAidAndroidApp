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
    public class Question
    {
        public int Id { get; set; }

        public string question { get; set; }
        public List<string> answers { get; set; }
        public List<int> correct { get; set; }

        public Question() { }

        public Question(int id, string q, List<string> a, List<int> c)
        {
            Id = id;
            question = q;
            answers = a;
            correct = c;
        }

        ~Question() { }

    }
}