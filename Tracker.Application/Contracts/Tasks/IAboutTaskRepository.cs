using Tracker.Domain.Entities;

namespace Tracker.Application.Contracts.Tasks;

public interface IAboutTaskRepository
{
    TaskDbModel GetFirstOrDefaultById(int id);
    List<TaskDbModel> GetByName(string name);
    List<TaskDbModel> GetAllByProjectId(int id);
}