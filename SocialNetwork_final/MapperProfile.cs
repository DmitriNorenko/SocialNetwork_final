using AutoMapper;
using SocialNetwork_final.Contract.Model.Request;
using SocialNetwork_final.DB.Model;
using SocialNetwork_final.Models;

namespace SocialNetwork_final
{
    public class MapperProfile :Profile
    {
        public MapperProfile() 
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(r => r.Email))
                .ForMember(u => u.BirthDate, opt => opt.MapFrom(r => $"{r.Year}.{r.Month}.{r.Date}"))
                .ForMember(u => u.MiddleName, opt => opt.MapFrom(r => $"{r.FirstName} {r.LastName}"));

            CreateMap<LoginViewModel, User>()
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(r => r.Password));
        }
    }
}
