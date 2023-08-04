using CQRS.Web.CQRS.Queries;
using CQRS.Web.CQRS.Results;
using CQRS.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Web.CQRS.Handlers
{
    public class GetStudentsQueryHandler
    {
        private readonly StudentContext _studentContext;

        public GetStudentsQueryHandler(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
        {
            return _studentContext.Students.Select(x =>
                new GetStudentsQueryResult { Name = x.Name, LastName = x.LastName, Age = x.Age }).AsNoTracking().AsEnumerable();
        }
    }
}
