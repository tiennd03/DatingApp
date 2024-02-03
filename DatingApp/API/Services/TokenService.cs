using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        //khởi tạo một đối tượng TokenService với một khóa bí mật được lấy từ cấu hình ứng dụng, để sử dụng cho việc tạo và xác thực token trong ứng dụng ASP.NET Core.
        private readonly SymmetricSecurityKey key; // chứa một khóa bí mật được sử dụng để tạo và xác thực token.
        public TokenService(IConfiguration config)
        {
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Tokenkey"]));
        }


        // tạo mã thông báo 
        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim> // Tạo một danh sách các "claim" cho mã thông báo
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);
            //Tạo đối sử dụng để ký (sign) mã thông báo đối tượng SigningCredentials được tạo với khóa bí mật _key đã được khởi tạo trước đó và thuật toán ký HmacSha512Signature
            //ký mã để thông báo gửi đi không bị thay đổi hoặc chỉnh sửa 

            // định nghĩa các thuộc tính của mã thông báo
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor); 

            return tokenHandler.WriteToken(token); // Chuyển đổi mã thông báo thành một chuỗi và trả về chuỗi này.
        }

    }
}