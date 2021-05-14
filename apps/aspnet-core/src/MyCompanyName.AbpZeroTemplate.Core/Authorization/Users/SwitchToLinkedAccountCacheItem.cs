using System;

namespace MyCompanyName.AbpZeroTemplate.Authorization.Users
{
    [Serializable]
    public class SwitchToLinkedAccountCacheItem
    {
        public const string CacheName = "AppSwitchToLinkedAccountCache";

        public SwitchToLinkedAccountCacheItem()
        {
        }

        public SwitchToLinkedAccountCacheItem(
            int? targetTenantId,
            long targetUserId,
            int? impersonatorTenantId,
            long? impersonatorUserId
        )
        {
            TargetTenantId = targetTenantId;
            TargetUserId = targetUserId;
            ImpersonatorTenantId = impersonatorTenantId;
            ImpersonatorUserId = impersonatorUserId;
        }

        public int? TargetTenantId { get; set; }

        public long TargetUserId { get; set; }

        public int? ImpersonatorTenantId { get; set; }

        public long? ImpersonatorUserId { get; set; }
    }
}