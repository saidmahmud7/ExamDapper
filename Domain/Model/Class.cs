namespace Domain.Model;

public class Class
{
    public int Classid { get; set; }
    public string Name { get; set; }
    public int Subjectid { get; set; }
    public int TeacherId { get; set; }
    public int ClassroomId { get; set; }
    public string Section { get; set; }
    public DateTime Createdat { get; set; }
    public DateTime Updateat { get; set; }
}
