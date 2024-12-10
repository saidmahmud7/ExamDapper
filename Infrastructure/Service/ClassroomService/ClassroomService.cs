using Dapper;
using Domain.Model;
using Npgsql;

namespace Infrastructure.Service.ClassroomService;

public class ClassroomService
{
    string connectionString = "Server=127.0.0.1;Port=5432;Database=SchoolDB;User Id=postgres;Password=280806;";
    public bool Insert(Classroom classroom)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = $@"Insert into classroom(capacity,roomtype,description) 
                        values(@capacity,@roomtype,@description)";
            var effect = connection.Execute(sql, classroom);
            return effect > 0;
        }
    }
    public bool Update(Classroom classroom)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"UPDATE classroom SET capacity = @capacity, roomtype = @roomtype, description =@description 
                        WHERE id = @id";
            var effect = connection.Execute(sql, classroom);
            return effect > 0;
        }
    }
    public bool Delete(Classroom classroom)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"DELETE FROM classroom WHERE id = @id";
            var effect = connection.Execute(sql, new { id = classroom.ClassroomId});
            return effect > 0;
        }
    }
    public List<Classroom> GetClassrooms()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"select * from classroom";
            List<Classroom> classrooms = connection.Query<Classroom>(sql).ToList();
            return classrooms;
        }
    }
    public Classroom GetClassroomById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from classroom where id=@Id;";
            var classrooms = connection.QuerySingle<Classroom>(sql, new { Id = id });
            return classrooms;
        }
    }

}
