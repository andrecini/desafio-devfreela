using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Projects.UpdateProject
{
    public class UpdateProjectCommandHandler(DevFreelaDbContext dbContext) : IRequestHandler<UpdateProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext = dbContext;

        public async Task<int> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Update(request.Title, request.Description, request.TotalCost);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
