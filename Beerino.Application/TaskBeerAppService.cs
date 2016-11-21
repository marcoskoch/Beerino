using Beerino.Application.Interface;
using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Services;

namespace Beerino.Application
{
    public class TaskBeerAppService : AppServiceBase<TaskBeer>, ITaskBeerAppService
    {
        private readonly ITaskBeerService _taskBeerService;

        public TaskBeerAppService(ITaskBeerService taskBeerService) 
            : base(taskBeerService)
        {
            _taskBeerService = taskBeerService;
        }

        public TaskBeer getNextTaskBeer(int beerId, int actualTaskBeerOrdem)
        {
            return _taskBeerService.getNextTaskBeer(_taskBeerService.GetAll(), beerId, actualTaskBeerOrdem);
        }
    }
}
