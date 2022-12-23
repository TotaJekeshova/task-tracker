using AutoMapper;
using Tracker.Domain.Entities;
using Tracker.Domain.Entities.RequestModels.Projects;

namespace Tracker.API.Mappings;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<CreateProjectRequestModel, ProjectDbModel>();
        CreateMap<EditProjectRequestModel, ProjectDbModel>();
        CreateMap<AddTaskRequestModel, ProjectDbModel>();
        CreateMap<RemoveTaskRequestModel, ProjectDbModel>();
        CreateMap<DeleteProjectRequestModel, ProjectDbModel>();
        CreateMap<FilteredByDateRequestModel, ProjectDbModel>();
        CreateMap<FindProjectByIdRequestModel, ProjectDbModel>();
    }
}