using DevFreela.Application.Commands.Projects.CreateComment;
using DevFreela.Application.Commands.Projects.CreateProject;
using DevFreela.Application.Commands.Projects.DeleteProject;
using DevFreela.Application.Commands.Projects.FinishProject;
using DevFreela.Application.Commands.Projects.StartProject;
using DevFreela.Application.Commands.Projects.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.Projects.GetAllProjects;
using DevFreela.Application.Queries.Projects.GetProjectsByID;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _mediator.Send(new GetAllProjectsQuery());

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var request = new GetProjectByIDQuery(id);
            var project = await _mediator.Send(request);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if (command.Title.Length > 50)
            {
                return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProjectInputModel inputModel)
        {
            if (inputModel.Description.Length > 200)
            {
                return BadRequest();
            }

            var command = new UpdateProjectCommand(id, inputModel.Title, inputModel.Description, inputModel.TotalCost);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteProjectCommand command = new(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, CreateCommentInputModel inputModel)
        {
            var command = new CreateCommentCommand(id, inputModel.Content, inputModel.UserId);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
