using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;

namespace ChatInAHat
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendMessage(int roomId, string message)
        {
            var user = Context.User;
            if (user?.Identity == null || string.IsNullOrEmpty(user.Identity.Name))
            {
                throw new HubException("User not authenticated.");
            }

            var chatMessage = new ChatMessage
            {
                Content = message,
                UserId = user.Identity.Name,
                ChatRoomId = roomId,
                Timestamp = DateTime.UtcNow
            };

            _context.ChatMessages.Add(chatMessage);
            await _context.SaveChangesAsync();

            await Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", user.Identity.Name, message, chatMessage.Timestamp);
        }

        public async Task JoinRoom(int roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        public async Task LeaveRoom(int roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
        }
    }
}