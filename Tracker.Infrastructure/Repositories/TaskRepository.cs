using Microsoft.EntityFrameworkCore;
using Tracker.Application.Contracts.Tasks;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Tasks;
using Tracker.Domain.Enums;
using Tracker.Infrastructure.Persistance;

namespace Tracker.Infrastructure.Repositories;

public class TaskRepository : IAboutTaskRepository, IChangeTaskRepository
{
    private readonly TrackerDbContext _db;

    public TaskRepository(TrackerDbContext db)
    {
        _db = db;
    }

    public TaskDbModel GetFirstOrDefaultById(int id)
    {
        var task = _db.Tasks
            .Include(t => t.Project)
            .FirstOrDefault(t => t.Id == id);
        
        if (task == null) throw new NullReferenceException("There is no such task");
        
        return task;
    }

    public List<TaskDbModel> GetByName(string name)
    {
        var tasks = _db.Tasks
            .Include(t => t.Project)
            .Where(t => t.Name.ToLower().Contains(name.ToLower())).ToList();
        
        if (tasks == null) throw new NullReferenceException("There is no such tasks");
        
        return tasks;
    }

    public List<TaskDbModel> GetAllByProjectId(int id)
    {
        var tasks = _db.Tasks
            .Include(t => t.Project)
            .Where(t => t.ProjectId == id).ToList();
        
        if (tasks == null) throw new NullReferenceException("There are no tasks in this project");
        
        return tasks;
    }

    public void Create(TaskDbModel item) => _db.Tasks.Add(item);
    public void Update(TaskDbModel item) => _db.Tasks.Update(item);
    public void Remove(TaskDbModel item) => _db.Tasks.Remove(item);
    public void SaveChanges() => _db.SaveChanges();

    public TaskDbModel MapTaskToDefault(CreateTaskRequestModel model)
    {
        var project = _db.Projects
            .Include(p => p.ProjectTasks)
            .FirstOrDefault(p => p.Id == model.ProjectId);
        if (project == null) 
            throw new NullReferenceException("There is no such project");
        
        var task = new TaskDbModel()
        {
            Name = model.Name,
            Description = model.Description,
            Priority = model.Priority,
            ProjectId = model.ProjectId,
            Project = project,
            Status = TasksStatus.ToDo
        };

        return task;
    }

    public TaskDbModel EditTask(EditTaskRequestModel model)
    {
        var task = _db.Tasks
            .Include(t => t.Project)
            .FirstOrDefault(t => t.Id == model.Id);

        if (task == null) throw new NullReferenceException("There is no such task");
        
        task.Name = model.Name;
        task.Description = model.Description;
        task.Status = model.Status;
        task.Priority = model.Priority;
        SaveChanges();
        
        return task;
    }

    public void DeleteTaskById(int id)
    {
        var task = _db.Tasks
            .Include(t => t.Project)
            .FirstOrDefault(t => t.Id == id);
        
        if (task == null) throw new NullReferenceException("There is no such task");
        
        Remove(task);
        SaveChanges();
    }
}