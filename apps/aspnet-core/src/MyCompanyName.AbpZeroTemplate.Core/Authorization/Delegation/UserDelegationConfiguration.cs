﻿namespace MyCompanyName.AbpZeroTemplate.Authorization.Delegation
{
    public class UserDelegationConfiguration : IUserDelegationConfiguration
    {
        public UserDelegationConfiguration()
        {
            IsEnabled = true;
        }

        public bool IsEnabled { get; set; }
    }
}