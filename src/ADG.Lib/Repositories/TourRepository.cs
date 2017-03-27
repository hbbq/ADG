using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADG.Lib.Models;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ADG.Lib.Repositories
{
    public class TourRepository : ITourRepository
    {

        internal Connectors.IApiConnector _apiConnector;
        internal Mappers.IApiMapper _apiMapper;

        public TourRepository(Connectors.IApiConnector apiConnector, Mappers.IApiMapper apiMapper)
        {
            _apiConnector = apiConnector;
            _apiMapper = apiMapper;
        }

        public IList<Models.Result> GetTourResults()
        {
            var response = _apiConnector.GetTourResults();
            var jArray = Newtonsoft.Json.Linq.JArray.Parse(response);
            var results = _apiMapper.ResultsFromJArray(jArray);
            return results;
        }

    }

}