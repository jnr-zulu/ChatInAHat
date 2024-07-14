using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ChatInAHat.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChatController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await _context.ChatRooms.ToListAsync();
            return View(rooms);
        }

        public async Task<IActionResult> Room(int id)
        {
            var room = await _context.ChatRooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            var messages = await _context.ChatMessages
                .Where(m => m.ChatRoomId == id)
                .OrderByDescending(m => m.Timestamp)
                .Take(50)
                .Reverse()
                .ToListAsync();

            ViewBag.RoomId = id;
            ViewBag.RoomName = room.Name;
            return View(messages);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            var room = new ChatRoom
            {
                Name = name,
                CreatedBy = User.Identity.Name,
                CreatedAt = DateTime.UtcNow
            };

            _context.ChatRooms.Add(room);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}