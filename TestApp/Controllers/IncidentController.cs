using Microsoft.AspNetCore.Mvc;
using TestApp.DTOs;
using TestApp.Interfaces;

namespace TestApp.Controllers
{
    public class IncidentController : BaseController
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOneAsync([FromBody] CreateIncidentDto incident, CancellationToken token = default)
            => Ok(await _incidentService.CreateOneAsync(incident, token));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken token = default)
            => Ok(await _incidentService.GetAllAsync(token));

        [HttpGet("[action]/{nameId:length(36)}")]
        public async Task<IActionResult> GetByIdWithDetailsAsync(string name, CancellationToken token = default)
        {
            var incident = await _incidentService.GetByIdAsync(name, token);
            if (incident is null)
            {
                return NotFound($"There is no incident with name: {name}");
            }
            return Ok(incident);
        }

        [HttpDelete("{nameId:length(36)}")]
        public async Task<IActionResult> DeleteByIdAsync(string name, CancellationToken token = default)
        {
            try
            {
                await _incidentService.DeleteByIdAsync(name, token);
            }
            catch (ArgumentException e)
            {
                return NotFound($"There is no incident with name: {name} is not exist \n{e.Message}");
            }

            return Ok($"Incident with nameId: {name} successfullt deleted");
        }
    }
}
