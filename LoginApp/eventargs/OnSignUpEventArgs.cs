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

namespace LoginApp.eventargs
{
    public class OnSignUpEventArgs : EventArgs
    {
        public OnSignUpEventArgs()
        {
        }

        public OnSignUpEventArgs(string firstName, string email, string password)
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }

        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }        
    }
}