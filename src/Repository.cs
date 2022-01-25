using Microsoft.Azure.Cosmos.Table;

public interface IRepository
{
    Task<IEnumerable<Guest>> DeleteAllGuest();
    Task<IEnumerable<Guest>> GetAllGuest();
    Task InsertGuest(Guest guest);
}
public class Repository : IRepository
{
    private readonly ILogger<Repository> _logger;
    private readonly IConfiguration _configuration;
    private readonly CloudTable _guestTable;

    public Repository(ILogger<Repository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        var _account = CloudStorageAccount.Parse(_configuration["ConnectionString"]);
        var _client = _account.CreateCloudTableClient();
        _guestTable = _client.GetTableReference(_configuration["Database:TableName"]);
    }

    public async Task InsertGuest(Guest guest)
    {
        _guestTable.CreateIfNotExistsAsync().GetAwaiter().GetResult();
        var insertOperation = TableOperation.Insert(guest);
        await _guestTable.ExecuteAsync(insertOperation);
    }
    public async Task<IEnumerable<Guest>> GetAllGuest()
    {
        _guestTable.CreateIfNotExistsAsync().GetAwaiter().GetResult();
        TableContinuationToken token = null;
        var guests = new List<Guest>();
        do
        {
            var queryResult = await _guestTable.ExecuteQuerySegmentedAsync(new TableQuery<Guest>(), token);
            guests.AddRange(queryResult.Results);
            token = queryResult.ContinuationToken;
        } while (token != null);

        return guests;
    }
    public async Task<IEnumerable<Guest>> DeleteAllGuest()
    {
        _guestTable.CreateIfNotExistsAsync().GetAwaiter().GetResult();
        TableContinuationToken token = null;
        var guests = new List<Guest>();
        do
        {
            var queryResult = await _guestTable.ExecuteQuerySegmentedAsync(new TableQuery<Guest>(), token);
            guests.AddRange(queryResult.Results);
            token = queryResult.ContinuationToken;
        } while (token != null);

        return guests;
    }
}
public class FakeRepository : IRepository
{
    private readonly ILogger<FakeRepository> _logger;

    public FakeRepository(ILogger<FakeRepository> logger)
    {
        _logger = logger;
    }
    public Task<IEnumerable<Guest>> DeleteAllGuest()
    {
        _logger.LogInformation("Fake delete all guests");
        return Task.FromResult<IEnumerable<Guest>>(new List<Guest>());
    }

    public Task<IEnumerable<Guest>> GetAllGuest()
    {
        _logger.LogInformation("Fake get all guests");
        return Task.FromResult<IEnumerable<Guest>>(new List<Guest>());
    }

    public Task InsertGuest(Guest guest)
    {
        _logger.LogInformation("Fake Insert Guest: " + guest.ToString());
        return Task.Delay(100);
    }
}
