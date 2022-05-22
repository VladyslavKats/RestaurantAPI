using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BLL;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Models;
using Restaurant.DAL.Entities;
using Restaurant.PL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserManager userManager;
        private readonly IMapper mapper;

        public AccountController(IUserManager userManager , IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("login")]
        public async Task<ActionResult<AuthenticateResponse>> Login([FromQuery] LogInModel model)
        {
            try
            {
                var response = await userManager.LogIn(model);
                return Ok(response);
            }
            catch(RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticateResponse>> Register([FromBody] UserCreateModel model)
        {
            try
            {
                var user = mapper.Map<User>(model);
                var response = await userManager.Register(user);
                return Ok(response);
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{login}")]
        public async Task<ActionResult<bool>> CheckLogin(string login)
        {
            try
            {
                var result = await userManager.CheckForLoginAsync(login);
                return Ok(result);
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAll()
        {
            try
            {
                var usersFromService = await userManager.GetAllUsersAsync();
                var users = mapper.Map<IEnumerable<UserViewModel>>(usersFromService);
                return Ok(users);
            }catch(RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userLogin}")]
        public async Task<ActionResult> Delete(string userLogin )
        {
            try
            {
                await userManager.DeleteUserAsync(new User { Login = userLogin });
                return Ok();
            }
            catch (RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit(UserUpdateModel model)
        {
            try
            {
                var user = mapper.Map<User>(model);
                await userManager.UpdateUserAsync(user);
                return Ok();
            }catch(RestaurantException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
