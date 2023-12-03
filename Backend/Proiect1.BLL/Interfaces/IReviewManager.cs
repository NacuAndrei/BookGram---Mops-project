using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.BLL.Interfaces
{
    public interface IReviewManager
    {
        List<Review> GetUserReviews(int id);
        List<Review> GetBookReviews(string bookName);
        void CreateReview(ReviewModel model);
        Review GetReviewById(int id);
        void UpdateReview(ReviewModel model);
        void DeleteReview(int id);
        List<Review> GetAllReviews();
    }
}
