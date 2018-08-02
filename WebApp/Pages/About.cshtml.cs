using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace WebApp.Pages
{
    public class AboutModel : PageModel
    {
        private  string _ratingControlColor;
        private  string _ratingControlType;

        public AboutModel(IConfiguration config)
        {
             _ratingControlColor = config["RatingControlColor"];
             _ratingControlType = config["RatingControlType"];
        }
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "RatingControlColor:" + _ratingControlColor +
                " RatingControlType:" + _ratingControlType;
        }
    }
}
