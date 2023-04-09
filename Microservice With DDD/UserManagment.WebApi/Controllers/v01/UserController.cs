using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagment.ApplicationService.Users;
using UserManagment.ApplicationService.Users.Dtos;

namespace UserManagment.WebApi.Controllers.v01
{
    [Route("v01/api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService= userService;  
        }


        [HttpPost]
        public async Task<object> CreateCustomer([FromBody] SaveCustomerDto customerDto)
        {
            var result=await _userService.CreateCustomerAsync(customerDto.FirstName,customerDto.LastName);
            return new {UserId=result.ToString()};
        }


    }
}
