using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace wedding_api.Controllers;

[ApiController]
[Route("api/[action]")]
public class Controller : ControllerBase
{
    private readonly ILogger<Controller> _logger;
    private readonly Repository _repository;

    public Controller(ILogger<Controller> logger, Repository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpPost]
    public async Task<IResult> Guest([BindRequired] GuestDto guestDto)
    {
        var guest = new Guest(guestDto);
        
        Console.WriteLine(guest.ToString());

        await _repository.InsertGuest(guest);

        return Results.StatusCode(202);
    }
}
