using Proiect1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.BLL.Interfaces
{
    public interface IReviewRepository
    {
        IQueryable<Review> GetUserReviewsIQueryable(int id);
        IQueryable<Review> GetBookReviewsIQueryable(string bookName);
        void CreateReview(Review review);
        Review GetReviewById(int id);
        void UpdateReview(Review review);
        void DeleteReview(Review review);
        List<Review> GetReviewsToList();
    }
}
