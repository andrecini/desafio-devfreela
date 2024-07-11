using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.Projects.GetProjectsByID
{
    public class GetProjectByIDQueryHandler(DevFreelaDbContext dbContext) : IRequestHandler<GetProjectByIDQuery, ProjectDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext = dbContext;

        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIDQuery request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == request.Id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            return projectDetailsViewModel;
        }
    }
}
