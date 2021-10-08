using System;
using System.Text.Json;
using AutoMapper;
using Eis.Pallet.Api.Data;
using Eis.Pallet.Api.Dtos;
using Eis.Pallet.Api.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Eis.Pallet.Api.EventProcessing
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.AppUserPublished:
                    AddAppUser(message);
                    break;
                default:
                    break;
            }
        }

        private EventType DetermineEvent(string notificationMessage)
        {
            Console.WriteLine($"--> Determining Event Type");
            var eventType = JsonSerializer.Deserialize<GenericEventDto>(notificationMessage);
            switch (eventType.Event)
            {
                case "AppUser_Published":
                    Console.WriteLine("-->App User Published Event Detected");
                    return EventType.AppUserPublished;
                default:
                    Console.WriteLine("--> Undetermined Published Event Detected");
                    return EventType.Undetermined;
            }
        }

        private void AddAppUser(string appUserPublishedMessage)
        {
            using(var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IPalletRepo>();
                var appUserPublishedDto = JsonSerializer.Deserialize<AppUserPublishedDto>(appUserPublishedMessage);

                try
                {
                    var appUser = _mapper.Map<AppUser>(appUserPublishedDto);
                    if(!repo.ExtAppUserExists(appUser.ExtId))
                    {
                        appUser.Id = 0;
                        appUser.ObjectId = Guid.NewGuid().ToString();
                        Console.WriteLine($"--> User Vals: Id={appUser.Id},Name={appUser.Name},ExtId={appUser.ExtId},ObjectId={appUser.ObjectId}");

                        repo.CreateAppUser(appUser);
                        repo.SaveChanges();
                        Console.WriteLine("--> AppUser added!");
                    }
                    else
                    {
                        Console.WriteLine("--> AppUser already exists.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"-->Could not add AppUser to DB {ex.Message}");
                }
            }
        }
    }

    enum EventType
    {
        AppUserPublished,
        Undetermined
    }
}