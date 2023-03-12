using CodingLibraryDSR.Data.Entity;
using CodingLibraryDSR.Services.Models;

namespace Services.Models;
using AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Languages, LanguagesModel>();
        CreateMap<Users, UsersModel>();
        CreateMap<Comments, CommentsModel>();
        CreateMap<Problems, ProblemsModel>();
        CreateMap<Categories, CategoriesModel>();
        CreateMap<Subscriptions, SubscriptionsModel>();
    }
}