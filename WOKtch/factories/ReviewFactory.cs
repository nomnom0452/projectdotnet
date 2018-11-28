using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.Models;

namespace WOKtch.factories
{
    public class ReviewFactory
    {
        public static Review createReview(int rating, string review, int productId, string email)
        {
            return new Review()
            {
                ReviewRating = rating,
                ReviewDescription = review,
                ProductId = productId,
                MemberEmail = email
            };
        }

        public static ReviewViewModel createReviewView(int rating, string review, int reviewId, string memberName)
        {
            return new ReviewViewModel()
            {
                ReviewRating = rating,
                ReviewDescription = review,
                MemberName = memberName,
                ReviewId = reviewId
            };
        }
    }
}