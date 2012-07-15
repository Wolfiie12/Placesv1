using System;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Placesv1.Web
{
    public class JsonNetSerialization : ISerialization
    {
        public string Serialize(object o)
        {
            return JsonConvert.SerializeObject((T)o);
        }

        public object DeSerialize(System.IO.Stream stream)
        {
            return JsonConvert.DeserializeObject(new StreamReader(stream).ReadToEnd());
        }
    }
}