using CQRS.Web.CQRS.Commands;
using CQRS.Web.Data;

namespace CQRS.Web.CQRS.Handlers
{
    public class CreateStudentCommandHandler
    {
        private readonly StudentContext _studentContext;

        public CreateStudentCommandHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public void Handle(CreateStudentCommand createStudent)
        {
            _studentContext.Students.Add(new Student 
            { Age = createStudent.Age, Name= createStudent.Name, LastName = createStudent.LastName });
            _studentContext.SaveChanges();
        }
    }
}
