namespace API.Data;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

public class LikesRepository(DataContext context, IMapper mapper) : ILikesRepository
{
    public void AddLike(UserLike like) => context.Likes.Add(like);

    public void DeleteLike(UserLike like) => context.Likes.Remove(like);

    public async Task<IEnumerable<int>> GetCurrentUserLikeIds(int currentUserId) => await context.Likes
                .Where(x => x.SourceUserId == currentUserId)
                .Select(x => x.TargetUserId)
                .ToListAsync();

    public async Task<UserLike?> GetUserLike(int SourceUserId, int TargetUserId) => await context.Likes.FindAsync(SourceUserId, TargetUserId);

    public async Task<PagedList<MemberDto>> GetUserLikes(LikesParams likedParams)
    {
        var likes = context.Likes.AsQueryable();
        IQueryable<MemberDto> query;

        switch (likedParams.Predicate)
        {
            case "liked":
                query = likes
                        .Where(x => x.SourceUserId == likedParams.UserId)
                        .Select(x => x.TargetUser)
                        .ProjectTo<MemberDto>(mapper.ConfigurationProvider);
                break;
            case "likedBy":
                query = likes
                        .Where(x => x.TargetUserId == likedParams.UserId)
                        .Select(x => x.SourceUser)
                        .ProjectTo<MemberDto>(mapper.ConfigurationProvider);
                break;
            default:
                var likedIds = await this.GetCurrentUserLikeIds(likedParams.UserId);

                query = likes
                        .Where(x => x.TargetUserId == likedParams.UserId && likedIds.Contains(x.SourceUserId))
                        .Select(x => x.SourceUser)
                        .ProjectTo<MemberDto>(mapper.ConfigurationProvider);
                break;
        }

        return await PagedList<MemberDto>.CreateAsync(query, likedParams.PageNumber, likedParams.PageSize);
    }

    public async Task<bool> SaveChanges() => await context.SaveChangesAsync() > 0;
}
