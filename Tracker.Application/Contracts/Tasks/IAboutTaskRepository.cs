using Tracker.Domain.Entities;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.Application.Contracts.Tasks;

public interface IAboutTaskRepository
{
    TaskDbModel GetFirstOrDefaultById(FindTaskByIdRequestModel model);
    List<TaskDbModel> GetAllByProjectId(FindAllByProjectIdRequestModel model);
}