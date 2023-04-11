using AutoMapper;
using Database.Data.Entity;
using FluentValidation;

namespace UserAccount.Services;

public class UserAccountModel
{
   public Guid Id { get; set; }
   public string Name { get; set; }
   public string Email { get; set; }
}

public class UserAccountModelProfile : Profile
{
   public UserAccountModelProfile()
   {
      CreateMap<Users, UserAccountModel>()
         .ForMember(d =>
            d.Id, o => o.MapFrom(s => s.Id))
         .ForMember(d => 
            d.Name, o => o.MapFrom(s => s.Name))
         .ForMember(d => 
            d.Email, o => o.MapFrom(s => s.Email));
   }
}