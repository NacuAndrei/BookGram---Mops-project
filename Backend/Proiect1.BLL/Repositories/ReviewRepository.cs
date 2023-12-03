using Proiect1.BLL.Interfaces;
using Proiect1.DAL.Entities;
using Proiect1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.BLL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext db;
        public ReviewRepository(AppDbContext db)
        {
            this.db = db;
        }
        public IQueryable<Review> GetUserReviewsIQueryable(int id)
        {
            var reviews = db.Reviews.Where(x => x.UserId == id);
            return reviews;
        }

        public List<Review> GetReviewsToList()
        {
            var reviews = db.Reviews.ToList();
            return reviews;
        }

        public IQueryable<Review> GetBookReviewsIQueryable(string bookName)
        {
            var books = db.Books.Where(x => x.Title == bookName).ToList();

            var bookIDs = books.Select(x => x.Id);

            var reviews = db.Reviews
                .Where(x => bookIDs.Contains(x.BookId));

            return reviews;
        }

        public Review GetReviewById(int id)
        {
            var review = db.Reviews
                .FirstOrDefault(x => x.Id == id);

            return review;
        }

        public void CreateReview(Review review)
        {
            db.Reviews.Add(review);
            db.SaveChanges();
        }

        public void UpdateReview(Review review)
        {
            db.Reviews.Update(review);
            db.SaveChanges();
        }

        public void DeleteReview(Review review)
        {
            db.Reviews.Remove(review);
            db.SaveChanges();
        }

    
    }
}
