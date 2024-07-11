using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Projects.CreateProject
{
    public class CreateProjectCommandHandler(DevFreelaDbContext dbContext) : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext = dbContext;

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(
                request.Title,
                request.Description,
                request.ClientId,
                request.FreelancerID,
                request.TotalCost);

            await _dbContext.Projects.AddAsync(project, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
