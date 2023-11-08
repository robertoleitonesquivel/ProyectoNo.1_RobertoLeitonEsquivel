using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public abstract class Master
    {

        private readonly string connectionString;

        public Master()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ProyectoNo1Taller"].ConnectionString;
        }

        protected SqlConnection GetConnection() {
            return new SqlConnection(connectionString); 
        }
    }




}
