using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Core.Command.Account;
using Todo.Core.Entity;
using Todo.Core.Enum;
using Todo.Core.Query.Account.CheckAccountEmailExists;
using Todo.Core.Query.Account.CheckAccountLoginExists;
using Todo.Core.Query.Account.LoginQuery;
using Todo.Core.Request.Account;
using Todo.Core.Response.Shared;

namespace Todo.Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginQuery loginFormQuery)
        {
            var res = await _mediator.Send(loginFormQuery);

            if (res == null)
                return Ok(new Error(ErrorType.InvalidUserOrPassword, ""));

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateAccountCommand registerForm)
        {
            return Ok(await _mediator.Send(registerForm));
        }

        [HttpGet("CheckEmailExists/{email}")]
        public async Task<IActionResult> CheckEmailExists(string email)
        {
            return Ok(await _mediator.Send(new CheckAccountEmailExistsQuery { Email = email }));
        }

        [HttpGet("CheckLoginExists/{login}")]
        public async Task<IActionResult> CheckLoginExists(string login)
        {
            return Ok(await _mediator.Send(new CheckAccountLoginExistsQuery { Login = login }));
        }

        [HttpGet("test")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }
    }
}
