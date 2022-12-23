using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.Application.Contracts.Tasks;

public interface IChangeTaskRepository : IBaseRepository<TaskDbModel>
{
    TaskDbModel MapTaskToDefault (CreateTaskRequestModel model);
    TaskDbModel EditTask (EditTaskRequestModel model);
    void DeleteTaskById(int id);
}