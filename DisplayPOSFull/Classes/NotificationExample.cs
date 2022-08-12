using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ZFame.Classes
{
    public class NotificationExample
    {
        private delegate void RateChangeNotification(DataTable table);
        private SqlDependency dependency;

        public void StartNotification(string cnnString, string queueName)
        {
            if (!HasPermissionSql()) return;

            SqlDependency.Stop(cnnString);

            SqlDependency.Start(cnnString);

            SqlConnection sqlCnn = new SqlConnection(cnnString);
            sqlCnn.Open();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCnn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "Get_ProductForDisplay";
            sqlCmd.Parameters.Add("@PriceLevel", SqlDbType.Int).Value = InfoApp.PRICE_LEVEL;

            this.dependency = new SqlDependency(sqlCmd);
            dependency.OnChange += new OnChangeEventHandler(OnRateChange);

        }

        public void StartNotification2(string cnnString, string queueName)
        {
            if (!HasPermissionSql()) return;

            SqlDependency.Start(cnnString);//, queueName);
            SqlConnection sqlCnn = new SqlConnection(cnnString);
            sqlCnn.Open();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = sqlCnn;
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "Get_ProductForDisplay";
            sqlCmd.Parameters.Add("@PriceLevel", SqlDbType.Int).Value = InfoApp.PRICE_LEVEL;

            this.dependency = new SqlDependency(sqlCmd);
            dependency.OnChange += new OnChangeEventHandler(OnRateChange);

        }
        private void OnRateChange(object s, SqlNotificationEventArgs e)
        {
            //Write code for you task    
        }
        public void StopNotification(string cnnString, string queueName)
        {
            SqlDependency.Stop(cnnString, queueName);
        }

        private bool HasPermissionSql()
        {
            SqlClientPermission sqlClientPermission = new SqlClientPermission(PermissionState.Unrestricted);
            try
            {
                sqlClientPermission.Demand();
                return true;
            }
            catch
            {
                return false;
                throw;
            }
        }

    }
}
