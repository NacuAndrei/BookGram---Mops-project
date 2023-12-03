using Proiect1.BLL.DTOs;
using Proiect1.BLL.Interfaces;
using Proiect1.DAL.Entities;
using Proiect1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Proiect1.BLL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly AppDbContext db;

        public UserManager(IUserRepository userRepository, AppDbContext db)
        {
            this.userRepository = userRepository;
            this.db = db;
        }

        public List<UserDTO> GetUsers()
        {
            return userRepository.GetAllUsersToList();
        }

        public string GetUserNameById(int id)
        {
            return userRepository.GetUserNameById(id);
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            userRepository.DeleteUser(user);
            db.SaveChanges();
        }

    }
}
