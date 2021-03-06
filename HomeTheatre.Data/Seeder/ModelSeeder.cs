﻿using HomeTheatre.Data.DbModels;
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
            Guid theatreId11 = Guid.NewGuid();
            Guid theatreId12 = Guid.NewGuid();
            Guid theatreId13 = Guid.NewGuid();
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
            Guid reviewId06 = Guid.NewGuid();
            Guid reviewId07 = Guid.NewGuid();
            Guid reviewId08 = Guid.NewGuid();
            Guid reviewId09 = Guid.NewGuid();
            Guid reviewId10 = Guid.NewGuid();
            Guid reviewId11 = Guid.NewGuid();
            Guid reviewId12 = Guid.NewGuid();
            Guid reviewId13 = Guid.NewGuid();
            #endregion
            ////
            #region Seed Role and Admin
            builder.Entity<Role>().HasData(
                new Role { Id = AdminRoleGuid, Name = "Administrator", NormalizedName = "ADMINISTRATOR" },
                new Role { Id = MemberRoleGuid, Name = "Member", NormalizedName = "MEMBER" }
                );

            User AdminUser = new User
            {
                Id = AdminId,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@gmail.com",
                Name = "Martin",
                PhoneNumber="0895488533",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true,
                RoleName = "Administrator",
                SecurityStamp="*JUTF774DBHJIUUT"
                
            };
            var hashePass = new PasswordHasher<User>().HashPassword(AdminUser, "Admin");
            AdminUser.PasswordHash = hashePass;

            builder.Entity<User>().HasData(AdminUser);

            builder.Entity<IdentityUserRole<Guid>>().HasData(
               new IdentityUserRole<Guid>
               {
                   RoleId = AdminRoleGuid,
                   UserId = AdminUser.Id
               });
            #endregion
            # region UserSeed
            User memberUser01 = new User
            {
                Id = MemberId01,
                UserName = "MemberFirst",
                NormalizedUserName = "MEMBERFIRST",
                Name = "Gosho",
                Email = "FirstMember@gmail.com",
                PhoneNumber = "0987453355",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true,
                RoleName = "Member",
                SecurityStamp="HHTF565DGH87NHFT"

            };
            var hashePass01 = new PasswordHasher<User>().HashPassword(memberUser01, "MemberFirst");
            memberUser01.PasswordHash = hashePass01;
            User memberUser02 = new User
            {
                Id = MemberId02,
                UserName = "MemberSecond",
                PasswordHash = PasswordHasher.GetStringSha256Hash("MemberSecond"),
                PhoneNumber = "0987453345",
                Name = "Pesho",
                NormalizedUserName = "MEMBERSECOND",
                Email = "SecondMember@gmail.com",
                CreatedOn = DateTime.UtcNow,
                RoleName = "Member",
                LockoutEnabled = true,
                SecurityStamp = "JKIVDR4H7DJSKH"
            };
            var hashePass02 = new PasswordHasher<User>().HashPassword(memberUser02, "MemberSecond");
            memberUser02.PasswordHash = hashePass02;


            User memberUser03 = new User
            {
                Id = MemberId03,
                UserName = "MemberThird",
                PasswordHash = PasswordHasher.GetStringSha256Hash("MemberThird"),
                PhoneNumber = "0987453985",
                Name = "Minka",
                NormalizedUserName = "MEMBERTHIRD",
                Email = "ThirdMember@gmail.com",
                RoleName = "Member",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true,
                SecurityStamp = "DA76A4HJ534UF7445T5E"

            };
            var hashePass03 = new PasswordHasher<User>().HashPassword(memberUser03, "MemberThird");
            memberUser03.PasswordHash = hashePass03;

            User memberUser04 = new User
            {
                Id = MemberId04,
                UserName = "MemberFourth",
                PhoneNumber = "0987453825",
                PasswordHash = PasswordHasher.GetStringSha256Hash("MemberFourth"),
                Name = "Ivancho",
                NormalizedUserName = "MEMBERFOURTH",
                Email = "FourthMember@gmail.com",
                RoleName = "Member",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true,
                SecurityStamp = "UDIADFG564433HGS"

            };
            var hashePass04 = new PasswordHasher<User>().HashPassword(memberUser04, "MemberFourth");
            memberUser04.PasswordHash = hashePass04;

            User memberUser05 = new User
            {
                Id = MemberId05,
                UserName = "MemberFifth",
                PasswordHash = PasswordHasher.GetStringSha256Hash("MemberFifth"),
                Name = "Bai Ganio",
                PhoneNumber = "0987482355",
                NormalizedUserName = "MEMBERFIFTH",
                Email = "FifthMember@gmail.com",
                RoleName = "Member",
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = true,
                SecurityStamp = "DOHASIUDG7637242G5YG"

            };
            var hashePass05 = new PasswordHasher<User>().HashPassword(memberUser05, "MemberFifth");
            memberUser05.PasswordHash = hashePass05;

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
                ImagePath = "/assets/images/Italian.jpg",
                Image = "Italian.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            Theatre theatre02 = new Theatre
            {
                Id = theatreId02,
                Name = "SecondTheatre",
                AboutInfo = "A Rather nasty Theatre with rats everywhere even in the popcorn",
                Location = "191-103 Integer Rd.Corona New Mexico 08219",
                ImagePath = "/assets/images/Depth.jpg",
                Image = "Depth.jpg",
                Phone = "0896453402",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre03 = new Theatre
            {
                Id = theatreId03,
                Name = "ThirdTheatre",
                AboutInfo = "Same as the second Theatre but with character",
                Location = "606-3727 Ullamcorper. StreetRoseville NH 11523",
                ImagePath = "/assets/images/LightHouse.jpg",
                Image = "LightHouse.jpg",
                Phone = "0896453433",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre04 = new Theatre
            {
                Id = theatreId04,
                Name = "FourthTheatre",
                AboutInfo = "The door man is very polite,otherwise the Theatre is rather unpleasant",
                Location = "Frederick Nebraska 20620",
                ImagePath = "/assets/images/ThatsAllFolks.jpg",
                Image = "ThatsAllFolks.jpg",
                Phone = "089645344",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre05 = new Theatre
            {
                Id = theatreId05,
                Name = "FifthTheatre",
                AboutInfo = "This Theatre has stood for 200 years and it shows then you enter",
                Location = "Mankato Mississippi 96522",
                ImagePath = "/assets/images/YellowTheatre.jpg",
                Image = "YellowTheatre.jpg",
                Phone = "0896453455",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre06 = new Theatre
            {
                Id = theatreId06,
                Name = "SixthTheatre",
                AboutInfo = "A Theatre for people with a finer taste then the average mortal man",
                Location = "Chaika str ,Varna city",
                ImagePath = "/assets/images/CathedralTheatre.jpg",
                Image = "CathedralTheatre.jpg",
                Phone = "0896453466",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre07 = new Theatre
            {
                Id = theatreId07,
                Name = "SeventhTheatre",
                AboutInfo = "There has never existed a fancier Theatre, the curtains are made o woven gold",
                Location = "TheOneTrueStreet str, BestCity city",
                ImagePath = "/assets/images/ComfyHomeCinema.jpg",
                Image = "ComfyHomeCinema.jpg",
                Phone = "0896453477",
                CreatedOn = DateTime.UtcNow,

            };


            Theatre theatre08 = new Theatre
            {
                Id = theatreId08,
                Name = "EigthTheatre",
                AboutInfo = "Same as the seventh Theatre but yet ,somehow the opposite",
                Location = "Gospodinovzi str, Sofia city",
                ImagePath = "/assets/images/Foiey.jpg",
                Image = "Foiey.jpg",
                Phone = "0896453488",
                CreatedOn = DateTime.UtcNow,

            };

            Theatre theatre09 = new Theatre
            {
                Id = theatreId09,
                Name = "NinthTheatre",
                AboutInfo = "This Theatre is very expensive,not well suited to poor people",
                Location = "Bullevard 27 str, Sofia city",
                ImagePath = "/assets/images/Old.jpg",
                Image = "Old.jpg",
                Phone = "0896453499",
                CreatedOn = DateTime.UtcNow,

            };
            Theatre theatre10 = new Theatre
            {
                Id = theatreId10,
                Name = "TenthTheatre",
                AboutInfo = "A ghetto Theatre which has the single purpose of getting robbed",
                Location = "Fifth and avenue str ,Cansas city",
                ImagePath = "/assets/images/Wide.jpg",
                Image = "Wide.jpg",
                Phone = "0896453410",
                CreatedOn = DateTime.UtcNow,
                
            };
            Theatre theatre11 = new Theatre
            {
                Id = theatreId11,
                Name = "EleventhTheatre",
                AboutInfo = "A den of scum and villany",
                Location = "Slanchaka",
                Phone = "0986553654",
                ImagePath = "/assets/images/Italian.jpg",
                Image = "Italian.jpg",
                CreatedOn = DateTime.UtcNow,
            };

            Theatre theatre12 = new Theatre
            {
                Id = theatreId12,
                Name = "TwelthTheatre",
                AboutInfo = "A regular theatre for average people",
                Location = "Sofia",
                Phone = "0986556953",
                ImagePath = "/assets/images/Italian.jpg",
                Image = "Italian.jpg",
                CreatedOn = DateTime.UtcNow,
            };
            Theatre theatre13 = new Theatre
            {
                Id = theatreId13,
                Name = "ThirteenthTheatre",
                AboutInfo = "An unlucky place ,maybe because it is called ThirteenthTheatre",
                Location = "UnluckyPlace",
                Phone = "09877364253",
                ImagePath = "/assets/images/Italian.jpg",
                Image = "Italian.jpg",
                CreatedOn = DateTime.UtcNow,
            };
            builder.Entity<Theatre>().HasData(theatre01, theatre02, theatre03, theatre04, theatre05, theatre06, theatre07, theatre08, theatre09, theatre10, theatre11, theatre12, theatre13);
            #endregion
            #region SeedReview
            var review01 = new Review
            {
                Id = reviewId01,
                Author = memberUser05.UserName,
                ReviewText = "This Theatre is halfway decent,but too expensive",
                Rating = 5,
                TheatreId = theatreId01,
                CreatedOn = DateTime.UtcNow
            };
            var review02 = new Review
            {
                Id = reviewId02,
                Author = memberUser04.UserName,
                ReviewText = "I liked it a lot ,but the seats were uncomfortable ",
                Rating = 4,
                TheatreId = theatreId02,
                CreatedOn = DateTime.UtcNow
            };
            var review03 = new Review
            {
                Id = reviewId03,
                Author = memberUser03.UserName,
                ReviewText = "Very fancy building,but the plays were old and poorly enacted",
                Rating = 3,
                TheatreId = theatreId03,
                CreatedOn = DateTime.UtcNow
            };
            var review04 = new Review
            {
                Id = reviewId04,
                Author = memberUser02.UserName,
                ReviewText = "I am very disappointed, not worth the money I spent",
                Rating = 2,
                TheatreId = theatreId04,
                CreatedOn = DateTime.UtcNow
            };
            var review05 = new Review
            {
                Id = reviewId05,
                Author = memberUser01.UserName,
                ReviewText = "I was plesantly surpriced, the actors were very talented",
                Rating = 1,
                TheatreId = theatreId05,
                CreatedOn = DateTime.UtcNow
            };
            var review06 = new Review
            {
                Id = reviewId06,
                Author = memberUser01.UserName,
                ReviewText = "The Theatre was not good",
                Rating = 4,
                TheatreId = theatreId06,
                CreatedOn = DateTime.UtcNow
            };
            var review07 = new Review
            {
                Id = reviewId07,
                Author = memberUser02.UserName,
                ReviewText = "It was a pleasant experience , would do it again",
                Rating = 4,
                TheatreId = theatreId07,
                CreatedOn = DateTime.UtcNow
            };
            var review08 = new Review
            {
                Id = reviewId08,
                Author = memberUser03.UserName,
                ReviewText = "I was plesantly surpriced, the actors were very talented",
                Rating = 4,
                TheatreId = theatreId08,
                CreatedOn = DateTime.UtcNow
            };
            var review09 = new Review
            {
                Id = reviewId09,
                Author = memberUser04.UserName,
                ReviewText = "I was plesantly surpriced, the actors were very talented",
                Rating = 3,
                TheatreId = theatreId09,
                CreatedOn = DateTime.UtcNow
            };
            var review10 = new Review
            {
                Id = reviewId10,
                Author = memberUser05.UserName,
                ReviewText = "I was plesantly surpriced, the actors were very talented",
                Rating = 5,
                TheatreId = theatreId10,
                CreatedOn = DateTime.UtcNow
            };
            var review11 = new Review
            {
                Id = reviewId11,
                Author = memberUser01.UserName,
                ReviewText = "I Have Made a Review For this theatre ",
                Rating = 2,
                TheatreId = theatreId11,
                CreatedOn = DateTime.UtcNow
            };
            var review12 = new Review
            {
                Id = reviewId12,
                Author = memberUser01.UserName,
                ReviewText = "Amazing theatre would go again ",
                Rating = 2,
                TheatreId = theatreId12,
                CreatedOn = DateTime.UtcNow
            };
            var review13 = new Review
            {
                Id = reviewId13,
                Author = memberUser03.UserName,
                ReviewText = "Meh it was very meh. ",
                Rating = 2,
                TheatreId = theatreId13,
                CreatedOn = DateTime.UtcNow
            };
          
            builder.Entity<Review>().HasData(review01, review02, review03, review04, review05,review06,review07,review08,review09,review10, review11, review12, review13);

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
