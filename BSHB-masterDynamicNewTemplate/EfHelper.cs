using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;

namespace BiharStateHousingBoard
{
    public static class EfHelper
    {
        /*
     * need to install Microsoft.EntityFrameworkCore.Relational
     */
        public static string Truncate<T>(this DbSet<T> dbSet) where T : class
        {
            var context = dbSet.GetService<ICurrentDbContext>().Context;
            string cmd = $"TRUNCATE TABLE {AnnotationHelper.TableName(dbSet)}";
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }
                command.CommandText = cmd;
                command.ExecuteNonQuery();
            }
            return cmd;
        }
    }
}
