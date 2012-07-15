using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Formatting;
using Placesv1.Models;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using Placesv1.Domain.Interfaces;
using Placesv1.Domain.Entities;
using Placesv1.Domain.Repositories;


namespace Placesv1.Controllers
{
    public class UsersController : ApiController
    {
        private IUserRepository repository;

        public UsersController(IUserRepository rep)
        {
            repository = rep;
        }

        // GET /api/users
        public IQueryable<User> Get()
        {
            return repository.Get().AsQueryable();
        }
    }
}