using MediatR;

namespace DevFreela.Application.Commands.Projects.UpdateProject
{
    public record UpdateProjectCommand(int Id, string Title, string Description, double TotalCost) : IRequest<int>
    {
    }
}
