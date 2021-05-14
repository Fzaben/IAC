using System;
using Abp.Dependency;
using GraphQL.Types;
using GraphQL.Utilities;
using MyCompanyName.AbpZeroTemplate.Queries.Container;

namespace MyCompanyName.AbpZeroTemplate.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IServiceProvider provider) :
            base(provider)
        {
            Query = provider.GetRequiredService<QueryContainer>();
        }
    }
}