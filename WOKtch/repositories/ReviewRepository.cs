using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.Models;

namespace WOKtch.repositories
{
    public class ReviewRepository
    {
        static Database1Entities db = new Database1Entities();

        /*================================Review Repository========================================*/
            /*Manipulate Review Database*/
        public static int addProductReviewToDatabase(Review review)
        {
            db.Reviews.Add(review);
            return db.SaveChanges();
        }
        public static int updateProductReviewByMemberId(int reviewId, int rating, string reviewDesc)
        {
            Review r = db.Reviews.Find(reviewId);
            r.ReviewRating = rating;
            r.ReviewDescription = reviewDesc;

            return db.SaveChanges();
        }
        public static int deleteProductReviewByReviewId(int id)
        {
            Review r = db.Reviews.Find(id);
            db.Reviews.Remove(r);
            return db.SaveChanges();
        }

            /*  GET Review Data  */
        public static Review getReviewAndRatingByReviewId(int reviewId)
        {
            return db.Reviews.Find(reviewId);
        }


        /*================================Custom Review Repository========================================*/
            /*  GET Review Data  */
        public static List<ReviewViewModel> getProductReviewAndRatingByProductId(int productId)
        {
            return (from x in db.Reviews
                    join y in db.Members on x.MemberEmail equals y.MemberEmail
                    where x.ProductId == productId select new ReviewViewModel()
                    {
                         MemberName = y.MemberName,
                         ReviewId = x.ReviewId,
                         ReviewDescription = x.ReviewDescription,
                         ReviewRating = x.ReviewRating
                    }).ToList();
        }
        
    }
}