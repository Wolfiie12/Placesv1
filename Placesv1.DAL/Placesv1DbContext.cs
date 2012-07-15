using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Placesv1.Model;

namespace Placesv1.DAL
{
    public class Placesv1DbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
