using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Contracts.Projects;

public interface IChangeProjectRepository : IBaseRepository<ProjectDbModel>
{
    ProjectDbModel MapProjectToDefault (CreateProjectRequestModel model);
    ProjectDbModel EditProject (EditProjectRequestModel model);
    void DeleteProjectById(DeleteProjectRequestModel model);
    ProjectDbModel AddTask(AddTaskRequestModel model);
    void RemoveTask(RemoveTaskRequestModel model);
}