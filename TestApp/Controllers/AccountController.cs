using Microsoft.AspNetCore.Mvc;
using TestApp.DTOs;
using TestApp.Interfaces;

namespace TestApp.Controllers
{

    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] AccountDto account)
            => Ok(await _accountService.CreateAsync(account));
    }
}
