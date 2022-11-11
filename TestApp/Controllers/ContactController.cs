using Microsoft.AspNetCore.Mvc;
using TestApp.DTOs;
using TestApp.Interfaces;

namespace TestApp.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ContactDto contactDto, CancellationToken token = default)
            => Ok(await _contactService.CreateAsync(contactDto, token));
    }
}
