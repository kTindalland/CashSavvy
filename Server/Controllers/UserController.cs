using CashSavvy.Server.Context;
using CashSavvy.Server.Interfaces;
using CashSavvy.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashSavvy.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;


    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest? loginRequest)
    {
        if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) ||
            string.IsNullOrEmpty(loginRequest.Password))
        {
            return BadRequest("Missing login details.");
        }

        var loginResponse = await _userService.Login(loginRequest);

        if (loginResponse == null)
        {
            return BadRequest("Invalid credentials.");
        }

        return Ok(loginResponse);
    }

    [HttpGet]
    [Route("test")]
    [Authorize(Policy = "IsAdmin")]
    public IActionResult Test()
    {
        return Ok("You have access!");
    }
}