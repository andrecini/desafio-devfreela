using MediatR;

namespace DevFreela.Application.Commands.Projects.StartProject
{
    public record StartProjectCommand(int Id) : IRequest<int>
    {
    }
}
