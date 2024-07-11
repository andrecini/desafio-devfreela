using MediatR;

namespace DevFreela.Application.Commands.Projects.DeleteProject
{
    public record DeleteProjectCommand(int Id) : IRequest<Unit>
    {
    }
}
