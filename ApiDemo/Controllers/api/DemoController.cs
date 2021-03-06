﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApiDemo.Filter;
using ApiDemo.M;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DemoController : ControllerBase
    {
        private IDB _db;
        public DemoController(IDB dbsql)
        {
            _db = dbsql;
        }
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
        [Route("/getlist/{item}")]
        public List<string> getlist(string item)
        {
            CorsHandler.list.Add(item);
            return CorsHandler.list;
        }
        [HttpGet]
        [Route("/info")]
        public dynamic info()
        {

            //DBSQL db = new DBSQL();
            //db.ConnectSQLServerDB("10.43.4.16","zbb","jfsys","jfsys123");
            //DataSet ds = db.ExeQuery("select * from 用户");
            //return DBSQL.DataSetToList(ds);
            return "hi";
        }
        [HttpGet]
        [Route("encode")]
        public string encode(string data)
        {
            return BCrypt.Net.BCrypt.HashPassword(data);
        }
        async Task<DataSet> getDS()
        {
            DataSet ds = null;
            await Task.Run(()=>
            {
                Thread.Sleep(10000);
                //ds = _db.ExeQuery("select * from sys_dept");

                
            });
            return ds;

        }
    }
}