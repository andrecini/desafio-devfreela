using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Projects.FinishProject
{
    public class FinishProjectCommandHandler(DevFreelaDbContext dbContext) : IRequestHandler<FinishProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext = dbContext;

        public async Task<int> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Finish();
            await _dbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
