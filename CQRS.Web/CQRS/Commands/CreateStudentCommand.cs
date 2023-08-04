namespace CQRS.Web.CQRS.Commands
{
    public class CreateStudentCommand
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
