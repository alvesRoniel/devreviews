namespace DevReviews.API.Models
{
    public class AddProductReviewInputModel
    {
        public int Racting { get; set; }
        public string Author { get; set; }
        public string Comments { get; set; }
        public int ProductId { get; internal set; }
    }
}
