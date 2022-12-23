using Tracker.Domain.Entities;
using Tracker.Domain.Entities.DbModels;

namespace Tracker.Application.Contracts.Tasks;

public interface IAboutTaskRepository
{
    TaskDbModel GetFirstOrDefaultById(int id);
    List<TaskDbModel> GetByName(string name);
    List<TaskDbModel> GetAllByProjectId(int id);
}