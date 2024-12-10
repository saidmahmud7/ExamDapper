namespace Domain.Model;

public class Subject
{
    public int SubjectId { get; set; }
    public string Title { get; set; }
    public int Schoolid { get; set; }
    public int Stage { get; set; }
    public int Carrymark { get; set; }
    public DateTime Createdat { get; set; }
    public DateTime Updateat { get; set; }
}
