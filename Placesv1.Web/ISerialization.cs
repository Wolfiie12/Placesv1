using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placesv1.Web
{
    public interface ISerialization
    {
        string Serialize(object o);
        object DeSerialize(Stream stream);
    }
}