using DevFreela.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace DevFreela.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<IEnumerable<ProjectViewModel>>
    {
    }
}
