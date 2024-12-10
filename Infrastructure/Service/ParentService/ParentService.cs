using Npgsql;
using Domain.Model;
using Dapper;
namespace Infrastructure.Service;

public class ParentService
{
    string connectionString = "Server=127.0.0.1;Port=5432;Database=SchoolDB;User Id=postgres;Password=280806;";
    public bool Insert(Parent parent)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = $@"Insert into parents(parentcode,fullname,email,phone) 
                        values(@parentcode,@fullname,@email,@phone) ";
            var effect = connection.Execute(sql, parent);
            return effect > 0;
        }
    }
    public bool Update(Parent parent)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"UPDATE parents SET parentcode = @parentcode, fullname = @fullname, email =@email,phone=@phone 
                        WHERE id = @id";
            var effect = connection.Execute(sql, parent);
            return effect > 0;
        }
    }
    public bool Delete(Parent parent)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"DELETE FROM parents WHERE id = @id";
            var effect = connection.Execute(sql, new { id = parent.Parentid});
            return effect > 0;
        }
    }
    public List<Parent> GetParents()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"select * from parents";
            List<Parent> parents = connection.Query<Parent>(sql).ToList();
            return parents;
        }
    }
    public Parent GetParentById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from parents where id=@Id;";
            var parents = connection.QuerySingle<Parent>(sql, new { Id = id });
            return parents;
        }
    }
}
