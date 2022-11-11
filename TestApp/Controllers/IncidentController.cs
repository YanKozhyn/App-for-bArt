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
        public async Task<ActionResult> CreateOneAsync([FromBody] IncidentDto incident, CancellationToken token = default)
            => Ok(await _incidentService.CreateOneAsync(incident, token));
    }
}
