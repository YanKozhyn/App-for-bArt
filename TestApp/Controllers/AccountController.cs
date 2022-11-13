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
        public async Task<ActionResult> CreateAsync([FromBody] CreateAccountDto account, CancellationToken token = default)
            => Ok(await _accountService.CreateAsync(account, token));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken token = default)
            => Ok(await _accountService.GetAllAsync(token));

        [HttpGet("[action]/{name}")]
        public async Task<IActionResult> GetByNameAsync(string name, CancellationToken token = default)
        {
            var account = await _accountService.GetByNameAsync(name, token);
            if (account is null)
            {
                return NotFound();
            }
            return Ok(account);

        }
    }
}
