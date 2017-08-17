using AutoMapper;

using System;
using System.Collections.Generic;

namespace BLL.Mappers
{
    using BLL.Interfacies.Entities;

    using DAL.Interfacies.DTO;

    public static class BllEntityMapper<TypeTo,TypeFrom> 
        where TypeTo:class
        where TypeFrom: class

    {
        static BllEntityMapper()
        {
            Mapper.CreateMap<BLLUser, DalUser>();
            Mapper.CreateMap<BLLRole, DalRole>();
            Mapper.CreateMap<BLLMessage, DalMessage>();
            Mapper.CreateMap<BLLAuthor, DalAuthor>();
            Mapper.CreateMap<BLLBook, DalBook>();
            Mapper.CreateMap<BLLGenre, DalGenre>();
            Mapper.CreateMap<BLLGrade, DalGrade>();
            Mapper.CreateMap<BLLFriendship, DalFriendship>();

            Mapper.CreateMap<DalUser, BLLUser>();
            Mapper.CreateMap<DalRole, BLLRole>();
            Mapper.CreateMap<DalMessage, BLLMessage>();
            Mapper.CreateMap<DalAuthor, BLLAuthor>();
            Mapper.CreateMap<DalBook, BLLBook>();
            Mapper.CreateMap<DalGenre, BLLGenre>();
            Mapper.CreateMap<DalGrade, BLLGrade>();
            Mapper.CreateMap<DalFriendship, BLLFriendship>();
            Mapper.AssertConfigurationIsValid();
        }
       
        public static TypeTo Map(TypeFrom itemFrom)
        {
            return Mapper.Map<TypeFrom, TypeTo>(itemFrom);
        }

        public static IEnumerable<TypeTo> MapList(IEnumerable<TypeFrom> listFrom)
        {
            return Mapper.Map<IEnumerable<TypeFrom>, IEnumerable<TypeTo>>(listFrom);
        }
        
    }
}
