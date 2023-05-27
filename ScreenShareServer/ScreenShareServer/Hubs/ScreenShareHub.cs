using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace ScreenShareServer.Hubs
{
    public class ScreenShareHub : Hub
    {
        public async Task JoinGroup([Required] string group)
        {
            await Groups.AddToGroupAsync(this.Context.ConnectionId, group);
        }

        public async Task Share([Required] string group, [Required] string base64)
        {
            await Clients.Group(group).SendAsync(base64);
        }
    }
}