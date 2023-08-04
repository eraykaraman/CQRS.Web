using CQRS.Web.CQRS.Commands;
using CQRS.Web.CQRS.Handlers;
using CQRS.Web.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
        private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
        private readonly CreateStudentCommandHandler _createStudentCommandHandler;
        private readonly RemoveStudentCommandHandler _removeStudentCommandHandler;
        private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;


        public StudentsController(GetStudentsQueryHandler getStudentsQueryHandler, GetStudentByIdQueryHandler handler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentCommandHandler removeStudentCommandHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
        {
            _getStudentsQueryHandler = getStudentsQueryHandler;
            _getStudentByIdQueryHandler = handler;
            _createStudentCommandHandler = createStudentCommandHandler;
            _removeStudentCommandHandler = removeStudentCommandHandler;
            _updateStudentCommandHandler = updateStudentCommandHandler;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
           var result = _getStudentByIdQueryHandler.Handle(new GetStudentByIdQuery(id));
           return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var result = _getStudentsQueryHandler.Handle(new GetStudentsQuery());
            return Ok(result);

        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentCommand command)
        {
            _createStudentCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveStudent(int id)
        {
            _removeStudentCommandHandler.Handle(new RemoveStudentCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(UpdateStudentCommand command)
        {
            _updateStudentCommandHandler.Handle(command);
            return Ok();
        }
    }
}
