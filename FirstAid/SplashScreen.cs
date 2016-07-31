using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FirstAid
{
    [Activity(Label = "Prva pomo�", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash", Icon = "@drawable/icon_")]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Thread.Sleep(1000);
            StartActivity(typeof(MainActivity));
        }
    }
}