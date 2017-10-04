using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using LoginApp.fragment;
using LoginApp.eventargs;
using System.Threading;

namespace LoginApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {

        private Button btnSignUp;
        private ProgressBar progress;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Set your main view here
            SetContentView(Resource.Layout.main);
            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            progress = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            btnSignUp.Click += BtnSignUp_Click;
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_SignUp dialog = new Dialog_SignUp();
            dialog.Show(transaction, "Dialog");
            dialog.mOnSignUpComplete += SignUpDialog_mOnSignUpComplete;
        }

        void SignUpDialog_mOnSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            progress.Visibility = ViewStates.Visible;
            Thread thread = new Thread(ActLikeRequest);
            thread.Start();
        }

        private void ActLikeRequest()
        {
            Thread.Sleep(3000);

            RunOnUiThread(() => { progress.Visibility = ViewStates.Invisible; });
            int x = Resource.Animation.slide_down;

        }
    }
}

