using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using Placesv1.Web.Models;
using Placesv1.Web;

namespace MVCWebAPIConsumer
{
    public class ProductRepository
    {
        private string restService = ConfigurationManager.AppSettings["restService"];
        private RequestMethod requestMethod = new RequestMethod();
        ISerialization _serializer;

        public ProductRepository(ISerialization serializer)
        {
            _serializer = serializer;
        }

        public User New()
        {
            return new User();
        }

        public void Update(User user)
        {
            String json = serializeProduct(user);
            requestMethod.getRequest("PUT", "application/json", "http://localhost:18950/api/users", json).GetResponse();
        }

        public List<User> Get()
        {
            var responseStream = requestMethod.GetResponseStream(requestMethod.getRequest("GET", "application/json",
             string.Format("{0}/api/users/", restService))
                                                                              .GetResponse());

            var products = deSerializeProduct<List>(responseStream) as List;

            return products;
        }

        public User Get(int id)
        {
            var responseStream = requestMethod.GetResponseStream(requestMethod.getRequest("GET", "application/json",
             string.Format("{0}/api/users/{1}", restService, id)).GetResponse());

            var product = deSerializeProduct(responseStream) as User;

            return product;
        }

        public void Create(User user)
  {
   String json = serializeProduct(user);
   requestMethod.getRequest("POST", "application/json", string.Format("{0}/api/users/", json).GetResponse();
  }

        public object deSerializeProduct(Stream stream)
        {
            var retval = _serializer.DeSerialize(stream);

            return retval;
        }

        public string serializeProduct(User user)
        {
            var retval = _serializer.Serialize(user);

            return retval;
        }

        public void Delete(int id)
        {
            requestMethod.GetResponseStream(requestMethod.getRequest("DELETE", "application/json",
             string.Format("{0}/api/users/{1}", restService, id)).GetResponse());
        }
    }
}