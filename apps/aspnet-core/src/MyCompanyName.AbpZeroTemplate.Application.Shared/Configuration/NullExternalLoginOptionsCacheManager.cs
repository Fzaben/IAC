﻿namespace MyCompanyName.AbpZeroTemplate.Configuration
{
    public class NullExternalLoginOptionsCacheManager : IExternalLoginOptionsCacheManager
    {
        public static NullExternalLoginOptionsCacheManager Instance { get; } =
            new NullExternalLoginOptionsCacheManager();

        public void ClearCache()
        {
        }
    }
}