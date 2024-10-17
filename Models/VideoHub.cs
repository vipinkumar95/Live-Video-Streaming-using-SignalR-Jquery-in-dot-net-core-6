using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

namespace Live_Video_Streaming.Models
{
    public class VideoHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public VideoHub(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task SendVideoData(byte[] videoData)
        {
            var video = new Video
            {
                VideoData = videoData,
                CreatedAt = DateTime.UtcNow
            };

            _context.Videos.Add(video);
            await _context.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveVideoData", videoData);
        }
    }
}
