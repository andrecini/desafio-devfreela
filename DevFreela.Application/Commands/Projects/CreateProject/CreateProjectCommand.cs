using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateProject
{
    public record CreateProjectCommand(
        string Title,
        string Description,
        int ClientId,
        int FreelancerID,
        double TotalCost) : IRequest<int>
    {
    }
}
