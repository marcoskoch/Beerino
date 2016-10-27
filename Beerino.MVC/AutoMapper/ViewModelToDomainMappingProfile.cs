using AutoMapper;
using Beerino.Domain.Entities;
using Beerino.MVC.ViewModel;

namespace Beerino.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<BeerinoUserViewModel, BeerinoUser>();
            CreateMap<BeerViewModel, Beer>();
            CreateMap<TaskBeerViewModel, TaskBeer>();
        }
    }
}