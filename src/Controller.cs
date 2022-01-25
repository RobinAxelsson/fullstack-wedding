using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

[ApiController]
[Route("api/[action]")]
public class Controller : ControllerBase
{
    private readonly ILogger<Controller> _logger;
    private readonly IRepository _repository;
    private readonly IEmailClient _emailClient;

    public Controller(ILogger<Controller> logger, IRepository repository, IEmailClient emailClient, IConfiguration configuration)
    {
        _logger = logger;
        _repository = repository;
        _emailClient = emailClient;
    }

    [HttpPost]
    public async Task<IActionResult> Guest([BindRequired] GuestDto guestDto)
    {
        var guest = new Guest(guestDto);
        await _repository.InsertGuest(guest);
        _emailClient.SendConfirmation(guest);
        return StatusCode(202);
    }
    [HttpGet]
    public async Task<IEnumerable<GuestDto>> Guest()
    {
        var guests = await _repository.GetAllGuest();
        return guests.Select(x => x.ExtractDto());
    }
}
