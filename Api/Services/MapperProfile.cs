using Api.Data.Entity;
using Api.Services.Models;

namespace Api.CodingLibraryDSR.Services.Models;
using AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Languages, GetLanguagesModel>();
        CreateMap<Users, GetUsersModel>();
        CreateMap<Comments, GetCommentsModel>();
        CreateMap<Problems, GetProblemsModel>();
        CreateMap<Categories, GetCategoriesModel>();
        CreateMap<Subscriptions, GetSubscriptionsModel>();
        CreateMap<PostLanguagesModel, Languages>();
        CreateMap<UpdateLanguagesModel, Languages>();
        CreateMap<PostProblemsModel, Problems>();
        CreateMap<DeleteProblemsModel, Problems>();
        CreateMap<PostUsersModel, Users>();
        CreateMap<UpdateUsersModel, Users>();
        CreateMap<DeleteUsersModel, Users>();
        CreateMap<PostCategoriesModel, Categories>();
        CreateMap<UpdateCategoriesModel, Categories>();
        CreateMap<DeleteCategoriesModel, Categories>();
        CreateMap<PostCommentsModel, Comments>();
        CreateMap<DeleteCommentsModel, Comments>();
        CreateMap<PostSubscriptionsModel, Subscriptions>();
        CreateMap<DeleteSubscriptionsModel, Subscriptions>();
    }
}