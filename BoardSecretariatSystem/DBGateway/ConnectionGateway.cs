using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardSecretariatSystem.DBGateway
{
  public   class ConnectionGateway
    {
        protected SqlConnection connection;
        public ConnectionGateway()
        {

            string connectionString = @"Data Source=tcp:KyotoServer,49172;Initial Catalog=BoardSecretariatDBKD66;User=sa;Password=SystemAdministrator;Persist Security Info=True;";
         
            connection = new SqlConnection(connectionString);
        }
    }
}
