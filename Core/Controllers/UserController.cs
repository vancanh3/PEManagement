using Microsoft.AspNetCore.Mvc;
using PersionalExpenditureManagement.Service;
using PersionalExpenditureManagement.Service.Interface;

namespace PersionalExpenditureManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserService _userService;
        public UserController(IUserService userService, ILogger<UserService> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserListAsync()
        {
            var userList = await _userService.GetListUser();
            return new ObjectResult(new { currentDate = DateTime.Now, data = userList });
        }
    }
}
