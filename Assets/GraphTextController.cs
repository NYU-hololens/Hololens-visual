using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GraphTextController : MonoBehaviour {

	// Use this for initialization
	public string col_name = "test1";
	public string col_type = "FLOAT";
	public string table_name = "table1";
	public int distinct_values = 0;
	public DateTime start_time = new DateTime(2017,1,1);
	public DateTime end_time = new DateTime(2017,8,11);

    void Start() {
        string text = "";
        if (col_type == "float" || col_type == "intger" || col_type == "INTEGER" || col_type == "FLOAT")
        {
            TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
            text = string.Format("{0}, <{1}>, {2}\n No. of distinct values: {3:0}\n Distribution(Grouped):", col_name, col_type, table_name, distinct_values);
            textmeshPro.SetText(text);
        }
        else if (col_type == "string" || col_type == "var_char")
        {
            TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
            text = string.Format("{0}, <{1}>, {2}\n No. of distinct values: {3:0}\n Distribution:", col_name, col_type, table_name, distinct_values);
            textmeshPro.SetText(text);
        }
        else if (col_type == "DATETIME")
        {
            TextMeshProUGUI textmeshPro = GetComponent<TextMeshProUGUI>();
            text = string.Format("{0}, <{1}>, {2}\n Start Date: {3}\n End Data: {4}\n Distribution:", col_name, col_type, table_name, start_time, end_time);
            textmeshPro.SetText(text);
        }
            
	}
}