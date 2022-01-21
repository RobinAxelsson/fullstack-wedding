using Microsoft.AspNetCore.Mvc;

namespace wedding_api.Controllers;

[ApiController]
[Route("[api/[controller]")]
public class GuestController : ControllerBase
{
    private readonly ILogger<GuestController> _logger;

    public GuestController(ILogger<GuestController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "Test")]
    public string TestEndpoint(){
        return "Hello World";
    }
}
