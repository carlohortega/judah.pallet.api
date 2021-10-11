using System;
using System.Collections.Generic;
using System.Linq;
using Eis.Pallet.Api.Models;
using Eis.Pallet.Api.SyncDataServices.Grpc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Eis.Pallet.Api.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var grcpClient = serviceScope.ServiceProvider.GetService<IIdentityDataClient>();
                var appUsers = grcpClient.ReturnAllAppUsers();

                SeedData(serviceScope.ServiceProvider.GetService<IPalletRepo>(), appUsers);
            }
        }

        private static void SeedData(IPalletRepo repo, IEnumerable<AppUser> appUsers)
        {
            Console.WriteLine("--> Seeding app users from GRPC.");

            foreach(var item in appUsers) {
                if(!repo.ExtAppUserExists(item.ExtId)) {
                    repo.CreateAppUser(item);
                }
                repo.SaveChanges();
            }
        }
    }
}