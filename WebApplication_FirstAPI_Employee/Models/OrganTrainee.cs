namespace WebApplication_FirstAPI_Employee.Models
{
    public class OrganTrainee
    {
        public int TraineeId { get; set; }
        public int OrganizationId { get;}
        public Trainee Trainee { get; set; }
        public Organization Organization { get; set; }
    }
}
