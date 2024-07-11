using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetProjectsByID
{
    public record GetProjectByIDQuery(int Id) : IRequest<ProjectDetailsViewModel>
    {
    }
}
