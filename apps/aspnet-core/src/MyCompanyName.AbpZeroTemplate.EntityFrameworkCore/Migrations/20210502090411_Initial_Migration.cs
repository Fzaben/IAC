using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AbpAuditLogs",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: true),
                    ServiceName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    MethodName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    Parameters = table.Column<string>("character varying(1024)", maxLength: 1024, nullable: true),
                    ReturnValue = table.Column<string>("text", nullable: true),
                    ExecutionTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    ExecutionDuration = table.Column<int>("integer", nullable: false),
                    ClientIpAddress = table.Column<string>("character varying(64)", maxLength: 64, nullable: true),
                    ClientName = table.Column<string>("character varying(128)", maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    ExceptionMessage = table.Column<string>("character varying(1024)", maxLength: 1024, nullable: true),
                    Exception = table.Column<string>("character varying(2000)", maxLength: 2000, nullable: true),
                    ImpersonatorUserId = table.Column<long>("bigint", nullable: true),
                    ImpersonatorTenantId = table.Column<int>("integer", nullable: true),
                    CustomData = table.Column<string>("character varying(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpAuditLogs", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpBackgroundJobs",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JobType = table.Column<string>("character varying(512)", maxLength: 512, nullable: false),
                    JobArgs = table.Column<string>("character varying(1048576)", maxLength: 1048576, nullable: false),
                    TryCount = table.Column<short>("smallint", nullable: false),
                    NextTryTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    LastTryTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    IsAbandoned = table.Column<bool>("boolean", nullable: false),
                    Priority = table.Column<byte>("smallint", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpBackgroundJobs", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpDynamicProperties",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropertyName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    DisplayName = table.Column<string>("text", nullable: true),
                    InputType = table.Column<string>("text", nullable: true),
                    Permission = table.Column<string>("text", nullable: true),
                    TenantId = table.Column<int>("integer", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpDynamicProperties", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpEditions",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("character varying(32)", maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>("character varying(64)", maxLength: 64, nullable: false),
                    Discriminator = table.Column<string>("text", nullable: false),
                    ExpiringEditionId = table.Column<int>("integer", nullable: true),
                    DailyPrice = table.Column<decimal>("numeric", nullable: true),
                    WeeklyPrice = table.Column<decimal>("numeric", nullable: true),
                    MonthlyPrice = table.Column<decimal>("numeric", nullable: true),
                    AnnualPrice = table.Column<decimal>("numeric", nullable: true),
                    TrialDayCount = table.Column<int>("integer", nullable: true),
                    WaitingDayAfterExpire = table.Column<int>("integer", nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    DeleterUserId = table.Column<long>("bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>("timestamp without time zone", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpEditions", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpEntityChangeSets",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrowserInfo = table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    ClientIpAddress = table.Column<string>("character varying(64)", maxLength: 64, nullable: true),
                    ClientName = table.Column<string>("character varying(128)", maxLength: 128, nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    ExtensionData = table.Column<string>("text", nullable: true),
                    ImpersonatorTenantId = table.Column<int>("integer", nullable: true),
                    ImpersonatorUserId = table.Column<long>("bigint", nullable: true),
                    Reason = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpEntityChangeSets", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpLanguages",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    Name = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>("character varying(64)", maxLength: 64, nullable: false),
                    Icon = table.Column<string>("character varying(128)", maxLength: 128, nullable: true),
                    IsDisabled = table.Column<bool>("boolean", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    DeleterUserId = table.Column<long>("bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>("timestamp without time zone", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpLanguages", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpLanguageTexts",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    LanguageName = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    Source = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    Key = table.Column<string>("character varying(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>("character varying(100)", maxLength: 100, nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpLanguageTexts", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpNotifications",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    NotificationName = table.Column<string>("character varying(96)", maxLength: 96, nullable: false),
                    Data = table.Column<string>("character varying(1048576)", maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>("character varying(250)", maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName =
                        table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    EntityId = table.Column<string>("character varying(96)", maxLength: 96, nullable: true),
                    Severity = table.Column<byte>("smallint", nullable: false),
                    UserIds = table.Column<string>("character varying(131072)", maxLength: 131072, nullable: true),
                    ExcludedUserIds =
                        table.Column<string>("character varying(131072)", maxLength: 131072, nullable: true),
                    TenantIds = table.Column<string>("character varying(131072)", maxLength: 131072, nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpNotifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpNotificationSubscriptions",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: false),
                    NotificationName = table.Column<string>("character varying(96)", maxLength: 96, nullable: true),
                    EntityTypeName = table.Column<string>("character varying(250)", maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName =
                        table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    EntityId = table.Column<string>("character varying(96)", maxLength: 96, nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpNotificationSubscriptions", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpOrganizationUnitRoles",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    RoleId = table.Column<int>("integer", nullable: false),
                    OrganizationUnitId = table.Column<long>("bigint", nullable: false),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpOrganizationUnits",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    ParentId = table.Column<long>("bigint", nullable: true),
                    Code = table.Column<string>("character varying(95)", maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    DeleterUserId = table.Column<long>("bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>("timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                        x => x.ParentId,
                        "AbpOrganizationUnits",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpPersistedGrants",
                table => new
                {
                    Id = table.Column<string>("character varying(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>("character varying(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>("character varying(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>("character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>("character varying(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    Expiration = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    ConsumedTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    Data = table.Column<string>("character varying(50000)", maxLength: 50000, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpPersistedGrants", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpTenantNotifications",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    NotificationName = table.Column<string>("character varying(96)", maxLength: 96, nullable: false),
                    Data = table.Column<string>("character varying(1048576)", maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>("character varying(250)", maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName =
                        table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    EntityId = table.Column<string>("character varying(96)", maxLength: 96, nullable: true),
                    Severity = table.Column<byte>("smallint", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpTenantNotifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserAccounts",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: false),
                    UserLinkId = table.Column<long>("bigint", nullable: true),
                    UserName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    DeleterUserId = table.Column<long>("bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>("timestamp without time zone", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpUserAccounts", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserLoginAttempts",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    TenancyName = table.Column<string>("character varying(64)", maxLength: 64, nullable: true),
                    UserId = table.Column<long>("bigint", nullable: true),
                    UserNameOrEmailAddress =
                        table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    ClientIpAddress = table.Column<string>("character varying(64)", maxLength: 64, nullable: true),
                    ClientName = table.Column<string>("character varying(128)", maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    Result = table.Column<byte>("smallint", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpUserLoginAttempts", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUserNotifications",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: false),
                    TenantNotificationId = table.Column<Guid>("uuid", nullable: false),
                    State = table.Column<int>("integer", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AbpUserNotifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpUsers",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfilePictureId = table.Column<Guid>("uuid", nullable: true),
                    ShouldChangePasswordOnNextLogin = table.Column<bool>("boolean", nullable: false),
                    SignInTokenExpireTimeUtc = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    SignInToken = table.Column<string>("text", nullable: true),
                    GoogleAuthenticatorKey = table.Column<string>("text", nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    DeleterUserId = table.Column<long>("bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    AuthenticationSource = table.Column<string>("character varying(64)", maxLength: 64, nullable: true),
                    UserName = table.Column<string>("character varying(256)", maxLength: 256, nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    EmailAddress = table.Column<string>("character varying(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>("character varying(64)", maxLength: 64, nullable: false),
                    Surname = table.Column<string>("character varying(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    EmailConfirmationCode =
                        table.Column<string>("character varying(328)", maxLength: 328, nullable: true),
                    PasswordResetCode = table.Column<string>("character varying(328)", maxLength: 328, nullable: true),
                    LockoutEndDateUtc = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    AccessFailedCount = table.Column<int>("integer", nullable: false),
                    IsLockoutEnabled = table.Column<bool>("boolean", nullable: false),
                    PhoneNumber = table.Column<string>("character varying(32)", maxLength: 32, nullable: true),
                    IsPhoneNumberConfirmed = table.Column<bool>("boolean", nullable: false),
                    SecurityStamp = table.Column<string>("character varying(128)", maxLength: 128, nullable: true),
                    IsTwoFactorEnabled = table.Column<bool>("boolean", nullable: false),
                    IsEmailConfirmed = table.Column<bool>("boolean", nullable: false),
                    IsActive = table.Column<bool>("boolean", nullable: false),
                    NormalizedUserName =
                        table.Column<string>("character varying(256)", maxLength: 256, nullable: false),
                    NormalizedEmailAddress =
                        table.Column<string>("character varying(256)", maxLength: 256, nullable: false),
                    ConcurrencyStamp = table.Column<string>("character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUsers", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUsers_AbpUsers_CreatorUserId",
                        x => x.CreatorUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpUsers_AbpUsers_DeleterUserId",
                        x => x.DeleterUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpUsers_AbpUsers_LastModifierUserId",
                        x => x.LastModifierUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpWebhookEvents",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    WebhookName = table.Column<string>("text", nullable: false),
                    Data = table.Column<string>("text", nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    DeletionTime = table.Column<DateTime>("timestamp without time zone", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpWebhookEvents", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpWebhookSubscriptions",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    WebhookUri = table.Column<string>("text", nullable: false),
                    Secret = table.Column<string>("text", nullable: false),
                    IsActive = table.Column<bool>("boolean", nullable: false),
                    Webhooks = table.Column<string>("text", nullable: true),
                    Headers = table.Column<string>("text", nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AbpWebhookSubscriptions", x => x.Id); });

            migrationBuilder.CreateTable(
                "AppBinaryObjects",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    Description = table.Column<string>("text", nullable: true),
                    Bytes = table.Column<byte[]>("bytea", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AppBinaryObjects", x => x.Id); });

            migrationBuilder.CreateTable(
                "AppChatMessages",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>("bigint", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    TargetUserId = table.Column<long>("bigint", nullable: false),
                    TargetTenantId = table.Column<int>("integer", nullable: true),
                    Message = table.Column<string>("character varying(4096)", maxLength: 4096, nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    Side = table.Column<int>("integer", nullable: false),
                    ReadState = table.Column<int>("integer", nullable: false),
                    ReceiverReadState = table.Column<int>("integer", nullable: false),
                    SharedMessageId = table.Column<Guid>("uuid", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AppChatMessages", x => x.Id); });

            migrationBuilder.CreateTable(
                "AppFriendships",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>("bigint", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    FriendUserId = table.Column<long>("bigint", nullable: false),
                    FriendTenantId = table.Column<int>("integer", nullable: true),
                    FriendUserName = table.Column<string>("character varying(256)", maxLength: 256, nullable: false),
                    FriendTenancyName = table.Column<string>("text", nullable: true),
                    FriendProfilePictureId = table.Column<Guid>("uuid", nullable: true),
                    State = table.Column<int>("integer", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AppFriendships", x => x.Id); });

            migrationBuilder.CreateTable(
                "AppInvoices",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceNo = table.Column<string>("text", nullable: true),
                    InvoiceDate = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    TenantLegalName = table.Column<string>("text", nullable: true),
                    TenantAddress = table.Column<string>("text", nullable: true),
                    TenantTaxNo = table.Column<string>("text", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AppInvoices", x => x.Id); });

            migrationBuilder.CreateTable(
                "AppSubscriptionPaymentsExtensionData",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubscriptionPaymentId = table.Column<long>("bigint", nullable: false),
                    Key = table.Column<string>("text", nullable: true),
                    Value = table.Column<string>("text", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AppSubscriptionPaymentsExtensionData", x => x.Id); });

            migrationBuilder.CreateTable(
                "AppUserDelegations",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceUserId = table.Column<long>("bigint", nullable: false),
                    TargetUserId = table.Column<long>("bigint", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    StartTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    DeleterUserId = table.Column<long>("bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>("timestamp without time zone", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AppUserDelegations", x => x.Id); });

            migrationBuilder.CreateTable(
                "AbpDynamicEntityProperties",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntityFullName = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    DynamicPropertyId = table.Column<int>("integer", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicEntityProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpDynamicEntityProperties_AbpDynamicProperties_DynamicProp~",
                        x => x.DynamicPropertyId,
                        "AbpDynamicProperties",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpDynamicPropertyValues",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>("text", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true),
                    DynamicPropertyId = table.Column<int>("integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicPropertyValues", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpDynamicPropertyValues_AbpDynamicProperties_DynamicProper~",
                        x => x.DynamicPropertyId,
                        "AbpDynamicProperties",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpFeatures",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    Name = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>("character varying(2000)", maxLength: 2000, nullable: false),
                    Discriminator = table.Column<string>("text", nullable: false),
                    EditionId = table.Column<int>("integer", nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatures", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpFeatures_AbpEditions_EditionId",
                        x => x.EditionId,
                        "AbpEditions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AppSubscriptionPayments",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>("text", nullable: true),
                    Gateway = table.Column<int>("integer", nullable: false),
                    Amount = table.Column<decimal>("numeric", nullable: false),
                    Status = table.Column<int>("integer", nullable: false),
                    EditionId = table.Column<int>("integer", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: false),
                    DayCount = table.Column<int>("integer", nullable: false),
                    PaymentPeriodType = table.Column<int>("integer", nullable: true),
                    ExternalPaymentId = table.Column<string>("text", nullable: true),
                    InvoiceNo = table.Column<string>("text", nullable: true),
                    IsRecurring = table.Column<bool>("boolean", nullable: false),
                    SuccessUrl = table.Column<string>("text", nullable: true),
                    ErrorUrl = table.Column<string>("text", nullable: true),
                    EditionPaymentType = table.Column<int>("integer", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    DeleterUserId = table.Column<long>("bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>("timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSubscriptionPayments", x => x.Id);
                    table.ForeignKey(
                        "FK_AppSubscriptionPayments_AbpEditions_EditionId",
                        x => x.EditionId,
                        "AbpEditions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpEntityChanges",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChangeTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    ChangeType = table.Column<byte>("smallint", nullable: false),
                    EntityChangeSetId = table.Column<long>("bigint", nullable: false),
                    EntityId = table.Column<string>("character varying(48)", maxLength: 48, nullable: true),
                    EntityTypeFullName = table.Column<string>("character varying(192)", maxLength: 192, nullable: true),
                    TenantId = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpEntityChanges_AbpEntityChangeSets_EntityChangeSetId",
                        x => x.EntityChangeSetId,
                        "AbpEntityChangeSets",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpRoles",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    DeleterUserId = table.Column<long>("bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    TenantId = table.Column<int>("integer", nullable: true),
                    Name = table.Column<string>("character varying(32)", maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>("character varying(64)", maxLength: 64, nullable: false),
                    IsStatic = table.Column<bool>("boolean", nullable: false),
                    IsDefault = table.Column<bool>("boolean", nullable: false),
                    NormalizedName = table.Column<string>("character varying(32)", maxLength: 32, nullable: false),
                    ConcurrencyStamp = table.Column<string>("character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoles", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpRoles_AbpUsers_CreatorUserId",
                        x => x.CreatorUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpRoles_AbpUsers_DeleterUserId",
                        x => x.DeleterUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpRoles_AbpUsers_LastModifierUserId",
                        x => x.LastModifierUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpSettings",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: true),
                    Name = table.Column<string>("character varying(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>("text", nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpSettings_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpTenants",
                table => new
                {
                    Id = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubscriptionEndDateUtc = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    IsInTrialPeriod = table.Column<bool>("boolean", nullable: false),
                    CustomCssId = table.Column<Guid>("uuid", nullable: true),
                    LogoId = table.Column<Guid>("uuid", nullable: true),
                    LogoFileType = table.Column<string>("character varying(64)", maxLength: 64, nullable: true),
                    SubscriptionPaymentType = table.Column<int>("integer", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    LastModifierUserId = table.Column<long>("bigint", nullable: true),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    DeleterUserId = table.Column<long>("bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    TenancyName = table.Column<string>("character varying(64)", maxLength: 64, nullable: false),
                    Name = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    ConnectionString = table.Column<string>("character varying(1024)", maxLength: 1024, nullable: true),
                    IsActive = table.Column<bool>("boolean", nullable: false),
                    EditionId = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenants", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpTenants_AbpEditions_EditionId",
                        x => x.EditionId,
                        "AbpEditions",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpTenants_AbpUsers_CreatorUserId",
                        x => x.CreatorUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpTenants_AbpUsers_DeleterUserId",
                        x => x.DeleterUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_AbpTenants_AbpUsers_LastModifierUserId",
                        x => x.LastModifierUserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AbpUserClaims",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: false),
                    ClaimType = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>("text", nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUserClaims_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserLogins",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: false),
                    LoginProvider = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>("character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLogins", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUserLogins_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserOrganizationUnits",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: false),
                    OrganizationUnitId = table.Column<long>("bigint", nullable: false),
                    IsDeleted = table.Column<bool>("boolean", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUserOrganizationUnits_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserRoles",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: false),
                    RoleId = table.Column<int>("integer", nullable: false),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserRoles", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUserRoles_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpUserTokens",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: false),
                    LoginProvider = table.Column<string>("character varying(128)", maxLength: 128, nullable: true),
                    Name = table.Column<string>("character varying(128)", maxLength: 128, nullable: true),
                    Value = table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    ExpireDate = table.Column<DateTime>("timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserTokens", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpUserTokens_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpWebhookSendAttempts",
                table => new
                {
                    Id = table.Column<Guid>("uuid", nullable: false),
                    WebhookEventId = table.Column<Guid>("uuid", nullable: false),
                    WebhookSubscriptionId = table.Column<Guid>("uuid", nullable: false),
                    Response = table.Column<string>("text", nullable: true),
                    ResponseStatusCode = table.Column<int>("integer", nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    LastModificationTime = table.Column<DateTime>("timestamp without time zone", nullable: true),
                    TenantId = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWebhookSendAttempts", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpWebhookSendAttempts_AbpWebhookEvents_WebhookEventId",
                        x => x.WebhookEventId,
                        "AbpWebhookEvents",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpDynamicEntityPropertyValues",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>("text", nullable: false),
                    EntityId = table.Column<string>("text", nullable: true),
                    DynamicEntityPropertyId = table.Column<int>("integer", nullable: false),
                    TenantId = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDynamicEntityPropertyValues", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpDynamicEntityPropertyValues_AbpDynamicEntityProperties_D~",
                        x => x.DynamicEntityPropertyId,
                        "AbpDynamicEntityProperties",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpEntityPropertyChanges",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntityChangeId = table.Column<long>("bigint", nullable: false),
                    NewValue = table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>("character varying(512)", maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>("character varying(96)", maxLength: 96, nullable: true),
                    PropertyTypeFullName =
                        table.Column<string>("character varying(192)", maxLength: 192, nullable: true),
                    TenantId = table.Column<int>("integer", nullable: true),
                    NewValueHash = table.Column<string>("text", nullable: true),
                    OriginalValueHash = table.Column<string>("text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        x => x.EntityChangeId,
                        "AbpEntityChanges",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpPermissions",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    Name = table.Column<string>("character varying(128)", maxLength: 128, nullable: false),
                    IsGranted = table.Column<bool>("boolean", nullable: false),
                    Discriminator = table.Column<string>("text", nullable: false),
                    RoleId = table.Column<int>("integer", nullable: true),
                    UserId = table.Column<long>("bigint", nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissions", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpPermissions_AbpRoles_RoleId",
                        x => x.RoleId,
                        "AbpRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AbpPermissions_AbpUsers_UserId",
                        x => x.UserId,
                        "AbpUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AbpRoleClaims",
                table => new
                {
                    Id = table.Column<long>("bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TenantId = table.Column<int>("integer", nullable: true),
                    RoleId = table.Column<int>("integer", nullable: false),
                    ClaimType = table.Column<string>("character varying(256)", maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>("text", nullable: true),
                    CreationTime = table.Column<DateTime>("timestamp without time zone", nullable: false),
                    CreatorUserId = table.Column<long>("bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AbpRoleClaims_AbpRoles_RoleId",
                        x => x.RoleId,
                        "AbpRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_ExecutionDuration",
                "AbpAuditLogs",
                new[] {"TenantId", "ExecutionDuration"});

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_ExecutionTime",
                "AbpAuditLogs",
                new[] {"TenantId", "ExecutionTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpAuditLogs_TenantId_UserId",
                "AbpAuditLogs",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime",
                "AbpBackgroundJobs",
                new[] {"IsAbandoned", "NextTryTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpDynamicEntityProperties_DynamicPropertyId",
                "AbpDynamicEntityProperties",
                "DynamicPropertyId");

            migrationBuilder.CreateIndex(
                "IX_AbpDynamicEntityProperties_EntityFullName_DynamicPropertyId~",
                "AbpDynamicEntityProperties",
                new[] {"EntityFullName", "DynamicPropertyId", "TenantId"},
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AbpDynamicEntityPropertyValues_DynamicEntityPropertyId",
                "AbpDynamicEntityPropertyValues",
                "DynamicEntityPropertyId");

            migrationBuilder.CreateIndex(
                "IX_AbpDynamicProperties_PropertyName_TenantId",
                "AbpDynamicProperties",
                new[] {"PropertyName", "TenantId"},
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AbpDynamicPropertyValues_DynamicPropertyId",
                "AbpDynamicPropertyValues",
                "DynamicPropertyId");

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChanges_EntityChangeSetId",
                "AbpEntityChanges",
                "EntityChangeSetId");

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChanges_EntityTypeFullName_EntityId",
                "AbpEntityChanges",
                new[] {"EntityTypeFullName", "EntityId"});

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChangeSets_TenantId_CreationTime",
                "AbpEntityChangeSets",
                new[] {"TenantId", "CreationTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChangeSets_TenantId_Reason",
                "AbpEntityChangeSets",
                new[] {"TenantId", "Reason"});

            migrationBuilder.CreateIndex(
                "IX_AbpEntityChangeSets_TenantId_UserId",
                "AbpEntityChangeSets",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpEntityPropertyChanges_EntityChangeId",
                "AbpEntityPropertyChanges",
                "EntityChangeId");

            migrationBuilder.CreateIndex(
                "IX_AbpFeatures_EditionId_Name",
                "AbpFeatures",
                new[] {"EditionId", "Name"});

            migrationBuilder.CreateIndex(
                "IX_AbpFeatures_TenantId_Name",
                "AbpFeatures",
                new[] {"TenantId", "Name"});

            migrationBuilder.CreateIndex(
                "IX_AbpLanguages_TenantId_Name",
                "AbpLanguages",
                new[] {"TenantId", "Name"});

            migrationBuilder.CreateIndex(
                "IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key",
                "AbpLanguageTexts",
                new[] {"TenantId", "Source", "LanguageName", "Key"});

            migrationBuilder.CreateIndex(
                "IX_AbpNotificationSubscriptions_NotificationName_EntityTypeNam~",
                "AbpNotificationSubscriptions",
                new[] {"NotificationName", "EntityTypeName", "EntityId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpNotificationSubscriptions_TenantId_NotificationName_Enti~",
                "AbpNotificationSubscriptions",
                new[] {"TenantId", "NotificationName", "EntityTypeName", "EntityId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId",
                "AbpOrganizationUnitRoles",
                new[] {"TenantId", "OrganizationUnitId"});

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnitRoles_TenantId_RoleId",
                "AbpOrganizationUnitRoles",
                new[] {"TenantId", "RoleId"});

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnits_ParentId",
                "AbpOrganizationUnits",
                "ParentId");

            migrationBuilder.CreateIndex(
                "IX_AbpOrganizationUnits_TenantId_Code",
                "AbpOrganizationUnits",
                new[] {"TenantId", "Code"});

            migrationBuilder.CreateIndex(
                "IX_AbpPermissions_RoleId",
                "AbpPermissions",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_AbpPermissions_TenantId_Name",
                "AbpPermissions",
                new[] {"TenantId", "Name"});

            migrationBuilder.CreateIndex(
                "IX_AbpPermissions_UserId",
                "AbpPermissions",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpPersistedGrants_Expiration",
                "AbpPersistedGrants",
                "Expiration");

            migrationBuilder.CreateIndex(
                "IX_AbpPersistedGrants_SubjectId_ClientId_Type",
                "AbpPersistedGrants",
                new[] {"SubjectId", "ClientId", "Type"});

            migrationBuilder.CreateIndex(
                "IX_AbpPersistedGrants_SubjectId_SessionId_Type",
                "AbpPersistedGrants",
                new[] {"SubjectId", "SessionId", "Type"});

            migrationBuilder.CreateIndex(
                "IX_AbpRoleClaims_RoleId",
                "AbpRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoleClaims_TenantId_ClaimType",
                "AbpRoleClaims",
                new[] {"TenantId", "ClaimType"});

            migrationBuilder.CreateIndex(
                "IX_AbpRoles_CreatorUserId",
                "AbpRoles",
                "CreatorUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoles_DeleterUserId",
                "AbpRoles",
                "DeleterUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoles_LastModifierUserId",
                "AbpRoles",
                "LastModifierUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpRoles_TenantId_NormalizedName",
                "AbpRoles",
                new[] {"TenantId", "NormalizedName"});

            migrationBuilder.CreateIndex(
                "IX_AbpSettings_TenantId_Name_UserId",
                "AbpSettings",
                new[] {"TenantId", "Name", "UserId"},
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AbpSettings_UserId",
                "AbpSettings",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpTenantNotifications_TenantId",
                "AbpTenantNotifications",
                "TenantId");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_CreationTime",
                "AbpTenants",
                "CreationTime");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_CreatorUserId",
                "AbpTenants",
                "CreatorUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_DeleterUserId",
                "AbpTenants",
                "DeleterUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_EditionId",
                "AbpTenants",
                "EditionId");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_LastModifierUserId",
                "AbpTenants",
                "LastModifierUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_SubscriptionEndDateUtc",
                "AbpTenants",
                "SubscriptionEndDateUtc");

            migrationBuilder.CreateIndex(
                "IX_AbpTenants_TenancyName",
                "AbpTenants",
                "TenancyName");

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_EmailAddress",
                "AbpUserAccounts",
                "EmailAddress");

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_TenantId_EmailAddress",
                "AbpUserAccounts",
                new[] {"TenantId", "EmailAddress"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_TenantId_UserId",
                "AbpUserAccounts",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_TenantId_UserName",
                "AbpUserAccounts",
                new[] {"TenantId", "UserName"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserAccounts_UserName",
                "AbpUserAccounts",
                "UserName");

            migrationBuilder.CreateIndex(
                "IX_AbpUserClaims_TenantId_ClaimType",
                "AbpUserClaims",
                new[] {"TenantId", "ClaimType"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserClaims_UserId",
                "AbpUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Res~",
                "AbpUserLoginAttempts",
                new[] {"TenancyName", "UserNameOrEmailAddress", "Result"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserLoginAttempts_UserId_TenantId",
                "AbpUserLoginAttempts",
                new[] {"UserId", "TenantId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey",
                "AbpUserLogins",
                new[] {"TenantId", "LoginProvider", "ProviderKey"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserLogins_TenantId_UserId",
                "AbpUserLogins",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserLogins_UserId",
                "AbpUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserNotifications_UserId_State_CreationTime",
                "AbpUserNotifications",
                new[] {"UserId", "State", "CreationTime"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId",
                "AbpUserOrganizationUnits",
                new[] {"TenantId", "OrganizationUnitId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserOrganizationUnits_TenantId_UserId",
                "AbpUserOrganizationUnits",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserOrganizationUnits_UserId",
                "AbpUserOrganizationUnits",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUserRoles_TenantId_RoleId",
                "AbpUserRoles",
                new[] {"TenantId", "RoleId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserRoles_TenantId_UserId",
                "AbpUserRoles",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserRoles_UserId",
                "AbpUserRoles",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_CreatorUserId",
                "AbpUsers",
                "CreatorUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_DeleterUserId",
                "AbpUsers",
                "DeleterUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_LastModifierUserId",
                "AbpUsers",
                "LastModifierUserId");

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_TenantId_NormalizedEmailAddress",
                "AbpUsers",
                new[] {"TenantId", "NormalizedEmailAddress"});

            migrationBuilder.CreateIndex(
                "IX_AbpUsers_TenantId_NormalizedUserName",
                "AbpUsers",
                new[] {"TenantId", "NormalizedUserName"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserTokens_TenantId_UserId",
                "AbpUserTokens",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AbpUserTokens_UserId",
                "AbpUserTokens",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AbpWebhookSendAttempts_WebhookEventId",
                "AbpWebhookSendAttempts",
                "WebhookEventId");

            migrationBuilder.CreateIndex(
                "IX_AppBinaryObjects_TenantId",
                "AppBinaryObjects",
                "TenantId");

            migrationBuilder.CreateIndex(
                "IX_AppChatMessages_TargetTenantId_TargetUserId_ReadState",
                "AppChatMessages",
                new[] {"TargetTenantId", "TargetUserId", "ReadState"});

            migrationBuilder.CreateIndex(
                "IX_AppChatMessages_TargetTenantId_UserId_ReadState",
                "AppChatMessages",
                new[] {"TargetTenantId", "UserId", "ReadState"});

            migrationBuilder.CreateIndex(
                "IX_AppChatMessages_TenantId_TargetUserId_ReadState",
                "AppChatMessages",
                new[] {"TenantId", "TargetUserId", "ReadState"});

            migrationBuilder.CreateIndex(
                "IX_AppChatMessages_TenantId_UserId_ReadState",
                "AppChatMessages",
                new[] {"TenantId", "UserId", "ReadState"});

            migrationBuilder.CreateIndex(
                "IX_AppFriendships_FriendTenantId_FriendUserId",
                "AppFriendships",
                new[] {"FriendTenantId", "FriendUserId"});

            migrationBuilder.CreateIndex(
                "IX_AppFriendships_FriendTenantId_UserId",
                "AppFriendships",
                new[] {"FriendTenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AppFriendships_TenantId_FriendUserId",
                "AppFriendships",
                new[] {"TenantId", "FriendUserId"});

            migrationBuilder.CreateIndex(
                "IX_AppFriendships_TenantId_UserId",
                "AppFriendships",
                new[] {"TenantId", "UserId"});

            migrationBuilder.CreateIndex(
                "IX_AppSubscriptionPayments_EditionId",
                "AppSubscriptionPayments",
                "EditionId");

            migrationBuilder.CreateIndex(
                "IX_AppSubscriptionPayments_ExternalPaymentId_Gateway",
                "AppSubscriptionPayments",
                new[] {"ExternalPaymentId", "Gateway"});

            migrationBuilder.CreateIndex(
                "IX_AppSubscriptionPayments_Status_CreationTime",
                "AppSubscriptionPayments",
                new[] {"Status", "CreationTime"});

            migrationBuilder.CreateIndex(
                "IX_AppSubscriptionPaymentsExtensionData_SubscriptionPaymentId_~",
                "AppSubscriptionPaymentsExtensionData",
                new[] {"SubscriptionPaymentId", "Key", "IsDeleted"},
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AppUserDelegations_TenantId_SourceUserId",
                "AppUserDelegations",
                new[] {"TenantId", "SourceUserId"});

            migrationBuilder.CreateIndex(
                "IX_AppUserDelegations_TenantId_TargetUserId",
                "AppUserDelegations",
                new[] {"TenantId", "TargetUserId"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AbpAuditLogs");

            migrationBuilder.DropTable(
                "AbpBackgroundJobs");

            migrationBuilder.DropTable(
                "AbpDynamicEntityPropertyValues");

            migrationBuilder.DropTable(
                "AbpDynamicPropertyValues");

            migrationBuilder.DropTable(
                "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                "AbpFeatures");

            migrationBuilder.DropTable(
                "AbpLanguages");

            migrationBuilder.DropTable(
                "AbpLanguageTexts");

            migrationBuilder.DropTable(
                "AbpNotifications");

            migrationBuilder.DropTable(
                "AbpNotificationSubscriptions");

            migrationBuilder.DropTable(
                "AbpOrganizationUnitRoles");

            migrationBuilder.DropTable(
                "AbpOrganizationUnits");

            migrationBuilder.DropTable(
                "AbpPermissions");

            migrationBuilder.DropTable(
                "AbpPersistedGrants");

            migrationBuilder.DropTable(
                "AbpRoleClaims");

            migrationBuilder.DropTable(
                "AbpSettings");

            migrationBuilder.DropTable(
                "AbpTenantNotifications");

            migrationBuilder.DropTable(
                "AbpTenants");

            migrationBuilder.DropTable(
                "AbpUserAccounts");

            migrationBuilder.DropTable(
                "AbpUserClaims");

            migrationBuilder.DropTable(
                "AbpUserLoginAttempts");

            migrationBuilder.DropTable(
                "AbpUserLogins");

            migrationBuilder.DropTable(
                "AbpUserNotifications");

            migrationBuilder.DropTable(
                "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                "AbpUserRoles");

            migrationBuilder.DropTable(
                "AbpUserTokens");

            migrationBuilder.DropTable(
                "AbpWebhookSendAttempts");

            migrationBuilder.DropTable(
                "AbpWebhookSubscriptions");

            migrationBuilder.DropTable(
                "AppBinaryObjects");

            migrationBuilder.DropTable(
                "AppChatMessages");

            migrationBuilder.DropTable(
                "AppFriendships");

            migrationBuilder.DropTable(
                "AppInvoices");

            migrationBuilder.DropTable(
                "AppSubscriptionPayments");

            migrationBuilder.DropTable(
                "AppSubscriptionPaymentsExtensionData");

            migrationBuilder.DropTable(
                "AppUserDelegations");

            migrationBuilder.DropTable(
                "AbpDynamicEntityProperties");

            migrationBuilder.DropTable(
                "AbpEntityChanges");

            migrationBuilder.DropTable(
                "AbpRoles");

            migrationBuilder.DropTable(
                "AbpWebhookEvents");

            migrationBuilder.DropTable(
                "AbpEditions");

            migrationBuilder.DropTable(
                "AbpDynamicProperties");

            migrationBuilder.DropTable(
                "AbpEntityChangeSets");

            migrationBuilder.DropTable(
                "AbpUsers");
        }
    }
}