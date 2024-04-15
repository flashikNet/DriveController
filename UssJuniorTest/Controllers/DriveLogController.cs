using Microsoft.AspNetCore.Mvc;
using UssJuniorTest.Application.Interfaces;
using UssJuniorTest.Application.Models.Requests;
using UssJuniorTest.Application.Models.Responses;

namespace UssJuniorTest.Controllers;

[ApiController]
[Route("api/driveLog")]
public class DriveLogController : Controller
{
    private IDriveService _driveService;
    public DriveLogController( IDriveService driveService)
    {
        _driveService = driveService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetDrivesRes[]), 200)]
    public IActionResult GetDriveLogsAggregation([FromBody]GetDrivesReq req)
    {
        if(req.Start >= req.End)
        {
            return BadRequest("Incorrect range");
        }
        return Ok(_driveService.GetDrives(req));
    }
}