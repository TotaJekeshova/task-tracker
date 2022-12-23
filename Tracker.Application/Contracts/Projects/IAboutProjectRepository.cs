using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Contracts.Projects;

public interface IAboutProjectRepository
{
    ProjectDbModel GetFirstOrDefaultById(int id);

    List<ProjectDbModel> GetFilteredByStartDate (DateTime startDate);
    List<ProjectDbModel> GetFilteredByEndDate(DateTime endDate);
    List<ProjectDbModel> GetRangeByDates (DateTime startDate, DateTime endDate);
}