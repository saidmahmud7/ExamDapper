using Domain.Model;
namespace Infrastructure.Service.SchoolService;
using Npgsql;
using Dapper;
public class SchoolService
{
    string connectionString = "Server=127.0.0.1;Port=5432;Database=SchoolDB;User Id=postgres;Password=280806;";
    public bool Insert(School school)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = $@"Insert into school(title,levelcount,isactive) 
                        values(@title,@levelcount,@isactive)";
            var effect = connection.Execute(sql, school);
            return effect > 0;
        }
    }
    public bool Update(School school)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"UPDATE school SET title = @title, levelcount = @levelcount, isactive =@isactive 
                        WHERE schoolid = @schoolid";
            var effect = connection.Execute(sql, school);
            return effect > 0;
        }
    }
    public bool Delete(School school)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"DELETE FROM school WHERE schoolid = @schoolid";
            var effect = connection.Execute(sql, new {schoolid = school.SchoolId});
            return effect > 0;
        }
    }
    public List<School> GetSchools()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"select * from school";
            List<School> schools = connection.Query<School>(sql).ToList();
            return schools;
        }
    }
    public School GetSchoolById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from school where schoolid=@Id;";
            var schools = connection.QuerySingle<School>(sql, new { Id = id });
            return schools;
        }
    }

}



