using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.Application.Contracts.Projects;

public interface IAboutProjectRepository
{
    ProjectDbModel GetFirstOrDefaultById(FindProjectByIdRequestModel model);

    List<ProjectDbModel> GetFilteredByStartDate (FilteredByDateRequestModel model);
    List<ProjectDbModel> GetFilteredByEndDate(FilteredByDateRequestModel model);
    List<ProjectDbModel> GetRangeByDates (FilteredByDateRequestModel model);
}