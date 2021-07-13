using Microsoft.Extensions.Logging;
using Nav.Services.DBConfigAPI.Repository;
using Nav.Services.DBConfigAPI.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Nav.Services.DBConfigAPI.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Nav.Services.DBConfigAPI.Repository
{
    public class DbConfigRepository : IDbConfigRepository
    {
        private ApplicationDBContext _db;
        public DbConfigRepository(ApplicationDBContext db)
        {
            this._db = db;
           
        }
        async Task<bool> IDbConfigRepository.CreateUpdateDbConfigAsync(Fields fields)
        {
            var DB = DBData.products.ToList();
            try
            {
                Fields record = DBData.products.Where(x => x.FieldId == fields.FieldId)
                        .FirstOrDefault();
                if (record != null)
                {
                    int index = DB.IndexOf(record);
                    record.FieldId = fields.FieldId;
                    record.field = fields.field;
                    record.IsRquired = fields.IsRquired;
                    record.Maxlength = fields.Maxlength;
                    record.Source = fields.Source;
                }
                else
                {
                    DB.Add(fields);
                }                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error --> {0} and at function -->{1}",
                   ex.Message.ToString(), ex.Source);

            }
            finally
            {
               DBData.products = DB;
            }
            return true;
        }

   

         async Task<IEnumerable<Fields>> IDbConfigRepository.GetDBConfigAsync()
        {
            List<Fields> dbConfigData = new List<Fields>();
            try
            {
               // feedData();
                dbConfigData =  DBData.products.Select(x=>x).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error --> {0} and at function -->{1}",
                   ex.Message.ToString(), ex.Source);

            }
            return dbConfigData;
        }
     
    }


    
}
