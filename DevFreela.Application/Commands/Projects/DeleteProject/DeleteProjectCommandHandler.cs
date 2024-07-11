using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Projects.DeleteProject
{
    public class DeleteProjectCommandHandler(DevFreelaDbContext dbContext) : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Cancel();
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
