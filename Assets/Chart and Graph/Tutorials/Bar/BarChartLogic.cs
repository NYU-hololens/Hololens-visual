using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using ChartAndGraph;

// This BarChart draws the key as x axis and the value as y axis
// It is not what we planned for the uniq count chart as that data should be pulled from the DB directly
public class BarChartLogic : MonoBehaviour {
	public Material mDefaultMaterial;
	// TODO: Remove this once we have a DB working
	private string[] col_name = new string[]{
		"policyID,statecode,county,eq_site_limit,hu_site_limit,fl_site_limit,fr_site_limit,tiv_2011,tiv_2012,eq_site_deductible,hu_site_deductible,fl_site_deductible," +
		"fr_site_deductible,point_latitude,point_longitude,line,construction,point_granularity"};
	public string key;
	public string value;
	// List<Dictionary<string,object>> finalData;
	List<List<Dictionary<string,object>>> dataSet = new List<List<Dictionary<string, object>>>();

	// Use this for initialization
	void Start () {
		// info supports multiple csv reads, for now we just use one
		TextAsset[] info = new TextAsset[1];
		info[0] = Resources.Load("csvs/sample", typeof(TextAsset)) as TextAsset;

		foreach (TextAsset t in info) {
			List<Dictionary<string,object>> data = TextReader.Read (t.text);
			dataSet.Add (data);
		}


		BarChart chart = GetComponent<BarChart>();
		// Group is the list of Categories, multi group is supported
		chart.DataSource.AddGroup ("test1");

		for (var i = 0; i < dataSet[0].Count; i++) {
			if (mDefaultMaterial == null) {
				mDefaultMaterial = new Material (Shader.Find ("Standard"));
				mDefaultMaterial.color = Color.blue;
			}
			chart.DataSource.AddCategory (dataSet [0] [i] [key].ToString(), mDefaultMaterial);
			double result = 0;
			double.TryParse (dataSet [0] [i] [value].ToString(), out result);
			chart.DataSource.SetValue(dataSet [0] [i][key].ToString(), "test1", result);
		}
	}
}
