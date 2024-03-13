using API.DTOs;
using API.Helpers;

namespace API.Entities
{
    public interface ILikesRepository
    {
         Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);
         Task<AppUser> GetUserWithLikes (int userId);
         Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
    }
}