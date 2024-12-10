namespace Domain.Model;

public class Teacher
{
    public int TeacherId { get; set; }
    public string Teachercode { get; set; }
    public string Fullname { get; set; }
    public string Gender { get; set; }
    public DateTime Dob { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool isActive { get; set; }
    public DateTime JoinDate { get; set; }
    public int WorkingDays { get; set; }
    public DateTime Createdat { get; set; }
    public DateTime Updateat { get; set; }
}
