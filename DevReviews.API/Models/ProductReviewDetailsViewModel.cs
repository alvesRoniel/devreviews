using System;

namespace DevReviews.API.Models
{
    public class ProductReviewDetailsViewModel
    {
        public int Id { get; private set; }
        public string Auth { get; private set; }
        public int Rating { get; private set; }
        public string Comment { get; private set; }
        public DateTime RegisteredAt { get; private set; }
    }
}
