namespace Domain.Model;

public class Student
{
    public int Studentid { get; set; }
    public string? Studentcode {get; set;}
    public string? Fullname {get; set; }
    public string? Gender {get;set; }
    public string? Dob {get;set;}
    public string? Email {get;set; }
    public string? Phone {get;set; }
    public int Shoolid {get;set; }
    public int Stage {get;set; }
    public string? Section {get;set; }
    public bool isActive {get;set;}
    public DateTime Joindate {get;set; }
    public DateTime Createdat {get;set; }
    public DateTime Updateat {get;set; }
}
