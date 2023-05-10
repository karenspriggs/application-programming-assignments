using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.DAL;
using ServiceLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UserController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class GameController : ControllerBase
        {
            private UserDAL _dateService = new UserDAL();

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
        }
    }
}
