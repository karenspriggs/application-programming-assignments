using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using ServiceLayer;
using ServiceLayer.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private DAL _dateService = new DAL();

        [HttpGet]
        [Route("get-all")]
        public IEnumerable<UserModel> Get()
        {
            return _dateService.APIGetAll();
        }

        [HttpGet]
        [Route("get-by-name/{name}")]
        public IEnumerable<UserModel> Get(string name)
        {
            return _dateService.APIGetbyName(name);
        }


        [HttpPost]
        [Route("insert-record")]
        public int Post([FromBody] UserModel model)
        {
            return _dateService.APIInsertRecord(model);
        }

        [HttpPost]
        [Route("update-record")]
        public int Update([FromBody] UserModel model)
        {
            return _dateService.APIUpdateRecord(model);
        }

        [HttpDelete]
        [Route("delete-by-id/{id}")]
        public string Delete(int id)
        {
            return _dateService.APIDeleteById(id);
        }
    }
}
