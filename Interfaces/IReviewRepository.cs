using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewsOfAProduct(int productId);
        bool ReviewExists(int id);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool Save();
    }
}
