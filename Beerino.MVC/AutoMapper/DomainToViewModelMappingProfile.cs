using AutoMapper;
using Beerino.Domain.Entities;
using Beerino.MVC.ViewModel;

namespace Beerino.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<BeerinoUser, BeerinoUserViewModel>();
            CreateMap<Beer, BeerViewModel>();
            CreateMap<TaskBeer, TaskBeerViewModel>();
        }
    }
}