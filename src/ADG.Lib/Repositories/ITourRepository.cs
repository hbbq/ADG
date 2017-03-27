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

namespace ADG.Lib.Repositories
{

    public interface ITourRepository
    {

        IList<Models.Result> GetTourResults();

    }

}