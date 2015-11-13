using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebApiApplication.Models
{
    public class CustomerDb : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}