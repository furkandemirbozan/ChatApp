using AutoMapper;
using ChatApp.Services.Models.Group;
using ChatApp.Services.Models.Message;
using ChatApp.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Services.Mapping
{
    public class MyProfiles:Profile
    {
        public MyProfiles()
        {
            CreateMap<Data.Entities.User, UserModel>().ReverseMap();
            CreateMap<Data.Entities.User,UserCreateModel>().ReverseMap();//User Create Model gelirsede User a dönüştür demek
            CreateMap<Data.Entities.User, UserUpdateModel>().ReverseMap();

            CreateMap<Data.Entities.Message, MessageModel>().ReverseMap();
            CreateMap<Data.Entities.Message,MessageCreateModel>().ReverseMap();
            CreateMap<Data.Entities.Message,MessageUpdateModel>().ReverseMap();

            CreateMap<Data.Entities.Group,GroupModel>().ReverseMap();
            CreateMap<Data.Entities.Group, GroupCreateModel>().ReverseMap();
            CreateMap<Data.Entities.Group,GroupUpdateModel>().ReverseMap();
            
        }
    }
}
