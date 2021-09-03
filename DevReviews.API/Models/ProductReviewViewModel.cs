using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevReviews.API.Models
{
    public class ProductReviewViewModel
    {
        public ProductReviewViewModel(int id, string auth, int rating, string comment, DateTime registeredAt)
        {
            Id = id;
            Auth = auth;
            Rating = rating;
            Comment = comment;
            RegisteredAt = registeredAt;
        }

        public int Id { get; private set; }
        public string Auth { get; private set; }
        public int Rating { get; private set; }
        public string Comment { get; private set; }
        public DateTime RegisteredAt { get; private set; }
    }
}
