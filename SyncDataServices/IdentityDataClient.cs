using System;
using System.Collections.Generic;
using AutoMapper;
using Eis.Identity.Api;
using Eis.Pallet.Api.Models;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;

namespace Eis.Pallet.Api.SyncDataServices.Grpc
{
    public class IdentityDataClient : IIdentityDataClient 
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public IdentityDataClient(IConfiguration config, IMapper mapper)
        {
            _config = config;
            _mapper = mapper;
        }

        public IEnumerable<AppUser> ReturnAllAppUsers()
        {
            Console.WriteLine($"--> Calling GRPC Service {_config["GrpcIdentity"]}");
            var channel = GrpcChannel.ForAddress(_config["GrpcIdentity"]);
            var client = new GrpcIdentity.GrpcIdentityClient(channel);
            var request = new GetAllRequest();

            try 
            {
                var reply = client.GetAllAppUsers(request);
                return _mapper.Map<IEnumerable<AppUser>>(reply.AppUsers);
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"--> Could not call GRPC Server {ex.Message}.");
                return null;
            }
        }
    }
}