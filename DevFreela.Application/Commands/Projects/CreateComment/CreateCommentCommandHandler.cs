using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.Projects.CreateComment
{
    public class CreateCommentCommandHandler(DevFreelaDbContext dbContext) : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly DevFreelaDbContext _dbContext = dbContext;

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.ProjectId, request.UserId);

            await _dbContext.ProjectComments.AddAsync(comment, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return comment.Id;
        }
    }
}
