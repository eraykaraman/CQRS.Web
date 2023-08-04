namespace CQRS.Web.CQRS.Commands
{
    public class RemoveStudentCommand
    {
        public RemoveStudentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
