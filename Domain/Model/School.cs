namespace Domain.Model;

public class School
{
    public int SchoolId { get; set; }
    public string Title { get; set; }
    public int Levelcount { get; set; }
    public bool isActive { get; set; }
    public DateTime Createdat { get; set; }
    public DateTime Updateat { get; set; }
}
