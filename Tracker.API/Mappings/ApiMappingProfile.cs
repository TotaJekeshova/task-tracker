using AutoMapper;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.DbModels;
using Tracker.Domain.Entities.RequestModels.Projects;
using Tracker.Domain.Entities.RequestModels.Tasks;

namespace Tracker.API.Mappings;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<CreateProjectRequestModel, ProjectDbModel>();
        CreateMap<EditProjectRequestModel, ProjectDbModel>();
        CreateMap<AddTaskRequestModel, ProjectDbModel>();
        CreateMap<RemoveTaskRequestModel, ProjectDbModel>();
        CreateMap<FilteredByDateRequestModel, List<ProjectDbModel>>();
        CreateMap<FilteredByStartDateRequestModel, List<ProjectDbModel>>();
        CreateMap<FilteredByEndDateRequestModel, List<ProjectDbModel>>();
        CreateMap<FindProjectByIdRequestModel, ProjectDbModel>();
        
        CreateMap<CreateTaskRequestModel, TaskDbModel>();
        CreateMap<EditTaskRequestModel, TaskDbModel>();
        CreateMap<FindTaskByIdRequestModel, TaskDbModel>();
        CreateMap<FindAllByProjectIdRequestModel,  List<TaskDbModel>>();
    }
}