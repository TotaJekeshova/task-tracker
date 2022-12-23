using Tracker.Domain.Entities;

namespace Tracker.Application.Contracts.Projects;

public interface IAboutProjectRepository
{
    ProjectDbModel GetFirstOrDefaultById(int id);
    List<ProjectDbModel> GetFirstOrDefaultByName(string name);
    
    List<ProjectDbModel> GetFilteredByStartDate (DateTime startDate);
    List<ProjectDbModel> GetFilteredByEndDate(DateTime endDate);
    List<ProjectDbModel> GetRangeByDates (DateTime startDate, DateTime endDate );
    List<ProjectDbModel> OrderByStatus ();
}