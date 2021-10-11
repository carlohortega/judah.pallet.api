using System.Collections.Generic;
using Eis.Pallet.Api.Models;

namespace Eis.Pallet.Api.SyncDataServices.Grpc
{
    public interface IIdentityDataClient
    {
        IEnumerable<AppUser> ReturnAllAppUsers();
    }
}