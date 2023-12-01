using Proiect1.BLL.Models;
using Proiect1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.BLL.Interfaces
{
    public interface IBookManager
    {
        void AddBook(BookModel model);
        List<Book> GetAllBooks();
        Book GetBook(string title);
        List<Book> GetBookRecommendations();
    }
}
