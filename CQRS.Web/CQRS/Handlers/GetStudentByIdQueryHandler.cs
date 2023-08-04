using CQRS.Web.CQRS.Queries;
using CQRS.Web.CQRS.Results;
using CQRS.Web.Data;

namespace CQRS.Web.CQRS.Handlers
{
    public class GetStudentByIdQueryHandler
    {
        private readonly StudentContext _studentContext;

        public GetStudentByIdQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        {
            var student = _studentContext.Set<Student>().Find(query.Id);
            return new GetStudentByIdQueryResult
            {
                Age = student.Age,
                Name = student.Name,
                LastName = student.LastName,
            };
        }
    }
}
