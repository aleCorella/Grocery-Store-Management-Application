using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PryDesarrolloAppsDueño.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Server=DESKTOP-J135DBV;Database=GroceryStore;Integrated Security=true";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
