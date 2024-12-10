using Dapper;
using Domain.Model;
using Npgsql;

namespace Infrastructure.Service;

public class StudentService
{
    string connectionString = "Server=127.0.0.1;Port=5432;Database=SchoolDB;User Id=postgres;Password=280806;";
    public bool Insert(Student student)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = $@"Insert into students(studentcode,fullname,gender,dob,email,phone,shoolid,stage,section,isactive) 
                        values(@studentcode,@fullname,@gender,@dob,@email,@phone,@shoolid,@stage,@section,@isactive) ";
            var effect = connection.Execute(sql, student);
            return effect > 0;
        }
    }
    public bool Update(Student student)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"UPDATE students SET studentcode = @studentcode, fullname = @fullname, gender =@gender,dob=@dob,email=@email,phone=@phone,
            shoolid = @shoolid,stage = @stage,section=@section,isactive = @isactive
                        WHERE studentid = @studentid";
            var effect = connection.Execute(sql, student);
            return effect > 0;
        }
    }
    public bool Delete(Student student)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"DELETE FROM students WHERE studentid = @studentid";
            var effect = connection.Execute(sql, new { studentid = student.Studentid });
            return effect > 0;
        }
    }
    public List<Student> GetStudents()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"select * from students";
            List<Student> students = connection.Query<Student>(sql).ToList();
            return students;
        }
    }
    public Student GetStudentById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from students where studentid=@Id;";
            var students = connection.QuerySingle<Student>(sql, new { Id = id });
            return students;
        }
    }
}
