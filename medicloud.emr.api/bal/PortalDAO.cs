using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
//using System.Web.UI.WebControls;



//namespace VendingService.DataAccess //HouseOfTara2.Model
//{
public class PortalDAO
{
    public PortalDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //private string message;
    private static SqlConnection connection;
    //private static OdbcConnection connection;
    //private static MySqlConnection myConnection;


    public static SqlConnection getNewConnection()
    {
        connection = new SqlConnection();
        // string conString = "Data Source=52.251.49.79;Initial Catalog=medismartsemr_db;Persist Security Info=True;User ID=medismarts;Password=md2015@tech";
        string conString = "Data Source=FCMB-IT-L16582\\TUNDE;Initial Catalog=medismartsemr_db;Persist Security Info=True;User ID=olatunde;Password=DVorak@23000;MultipleActiveResultSets=True";
        // "Data Source=FCMB-IT-L16582\\TUNDE;Initial Catalog=medismartsemr_db;Persist Security Info=True;User ID=olatunde;Password=DVorak@23000;MultipleActiveResultSets=True"
        //string conString = ConfigurationManager.ConnectionStrings["DataService"].ConnectionString;
        //string conString = "";
        connection.ConnectionString = conString;
        return connection;
    }

    




}
//}
