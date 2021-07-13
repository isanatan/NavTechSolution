
using Microsoft.EntityFrameworkCore;
using Nav.Services.DBConfigAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nav.Services.DBConfigAPI.DbContexts
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
          // feedData();
        }

        public DbSet<Fields> Products { get; set; }

        public void feedData()
        {
            Products.AddRange(new Fields
            {

                FieldId = 101,
                field = "DbField1",
                Maxlength = 4,
                IsRquired = true,
                Source = "DB"
            },
            new Fields
            {

                FieldId = 102,
                field = "DbField2",
                Maxlength = 10,
                IsRquired = true,
                Source = "DB"
            },
            new Fields
            {

                FieldId = 103,
                field = "DbField3",
                Maxlength = 15,
                IsRquired = true,
                Source = "DB"
            },
            new Fields
            {

                FieldId = 104,
                field = "DbField4",
                Maxlength = 10,
                IsRquired = true,
                Source = "DB"
            }
            );
        }
    }
    
}
