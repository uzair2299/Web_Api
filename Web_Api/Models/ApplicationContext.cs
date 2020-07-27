using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web_Api.Models
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext():base("name = WebApi")
        {

        } 

        public DbSet<User> Users { get; set; }
    }
}