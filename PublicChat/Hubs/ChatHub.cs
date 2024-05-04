using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicChat.Hubs
{
    public class ChatHub : Hub
    {
        public static ConcurrentDictionary<string, string> clients = new ConcurrentDictionary<string, string>();

        readonly string[] _names = { "A", "B", "C", "D", "E" };
        readonly Random _rand = new();
        static string GetRandomName(string[] names, Random rand)
        {
            int index = rand.Next(names.Length);
            return names[index];
        }
        public override async Task OnConnectedAsync()
        {
            //string userId = Context.User?.Identity?.Name;
             clients.TryAdd( GetRandomName(_names, _rand),Context.ConnectionId);
            await base.OnConnectedAsync();
        }
        
        //public bool registerClient(string userName)
        //{
        //    try
        //    {
        //        var c = Clients.Client(Context.ConnectionId); //= userName;
        //        clients.TryAdd(userName, Context.ConnectionId);
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}
        public override Task OnDisconnectedAsync(Exception exception)
        {

            clients.TryRemove(clients.FirstOrDefault(x => x.Value == Context.ConnectionId));
            return base.OnDisconnectedAsync(exception);
        }

    }
}
