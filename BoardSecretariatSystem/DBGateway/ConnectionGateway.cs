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
<<<<<<< HEAD
            string connectionString = @"Data Source=tcp:KyotoServer,49172;Initial Catalog=BoardSecretariatDBKD66;User=sa;Password=SystemAdministrator;Persist Security Info=True;";
||||||| merged common ancestors
            string connectionString = @"Data Source=tcp:KyotoServer,49172;Initial Catalog=BoardSecretariatDBKD;User=sa;Password=SystemAdministrator;Persist Security Info=True;";
=======
            string connectionString = @"Data Source=tcp:KyotoServer,49172;Initial Catalog=BoardSecretariatDBKD22;User=sa;Password=SystemAdministrator;Persist Security Info=True;";
>>>>>>> ee78a2d02a4f46bd6ed50ba032f403670b187baa
            // string connectionString = @"server=KYOTO-PC1\SQLSERVER2014; Integrated Security = SSPI; database =EmployeeMSDb";
            // string connectionString = @"KYOTOPC-7\SQLSERVER1416;database =EmployeeMSDb;Integrated Security = true;";
            //string connectionString = @"server=KYOTO-PC06\SQLSERVER2014; Integrated Security = SSPI; database =NewProductList;Connect Timeout=30";
            // string connectionString = @"server=DESKTOP-TQ74LPH\SQLSERVER2018;Initial Catalog=NewProductList;User=sa;Password=SystemAdministrator;Persist Security Info=True;";

            connection = new SqlConnection(connectionString);
        }
    }
}
