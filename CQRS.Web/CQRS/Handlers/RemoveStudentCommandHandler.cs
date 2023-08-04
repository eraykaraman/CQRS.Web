using CQRS.Web.CQRS.Commands;
using CQRS.Web.Data;

namespace CQRS.Web.CQRS.Handlers
{
    public class RemoveStudentCommandHandler
    {
        private readonly StudentContext _studentContext;

        public RemoveStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(RemoveStudentCommand command) 
        {
            var student = _studentContext.Students.Find(command.Id);
            if (student != null)
            {
                _studentContext.Students.Remove(student);
                _studentContext.SaveChanges();
            }
            Console.WriteLine("user not found.");

        }
    }
}
