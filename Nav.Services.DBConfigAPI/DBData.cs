using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nav.Services.DBConfigAPI.DbContexts;
using Nav.Services.DBConfigAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nav.Services.DBConfigAPI
{
    public static class DBData
    {
        public static IEnumerable<Fields> products;

        public static void feedData(ApplicationDBContext context)
        {
            
            
                // Look for any board games.
                if (context.Products.Any())
                {
                    // Data was already seeded
                }

                context.Products.AddRange(new Fields
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

            products = context.Products.Local;


        }
    }
}
