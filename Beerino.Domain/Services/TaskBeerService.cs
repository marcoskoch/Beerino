
using Beerino.Domain.Entities;
using Beerino.Domain.Interfaces.Repositories;
using Beerino.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public TaskBeer getNextTaskBeer(IEnumerable<TaskBeer> taskBeer, int beerId, int order)
        {
            return taskBeer.Where(t => t.NextTaskBeer(t, beerId, order)).FirstOrDefault();
        }
    }
}
