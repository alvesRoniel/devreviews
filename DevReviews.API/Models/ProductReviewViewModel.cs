using System;

namespace DevReviews.API.Models
{
    public class ProductReviewViewModel
    {
        public ProductReviewViewModel(int id, string auth, int rating, string comment, DateTime registeredAt, int produtctId)
        {
            Id = id;
            Auth = auth;
            Rating = rating;
            Comment = comment;
            RegisteredAt = DateTime.Now;
            ProdutctId = produtctId;
        }

        public int Id { get; private set; }
        public string Auth { get; private set; }
        public int Rating { get; private set; }
        public string Comment { get; private set; }
        public DateTime RegisteredAt { get; private set; }
        public int ProdutctId { get; private set; }
    }
}
