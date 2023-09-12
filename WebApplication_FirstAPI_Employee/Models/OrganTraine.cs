namespace WebApplication_FirstAPI_Employee.Models
{
    public class OrganTraine
    {
        public int TraineeId { get; set; }
        public int OrganizationId { get; set; }
        public Trainee Trainee { get; set; }
        public Organization Organization { get; set; }
    }
}
