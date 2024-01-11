﻿using Proiect1.BLL.Interfaces;
using Proiect1.DAL.Entities;
using System.Collections.Generic;
using Proiect1.BLL.DTOs;
using Proiect1.DAL;
using System.Net.Mail;
using System.Threading.Tasks;
using System;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Linq;

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
            var friendships = db.Friendships.ToList();
            foreach (var fs in friendships)
            {
                if (fs.UserId == id || fs.FriendId == id)
                {
                    db.Friendships.Remove(fs);
                }
            }
            db.SaveChanges();
            userRepository.DeleteUser(user);
        }

        public virtual async Task SendEmailTemplate(EmailReceiverDTO emailDto)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Environment.GetEnvironmentVariable("SENDGRID_EMAIL"), Environment.GetEnvironmentVariable("SENDGRID_NAME"));
            var to = new EmailAddress(emailDto.Email, emailDto.Name);
            var subject = "Thank you for your register!";
            var plainTextContent = "Hi!";
            var htmlContent = "<p><span style=\"font-family:Lucida Sans Unicode,Lucida Grande,sans-serif\"><span style=\"font-size:14px\">Hello, t</span>hank you for registering on Bookgram!&nbsp;</span></p>" +
                "<p><span style=\"font-family:Lucida Sans Unicode,Lucida Grande,sans-serif\">BookGram is the right place for your reading! You will be able to post your favorite books, you will have weekly challenges and you will be able to make friends who love reading.</span></p>" +
                "<p>&nbsp;</p>";
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                subject,
                plainTextContent,
                htmlContent
           );
            var response = await client.SendEmailAsync(msg);
        }
    }
}