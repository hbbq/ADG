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

namespace ADG.Lib.Models
{

    public class Result
    {

        public string Player { get; set; }
        public string Class { get; set; }
        public string Course { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }

    }

}