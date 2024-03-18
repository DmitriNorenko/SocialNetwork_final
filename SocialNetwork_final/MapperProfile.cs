using AutoMapper;
using SocialNetwork_final.Contract.Model.Request;
using SocialNetwork_final.DB.Model;

namespace SocialNetwork_final
{
    public class MapperProfile :Profile
    {
        public MapperProfile() 
        {
            CreateMap<UserRequest, User>();
        }
    }
}
