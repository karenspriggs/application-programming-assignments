using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer.Models;
using ServiceLayer.DAL;

namespace API.Controllers
{
    public class FighterController : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class GameController : ControllerBase
        {
            private FighterDAL _dateService = new FighterDAL();

            [HttpGet]
            [Route("get-all")]
            public IEnumerable<FighterModel> Get()
            {
                return _dateService.APIGetAll();
            }

            [HttpGet]
            [Route("get-by-name/{name}")]
            public IEnumerable<FighterModel> Get(string name)
            {
                return _dateService.APIGetbyName(name);
            }
        }
    }
}
