using Abp;

namespace MyCompanyName.AbpZeroTemplate.Friendships
{
    public static class FriendshipExtensions
    {
        public static UserIdentifier ToUserIdentifier(this Friendship friendship)
        {
            return new(friendship.TenantId, friendship.UserId);
        }

        public static UserIdentifier ToFriendIdentifier(this Friendship friendship)
        {
            return new(friendship.FriendTenantId, friendship.FriendUserId);
        }
    }
}