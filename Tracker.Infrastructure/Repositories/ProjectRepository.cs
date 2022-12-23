using Microsoft.EntityFrameworkCore;
using Tracker.Application.Contracts.Projects;
using Tracker.Application.Contracts.Tasks;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Projects;
using Tracker.Domain.Entities.RequestModels.Tasks;
using Tracker.Domain.Enums;
using Tracker.Infrastructure.Persistance;

namespace Tracker.Infrastructure.Repositories;

public class ProjectRepository : IAboutProjectRepository, IChangeProjectRepository
{
    private readonly TrackerDbContext _db;
    private readonly IChangeTaskRepository _changeTaskRepository;
    private readonly IAboutTaskRepository _aboutTaskRepository;

    public ProjectRepository(TrackerDbContext db, IChangeTaskRepository changeTaskRepository, IAboutTaskRepository aboutTaskRepository)
    {
        _db = db;
        _changeTaskRepository = changeTaskRepository;
        _aboutTaskRepository = aboutTaskRepository;
    }

    public ProjectDbModel GetFirstOrDefaultById(int id)
    {
        var project = _db.Projects
            .Include(p => p.ProjectTasks)
            .FirstOrDefault(p => p.Id == id);
        if (project == null) throw new NullReferenceException("There is no such project");
        
        return project;
    }

    public List<ProjectDbModel> GetFirstOrDefaultByName(string name)
    {
        var projects = _db.Projects
            .Include(p => p.ProjectTasks)
            .Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
        
        if (projects == null) throw new NullReferenceException("There is no such projects");
        
        return projects;
    }

    public List<ProjectDbModel> GetFilteredByStartDate(DateTime startDate)
    {
        var projects = _db.Projects
            .Include(p => p.ProjectTasks)
            .Where(p => p.StartDate.Date == startDate.Date)
            .OrderByDescending(p => p.Priority)
            .ToList();

        return projects;
    }

    public List<ProjectDbModel> GetFilteredByEndDate(DateTime endDate)
    {
        var projects = _db.Projects
            .Include(p => p.ProjectTasks)
            .Where(p => p.CompletionDate.Date == endDate.Date)
            .OrderByDescending(p => p.Priority)
            .ToList();

        return projects;
    }

    public List<ProjectDbModel> GetRangeByDates(DateTime startDate, DateTime endDate)
    {
        var projects = _db.Projects
            .Include(p => p.ProjectTasks)
            .Where(p => p.StartDate.Date >= startDate.Date 
                        && p.CompletionDate.Date <= endDate.Date)
            .OrderByDescending(p => p.Priority)
            .ToList();

        return projects;
    }

    public List<ProjectDbModel> OrderByStatus()
    {
        var projects = _db.Projects
            .Include(p => p.ProjectTasks)
            .OrderByDescending(p => p.Status)
            .ToList();

        return projects;
    }

    public void Create(ProjectDbModel item) => _db.Projects.Add(item);
    public void Update(ProjectDbModel item) => _db.Projects.Update(item);
    public void Remove(ProjectDbModel item) => _db.Projects.Remove(item);
    public void SaveChanges() => _db.SaveChanges();

    public ProjectDbModel MapProjectToDefault(CreateProjectRequestModel model)
    {
        var project = new ProjectDbModel()
        {
            Name = model.Name,
            StartDate = model.StartDate,
            CompletionDate = model.CompletionDate,
            Status = ProjectStatus.NotStarted,
            Priority = model.Priority,
            ProjectTasks = new List<TaskDbModel>()
        };
        
        return project;
    }

    public ProjectDbModel EditProject(EditProjectRequestModel model)
    {
        var project = _db.Projects
            .Include(p => p.ProjectTasks)
            .FirstOrDefault(p => p.Id == model.Id);
        if (project == null) throw new NullReferenceException("There is no such project");

        project.Name = model.Name;
        project.StartDate = model.StartDate;
        project.CompletionDate = model.CompletionDate;
        project.Status = model.Status;
        project.Priority = model.Priority;

        SaveChanges();
        return project;
    }

    public void DeleteProjectById(int id)
    {
        var project = _db.Projects
            .Include(p => p.ProjectTasks)
            .FirstOrDefault(p => p.Id == id);
        if (project == null) throw new NullReferenceException("There is no such project");
        
        Remove(project);
        SaveChanges();
    }

    public ProjectDbModel AddTask(AddTaskRequestModel model)
    {
        var project = _db.Projects
            .Include(p => p.ProjectTasks)
            .FirstOrDefault(p => p.Id == model.ProjectId);
        
        if (project == null) throw new NullReferenceException("There is no such project");
        try
        {
            var requestTask = new CreateTaskRequestModel()
            {
                Name = model.TaskName,
                Description = model.TaskDescription,
                Priority = model.TaskPriority,
                ProjectId = project.Id
            };

            var task = _changeTaskRepository.MapTaskToDefault(requestTask);
            _changeTaskRepository.Create(task);
            SaveChanges();

            return project;
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public void RemoveTask(RemoveTaskRequestModel model)
    {
        var project = _db.Projects
            .Include(p => p.ProjectTasks)
            .FirstOrDefault(p => p.Id == model.ProjectId);
        if (project == null) throw new NullReferenceException("There is no such project");

        var task = _aboutTaskRepository.GetFirstOrDefaultById(model.TaskId);
        if (task == null) throw new NullReferenceException("There is no such task");

        project.ProjectTasks.Remove(task);
        SaveChanges();
    }
}