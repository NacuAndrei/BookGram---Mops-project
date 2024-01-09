using Proiect1.BLL.Interfaces;
using Proiect1.DAL.Entities;
using System.Collections.Generic;
using Proiect1.BLL.DTOs;
using Proiect1.DAL;

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
        }
    }
}