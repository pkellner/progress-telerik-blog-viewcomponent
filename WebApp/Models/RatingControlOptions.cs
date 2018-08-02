using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class RatingControlOptions
    {
        public RatingControlOptions()
        {
            // Set default values.
            RatingControlType = "movie"; // default, other options: 1to10;movie;pill

            RatingControlValuesMovie = new List<string> { "Bad", "Mediocre", "Good", "Awesome" };
            RatingControlInitialValueMovie = "Awesome";

            RatingControlValues1to10 = new List<string> {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};
            RatingControlInitialValue1to10 = "10";


            RatingControlValuesPill = new List<string> { "A", "B", "C", "D", "E", "F" };
            RatingControlInitialValuePill = "A";
        }

        public string RatingControlType { get; set; }

        public List<string> RatingControlValuesMovie { get; set; }
        public string RatingControlInitialValueMovie { get; set; }

        public List<string> RatingControlValues1to10 { get; set; }
        public string RatingControlInitialValue1to10 { get; set; }


        public List<string> RatingControlValuesPill { get; set; }
        public string RatingControlInitialValuePill { get; set; }
    }
}
