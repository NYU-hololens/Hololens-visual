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

	void Start () {
		TextMeshPro textmeshPro = GetComponent<TextMeshPro>();
		string text="";
		if (col_type == "float" || col_type == "intger" || col_type == "INTEGER" || col_type == "FLOAT" )
			text = string.Format("{0}, <{0}>, {0}\n No. of distinct values{1:0}\n Distribution(Grouped):", col_name, col_type, table_name, distinct_values);
		else if (col_type == "string" || col_type == "var_char")
			text = string.Format("{0}, <{0}>, {0}\n No. of distinct values{1:0}\n Distribution:", col_name, col_type, table_name, distinct_values);
		else if (col_type == "DATATIME")
			text = string.Format("{0}, <{0}>, {0}\n Start Date: {0}\n End Data: {0}\n Distribution:", col_name, col_type, table_name, start_time, end_time);
		textmeshPro.SetText (text);
	}
}