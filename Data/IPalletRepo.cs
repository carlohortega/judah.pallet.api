using System.Collections.Generic;
using Eis.Pallet.Api.Models;

namespace Eis.Pallet.Api.Data
{
    public interface IPalletRepo 
    {
        bool SaveChanges();

        // App User
        IEnumerable<AppUser> GetAllAppUsers();
        void CreateAppUser(AppUser appUser);
        bool AppUserExists(int appUserId);

        // Pallets
        IEnumerable<Models.Pallet> GetPalletsForAppUserId(int appUserId);
        Models.Pallet GetPallet(int appUserId, int palletId);
        void CreatePallet(int appUserId, Models.Pallet pallet);
    }
}