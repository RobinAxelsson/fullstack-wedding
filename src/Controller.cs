using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

[ApiController]
[Route("api/[action]")]
public class Controller : ControllerBase
{
    private readonly ILogger<Controller> _logger;
    private readonly IRepository _repository;
    private readonly IMessageClient _emailClient;
    private readonly HtmlParser _htmlParser;

    public Controller(ILogger<Controller> logger, IRepository repository, IMessageClient emailClient, IConfiguration configuration, HtmlParser htmlParser)
    {
        _logger = logger;
        _repository = repository;
        _emailClient = emailClient;
        _htmlParser = htmlParser;
    }

    [HttpPost]
    public async Task<IActionResult> Guest([BindRequired] GuestDto guestDto)
    {
        var guest = new Guest(guestDto);
        await _repository.InsertGuest(guest);
        var html = _htmlParser.ParseTemplate(guest);
        _emailClient.SendConfirmation(guest, html);
        return StatusCode(202);
    }
    [HttpGet]
    public async Task<IEnumerable<GuestDto>> Guest()
    {
        var guests = await _repository.GetAllGuest();
        return guests.Select(x => x.ExtractDto());
    }
}
