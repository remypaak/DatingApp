namespace API.Interfaces;
using API.DTOs;
using API.Entities;
using API.Helpers;

public interface ILikesRepository
{
    Task<UserLike?> GetUserLike(int SourceUserId, int TargetUserId);
    Task<PagedList<MemberDto>> GetUserLikes(LikesParams likedParams);
    Task<IEnumerable<int>> GetCurrentUserLikeIds(int currentUserId);

    void DeleteLike(UserLike like);
    void AddLike(UserLike like);

    Task<bool> SaveChanges();
}
