using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Placesv1.Model;
using Placesv1.DAL;

namespace Placesv1.DAL
{
    public class UserRepository : IUserRepository
    {
        private Placesv1DbContext db = new Placesv1DbContext();

        public IQueryable<User> GetUsers()
        {
            return db.Users.AsQueryable();
        }

        public User GetUser(int id)
        {
            return db.Users.Find(id);
        }

        public User GetUserByName(string name)
        {
            return db.Users.Where(u => u.NickName == name).FirstOrDefault();
        }

        public User PutUser(User user)
        {
            var _user = this.GetUser(user.UserID);
            _user.NickName = user.NickName;
            _user.Email = user.Email;
            _user.EmailVerified = user.EmailVerified;
            _user.Password = user.Password;
           
            db.SaveChanges();

            return user;
        }

        public void PostUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User DeleteUser(int id)
        {
            User user = GetUser(id);
            if (user == null)
            {
                return null;
            }

            db.Users.Remove(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return user;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}