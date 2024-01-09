using LAOZ.CQRS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data.SqlClient;

namespace LAOZ.CQRS.Infrastructure.Repositories.Commands
{
    public abstract class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public CommandRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return 1;
        }

        public int Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return 1;
        }

        public int Delete(T entity)
        {
            _dbSet.Remove(entity);
            return 1;
        }

        public int ExecuteSqlCommand(string sqlCommand)
        {
            using (SqlConnection connection = new())
            {
                connection.Open();

                using SqlCommand command = new(sqlCommand, connection);
                return command.ExecuteNonQuery();
            }
        }
    }
}
