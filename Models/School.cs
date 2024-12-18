using SchoolsWebApi.Models;

public class School
{
    public required string Name { get; set; }

    public List<StudentAdvisor> StudentAdvisors { get; set; } = new List<StudentAdvisor>();
    public List<Meeting> Meetings { get; set; } = new List<Meeting>();
}
