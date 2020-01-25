using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeTheatre.Data.Migrations
{
    public partial class I : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsBanned = table.Column<bool>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: true),
                    RoleName = table.Column<string>(nullable: true),
                    BanReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReasonBanned = table.Column<string>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ExpiresOn = table.Column<DateTime>(nullable: false),
                    HasExpired = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bans_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Theatres",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    AverageRating = table.Column<double>(nullable: true),
                    NumberOfReviews = table.Column<int>(nullable: false),
                    AboutInfo = table.Column<string>(maxLength: 1000, nullable: false),
                    Location = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    CurrentUserRating = table.Column<double>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theatres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theatres_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    ReviewText = table.Column<string>(maxLength: 500, nullable: true),
                    TheatreId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Theatres_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CommentText = table.Column<string>(maxLength: 500, nullable: false),
                    Author = table.Column<string>(nullable: true),
                    ReviewId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2eecd046-8de2-4794-b91d-dffd4ede8c11"), "9eb1647f-348e-45a1-b53e-eca38d50658c", "Administrator", "ADMINISTRATOR" },
                    { new Guid("b4ae87fb-2c3f-4837-b791-8cf6aaa5e763"), "02ca38b9-6269-4f63-a5e0-6240c7ae88f3", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BanReason", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsBanned", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "RoleName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("f53f6435-03d8-4567-9edb-48443dd520cc"), 0, null, "1c20fb7d-f256-46bd-b63d-a0d3cced6ac0", new DateTime(2020, 1, 24, 18, 37, 46, 338, DateTimeKind.Utc).AddTicks(9705), null, "ThirdMember@gmail.com", false, false, false, true, null, null, "Minka", null, "MEMBERTHIRD", "6DF09E116C3095DD31B0952CCED5AAA34AF32CB0EA176F26ADCECB5F8C128083", "0987453985", false, null, "Member", "DA76A4HJ534UF7445T5E", false, "MemberThird" },
                    { new Guid("d73312b2-789c-4569-aadd-d5d9eb411506"), 0, null, "0ff5c490-da63-4b23-9f1b-7795eb637bf2", new DateTime(2020, 1, 24, 18, 37, 46, 338, DateTimeKind.Utc).AddTicks(9665), null, "SecondMember@gmail.com", false, false, false, true, null, null, "Pesho", null, "MEMBERSECOND", "033AD8354032D25A04D3859A9ACB7786EB3DE73F852879978028526F2C49932B", "0987453345", false, null, "Member", "JKIVDR4H7DJSKH", false, "MemberSecond" },
                    { new Guid("4eac031b-26fd-40ba-bacf-603534229f79"), 0, null, "e5dc0bf5-7a26-418b-83d0-023e4624177b", new DateTime(2020, 1, 24, 18, 37, 46, 338, DateTimeKind.Utc).AddTicks(9161), null, "FirstMember@gmail.com", false, false, false, true, null, null, "Gosho", null, "MEMBERFIRST", "3CF19CDEA15EEE7CC3F2BA9C0879DCB00BCE00E06D9A3353B29DD2186FA1E7E7", "0987453355", false, null, "Member", "HHTF565DGH87NHFT", false, "MemberFirst" },
                    { new Guid("eb8b5e77-0296-400a-aa32-5887033a7be5"), 0, null, "b1cf0e9b-45b3-4831-8910-ffb3fa52b2da", new DateTime(2020, 1, 24, 18, 37, 46, 321, DateTimeKind.Utc).AddTicks(8317), null, "Admin@gmail.com", false, false, false, true, null, null, "Martin", null, "ADMIN", "AQAAAAEAACcQAAAAEHaDwds1kY9cTop2npqlv5Exuoq44q+yLlLcTxFfM1u0avE6qKOiz26bP1VzEiuktQ==", "0895488533", false, null, "Administrator", "*JUTF774DBHJIUUT", false, "Admin" },
                    { new Guid("019e9517-da08-47f2-8b33-6b7ccde04aed"), 0, null, "9db0c738-0e2c-4176-8f76-7f1eecf70402", new DateTime(2020, 1, 24, 18, 37, 46, 338, DateTimeKind.Utc).AddTicks(9731), null, "FourthMember@gmail.com", false, false, false, true, null, null, "Ivancho", null, "MEMBERFOURTH", "A8081515001427F49CCE5EFCCCDDAFEC449C2409D7C55BF003034FF33752E212", "0987453825", false, null, "Member", "UDIADFG564433HGS", false, "MemberFourth" },
                    { new Guid("80b8434d-6d7e-42f5-a499-cdb3a635bb0e"), 0, null, "0b740afe-95a0-4d83-a432-a3b0c6f8829b", new DateTime(2020, 1, 24, 18, 37, 46, 338, DateTimeKind.Utc).AddTicks(9757), null, "FifthMember@gmail.com", false, false, false, true, null, null, "Bai Ganio", null, "MEMBERFIFTH", "C5EE108214C790A2EC74ECBAF557498B03E6F00E90EDA64C1D01631776FE1B10", "0987482355", false, null, "Member", "DOHASIUDG7637242G5YG", false, "MemberFifth" }
                });

            migrationBuilder.InsertData(
                table: "Theatres",
                columns: new[] { "Id", "AboutInfo", "AverageRating", "CreatedOn", "CurrentUserRating", "DeletedOn", "ImagePath", "IsDeleted", "Location", "ModifiedOn", "Name", "NumberOfReviews", "Phone", "UserId" },
                values: new object[,]
                {
                    { new Guid("50ee9f38-1484-4eb9-800a-39c98d6d8ff3"), "This Theatre has stood for 200 years and it shows then you enter", null, new DateTime(2020, 1, 24, 18, 37, 46, 339, DateTimeKind.Utc).AddTicks(5922), null, null, "/assets/images/YellowTheatre.jpg", false, "Mankato Mississippi 96522", null, "FifthTheatre", 0, "0896453455", null },
                    { new Guid("bb9bfebb-995f-4ed1-84a9-00c32be3f602"), "Same as the seventh Theatre but yet ,somehow the opposite", null, new DateTime(2020, 1, 24, 18, 37, 46, 339, DateTimeKind.Utc).AddTicks(5928), null, null, "/assets/images/Foiey.jpg", false, "Gospodinovzi str, Sofia city", null, "EigthTheatre", 0, "0896453488", null },
                    { new Guid("42e96f5d-fe9e-4877-8e95-ed2a9f94ae06"), "This Theatre is very expensive,not well suited to poor people", null, new DateTime(2020, 1, 24, 18, 37, 46, 339, DateTimeKind.Utc).AddTicks(5929), null, null, "/assets/images/Old.jpg", false, "Bullevard 27 str, Sofia city", null, "NinthTheatre", 0, "0896453499", null },
                    { new Guid("7ba7ac70-0d4b-49c0-810e-77939562597f"), "A ghetto Theatre which has the single purpose of getting robbed", null, new DateTime(2020, 1, 24, 18, 37, 46, 339, DateTimeKind.Utc).AddTicks(5931), null, null, "/assets/images/Wide.jpg", false, "Fifth and avenue str ,Cansas city", null, "TenthTheatre", 0, "0896453410", null },
                    { new Guid("75cb73a2-86a1-40f0-8e4e-6dd158050c6d"), "The door man is very polite,otherwise the Theatre is rather unpleasant", null, new DateTime(2020, 1, 24, 18, 37, 46, 339, DateTimeKind.Utc).AddTicks(5921), null, null, "/assets/images/ThatsAllFolks.jpg", false, "Frederick Nebraska 20620", null, "FourthTheatre", 0, "089645344", null },
                    { new Guid("dee99c29-3a43-491e-b2a4-814bf77dc31f"), "Same as the second Theatre but with character", null, new DateTime(2020, 1, 24, 18, 37, 46, 339, DateTimeKind.Utc).AddTicks(5919), null, null, "/assets/images/LightHouse.jpg", false, "606-3727 Ullamcorper. StreetRoseville NH 11523", null, "ThirdTheatre", 0, "0896453433", null },
                    { new Guid("1930f972-5dbf-4fab-af28-eb3d6e71364b"), "A Rather nasty Theatre with rats everywhere even in the popcorn", null, new DateTime(2020, 1, 24, 18, 37, 46, 339, DateTimeKind.Utc).AddTicks(5914), null, null, "/assets/images/Depth.jpg", false, "191-103 Integer Rd.Corona New Mexico 08219", null, "SecondTheatre", 0, "0896453402", null },
                    { new Guid("3790ba40-4f3b-41c2-8b6e-8f92fbd9a69e"), "A Cultural Theatre for those with too much time on their hands", null, new DateTime(2020, 1, 24, 18, 37, 46, 339, DateTimeKind.Utc).AddTicks(5248), null, null, "/assets/images/Italian.jpg", false, "7292 Dictum Av.San Antonio MI 47096", null, "FirstTheatre", 0, "0896453401", null },
                    { new Guid("7f888d1a-7be0-4ba5-9a8e-9cbf7bf9d25a"), "A Theatre for people with a finer taste then the average mortal man", null, new DateTime(2020, 1, 24, 18, 37, 46, 339, DateTimeKind.Utc).AddTicks(5923), null, null, "/assets/images/CathedralTheatre.jpg", false, "Chaika str ,Varna city", null, "SixthTheatre", 0, "0896453466", null },
                    { new Guid("3e34e9e4-ff04-4463-ae27-3c295b715e88"), "There has never existed a fancier Theatre, the curtains are made o woven gold", null, new DateTime(2020, 1, 24, 18, 37, 46, 339, DateTimeKind.Utc).AddTicks(5927), null, null, "/assets/images/ComfyHomeCinema.jpg", false, "TheOneTrueStreet str, BestCity city", null, "SeventhTheatre", 0, "0896453477", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("eb8b5e77-0296-400a-aa32-5887033a7be5"), new Guid("2eecd046-8de2-4794-b91d-dffd4ede8c11") },
                    { new Guid("4eac031b-26fd-40ba-bacf-603534229f79"), new Guid("b4ae87fb-2c3f-4837-b791-8cf6aaa5e763") }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Author", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Rating", "ReviewText", "TheatreId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c76ab3f4-e445-4e88-9359-a4a171f97862"), "MemberFifth", new DateTime(2020, 1, 24, 18, 37, 46, 340, DateTimeKind.Utc).AddTicks(2090), null, false, null, 5.0, "This Theatre is halfway decent,but too expensive", new Guid("3790ba40-4f3b-41c2-8b6e-8f92fbd9a69e"), null },
                    { new Guid("03383637-e73b-4005-9b16-9a11168240bc"), "MemberFourth", new DateTime(2020, 1, 24, 18, 37, 46, 340, DateTimeKind.Utc).AddTicks(2730), null, false, null, 4.0, "I liked it a lot ,but the seats were uncomfortable ", new Guid("1930f972-5dbf-4fab-af28-eb3d6e71364b"), null },
                    { new Guid("0ba3071d-a4a6-4e26-8923-3745aff05938"), "MemberThird", new DateTime(2020, 1, 24, 18, 37, 46, 340, DateTimeKind.Utc).AddTicks(2736), null, false, null, 3.0, "Very fancy building,but the plays were old and poorly enacted", new Guid("dee99c29-3a43-491e-b2a4-814bf77dc31f"), null },
                    { new Guid("f124fd00-79f0-4e82-95ec-0afdef72996a"), "MemberSecond", new DateTime(2020, 1, 24, 18, 37, 46, 340, DateTimeKind.Utc).AddTicks(2738), null, false, null, 2.0, "I am very disappointed, not worth the money I spent", new Guid("75cb73a2-86a1-40f0-8e4e-6dd158050c6d"), null },
                    { new Guid("8f40b542-a3f9-447e-ad8a-7d61ad730bb6"), "MemberFirst", new DateTime(2020, 1, 24, 18, 37, 46, 340, DateTimeKind.Utc).AddTicks(2739), null, false, null, 1.0, "I was plesantly surpriced, the actors were very talented", new Guid("50ee9f38-1484-4eb9-800a-39c98d6d8ff3"), null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Author", "CommentText", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "ReviewId", "UserId" },
                values: new object[,]
                {
                    { new Guid("95501766-3607-4a7a-aa13-a81b50bf9385"), "MemberFirst", "Random comment text for firstComment", new DateTime(2020, 1, 24, 18, 37, 46, 340, DateTimeKind.Utc).AddTicks(6521), null, false, null, new Guid("c76ab3f4-e445-4e88-9359-a4a171f97862"), new Guid("4eac031b-26fd-40ba-bacf-603534229f79") },
                    { new Guid("7720a526-fff3-4cc9-a0f9-ea77453a3e63"), "MemberSecond", "Random comment text for Second efin comment", new DateTime(2020, 1, 24, 18, 37, 46, 340, DateTimeKind.Utc).AddTicks(7138), null, false, null, new Guid("03383637-e73b-4005-9b16-9a11168240bc"), new Guid("d73312b2-789c-4569-aadd-d5d9eb411506") },
                    { new Guid("4f17d309-2034-46b2-99f0-40b3e20bb4b9"), "MemberThird", "Random comment text for Third damn comment", new DateTime(2020, 1, 24, 18, 37, 46, 340, DateTimeKind.Utc).AddTicks(7144), null, false, null, new Guid("0ba3071d-a4a6-4e26-8923-3745aff05938"), new Guid("f53f6435-03d8-4567-9edb-48443dd520cc") },
                    { new Guid("3bda46fd-b1d9-45a1-bbe1-aa03f39ed4d9"), "MemberFourth", "Random comment text for Fourth damn comment", new DateTime(2020, 1, 24, 18, 37, 46, 340, DateTimeKind.Utc).AddTicks(7146), null, false, null, new Guid("f124fd00-79f0-4e82-95ec-0afdef72996a"), new Guid("019e9517-da08-47f2-8b33-6b7ccde04aed") },
                    { new Guid("a93cbf15-3302-4bb0-8da8-e7888193b736"), "MemberFifth", "Random comment text for the fifth wholesome comment", new DateTime(2020, 1, 24, 18, 37, 46, 340, DateTimeKind.Utc).AddTicks(7147), null, false, null, new Guid("8f40b542-a3f9-447e-ad8a-7d61ad730bb6"), new Guid("80b8434d-6d7e-42f5-a499-cdb3a635bb0e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bans_UserId",
                table: "Bans",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReviewId",
                table: "Comments",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TheatreId",
                table: "Reviews",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Theatres_UserId",
                table: "Theatres",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Theatres");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}
