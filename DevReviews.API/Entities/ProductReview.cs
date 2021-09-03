using System;

namespace DevReviews.API.Entities
{
    public class ProductReview
    {
        public ProductReview(string author, int rating, string comments, int productid)
        {
            Author = author;
            Rating = rating;
            Comments = comments;
            RegisteredAt = DateTime.Now;
            Productid = productid;
        }

        public int Id { get; private set; }
        public string Author { get; private set; }
        public int Rating { get; private set; }
        public string Comments { get; private set; }
        public DateTime RegisteredAt { get; private set; }
        public int Productid { get; private set; }
    }
}
