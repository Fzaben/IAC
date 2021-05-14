﻿using System;

namespace MyCompanyName.AbpZeroTemplate.Authorization.Impersonation
{
    [Serializable]
    public class ImpersonationCacheItem
    {
        public const string CacheName = "AppImpersonationCache";

        public ImpersonationCacheItem()
        {
        }

        public ImpersonationCacheItem(int? targetTenantId, long targetUserId, bool isBackToImpersonator)
        {
            TargetTenantId = targetTenantId;
            TargetUserId = targetUserId;
            IsBackToImpersonator = isBackToImpersonator;
        }

        public int? ImpersonatorTenantId { get; set; }

        public long ImpersonatorUserId { get; set; }

        public int? TargetTenantId { get; set; }

        public long TargetUserId { get; set; }

        public bool IsBackToImpersonator { get; set; }
    }
}