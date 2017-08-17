namespace MvcPL
{
    using System;
    using System.Linq;

    using AutoMapper;

    using BLL.Interfacies.Entities;

    using MvcPL.Models;

    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            #region User
            Mapper.CreateMap<BLLUser, UserIndexModel>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.Name, x => x.MapFrom(y => y.FirstName+" "+y.LastName))
                .ForMember(dest => dest.Location, x => x.MapFrom(y => y.LocationCoutry+", "+y.LocationCity))
                .ForMember(dest => dest.BirthDate, x => x.MapFrom(y => y.BirthDate));            

            Mapper.CreateMap<BLLUser, UserDetailsModel>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.Name, x => x.MapFrom(y => y.FirstName + " " + y.LastName))
                .ForMember(dest => dest.LocationCoutry, x => x.MapFrom(y => y.LocationCoutry))
                .ForMember(dest => dest.LocationCity, x => x.MapFrom(y => y.LocationCity))
                .ForMember(dest => dest.BirthDate, x => x.MapFrom(y => y.BirthDate))
                .ForMember(dest => dest.Description, x => x.MapFrom(y => y.Description))
                .ForMember(dest => dest.Grades, x => x.MapFrom(y => y.Grades.Reverse().Take(3)))
                .ForMember(dest => dest.Friendships, x => x.MapFrom(y => y.Friendships))
                ;

            Mapper.CreateMap<BLLUser, UserCreateModel>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.BirthDate, x => x.MapFrom(y => y.BirthDate))
                .ForMember(dest => dest.FirstName, x => x.MapFrom(y => y.FirstName))
                .ForMember(dest => dest.LastName, x => x.MapFrom(y => y.LastName))
                .ForMember(dest => dest.Description, x => x.MapFrom(y => y.Description))
                .ForMember(dest => dest.LocationCity, x => x.MapFrom(y => y.LocationCity))
                .ForMember(dest => dest.LocationCoutry, x => x.MapFrom(y => y.LocationCoutry))
                .ForMember(dest => dest.UserName, x => x.MapFrom(y => y.UserName))
                .ForMember(dest => dest.Email, x => x.MapFrom(y => y.Email))
                .ForMember(dest => dest.Password, x => x.MapFrom(y => y.Password))
                .ForMember(dest => dest.RoleId, x => x.MapFrom(y => y.RoleId))
                .ForMember(dest => dest.PasswordConfirm, dest => dest.Ignore())
                .ForMember(dest => dest.IsCreatingNow, dest => dest.Ignore());

            Mapper.CreateMap<UserCreateModel, BLLUser>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.FirstName, x => x.MapFrom(y => y.FirstName))
                .ForMember(dest => dest.LastName, x => x.MapFrom(y => y.LastName))
                .ForMember(dest => dest.Description, x => x.MapFrom(y => y.Description))
                .ForMember(dest => dest.RoleId, x => x.MapFrom(y => y.RoleId))
                .ForMember(dest => dest.Role, y => y.Ignore())
                .ForMember(dest => dest.BirthDate, x => x.MapFrom(y => y.BirthDate))
                .ForMember(dest => dest.UserName, x => x.MapFrom(y => y.UserName))
                .ForMember(dest => dest.Email, x => x.MapFrom(y => y.Email))
                .ForMember(dest => dest.Password, x => x.MapFrom(y => y.Password))
                .ForMember(dest => dest.Messages, y => y.Ignore())
                .ForMember(dest => dest.Grades, y => y.Ignore())
                .ForMember(dest => dest.Friendships, y => y.Ignore())
                .ForMember(dest => dest.LocationCity, x => x.MapFrom(y => y.LocationCity))
                .ForMember(dest => dest.LocationCoutry, x => x.MapFrom(y => y.LocationCoutry))
                .ForSourceMember(src => src.PasswordConfirm, x => x.Ignore())
                .ForSourceMember(src => src.IsCreatingNow, x => x.Ignore())
                .AfterMap((src, dest) =>
                {
                    if (src.BirthDate == DateTime.MinValue)
                    {
                        dest.BirthDate = null;
                    }
                    else
                    {
                        dest.BirthDate = src.BirthDate;
                    }
                })
                ;

            Mapper.CreateMap<UserLoginModel, BLLUser>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.FirstName, y => y.Ignore())
                .ForMember(dest => dest.LastName, y => y.Ignore())
                .ForMember(dest => dest.Description, y => y.Ignore())
                .ForMember(dest => dest.RoleId, y => y.Ignore())
                .ForMember(dest => dest.Role, y => y.Ignore())
                .ForMember(dest => dest.BirthDate, y => y.Ignore())
                .ForMember(dest => dest.UserName, x => x.MapFrom(y => y.UserName))
                .ForMember(dest => dest.Email, y => y.Ignore())
                .ForMember(dest => dest.Password, x => x.MapFrom(y => y.Password))
                .ForMember(dest => dest.Messages, y => y.Ignore())
                .ForMember(dest => dest.Grades, y => y.Ignore())
                .ForMember(dest => dest.Friendships, y => y.Ignore())
                .ForMember(dest => dest.LocationCity, y => y.Ignore())
                .ForMember(dest => dest.LocationCoutry, y => y.Ignore())
                ;

            Mapper.CreateMap<UserRegisterModel, BLLUser>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.FirstName, y => y.Ignore())
                .ForMember(dest => dest.LastName, y => y.Ignore())
                .ForMember(dest => dest.Description, y => y.Ignore())
                .ForMember(dest => dest.RoleId, x => x.MapFrom(y => y.RoleId))
                .ForMember(dest => dest.Role, y => y.Ignore())
                .ForMember(dest => dest.BirthDate, y => y.Ignore())
                .ForMember(dest => dest.UserName, x => x.MapFrom(y => y.UserName))
                .ForMember(dest => dest.Email, y => y.Ignore())
                .ForMember(dest => dest.Password, x => x.MapFrom(y => y.Password))
                .ForMember(dest => dest.Messages, y => y.Ignore())
                .ForMember(dest => dest.Grades, y => y.Ignore())
                .ForMember(dest => dest.Friendships, y => y.Ignore())
                .ForMember(dest => dest.LocationCity, y => y.Ignore())
                .ForMember(dest => dest.LocationCoutry, y => y.Ignore())
                .ForSourceMember(src => src.ConfirmPassword, x => x.Ignore())
                ;

            #endregion


            #region BLL=>UI entities

            Mapper.CreateMap<BLLUser, UIUser>();
            Mapper.CreateMap<BLLRole, UIRole>();
            Mapper.CreateMap<BLLMessage, UIMessage>();
            Mapper.CreateMap<BLLAuthor, UIAuthor>();
            Mapper.CreateMap<BLLBook, UIBook>();
            Mapper.CreateMap<BLLGenre, UIGenre>();
            Mapper.CreateMap<BLLGrade, UIGrade>();
            Mapper.CreateMap<BLLFriendship, UIFriendship>();

            Mapper.CreateMap<UIUser, BLLUser>();
            Mapper.CreateMap<UIRole, BLLRole>();
            Mapper.CreateMap<UIMessage, BLLMessage>();
            Mapper.CreateMap<UIAuthor, BLLAuthor>();
            Mapper.CreateMap<UIBook, BLLBook>();
            Mapper.CreateMap<UIGenre, BLLGenre>();
            Mapper.CreateMap<UIGrade, BLLGrade>();
            Mapper.CreateMap<UIFriendship, BLLFriendship>();
            Mapper.AssertConfigurationIsValid();
            #endregion

            #region Authors
            Mapper.CreateMap<BLLAuthor, AuthorForBookModel>()
               .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
               .ForMember(dest => dest.FullName, x => x.MapFrom(y => y.FirstName + " " + y.LastName))
               .ForMember(dest => dest.LocationCoutry, x => x.MapFrom(y => y.LocationCoutry));


            Mapper.CreateMap<BLLAuthor, AuthorIndexModel>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.FullName, x => x.MapFrom(y => y.FirstName + " " + y.LastName))
                .ForMember(dest => dest.LocationCoutry, x => x.MapFrom(y => y.LocationCoutry))
                .ForMember(dest => dest.BirthDate, x => x.MapFrom(y => y.BirthDate))
                .ForMember(dest => dest.DeathDate, x => x.MapFrom(y => y.DeathDate));
                        

            Mapper.CreateMap<BLLAuthor, AuthorCreateModel>()
               .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
               .ForMember(dest => dest.FirstName, x => x.MapFrom(y => y.FirstName))
               .ForMember(dest => dest.LastName, x => x.MapFrom(y => y.LastName))
               .ForMember(dest => dest.LocationCoutry, x => x.MapFrom(y => y.LocationCoutry))
               .ForMember(dest => dest.BirthDate, x => x.MapFrom(y => y.BirthDate))
               .ForMember(dest => dest.DeathDate, x => x.MapFrom(y => y.DeathDate))
               .ForMember(dest => dest.Books, x => x.Ignore())
               .ForMember(dest => dest.IsCreatingNow, x => x.Ignore());

            Mapper.CreateMap<AuthorCreateModel, BLLAuthor>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.FirstName, x => x.MapFrom(y => y.FirstName))
                .ForMember(dest => dest.LastName, x => x.MapFrom(y => y.LastName))
                .ForMember(dest => dest.LocationCoutry, x => x.MapFrom(y => y.LocationCoutry))
                .ForMember(dest => dest.BirthDate, x => x.MapFrom(y => y.BirthDate))
                .ForMember(dest => dest.DeathDate, x => x.MapFrom(y => y.DeathDate))
                .ForMember(dest => dest.Books, x => x.Ignore())
                .ForSourceMember(src => src.IsCreatingNow, x => x.Ignore())
                .AfterMap((src, dest) =>
                {
                    if (src.BirthDate == DateTime.MinValue)
                    {
                        dest.BirthDate = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        dest.BirthDate = src.BirthDate;
                    }

                    if (src.DeathDate == DateTime.MinValue)
                    {
                        dest.DeathDate = new DateTime(1945, 1, 1);
                    }
                    else
                    {
                        dest.DeathDate = src.DeathDate;
                    }
                });
            #endregion

            #region books

            Mapper.CreateMap<BLLBook, BookIndexModel>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.AuthorId, x => x.MapFrom(y => y.AuthorId))
                .ForMember(dest => dest.Name, x => x.MapFrom(y => y.Name))
                .ForMember(dest => dest.Author, x => x.MapFrom(y => y.Author));                 
                //.ForMember(dest => dest.Author, src => src.Ignore());

            Mapper.CreateMap<BLLBook, BookCreateModel>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.AuthorId, x => x.MapFrom(y => y.AuthorId))
                .ForMember(dest => dest.Name, x => x.MapFrom(y => y.Name))
                .ForMember(dest => dest.Genres, x => x.MapFrom(y => y.Genres))
                .ForMember(dest => dest.ListOfAuthors, dest => dest.Ignore())
                .ForMember(dest => dest.IsCreatingNow, dest => dest.Ignore());            

            Mapper.CreateMap<BookCreateModel, BLLBook>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.Name, x => x.MapFrom(y => y.Name))
                .ForMember(dest => dest.AuthorId, x => x.MapFrom(y => y.AuthorId))
                .ForMember(dest => dest.Author, x => x.Ignore())
                .ForMember(dest => dest.Author, x => x.Ignore())
                .ForMember(dest => dest.Genres, x => x.MapFrom(y => y.Genres))
                .ForMember(dest => dest.Grades, x => x.Ignore())
                .ForSourceMember(src => src.ListOfAuthors, x => x.Ignore())
                .ForSourceMember(src => src.IsCreatingNow, x => x.Ignore());
            #endregion

            #region grades

            Mapper.CreateMap<BLLGrade, GradeCreateModel>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.AppreiserId, x => x.MapFrom(y => y.AppreiserId))
                .ForMember(dest => dest.Appreiser, x => x.MapFrom(y => y.Appreiser))
                .ForMember(dest => dest.BookId, x => x.MapFrom(y => y.BookId))
                .ForMember(dest => dest.Book, x => x.MapFrom(y => y.Book))
                .ForMember(dest => dest.GradeValue, x => x.MapFrom(y => y.GradeValue))
                .ForMember(dest => dest.Comment, x => x.MapFrom(y => y.Comment))
                .ForMember(dest => dest.IsBookHadRead, x => x.MapFrom(y => y.IsBookHadRead))
                .ForMember(dest => dest.BookId, x => x.MapFrom(y => y.BookId))
                .ForMember(dest => dest.IsCreatingNow, dest => dest.Ignore());

            Mapper.CreateMap<GradeCreateModel, BLLGrade>()
                .ForMember(dest => dest.Id, x => x.MapFrom(y => y.Id))
                .ForMember(dest => dest.AppreiserId, x => x.MapFrom(y => y.AppreiserId))
                .ForMember(dest => dest.Appreiser, x => x.MapFrom(y => y.Appreiser))
                .ForMember(dest => dest.BookId, x => x.MapFrom(y => y.BookId))
                .ForMember(dest => dest.Book, x => x.MapFrom(y => y.Book))
                .ForMember(dest => dest.GradeValue, x => x.MapFrom(y => y.GradeValue))
                .ForMember(dest => dest.Comment, x => x.MapFrom(y => y.Comment))
                .ForMember(dest => dest.IsBookHadRead, x => x.MapFrom(y => y.IsBookHadRead))
                .ForMember(dest => dest.BookId, x => x.MapFrom(y => y.BookId))
                .ForSourceMember(src => src.IsCreatingNow, x => x.Ignore());

            #endregion

            

        }
    }
}