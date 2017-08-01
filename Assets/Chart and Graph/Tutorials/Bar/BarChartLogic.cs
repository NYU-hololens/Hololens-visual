using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using ChartAndGraph;


public class BarChartLogic : MonoBehaviour {
	public Material mDefaultMaterial;
	public string[] col_name = new string[]{
		"policyID,statecode,county,eq_site_limit,hu_site_limit,fl_site_limit,fr_site_limit,tiv_2011,tiv_2012,eq_site_deductible,hu_site_deductible,fl_site_deductible," +
		"fr_site_deductible,point_latitude,point_longitude,line,construction,point_granularity"};
	public string primaryKey;
	public string value;
	List<Dictionary<string,object>> finalData;
	List<List<Dictionary<string,object>>> dataSet = new List<List<Dictionary<string, object>>>();

	// Use this for initialization
	void Start () {
		TextAsset[] info = new TextAsset[1];
		info[0] = Resources.Load("csvs/sample", typeof(TextAsset)) as TextAsset;

		foreach (TextAsset t in info) {
			List<Dictionary<string,object>> data = TextReader.Read (t.text);
			dataSet.Add (data);
		}

		// Dictionary<object,Color> labelColors = new Dictionary<object, Color> ();
		BarChart chart = GetComponent<BarChart>();
		chart.DataSource.AddGroup ("test1");
		for (var i = 0; i < dataSet[0].Count; i++) {
			// System.Diagnostics.Debug.WriteLine(dataSet[0][i]);
			// Debug.Log (dataSet [0] [i]["policyID"]);
			if (mDefaultMaterial == null) {
				mDefaultMaterial = new Material (Shader.Find ("Standard"));
				mDefaultMaterial.color = Color.blue;
			}
			chart.DataSource.AddCategory (dataSet [0] [i] [primaryKey].ToString(), mDefaultMaterial);
			double result = 0;
			double.TryParse (dataSet [0] [i] [value].ToString(), out result);
			chart.DataSource.SetValue(dataSet [0] [i][primaryKey].ToString(), "test1", result);
			/*
			object finalvalue = dataSet[0][i]["point_longitude"];
			float f=(float)dataSet[0][i]["point_longitude"];
			*/
			// float.TryParse(finalvalue, out f);
			// point.transform.position = new Vector3((float)dataSet[0][i]["point_latitude"]/10, (float)dataSet[0][i]["point_longitude"]/10, f);
			// point.transform.position = new Vector3((float)dataSet[0][i]["x"], (float)dataSet[0][i]["y"], (float)dataSet[0][i]["x"]);
			// points.Add (point);
		}
        
	}
}
