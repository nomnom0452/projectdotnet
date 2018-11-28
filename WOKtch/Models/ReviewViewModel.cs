using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOKtch.Models
{
    public class ReviewViewModel
    {
        public string MemberName { get; set; }
        public int ReviewId { get; set; }
        public int ReviewRating { get; set; }
        public string ReviewDescription { get; set; }
    }
}