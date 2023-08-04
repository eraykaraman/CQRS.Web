using CQRS.Web.CQRS.Commands;
using CQRS.Web.Data;

namespace CQRS.Web.CQRS.Handlers
{
    public class UpdateStudentCommandHandler
    {
        private readonly StudentContext _studentContext;

        public UpdateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(UpdateStudentCommand command)
        {
            var student = _studentContext.Students.FirstOrDefault(x => x.Id == command.Id);
            if (student == null)
            {
                throw new Exception("user not found");
            }
            else
            {
                student.Age = command.Age;
                student.Name = command.Name;
                student.LastName = command.LastName;
                _studentContext.SaveChanges();
            }
        }
    }
}
