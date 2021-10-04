using System.Collections.Generic;
using System.Linq;
using Eis.Pallet.Api.Models;

namespace Eis.Pallet.Api.Data
{
    public class PalletRepo : IPalletRepo
    {
        private readonly AppDbContext _context;

        public PalletRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePallet(int appUserId, Models.Pallet pallet)
        {
            if(pallet == null)
            {
                throw new System.ArgumentNullException();
            }

            pallet.AppUserId = appUserId;
            _context.Pallets.Add(pallet);
        }

        public void CreateAppUser(AppUser appUser)
        {
            if(appUser == null)
            {
                throw new System.ArgumentNullException();
            }

            _context.AppUsers.Add(appUser);
        }

        public IEnumerable<AppUser> GetAllAppUsers()
        {
            return _context.AppUsers.ToList();
        }

        public IEnumerable<Models.Pallet> GetAllPallets()
        {
            return _context.Pallets.ToList();
        }

        public Models.Pallet GetPallet(int appUserId, int palletId)
        {
            return _context.Pallets
                .FirstOrDefault(p => p.AppUserId == appUserId && p.Id == palletId);
        }

        public IEnumerable<Models.Pallet> GetPalletsForAppUserId(int appUserId)
        {
            return _context.Pallets
                .Where(w => w.AppUserId == appUserId)
                .OrderBy(o => o.AppUser.Name);
        }

        public bool AppUserExists(int appUserId)
        {
            return _context.AppUsers.Any(p => p.Id == appUserId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}