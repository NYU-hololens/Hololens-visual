﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class DBScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/mainsql.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT policyID " + "FROM FL_insurance_sample_test1";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            // int policyID = reader.GetInt32(0);
            //string name = reader.GetString(0);
            int rand = reader.GetInt32(0);
            Debug.Log("The Policy ID is = " + rand);
            // Debug.Log("The Policy ID is = " + value + "  name =" + name + "  random =" + rand);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
