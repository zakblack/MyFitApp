using MyFit.helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyFit.models
{
    class User
    {

       
        public string username { get; set; }
        
        public string email { get; set; }

        public string password { get; set; }
        public int poids { get; set; }
        public int height { get; set; }
        public int age { get; set; }

        public string fullname { get; set; }

    }
}
