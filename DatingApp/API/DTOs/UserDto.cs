namespace API.DTOs
{
    // Đối tượng trả về thông báo khi đăng nhập hoặc đăng ký 
    public class UserDto
    {
        public string? Username { get; set; }
        public string? Token { get; set; }
    }
}