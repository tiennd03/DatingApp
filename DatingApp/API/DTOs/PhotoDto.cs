using API.Entities;

namespace API.DTOs
{
    public class PhotoDto
    {
        public int ID { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}