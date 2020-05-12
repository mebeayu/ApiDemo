using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Filter;
using ApiDemo.M;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DemoController : ControllerBase
    {

        [Route("/show/{id}")]
        [HttpGet]
        [ActionFilter]
        public object show(int id)
        {
            return new { id = id };
        }
        [HttpGet]
        [Route("showa/{id}")]
        public object showa(int id)
        {
            return new { id = id };
        }
        [HttpPost]
        [Route("/postst")]
        [ActionFilter]
        public user showb([FromBody] user obj)
        {
            var httpcontext =  this.HttpContext;
            string uid = this.HttpContext.Request.Headers["uid"];
            
            return obj;
        }
        [HttpGet]
        [Route("/getlist")]
        public List<string> getlist()
        {
            CorsHandler.list.Add("getlist");
            return CorsHandler.list;
        }
    }
}