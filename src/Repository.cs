using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

public class Repository
{
    public async Task InsertGuest(Guest guest)
    {
        var account = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
        var client = account.CreateCloudTableClient();
        var _guestTable = client.GetTableReference("WeddingGuestTable");
        _guestTable.CreateIfNotExistsAsync().GetAwaiter().GetResult();
        var insertOperation = TableOperation.Insert(guest);
        await _guestTable.ExecuteAsync(insertOperation);
    }
}