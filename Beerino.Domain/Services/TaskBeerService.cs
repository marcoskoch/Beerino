
using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Repositories;
using Beerino.Domain.Interfaces.Services;

namespace Beerino.Domain.Services
{
    public class TaskBeerService : ServiceBase<TaskBeer>, ITaskBeerService
    {
        private readonly ITaskBeerRepository _taskBeerRepository;

        public TaskBeerService(ITaskBeerRepository taskBeerRepository) 
            : base(taskBeerRepository)
        {
            _taskBeerRepository = taskBeerRepository;
        }
    }
}
