using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nav.Services.CustomFieldAPI.Model;
using Nav.Services.CustomFieldAPI.Repository;

namespace Nav.Services.CustomFieldAPI.Controllers
{
    [Route("api/CustomFields")]
    [ApiController]
    public class CustomFieldController : ControllerBase
    {
        private ICustomRepository _customRepository;
        public CustomFieldController(ICustomRepository _customRepository)
        {
            this._customRepository = _customRepository;
            
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> getCustomFieldsAsync()
        {
            IEnumerable<Product> defaultFieldList=new List<Product>();
            try
            {
                defaultFieldList =  await _customRepository.GetProductsAsync();
               
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