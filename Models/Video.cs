namespace Live_Video_Streaming.Models
{
    public class Video
    {
        public int Id { get; set; }
        public byte[] VideoData { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
