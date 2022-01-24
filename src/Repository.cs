using Microsoft.Azure.Cosmos.Table;

public class Repository
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
        _guestTable = _client.GetTableReference(_configuration["TableName"]);
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