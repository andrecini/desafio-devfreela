using MediatR;

namespace DevFreela.Application.Commands.Projects.CreateComment
{
    public record CreateCommentCommand(int ProjectId, string Content, int UserId) : IRequest<int>
    {
    }
}
