using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.Pages.Components.RatingControl
{
    public class RingControlModel
    {
        public List<SelectListItem> SelectedListItems { get; set; }
        public string RatingControlType { get; set; }
        public string RatingControlValue { get; set; }
        public int RatingControlIdValue { get; internal set; }
    }


    public class RatingControlViewComponent : ViewComponent
    {
        private readonly RatingControlOptions _ratingControlOptions;

        public RatingControlViewComponent(IConfiguration config)
        {
            _ratingControlOptions = new RatingControlOptions
            {
                RatingControlType = config["RatingControlType"],
                RatingControlInitialValue1to10 = config["RatingControlInitialValue1to10"],
                RatingControlInitialValuePill = config["RatingControlInitialValuePill"],
                RatingControlInitialValueMovie = config["RatingControlInitialValueMovie"]
            };
        }

        public IViewComponentResult Invoke(string ratingControlType,int ratingControlIdValue)
        {
            var ratingControlValues = new List<string>();
            var ratingControlInitialValue = "";

            if (ratingControlType == "pill")
            {
                _ratingControlOptions.RatingControlValuesPill.ForEach(a => ratingControlValues.Add(a));
                ratingControlInitialValue = _ratingControlOptions.RatingControlInitialValuePill;
            }
            else if (ratingControlType == "1to10")
            {
                _ratingControlOptions.RatingControlValues1to10.ForEach(a => ratingControlValues.Add(a));
                ratingControlInitialValue = _ratingControlOptions.RatingControlInitialValue1to10;

            }
            else if (ratingControlType == "movie")
            {
                _ratingControlOptions.RatingControlValuesMovie.ForEach(a => ratingControlValues.Add(a));
                ratingControlInitialValue = _ratingControlOptions.RatingControlInitialValueMovie;
            }

            List<SelectListItem> ratings = ratingControlValues
                .Select(myValue => new SelectListItem
                {
                    Value = myValue,
                    Text = myValue,
                    Selected = myValue.Equals(ratingControlInitialValue)
                }).ToList();

            RingControlModel ringControlModel = new RingControlModel
            {
                SelectedListItems = ratings,
                RatingControlType = ratingControlType,
                RatingControlValue = ratingControlInitialValue,
                RatingControlIdValue = ratingControlIdValue
            };

            return View(ringControlModel);
        }
    }
}
