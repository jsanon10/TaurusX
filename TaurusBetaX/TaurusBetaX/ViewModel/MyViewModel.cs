using System;
using System.Collections.Generic;
using System.Text;

namespace TaurusBetaX.ViewModel
{
    public class MyViewModel
    {
        private static MyViewModel _instance;
        public static MyViewModel Instance
        {
            get { return _instance ?? (_instance = new MyViewModel()); }
        }
        public string MyTextColor
        {
            get { return "#00FF00"; }
        }
    }
}
