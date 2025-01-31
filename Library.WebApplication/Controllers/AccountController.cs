﻿using Library.BusinessLogic.Services.Interfaces;
using Library.BusinessLogic.Services.ViewModel.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var result = await _accountService.RegisterUser(model);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var result = await _accountService.Login(model);
            return Ok(result);
        }

        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            await _accountService.Confirm(userId, code);
            return Ok();
        }

        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordView model)
        {
            await _accountService.ForgotPassword(model);
            return Ok();
        }

        [HttpGet("reset")]
        public async Task<IActionResult> ResetPasswodr(string userId, string code)
        {
            await _accountService.ResetPassword(userId, code);
            return Ok();
        }
        [HttpPost("changeEmail")]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeEmailView model)
        {
            await _accountService.ChangeEmail(model);
            return Ok(model);

        }
        [HttpGet("acceptNewEmail")]
        public async Task<IActionResult> AcceptNewEmail(string userId, string newEmail, string code)
        {
            await _accountService.ResetEmail(userId, newEmail, code);
            return Ok();
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordView model)
        {
            var result = _accountService.ChangePassword(model);
            return Ok(result);
        }
    }
}