using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Projects.StartProject
{
    public class StartProjectCommandHandler(DevFreelaDbContext dbContext) : IRequestHandler<StartProjectCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext = dbContext;

        public async Task<int> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Start();
            await _dbContext.SaveChangesAsync(cancellationToken);

            return project.Id;
        }
    }
}
