using System.Collections.Generic;
using System.Linq;
using Abp.MultiTenancy;
using MyCompanyName.AbpZeroTemplate.Authorization;

namespace MyCompanyName.AbpZeroTemplate.DashboardCustomization.Definitions
{
    public class DashboardConfiguration
    {
        public DashboardConfiguration()
        {
            #region FilterDefinitions

            // These are global filter which all widgets can use
            var dateRangeFilter = new WidgetFilterDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Filters.FilterDateRangePicker,
                "FilterDateRangePicker"
            );

            WidgetFilterDefinitions.Add(dateRangeFilter);

            // Add your filters here

            #endregion

            #region WidgetDefinitions

            // Define Widgets

            #region TenantWidgets

            var tenantWidgetsDefaultPermission = new List<string>
            {
                AppPermissions.Pages_Tenant_Dashboard
            };

            var dailySales = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Tenant.DailySales,
                "WidgetDailySales",
                MultiTenancySides.Tenant,
                new List<string> {dateRangeFilter.Id},
                tenantWidgetsDefaultPermission
            );

            var generalStats = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Tenant.GeneralStats,
                "WidgetGeneralStats",
                MultiTenancySides.Tenant,
                permissions: tenantWidgetsDefaultPermission
                    .Concat(new List<string> {AppPermissions.Pages_Administration_AuditLogs}).ToList());

            var profitShare = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Tenant.ProfitShare,
                "WidgetProfitShare",
                MultiTenancySides.Tenant,
                permissions: tenantWidgetsDefaultPermission);

            var memberActivity = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Tenant.MemberActivity,
                "WidgetMemberActivity",
                MultiTenancySides.Tenant,
                permissions: tenantWidgetsDefaultPermission);

            var regionalStats = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Tenant.RegionalStats,
                "WidgetRegionalStats",
                MultiTenancySides.Tenant,
                permissions: tenantWidgetsDefaultPermission);

            var salesSummary = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Tenant.SalesSummary,
                "WidgetSalesSummary",
                usedWidgetFilters: new List<string> {dateRangeFilter.Id},
                side: MultiTenancySides.Tenant,
                permissions: tenantWidgetsDefaultPermission);

            var topStats = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Tenant.TopStats,
                "WidgetTopStats",
                MultiTenancySides.Tenant,
                permissions: tenantWidgetsDefaultPermission);

            WidgetDefinitions.Add(generalStats);
            WidgetDefinitions.Add(dailySales);
            WidgetDefinitions.Add(profitShare);
            WidgetDefinitions.Add(memberActivity);
            WidgetDefinitions.Add(regionalStats);
            WidgetDefinitions.Add(topStats);
            WidgetDefinitions.Add(salesSummary);
            // Add your tenant side widgets here

            #endregion

            #region HostWidgets

            var hostWidgetsDefaultPermission = new List<string>
            {
                AppPermissions.Pages_Administration_Host_Dashboard
            };

            var incomeStatistics = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Host.IncomeStatistics,
                "WidgetIncomeStatistics",
                MultiTenancySides.Host,
                permissions: hostWidgetsDefaultPermission);

            var hostTopStats = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Host.TopStats,
                "WidgetTopStats",
                MultiTenancySides.Host,
                permissions: hostWidgetsDefaultPermission);

            var editionStatistics = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Host.EditionStatistics,
                "WidgetEditionStatistics",
                MultiTenancySides.Host,
                permissions: hostWidgetsDefaultPermission);

            var subscriptionExpiringTenants = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Host.SubscriptionExpiringTenants,
                "WidgetSubscriptionExpiringTenants",
                MultiTenancySides.Host,
                permissions: hostWidgetsDefaultPermission);

            var recentTenants = new WidgetDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.Widgets.Host.RecentTenants,
                "WidgetRecentTenants",
                MultiTenancySides.Host,
                new List<string> {dateRangeFilter.Id},
                hostWidgetsDefaultPermission);

            WidgetDefinitions.Add(incomeStatistics);
            WidgetDefinitions.Add(hostTopStats);
            WidgetDefinitions.Add(editionStatistics);
            WidgetDefinitions.Add(subscriptionExpiringTenants);
            WidgetDefinitions.Add(recentTenants);

            // Add your host side widgets here

            #endregion

            #endregion

            #region DashboardDefinitions

            // Create dashboard
            var defaultTenantDashboard = new DashboardDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.DashboardNames.DefaultTenantDashboard,
                new List<string>
                {
                    generalStats.Id, dailySales.Id, profitShare.Id, memberActivity.Id, regionalStats.Id, topStats.Id,
                    salesSummary.Id
                });

            DashboardDefinitions.Add(defaultTenantDashboard);

            var defaultHostDashboard = new DashboardDefinition(
                AbpZeroTemplateDashboardCustomizationConsts.DashboardNames.DefaultHostDashboard,
                new List<string>
                {
                    incomeStatistics.Id,
                    hostTopStats.Id,
                    editionStatistics.Id,
                    subscriptionExpiringTenants.Id,
                    recentTenants.Id
                });

            DashboardDefinitions.Add(defaultHostDashboard);

            // Add your dashboard definiton here

            #endregion
        }

        public List<DashboardDefinition> DashboardDefinitions { get; } = new();

        public List<WidgetDefinition> WidgetDefinitions { get; } = new();

        public List<WidgetFilterDefinition> WidgetFilterDefinitions { get; } = new();
    }
}