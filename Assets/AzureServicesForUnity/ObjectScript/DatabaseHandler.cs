using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Data.SqlClient;

public class DatabaseHandler : MonoBehaviour {

    //private string _conString = @"Data Source = 127.0.0.1; 
    // user id = Username;
    // password = Password1@;
    // Initial Catalog = DatabaseName;";

    //public string SimpleQuery(string _query)
    //{
    //    using (SqlConnection dbCon = new SqlConnection(_conString))
    //    {
    //        SqlCommand cmd = new SqlCommand(_query, dbCon);
    //        try
    //        {
    //            dbCon.Open();
    //            string _returnQuery = (string)cmd.ExecuteScalar();
    //            return _returnQuery;
    //        }
    //        catch (SqlException _exception)
    //        {
    //            Debug.LogWarning(_exception.ToString());
    //            return null;
    //        }
    //    }
    //}



    string conString = "Server=tcp:serverholo.database.windows.net,1433;" +
        "Database=CitiHoloDB;" +
        "User ID=sonal@serverholo;" +
        "Password=Password1@;";

    public string GetStringFromSQL()
    {
        
        string result = "";

        SqlConnection connection = new SqlConnection(conString);
        connection.Open();
        Debug.Log(connection.State);
        SqlCommand Command = connection.CreateCommand();
        Command.CommandText = "select COLUMN_NAME, DATA_TYPE, from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'TableName'";
        SqlDataReader ThisReader = Command.ExecuteReader();
        while (ThisReader.Read())
        {
            result = ThisReader.GetString(0);
        }
        ThisReader.Close();
        connection.Close();

        return result;
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
