using HomeTheatre.Data.DbModels;
using HomeTheatre.Data.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.Seeder
{
    public static class ModelSeeder
    {
        public static void Seeder(this ModelBuilder builder)
        {
            #region UserGuid
            Guid AdminRoleGuid = Guid.NewGuid();
            Guid MemberRoleGuid = Guid.NewGuid();
            Guid AdminId = Guid.NewGuid();
            Guid MemberId01 = Guid.NewGuid();
            Guid MemberId02 = Guid.NewGuid();
            Guid MemberId03 = Guid.NewGuid();
            Guid MemberId04 = Guid.NewGuid();
            Guid MemberId05 = Guid.NewGuid();
            #endregion
            #region TheatreGuid
            Guid theatreId01 = Guid.NewGuid();
            Guid theatreId02 = Guid.NewGuid();
            Guid theatreId03 = Guid.NewGuid();
            Guid theatreId04 = Guid.NewGuid();
            Guid theatreId05 = Guid.NewGuid();
            Guid theatreId06 = Guid.NewGuid();
            Guid theatreId07 = Guid.NewGuid();
            Guid theatreId08 = Guid.NewGuid();
            Guid theatreId09 = Guid.NewGuid();
            Guid theatreId10 = Guid.NewGuid();
            #endregion
            #region CommentGuid
            Guid commentId01 = Guid.NewGuid();
            Guid commentId02 = Guid.NewGuid();
            Guid commentId03 = Guid.NewGuid();
            Guid commentId04 = Guid.NewGuid();
            Guid commentId05 = Guid.NewGuid();
            #endregion
            #region ReviewGuid
            Guid reviewId01 = Guid.NewGuid();
            Guid reviewId02 = Guid.NewGuid();
            Guid reviewId03 = Guid.NewGuid();
            Guid reviewId04 = Guid.NewGuid();
            Guid reviewId05 = Guid.NewGuid();
            #endregion
            ////
            #region SeedAdmin
            builder.Entity<Role>().HasData(
                new Role { Id = AdminRoleGuid, Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new Role { Id = MemberRoleGuid, Name = "Member", NormalizedName = "MEMBER" }
                );

            User AdminUser00 = new User
            {
                Id = AdminId,
                UserName = "AdminFirst",
                PasswordHash = PasswordHasher.GetStringSha256Hash("AdminFirst"),
                NormalizedUserName = "ADMINFIRST",
                Email = "AdminFirst@gmail.com",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true,
            };

            builder.Entity<User>().HasData(AdminUser00);

            builder.Entity<IdentityUserRole<Guid>>().HasData(
               new IdentityUserRole<Guid>
               {
                   RoleId = AdminRoleGuid,
                   UserId = AdminUser00.Id
               });
            #endregion
            # region UserSeed
            User memberUser01 = new User
            {
                Id = MemberId01,
                UserName = "MemberFirst",
                PasswordHash = PasswordHasher.GetStringSha256Hash("MemberFirst"),
                NormalizedUserName = "MEMBERFIRST",
                Email = "MemberFirst@gmail.com",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true
            };
            User memberUser02 = new User
            {
                Id = MemberId02,
                UserName = "MemberSecond",
                PasswordHash = PasswordHasher.GetStringSha256Hash("MemberSecond"),
                NormalizedUserName = "MEMBERSECOND",
                Email = "MemberSecond@gmail.com",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true
            };
            User memberUser03 = new User
            {
                Id = MemberId03,
                UserName = "MemberThird",
                PasswordHash = PasswordHasher.GetStringSha256Hash("MemberThird"),
                NormalizedUserName = "MEMBERTHIRD",
                Email = "MemberThird@gmail.com",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true
            };
            User memberUser04 = new User
            {
                Id = MemberId04,
                UserName = "MemberFourth",
                PasswordHash = PasswordHasher.GetStringSha256Hash("MemberFourth"),
                NormalizedUserName = "MEMBERFOURTH",
                Email = "MemberFourth@gmail.com",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true
            };
            User memberUser05 = new User
            {
                Id = MemberId05,
                UserName = "MemberFifth",
                PasswordHash = PasswordHasher.GetStringSha256Hash("MemberFifth"),
                NormalizedUserName = "MEMBERFIRST",
                Email = "MemberFifth@gmail.com",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true
            };
            builder.Entity<User>().HasData(memberUser01, memberUser02, memberUser03, memberUser04, memberUser05);

            builder.Entity<IdentityUserRole<Guid>>().HasData(
               new IdentityUserRole<Guid>
               {
                   RoleId = MemberRoleGuid,
                   UserId = memberUser01.Id,

               });
            #endregion
            #region SeedTheatres
            Theatre theatre01 = new Theatre
            {
                Id = theatreId01,
                Name = "FirstTheatre",
                AboutInfo = "A Cultural Theatre for those with too much time on their hands",
                Location = "7292 Dictum Av.San Antonio MI 47096",
                Phone = "0896453401",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre02 = new Theatre
            {
                Id = theatreId02,
                Name = "SecondTheatre",
                AboutInfo = "A Rather nasty Theatre with rats everywhere even in the popcorn",
                Location = "191-103 Integer Rd.Corona New Mexico 08219",
                Phone = "0896453402",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre03 = new Theatre
            {
                Id = theatreId03,
                Name = "ThirdTheatre",
                AboutInfo = "Same as the second Theatre but with character",
                Location = "606-3727 Ullamcorper. StreetRoseville NH 11523",
                Phone = "0896453433",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre04 = new Theatre
            {
                Id = theatreId04,
                Name = "FourthTheatre",
                AboutInfo = "The door man is very polite,otherwise the Theatre is rather unpleasant",
                Location = "Frederick Nebraska 20620",
                Phone = "089645344",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre05 = new Theatre
            {
                Id = theatreId05,
                Name = "FifthTheatre",
                AboutInfo = "This Theatre has stood for 200 years and it shows then you enter",
                Location = "Mankato Mississippi 96522",
                Phone = "0896453455",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre06 = new Theatre
            {
                Id = theatreId06,
                Name = "SixthTheatre",
                AboutInfo = "A Theatre for people with a finer taste then the average mortal man",
                Location = "Chaika str ,Varna city",
                Phone = "0896453466",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre07 = new Theatre
            {
                Id = theatreId07,
                Name = "SeventhTheatre",
                AboutInfo = "There has never existed a fancier Theatre, the curtains are made o woven gold",
                Location = "TheOneTrueStreet str, BestCity city",
                Phone = "0896453477",
                CreatedOn = DateTime.UtcNow,

            };


            Theatre theatre08 = new Theatre
            {
                Id = theatreId08,
                Name = "EigthTheatre",
                AboutInfo = "Same as the seventh Theatre but yet ,somehow the opposite",
                Location = "Gospodinovzi str, Sofia city",
                Phone = "0896453488",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre09 = new Theatre
            {
                Id = theatreId09,
                Name = "NinthTheatre",
                AboutInfo = "This Theatre is very expensive,not well suited to poor people",
                Location = "Bullevard 27 str, Sofia city",
                Phone = "0896453499",
                CreatedOn = DateTime.UtcNow,

            };
            Theatre theatre10 = new Theatre
            {
                Id = theatreId10,
                Name = "TenthTheatre",
                AboutInfo = "A ghetto Theatre which has the single purpose of getting robbed",
                Location = "Fifth and avenue str ,Cansas city",
                Phone = "0896453410",
                CreatedOn = DateTime.UtcNow,

            };
            builder.Entity<Theatre>().HasData(theatre01, theatre02, theatre03, theatre04, theatre05, theatre06, theatre07, theatre08, theatre09, theatre10);
            #endregion
            #region SeedReview
            var review01 = new Review
            {
                Id = reviewId01,
                Author = memberUser05.UserName,
                Rating = 5,
                TheatreId = theatreId01,
                CreatedOn = DateTime.UtcNow
            };
            var review02 = new Review
            {
                Id = reviewId02,
                Author = memberUser04.UserName,
                Rating = 4,
                TheatreId = theatreId02,
                CreatedOn = DateTime.UtcNow
            };
            var review03 = new Review
            {
                Id = reviewId03,
                Author = memberUser03.UserName,
                Rating = 3,
                TheatreId = theatreId03,
                CreatedOn = DateTime.UtcNow
            };
            var review04 = new Review
            {
                Id = reviewId04,
                Author = memberUser02.UserName,
                Rating = 2,
                TheatreId = theatreId04,
                CreatedOn = DateTime.UtcNow
            };
            var review05 = new Review
            {
                Id = reviewId05,
                Author = memberUser01.UserName,
                Rating = 1,
                TheatreId = theatreId05,
                CreatedOn = DateTime.UtcNow
            };
            builder.Entity<Review>().HasData(review01, review02, review03, review04, review05);
            #endregion
            #region CommentSeed
            var comment01 = new Comment
            {
                Id = commentId01,
                CommentText = "Random comment text for firstComment",
                Author = memberUser01.UserName,
                ReviewId = reviewId01,
                UserId = MemberId01,
                CreatedOn = DateTime.UtcNow
            };
            var comment02 = new Comment
            {
                Id = commentId02,
                CommentText = "Random comment text for Second efin comment",
                Author = memberUser02.UserName,
                ReviewId = reviewId02,
                UserId = MemberId02,
                CreatedOn = DateTime.UtcNow
            };
            var comment03 = new Comment
            {
                Id = commentId03,
                CommentText = "Random comment text for Third damn comment",
                Author = memberUser03.UserName,
                ReviewId = reviewId03,
                UserId = MemberId03,
                CreatedOn = DateTime.UtcNow
            };
            var comment04 = new Comment
            {
                Id = commentId04,
                CommentText = "Random comment text for Fourth damn comment",
                Author = memberUser04.UserName,
                ReviewId = reviewId04,
                UserId = MemberId04,
                CreatedOn = DateTime.UtcNow
            };
            var comment05 = new Comment
            {
                Id = commentId05,
                CommentText = "Random comment text for the fifth wholesome comment",
                Author = memberUser05.UserName,
                ReviewId = reviewId05,
                UserId = MemberId05,
                CreatedOn = DateTime.UtcNow
            };
            builder.Entity<Comment>().HasData(comment01, comment02, comment03, comment04, comment05);

            #endregion

        }
    }
}
