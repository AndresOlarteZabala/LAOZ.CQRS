using Dapper;
using LAOZ.CQRS.Repositories.Interfaces;
using System.Data;
using System.Data.SqlClient;

public abstract class CommandRepository<T> : ICommandRepository<T> where T : class
{
    private readonly string _connectionString;
    private readonly string _storedProcedure;

    public CommandRepository(string connectionString, string storedProcedure)
    {
        _connectionString = connectionString;
        _storedProcedure = storedProcedure;
    }

    protected IDbConnection Connection
    {
        get
        {
            return new SqlConnection(_connectionString);
        }
    }

    public int Add(T entity)
    {
        using (IDbConnection dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Execute(_storedProcedure, entity, commandType: CommandType.StoredProcedure);
        }
    }

    public int Update(T entity)
    {
        using (IDbConnection dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Execute(_storedProcedure, entity, commandType: CommandType.StoredProcedure);
        }
    }

    public int Delete(T entity)
    {
        using (IDbConnection dbConnection = Connection)
        {
            dbConnection.Open();
            return dbConnection.Execute(_storedProcedure, entity, commandType: CommandType.StoredProcedure);
        }
    }

    public int ExecuteSqlCommand(string sqlCommand)
    {
        using (SqlConnection connection = new(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new(sqlCommand, connection))
            {
                return command.ExecuteNonQuery();
            }
        }
    }
}
