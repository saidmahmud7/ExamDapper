using Dapper;
using Npgsql;
using Domain.Model;
namespace Infrastructure.Service;

public class SubjectService
{
    string connectionString = "Server=127.0.0.1;Port=5432;Database=SchoolDB;User Id=postgres;Password=280806;";
    public bool Insert(Subject subject)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = $@"Insert into subject(title,schoolid,stage,carrymark) 
                        values(@title,@schoolid,@stage,@carrymark)";
            var effect = connection.Execute(sql, subject);
            return effect > 0;
        }
    }
    public bool Update(Subject subject)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"UPDATE subject SET title = @title, schoolid = @schoolid, stage =@stage,carrymark=@carrymark 
                        WHERE subjectid = @subjectid";
            var effect = connection.Execute(sql, subject);
            return effect > 0;
        }
    }
    public bool Delete(Subject subject)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"DELETE FROM subject WHERE subjectid = @subjectid";
            var effect = connection.Execute(sql, new { subjectid = subject.SubjectId});
            return effect > 0;
        }
    }
    public List<Subject> GetSubjects()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"select * from subject";
            List<Subject> subjects = connection.Query<Subject>(sql).ToList();
            return subjects;
        }
    }
    public Subject GetSubjectById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from subject where id=@Id;";
            var subjects = connection.QuerySingle<Subject>(sql, new { Id = id });
            return subjects;
        }
    }
}
