using Microsoft.Extensions.Logging;
using Nav.Services.DefaultFieldsAPI.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nav.Services.DefaultFieldsAPI.Repository
{
    public class DefaultRepository : IDefaultRepository
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
                FieldId = 1,
               field ="Field1",
                IsRquired = true,
                Maxlength = 10,
                Source = "Source1"
            });
            defaultList.Add(new Product
            {
                FieldId = 2,
                field = "Field2",
                IsRquired = true,
                Maxlength = 5,
                Source = "Source1"
            });
            defaultList.Add(new Product
            {
                FieldId = 3,
                field = "Field3",
                IsRquired = true,
                Maxlength = 8,
                Source = "Source1"
            });
            defaultList.Add(new Product
            {
                FieldId = 4,
                field = "Field4",
                IsRquired = true,
                Maxlength = 10,
                Source = "Source1"
            });
            defaultList.Add(new Product
            {
                FieldId = 5,
                field = "Field5",
                IsRquired = true,
                Maxlength = 6,
                Source = "Source1"
            });
            return defaultList;
        }
    }
}
