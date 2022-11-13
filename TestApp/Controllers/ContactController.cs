using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> CreateAsync([FromBody] CreateContactDto contactDto, CancellationToken token = default)
            => Ok(await _contactService.CreateAsync(contactDto, token));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken token = default)
            => Ok(await _contactService.GetAllAsync(token));

        [HttpPatch("[action]/{id:guid}")]
        public async Task<IActionResult> UpdateAccountAsync(Guid id, [FromBody] UpdateContactDto contactDto, CancellationToken token = default)
        {
            try
            {
               return Ok(await _contactService.UpdateAccountIdAsync(id, contactDto, token));
            }
            catch (Exception ex)
            {
                return NotFound($"AccoutId not correct, please check if u typed correct accountId");
            }
            
        }
    }
}
