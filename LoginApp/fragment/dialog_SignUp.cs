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
using LoginApp.eventargs;

namespace LoginApp.fragment
{
    class Dialog_SignUp : DialogFragment
    {
        private EditText mFistname;
        private EditText mEmail;
        private EditText mPassword;
        private Button mSignup;

        public EventHandler<OnSignUpEventArgs> mOnSignUpComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_signup, container, false);
            mFistname = view.FindViewById<EditText>(Resource.Id.txtFirstName);
            mEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            mPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            mSignup = view.FindViewById<Button>(Resource.Id.btnRegister);
            mSignup.Click += MSignup_Click;
            return view;
        }

        private void MSignup_Click(object sender, EventArgs e)
        {
            mOnSignUpComplete.Invoke(this, new OnSignUpEventArgs(mFistname.Text, mEmail.Text, mPassword.Text));
            Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.DialogAnimation;
        }
    }
}