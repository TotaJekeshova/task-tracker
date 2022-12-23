using Tracker.Domain.Entities;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Projects;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.Application.Contracts.Tasks;

public interface IChangeTaskRepository : IBaseRepository<TaskDbModel>
{
    TaskDbModel MapTaskToDefault (CreateTaskRequestModel model);
    TaskDbModel EditTask (EditTaskRequestModel model);
    void DeleteTaskById(DeleteTaskRequestModel model);
}