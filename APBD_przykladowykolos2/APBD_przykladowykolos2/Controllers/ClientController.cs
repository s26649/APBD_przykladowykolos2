using APBD_przykladowykolos2.RequestModels;
using APBD_przykladowykolos2.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_przykladowykolos2.Controllers;

[Route("api/client")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public IActionResult GetClient(int id)
    {
        var client = _service.GetClientWithReservations(id);
        if (client == null)
        {
            return NotFound();
        }

        return Ok(client);
    }

    [HttpPost("reservation")]
    public IActionResult AddReservation([FromBody] ReservationRequest request)
    {
        if (!_service.AddReservation(request, out int reservationId))
        {
            return BadRequest("nie wyszlo zarezerwowac");
        }

        return CreatedAtAction(nameof(GetClient), new { id = request.IdClient }, new { IdReservation = reservationId });
    }
}
