using MediatR;

namespace DevFreela.Application.Commands.Projects.FinishProject
{
    public record FinishProjectCommand(int Id) : IRequest<int>
    {
    }
}
