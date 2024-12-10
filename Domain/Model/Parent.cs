namespace Domain.Model;

public class Parent
{
    public int Parentid { get; set; }
    public string? Parentcode { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Createdat { get; set; }
    public DateTime Updateat { get; set; }
}
