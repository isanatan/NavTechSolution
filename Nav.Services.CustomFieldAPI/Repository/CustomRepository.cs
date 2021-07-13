using Microsoft.Extensions.Logging;
using Nav.Services.CustomFieldAPI.Repository;
using Nav.Services.CustomFieldAPI.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nav.Services.DefaultFieldsAPI.Repository
{
    public class CustomRepository : ICustomRepository
    {
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            List<Product> defaultList = new List<Product>();
            try
            {
                var data =  FeedDefaultData();
                defaultList = data.Select(x => x).ToList();
            }

            catch(Exception ex)  
            {
                Debug.WriteLine("Error --> {0} and at function -->{1}",
                    ex.Message.ToString(), ex.Source);
            }
            return defaultList;
        }

        private static IList<Product> FeedDefaultData()
        {
            List<Product> defaultList = new List<Product>();

            defaultList.Add(new Product
            {
                FieldId = 11,
               field ="CField1",
                IsRquired = true,
                Maxlength = 10,
                Source = "Source2"
            });
            defaultList.Add(new Product
            {
                FieldId = 12,
                field = "CField2",
                IsRquired = true,
                Maxlength = 5,
                Source = "Source2"
            });
            defaultList.Add(new Product
            {
                FieldId = 13,
                field = "CField3",
                IsRquired = true,
                Maxlength = 8,
                Source = "Source2"
            });
            defaultList.Add(new Product
            {
                FieldId = 14,
                field = "CField4",
                IsRquired = true,
                Maxlength = 10,
                Source = "Source2"
            });
            defaultList.Add(new Product
            {
                FieldId = 15,
                field = "CField5",
                IsRquired = true,
                Maxlength = 6,
                Source = "Source2"
            });
            return defaultList;
        }
    }
}
