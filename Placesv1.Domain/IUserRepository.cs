using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Placesv1.Model;

namespace Placesv1.DAL
{
    public interface IUserRepository
    {
        IQueryable<User> GetUsers();
        User GetUser(int id);
        User GetUserByName(string name);
        User PutUser(User user);
        void PostUser(User user);
        User DeleteUser(int id);
        void Save();
        void Dispose();
    }
}