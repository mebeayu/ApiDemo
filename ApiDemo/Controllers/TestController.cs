using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IDB _db;
        public TestController(IDB db)
        {
            _db = db;
        }
        [HttpGet("show")]
        [Route("show/{id}")]
        public object show(int id)
        {
            return new { id = id };
        }
        [HttpGet]
        [Route("/info2")]
        public dynamic info()
        {
            DataSet ds = _db.ExeQuery("select * from sys_dept");
            return ds.Tables[0];
        }
    }
}