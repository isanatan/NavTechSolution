using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nav.Services.DefaultFieldsAPI.Model;
using Nav.Services.DefaultFieldsAPI.Repository;

namespace Nav.Services.DefaultFieldsAPI.Controllers
{
    [Route("api/DefaultFields")]
    [ApiController]
    public class DefaultFieldController : ControllerBase
    {
        private IDefaultRepository _defaultRepository;
        public DefaultFieldController(IDefaultRepository _defaultRepository)
        {
            this._defaultRepository = _defaultRepository;
            
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> getDefaultFieldsAsync()
        {
            IEnumerable<Product> defaultFieldList=new List<Product>();
            try
            {
                defaultFieldList =  await _defaultRepository.GetProductsAsync();
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error --> {0} and at function -->{1}",
                    ex.Message.ToString(), ex.Source);
            }
            return defaultFieldList;
        }
    }
}