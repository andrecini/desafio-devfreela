using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Projects.GetAllProjects
{
    public class GetAllProjectsQueryHandler(DevFreelaDbContext dbContext) : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext = dbContext;

        public async Task<IEnumerable<ProjectViewModel>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt));

            return projectsViewModel;
        }
    }
}
