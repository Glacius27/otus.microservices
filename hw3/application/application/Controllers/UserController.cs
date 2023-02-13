using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController 
    {

        private readonly ILogger<UserController> _logger;
        private DataBaseService _dbService;

        public UserController(ILogger<UserController> logger, DataBaseService service)
        {
            _logger = logger;
            _dbService = service;
        }

        [HttpPost]
        [Route("/User")]
        public Response CreateUser(User user)
        {

            var _user = _dbService.Create(user);
            return new Response()
            {
                Data = _user.UserID
            };
        }

        [HttpGet]
        [Route("{userId}")]
        public Response GetUserByID(string userId)
        {
            var user = _dbService.Find(userId);
            return new Response()
            {
                Data = user
            };
        }

        [HttpDelete]
        [Route("{userId}")]
        public Response DeleteUser(string userId)
        {
            var resp = new Response();
            var result = _dbService.Delete(userId);
            if (result.DeletedCount > 0)
            {
                resp.Code = (int)ErrorCode.Success;
                resp.Message = "user deleted";

            }
            else
            {
                resp.Code = (int)ErrorCode.Success;
                resp.Message = "can`t find user";
            }
            return resp;

        }

        [HttpPut]
        [Route("{userId}")]
        public Response UpdateUser(string userId, User user)
        {
            _dbService.Update(userId, user);
            return new Response()
            {
                Code = (int)ErrorCode.Success,
                Message = "User updated"
            };
        }
    }
}
