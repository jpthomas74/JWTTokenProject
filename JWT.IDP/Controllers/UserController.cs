﻿using JWT.IDP.IDPModels;
using JWT.IDP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.IDP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync(RegisterModel model)
        {
            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("login")] // New function created
        public async Task<IActionResult> ValidateLoginAsync(LoginRequestModel model)
        {
            var response = await _userService.CheckPasswordAsync(model);
            if (response.IsAuthenticated)
            {
                var result = await _userService.GetApplicationUserAsync(model);
                if (result != null && result.AccessibleDbs.Count() > 0)
                {
                    return Ok(result.AccessibleDbs);
                }
                else
                {
                    return BadRequest("Database Information Not Available");
                }
            }
            else
            {
                return BadRequest("Invalid Username or Password");
            }
        }

        [HttpPost("tokenonly")]
        public async Task<IActionResult> GetTokenOnlyAsync(TokenRequestModel model)
        {
            var result = await _userService.GetTokenOnlyAsync(model);
            SetRefreshTokenInCookie(result.RefreshToken);
            return Ok(result);
        }

        //[HttpPost("token")] //Comenting to use new function GetTokenOnlyAsync
        //public async Task<IActionResult> GetTokenAsync(LoginRequestModel model)
        //{
        //    var result = await _userService.GetTokenAsync(model);
        //    SetRefreshTokenInCookie(result.RefreshToken);
        //    return Ok(result);
        //}

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _userService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRefreshTokenInCookie(response.RefreshToken);
            return Ok(response);
        }

        [Authorize]
        [HttpPost("tokens/{id}")]
        public IActionResult GetRefreshTokens(string id)
        {
            var user = _userService.GetById(id);
            return Ok(user.RefreshTokens);
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });
            var response = _userService.RevokeToken(token);
            if (!response)
                return NotFound(new { message = "Token not found" });
            return Ok(new { message = "Token revoked" });
        }

        private void SetRefreshTokenInCookie(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(10),
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }


    }
}
