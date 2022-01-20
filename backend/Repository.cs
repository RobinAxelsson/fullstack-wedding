using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

public class Repository
{
    private readonly CloudTable _guestTable;

    public Repository(string connectionstring = "UseDevelopmentStorage=true")
    {
        var account = CloudStorageAccount.Parse(connectionstring);
        var client = account.CreateCloudTableClient();
        _guestTable = client.GetTableReference("WeddingGuestTable");
        _guestTable.CreateIfNotExistsAsync().GetAwaiter().GetResult();
    }

    public async Task<string> AddOrUpdateGuest(Guest guest)
    {
        // if (GuestExist(guest))
        // {
        //     var update = TableOperation.Replace(guest);
        //     await _guestTable.ExecuteAsync(update);
        //     return guest.RowKey;
        // }

        var insertOperation = TableOperation.Insert(guest);
        await _guestTable.ExecuteAsync(insertOperation);

        return insertOperation.Entity.RowKey;
    }

    public async Task<IEnumerable<Guest>> GetGuests()
    {
        var query = new TableQuery<Guest>();

        var result = new List<Guest>();
        TableContinuationToken token = null;
        do
        {
            var segment = await _guestTable.ExecuteQuerySegmentedAsync(query, token);
            result.AddRange(segment);
            token = segment.ContinuationToken;
        } while (token != null);
        return result;
    }

    public async Task<bool> RemoveActivity(string rowKey, string userId)
    {
        var retrive = TableOperation.Retrieve<Guest>(userId, rowKey);
        var result = await _guestTable.ExecuteAsync(retrive);
        var entity = (Guest)result.Result;
        if (entity == null)
            return false;

        var delete = TableOperation.Delete(entity);
        await _guestTable.ExecuteAsync(delete);

        return true;
    }

    private bool GuestExist(Guest guest)
    {
        var query = TableOperation.Retrieve<Guest>(guest.PartitionKey, guest.RowKey);
        var result = _guestTable.Execute(query);
        return result.Result != null;
    }
}