using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Placesv1.Model;
using Placesv1.DAL;

namespace Placesv1.Web.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserRepository repository;

        public UsersController(IUserRepository repository)
        {
            this.repository = repository;
        }

        // GET api/Users
        [Queryable]
        public IQueryable<User> GetUsers()
        {
            return repository.GetUsers().AsQueryable();
        }
        
        // GET api/Users/username
        public User GetUserByName(string name)
        {
            User user = repository.GetUserByName(name);
            if (user == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return user;
        }

        // PUT api/Users/5
        public HttpResponseMessage PutUser(User user)
        {
            user = repository.PutUser(user);
            var response = Request.CreateResponse<User>(HttpStatusCode.Created, user);
            string uri = Url.Link("DefaultApi", new { id = user.UserID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        // POST api/Users
        public HttpResponseMessage PostUser(User user)
        {
                this.repository.PostUser(user);
                var response = Request.CreateResponse<User>(HttpStatusCode.Created, user);
                string uri = Url.Link("DefaultApi", new { id = user.UserID });
                response.Headers.Location = new Uri(uri);
                return response;
        }

        // DELETE api/Users/5
        public HttpResponseMessage DeleteUser(int id)
        {
            User user = repository.GetUser(id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            repository.DeleteUser(id);

            try
            {
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }

        Uri GetUserLocation(int id)
        {
            var controller = this.Request.GetRouteData().Values["controller"];
            return new Uri(this.Url.Link("DefaultApi", new { controller = controller, id = id }));
        }
    }
}