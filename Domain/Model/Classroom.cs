namespace Domain.Model;

public class Classroom
{
    public int ClassroomId { get; set; }
    public int Capacity { get; set; }
    public int Roomtype { get; set; }
    public string Description { get; set; }
    public DateTime Createdat { get; set; }
    public DateTime Updateat { get; set; }
}
