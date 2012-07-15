using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Placesv1.DAL.Models {
    public class BlogContext : DbContext {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
